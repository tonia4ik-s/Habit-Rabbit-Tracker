using Microsoft.AspNetCore.Mvc;
using Core.DTO.UserDTO;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : Controller
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(
        IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] UserRegistrationDTO data)
    {
        var tokens = await _authenticationService.RegisterAsync(data);
        return Ok(tokens);
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] UserLoginDTO data)
    {
        var tokens = await _authenticationService.LoginAsync(data);
        return Ok(tokens);
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshTokenAsync([FromBody] UserAuthorizationDTO userTokensDTO)
    {
        var tokens = await _authenticationService.RefreshTokenAsync(userTokensDTO);
        return Ok(tokens);
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> LogoutAsync([FromBody] UserLogoutDTO userLogoutDTO)
    {
        await _authenticationService.LogoutAsync(userLogoutDTO);
        return Ok();
    }
}
