using UserDTO = Core.DTO.UserDTO.UserDTO;
using UserLoginDTO = Core.DTO.UserDTO.UserLoginDTO;
using UserRegistrationDTO = Core.DTO.UserDTO.UserRegistrationDTO;

namespace Core.Interfaces.Services;

public interface IAuthorizationService
{
    Task<string> LoginAsync(UserLoginDTO userLogin);
    Task<string> RegisterAsync(UserRegistrationDTO userRegistrationDto);
    Task<UserDTO> GetUserByJwt(string jwtToken);
}