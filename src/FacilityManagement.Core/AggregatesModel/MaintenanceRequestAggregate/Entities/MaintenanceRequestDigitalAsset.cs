using Microsoft.EntityFrameworkCore;

namespace FacilityManagement.Core
{
    [Owned]
    public class MaintenanceRequestDigitalAsset
    {
        public MaintenanceRequestId MaintenanceRequestId { get; private set; }
        public DigitalAssetId DigitalAssetId { get; private set; }

        public MaintenanceRequestDigitalAsset(MaintenanceRequestId maintenanceRequestId, DigitalAssetId digitalAssetId)
        {
            MaintenanceRequestId = maintenanceRequestId;
            DigitalAssetId = digitalAssetId;
        }

        public MaintenanceRequestDigitalAsset(DigitalAssetId digitalAssetId)
        {
            DigitalAssetId = digitalAssetId;
        }

        private MaintenanceRequestDigitalAsset()
        {

        }
    }
    }
