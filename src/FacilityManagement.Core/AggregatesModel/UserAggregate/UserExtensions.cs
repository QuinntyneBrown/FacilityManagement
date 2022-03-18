using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace FacilityManagement.Core
{
    public static class UserExtensions
    {
        public static UserDto ToDto(this User user)
        {
            return new ()
            {
                UserId = user.UserId.Value,
                UserName = user.UserName,
                Password = user.Password,
                Salt = user.Salt,
                Roles = user.Roles,
                Profiles = user.Profiles,
            };
        }
        
        public static async Task<List<UserDto>> ToDtosAsync(this IQueryable<User> users, CancellationToken cancellationToken)
        {
            return await users.Select(x => x.ToDto()).ToListAsync(cancellationToken);
        }
        
        public static List<UserDto> ToDtos(this IEnumerable<User> users)
        {
            return users.Select(x => x.ToDto()).ToList();
        }
        
    }
}
