using FacilityManagement.SharedKernel.Abstractions;

namespace FacilityManagement.Core
{
    public class BuildToken : BaseDomainEvent
    {
        public BuildToken(string username)
        {
            Username = username;
        }
        public string Username { get; private set; }
    }
}