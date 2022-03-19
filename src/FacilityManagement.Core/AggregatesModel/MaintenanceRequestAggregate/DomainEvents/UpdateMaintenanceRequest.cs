namespace FacilityManagement.Core
{
    public class UpdateMaintenanceRequest
    {
        public Guid RequestedByProfileId { get; set; }
        public string RequestedByName { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public bool UnattendedUnitEntryAllowed { get; set; }
    }
}
