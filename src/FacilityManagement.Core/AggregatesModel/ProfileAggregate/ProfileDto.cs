using System;

namespace FacilityManagement.Core
{
    public class ProfileDto
    {
        public Guid? ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
