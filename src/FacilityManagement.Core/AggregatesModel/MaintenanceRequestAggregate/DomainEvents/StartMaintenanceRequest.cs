using FacilityManagement.SharedKernel.Abstractions;

namespace FacilityManagement.Core
{
    public class StartMaintenanceRequest : BaseDomainEvent
    {
        public UnitEntered UnitEntered { get; set; }
        public DateTime WorkStarted { get; set; }
    }
}
