using FacilityManagement.SharedKernel.Abstractions;

namespace FacilityManagement.Core
{
    public class AuthenticatedUser : BaseDomainEvent
    {
        public AuthenticatedUser(string username)
        {
            Username = username;
        }
        public string Username { get; private set; }
    }
}