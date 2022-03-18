using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

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
