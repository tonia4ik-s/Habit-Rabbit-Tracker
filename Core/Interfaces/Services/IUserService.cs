using System.Security.Claims;
using System.Threading.Tasks;
using UpdateUserDTO = Core.DTO.UserDTO.UpdateUserDTO;
using UserDTO = Core.DTO.UserDTO.UserDTO;

namespace Core.Interfaces.Services;

public interface IUserService
{
    UserDTO GetUserByName(string userName);
    Task UpdateUserInfo(UpdateUserDTO updateUserDto);
    Task DeleteUser(string userName);
        
}