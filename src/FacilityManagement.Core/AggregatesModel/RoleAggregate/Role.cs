namespace FacilityManagement.Core
{
    public class Role
    {
        public RoleId RoleId { get; set; }  = new RoleId(Guid.NewGuid());
        public string Name { get; set; }
        public List<Privilege> Privileges { get; private set; } = new();
    }
}
