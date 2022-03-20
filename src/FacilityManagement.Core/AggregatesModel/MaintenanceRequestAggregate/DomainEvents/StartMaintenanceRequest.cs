using FacilityManagement.SharedKernel.Abstractions;

namespace FacilityManagement.Core
{
    public class StartMaintenanceRequest : BaseDomainEvent
    {
        public UnitEntered UnitEntered { get; set; }
        public DateTime WorkStarted { get; set; }

        public StartMaintenanceRequest(UnitEntered unitEntered, DateTime workStarted)
        {
            UnitEntered = unitEntered;
            WorkStarted = workStarted;
        }
    }
}
