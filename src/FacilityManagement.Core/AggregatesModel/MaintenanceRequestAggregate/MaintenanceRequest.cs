using FacilityManagement.SharedKernel.Abstractions;

namespace FacilityManagement.Core
{
    public class MaintenanceRequest: AggregateRoot
    {
        public MaintenanceRequestId MaintenanceRequestId { get; set; }  = new MaintenanceRequestId(Guid.NewGuid());
        public ProfileId RequestedByProfileId { get; set; }
        public string? RequestedByName { get; set; }
        public DateTime Date { get; set; }
        public Address? Address { get; set; }
        public string? Phone { get; set; }
        public string? Description { get; set; }
        public bool UnattendedUnitEntryAllowed { get; set; }
        public ProfileId ReceivedByProfileId { get; set; }
        public string? ReceivedByName { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string? WorkDetails { get; set; }
        public DateTime WorkStarted { get; set; }
        public DateTime WorkCompleted { get; set; }
        public string? WorkCompletedByName { get; set; }
        public UnitEntered UnitEntered { get; set; }
        public Profile? RequestedByProfile { get; set; }
        public MaintenanceRequestStatus Status { get; set; }
        public List<MaintenanceRequestComment> Comments { get; set; } = new();
        public List<MaintenanceRequestDigitalAsset> DigitalAssets { get; set; } = new();

        private MaintenanceRequest()
        {

        }
        protected override void EnsureValidState()
        {

        }

        protected override void When(dynamic @event) => When(@event);

        public MaintenanceRequest(CreateMaintenanceRequest createMaintenanceRequest)
        {
            MaintenanceRequestId = new MaintenanceRequestId(createMaintenanceRequest.MaintenanceRequestId);
            RequestedByProfileId = new ProfileId(createMaintenanceRequest.RequestedByProfileId);
            RequestedByName = createMaintenanceRequest.RequestedByName;
            Address = createMaintenanceRequest.Address;
            Phone = createMaintenanceRequest.Phone;
            Description = createMaintenanceRequest.Description;
            UnattendedUnitEntryAllowed = createMaintenanceRequest.UnattendedUnitEntryAllowed;
            Date = createMaintenanceRequest.Created;
        }

        public void When(UpdateMaintenanceRequestDescription updateMaintenanceRequestDescription)
        {
            Description = updateMaintenanceRequestDescription.Description;
        }

        public void When(UpdateMaintenanceRequest @event)
        {
            Address = @event.Address;
            Phone = @event.Phone;
            Description = @event.Description;
            UnattendedUnitEntryAllowed = @event.UnattendedUnitEntryAllowed;
        }

        public void When(ReceiveMaintenanceRequest @event)
        {
            ReceivedByName = @event.ReceivedByName;
            ReceivedByProfileId = new ProfileId(@event.ReceivedByProfileId);
            Status = MaintenanceRequestStatus.Received;
        }

        public void When(StartMaintenanceRequest @event)
        {
            UnitEntered = @event.UnitEntered;
            WorkStarted = @event.WorkStarted;
            Status = MaintenanceRequestStatus.Started;
        }

        public void When(UpdateMaintenanceRequestWorkDetails @event)
        {
            WorkDetails = @event.WorkDetails;
        }

        public void When(CompleteMaintenanceRequest @event)
        {
            WorkCompleted = @event.WorkCompleted;
            WorkCompletedByName = @event.WorkCompletedByName;
            Status = MaintenanceRequestStatus.Completed;
        }
    }
}
