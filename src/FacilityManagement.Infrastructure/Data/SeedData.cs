using FacilityManagement.Core;
using FacilityManagement.SharedKernel.Identity;

namespace FacilityManagement.Infrastructure.Data
{
    public static class SeedData
    {
        public static void Seed(FacilityManagementDbContext context)
        {
            UserConfiguration.Seed(context);
        }
    }

    internal static class UserConfiguration
    {
        public static void Seed(FacilityManagementDbContext context)
        {            
            var users = new List<User>() { 
                _createStaff("Quinntyne","Brown"),
                _createTenant("Olivia","Brown"),
            };

            foreach(var user in users)
            {                
                context.Users.Add(user);
            }

            context.SaveChanges();

            User _createStaff(string firstName, string lastName) => _create(firstName, lastName, ProfileType.Staff);

            User _createTenant(string firstName, string lastName) => _create(firstName, lastName, ProfileType.Tenant);

            User _create(string firstName, string lastName, ProfileType profileType)
            {
                var passwordHasher = new PasswordHasher();

                var user = new User(new CreateUser(firstName, "P@ssw0rd", passwordHasher));

                var profile = new Profile(firstName, lastName, profileType);

                user.Profiles.Add(profile);

                return user;
            }
        }
    }
}
