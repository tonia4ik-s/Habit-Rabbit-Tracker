using System.Net;
using System.Text;
using AutoMapper;
using Core.DTO.UserDTO;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace Core.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly IJwtService _jwtService;
    private readonly IRepository<RefreshToken> _refreshTokenRepository;

    public AuthenticationService(
        UserManager<User> userManager,
        IMapper mapper,
        IJwtService jwtService,
        IRepository<RefreshToken> refreshTokenRepository)
    {
        _userManager = userManager;
        _mapper = mapper;
        _jwtService = jwtService;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<UserAuthorizationDTO> RegisterAsync(UserRegistrationDTO userData)
    {
        var user = _mapper.Map<User>(userData);
        var result = await _userManager.CreateAsync(user, userData.Password);
        if (!result.Succeeded)
        {
            var messageBuilder = new StringBuilder();
            foreach (var error in result.Errors)
            {
                messageBuilder.AppendLine(error.Description);
            }

            throw new HttpException(messageBuilder.ToString(), HttpStatusCode.BadRequest);
        }

        var loginDTO = new UserLoginDTO
        {
            Email = user.Email,
            Password = userData.Password
        };
        return await LoginAsync(loginDTO);
    }

    public async Task<UserAuthorizationDTO> LoginAsync(UserLoginDTO data)
    {
        var user = await _userManager.FindByEmailAsync(data.Email) ??
                   await _userManager.FindByNameAsync(data.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, data.Password))
        {
            throw new HttpException("Incorrect login or password", HttpStatusCode.Unauthorized);
        }

        return await GenerateUserTokens(user);
    }

    public async Task LogoutAsync(UserLogoutDTO userLogoutDTO)
    {
        var refreshToken = _refreshTokenRepository.Query().SingleOrDefault(t => t.Token == userLogoutDTO.RefreshToken);
        if (refreshToken == null)
        {
            throw new HttpException("Invalid Token", HttpStatusCode.NotFound);
        }

        await _refreshTokenRepository.DeleteAsync(refreshToken);
        await _refreshTokenRepository.SaveChangesAsync();
    }

    private async Task<UserAuthorizationDTO> GenerateUserTokens(User user)
    {
        var claims = _jwtService.SetClaims(user);
        var token = _jwtService.CreateToken(claims);
        var refreshToken = await CreateRefreshToken(user.Id);
        user.RefreshTokens.Add(refreshToken);
        var tokens = new UserAuthorizationDTO
        {
            AccessToken = token,
            RefreshToken = refreshToken.Token
        };
        return tokens;
    }

    private async Task<RefreshToken> CreateRefreshToken(string userId)
    {
        var refreshToken = _jwtService.GenerateRefreshToken();
        var refreshTokenEntity = new RefreshToken
        {
            Token = refreshToken,
            UserId = userId
        };
        await _refreshTokenRepository.AddAsync(refreshTokenEntity);
        await _refreshTokenRepository.SaveChangesAsync();
        return refreshTokenEntity;
    }

    public async Task<UserAuthorizationDTO> RefreshTokenAsync(UserAuthorizationDTO userTokensDTO)
    {
        var refreshToken = GetRefreshToken(userTokensDTO.RefreshToken);
        var claims = _jwtService.GetClaimsFromExpiredToken(userTokensDTO.AccessToken);
        var newToken = _jwtService.CreateToken(claims);
        var newRefreshToken = _jwtService.GenerateRefreshToken();
        refreshToken.Token = newRefreshToken;
        await _refreshTokenRepository.UpdateAsync(refreshToken);
        await _refreshTokenRepository.SaveChangesAsync();
        var tokens = new UserAuthorizationDTO
        {
            AccessToken = newToken,
            RefreshToken = refreshToken.Token
        };
        return tokens;
    }

    private RefreshToken GetRefreshToken(string token)
    {
        var refreshToken = _refreshTokenRepository
            .Query()
            .FirstOrDefault(t => t.Token == token);

        if (refreshToken == null)
        {
            throw new HttpException("Invalid Token", HttpStatusCode.NotFound);
        }

        return refreshToken;
    }
}