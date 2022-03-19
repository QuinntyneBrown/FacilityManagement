using Microsoft.EntityFrameworkCore;

namespace FacilityManagement.Core
{
    public static class ProfileExtensions
    {
        public static ProfileDto ToDto(this Profile profile)
        {
            return new ()
            {
                ProfileId = profile.ProfileId.Value,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                ProfileType = profile.ProfileType
            };
        }
        
        public static async Task<List<ProfileDto>> ToDtosAsync(this IQueryable<Profile> profiles, CancellationToken cancellationToken)
        {
            return await profiles.Select(x => x.ToDto()).ToListAsync(cancellationToken);
        }
        
        public static List<ProfileDto> ToDtos(this IEnumerable<Profile> profiles)
        {
            return profiles.Select(x => x.ToDto()).ToList();
        }
        
    }
}
