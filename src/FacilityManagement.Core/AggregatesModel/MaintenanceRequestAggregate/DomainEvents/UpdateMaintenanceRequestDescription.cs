namespace FacilityManagement.Core
{
    public class UpdateMaintenanceRequestDescription
    {
        public string Description { get; set; }
        public UpdateMaintenanceRequestDescription(string description)
        {
            Description = description;
        }
    }
}
