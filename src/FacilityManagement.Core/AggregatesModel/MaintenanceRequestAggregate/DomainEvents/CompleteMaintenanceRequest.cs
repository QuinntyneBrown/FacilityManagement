using FacilityManagement.SharedKernel.Abstractions;

namespace FacilityManagement.Core
{
    public class CompleteMaintenanceRequest: BaseDomainEvent
    {
        public string? WorkCompletedByName { get; set; }
        public DateTime WorkCompleted { get; set; }
        public CompleteMaintenanceRequest(string? workCompletedByName, DateTime workCompleted)
        {
            WorkCompletedByName = workCompletedByName;
            WorkCompleted = workCompleted;
        }
    }
}
