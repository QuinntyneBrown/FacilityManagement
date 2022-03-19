using Microsoft.EntityFrameworkCore;

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
                Roles = user.Roles.ToDtos(),
                Profiles = user.Profiles.ToDtos(),
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
