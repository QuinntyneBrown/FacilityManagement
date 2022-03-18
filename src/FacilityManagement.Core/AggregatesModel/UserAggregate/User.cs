using System;

namespace FacilityManagement.Core
{
    public class User
    {
        public UserId UserId { get; set; }  = new UserId(Guid.NewGuid());
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public List<Role> Roles { get; set; }
        public List<Profile> Profiles { get; set; }
    }
}
