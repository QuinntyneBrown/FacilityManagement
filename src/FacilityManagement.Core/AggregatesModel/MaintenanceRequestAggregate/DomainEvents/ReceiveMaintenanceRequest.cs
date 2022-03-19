namespace FacilityManagement.Core
{
    public class ReceiveMaintenanceRequest
    {
        public string ReceivedByName { get; init; }
        public Guid ReceivedByProfileId { get; init; }
        public ReceiveMaintenanceRequest(string receivedByName, Guid receivedByProfileId)
        {
            ReceivedByName = receivedByName;
            ReceivedByProfileId = receivedByProfileId;
        }
        private ReceiveMaintenanceRequest()
        {

        }
    }
}
