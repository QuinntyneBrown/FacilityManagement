using System.Security.Claims;

namespace FacilityManagement.SharedKernel.Identity
{
    public interface ITokenProvider
    {
        string Get(string username, IEnumerable<Claim> customClaims = null);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        string GenerateRefreshToken();
    }
}