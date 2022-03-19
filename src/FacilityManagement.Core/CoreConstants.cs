namespace FacilityManagement.Core
{
    public static class CoreConstants
    {
        public static class Aggregates
        {
            public const string MaintenanceRequest = nameof(MaintenanceRequest);
            public static List<string> All => new()
            {
                MaintenanceRequest
            };
        }
    }
}
