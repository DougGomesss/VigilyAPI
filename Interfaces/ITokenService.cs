using System.Security.Claims;
using VigilyAPI.Models;

namespace VigilyAPI.Interfaces;

public interface ITokenService
{
    string GenerateAccessToken(IEnumerable<Claim> claims, IConfiguration config);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token, IConfiguration configuration);
}
