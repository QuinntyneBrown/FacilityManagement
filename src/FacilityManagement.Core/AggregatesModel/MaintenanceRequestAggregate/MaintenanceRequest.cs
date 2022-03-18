namespace FacilityManagement.Core
{
    public class MaintenanceRequest
    {
        public MaintenanceRequestId MaintenanceRequestId { get; set; }  = new MaintenanceRequestId(Guid.NewGuid());
        public ProfileId RequestedByProfileId { get; set; }
        public string RequestedByName { get; set; }
        public DateTime Date { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public bool UnattendedUnitEntryAllowed { get; set; }
        public ProfileId ReceivedByProfileId { get; set; }
        public string ReceivedByName { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string WorkDetails { get; set; }
        public DateTime WorkStarted { get; set; }
        public DateTime WorkCompleted { get; set; }
        public string WorkCompletedByName { get; set; }
        public UnitEntered UnitEntered { get; set; }
        public Profile RequestedByProfile { get; set; }
        public MaintenanceRequestStatus Status { get; set; }
        public List<MaintenanceRequestComment> Comments { get; set; }
        public List<MaintenanceRequestDigitalAsset> DigitalAssets { get; set; }
    }
}
