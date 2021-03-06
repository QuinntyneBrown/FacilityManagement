using FacilityManagement.SharedKernel.Abstractions;
using FacilityManagement.SharedKernel.Identity;

namespace FacilityManagement.Core
{
    public class User : AggregateRoot
    {
        public UserId UserId { get; private set; } = new UserId(Guid.NewGuid());
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public byte[] Salt { get; private set; }
        public List<Profile> Profiles { get; private set; } = new();
        public List<Role> Roles { get; set; } = new();
        public User(CreateUser @event)
        {
            Apply(@event);

        }

        private User()
        {

        }


        public User ChangePassword(string oldPassword, string newPassword, IPasswordHasher passwordHasher)
        {
            if (Password != passwordHasher.HashPassword(Salt, oldPassword))
            {
                throw new Exception("Old password is invalid");
            }

            var newPasswordHash = passwordHasher.HashPassword(Salt, newPassword);

            if (Password == newPassword)
            {
                throw new Exception("Changed password is equal to old password");
            }

            Password = newPasswordHash;

            return this;
        }

        public User SetPassword(string password, IPasswordHasher passwordHasher)
        {
            Password = passwordHasher.HashPassword(Salt, password);

            return this;
        }

        public User SetUsername(string username)
        {
            UserName = username;

            return this;
        }

        protected override void When(dynamic @event) => When(@event);

        private void When(CreateUser @event)
        {
            UserId = new UserId(@event.UserId);
            Salt = @event.Salt;
            Password = @event.Password;
            UserName = @event.Username;
        }

        protected override void EnsureValidState()
        {

        }
    }
}