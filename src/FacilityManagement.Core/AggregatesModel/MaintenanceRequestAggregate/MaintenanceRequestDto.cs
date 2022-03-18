namespace FacilityManagement.Core
{
    public class MaintenanceRequestDto
    {
        public Guid? MaintenanceRequestId { get; set; }
        public Guid? RequestedByProfileId { get; set; }
        public string? RequestedByName { get; set; }
        public DateTime Date { get; set; }
        public AddressDto? Address { get; set; }
        public string? Phone { get; set; }
        public string? Description { get; set; }
        public bool? UnattendedUnitEntryAllowed { get; set; }
        public Guid? ReceivedByProfileId { get; set; }
        public string? ReceivedByName { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string? WorkDetails { get; set; }
        public DateTime WorkStarted { get; set; }
        public DateTime WorkCompleted { get; set; }
        public string? WorkCompletedByName { get; set; }
        public UnitEntered UnitEntered { get; set; }
        public ProfileDto? RequestedByProfile { get; set; }
        public MaintenanceRequestStatus Status { get; set; }
        public List<MaintenanceRequestCommentDto> Comments { get; set; } = new();
        public List<MaintenanceRequestDigitalAssetDto> DigitalAssets { get; set; } = new();
    }
}
