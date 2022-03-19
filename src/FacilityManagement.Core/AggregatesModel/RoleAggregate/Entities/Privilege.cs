using FacilityManagement.SharedKernel.Identity;

namespace FacilityManagement.Core
{
    public class Privilege
    {
        public PrivilegeId PrivilegeId { get; private set; } = new PrivilegeId(Guid.NewGuid());
        public RoleId RoleId { get; private set; }
        public AccessRight AccessRight { get; private set; }
        public string Aggregate { get; private set; }
        public Privilege(RoleId roleId, AccessRight accessRight, string aggregate)
        {
            RoleId = roleId;
            AccessRight = accessRight;
            Aggregate = aggregate;
        }

        public Privilege(AccessRight accessRight, string aggregate)
        {
            AccessRight = accessRight;
            Aggregate = aggregate;
        }

        private Privilege()
        {

        }
    }
}
