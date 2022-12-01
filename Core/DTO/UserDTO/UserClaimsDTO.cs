using System.Security.Claims;

namespace Core.DTO.UserDTO;

public class UserClaimsDTO
{
    public ClaimsPrincipal Principal { get; set; }
}