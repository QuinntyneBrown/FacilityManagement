using System.Security.Claims;

namespace FacilityManagement.SharedKernel.Identity
{
    public interface ITokenBuilder
    {
        TokenBuilder AddOrUpdateClaim(Claim claim);
        TokenBuilder AddClaim(Claim claim);
        TokenBuilder AddUsername(string username);
        string Build();
        TokenBuilder FromClaimsPrincipal(ClaimsPrincipal claimsPrincipal);
        TokenBuilder RemoveClaim(Claim claim);
    }
}
