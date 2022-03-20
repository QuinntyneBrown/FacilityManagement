namespace FacilityManagement.Core
{
    public class UpdateMaintenanceRequestWorkDetails
    {
        public string WorkDetails { get; set; }
        public UpdateMaintenanceRequestWorkDetails(string workDetails)
        {
            WorkDetails = workDetails;
        }
    }
}
