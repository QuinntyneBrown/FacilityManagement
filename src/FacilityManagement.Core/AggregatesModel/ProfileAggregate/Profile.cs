namespace FacilityManagement.Core
{
    public class Profile
    {
        public ProfileId ProfileId { get; set; }  = new ProfileId(Guid.NewGuid());
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ProfileType ProfileType { get; set; }

        public Profile(string firstName, string lastName, ProfileType profileType)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileType = profileType;
        }

        private Profile()
        {

        }

        public void Update(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
