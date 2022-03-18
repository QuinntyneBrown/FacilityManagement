using System;

namespace FacilityManagement.Core
{
    public class Profile
    {
        public ProfileId ProfileId { get; set; }  = new ProfileId(Guid.NewGuid());
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
