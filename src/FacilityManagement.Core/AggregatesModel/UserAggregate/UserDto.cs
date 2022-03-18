using System;

namespace FacilityManagement.Core
{
    public class UserDto
    {
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public List<Role> Roles { get; set; }
        public List<Profile> Profiles { get; set; }
    }
}
