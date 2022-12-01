using System.Security.Claims;
using Core.Entities;

namespace Core.Interfaces.Services;

public interface IJwtService
{
    IEnumerable<Claim> SetClaims(User user);
    string CreateToken(IEnumerable<Claim> claims);
    string GenerateRefreshToken();
    public IEnumerable<Claim> GetClaimsFromExpiredToken(string token);
}