using Microsoft.EntityFrameworkCore;

namespace FacilityManagement.Core
{
    public static class MaintenanceRequestExtensions
    {
        public static MaintenanceRequestDto ToDto(this MaintenanceRequest maintenanceRequest)
        {
            return new ()
            {
                MaintenanceRequestId = maintenanceRequest.MaintenanceRequestId.Value,
                RequestedByProfileId = Guid.Parse(maintenanceRequest.RequestedByProfileId.ToString()),
                RequestedByName = maintenanceRequest.RequestedByName,
                Date = maintenanceRequest.Date,
                Address = maintenanceRequest.Address.ToDto(),
                Phone = maintenanceRequest.Phone,
                Description = maintenanceRequest.Description,
                UnattendedUnitEntryAllowed = maintenanceRequest.UnattendedUnitEntryAllowed,
                ReceivedByProfileId = Guid.Parse(maintenanceRequest.ReceivedByProfileId.ToString()),
                ReceivedByName = maintenanceRequest.ReceivedByName,
                ReceivedDate = maintenanceRequest.ReceivedDate,
                WorkDetails = maintenanceRequest.WorkDetails,
                WorkStarted = maintenanceRequest.WorkStarted,
                WorkCompleted = maintenanceRequest.WorkCompleted,
                WorkCompletedByName = maintenanceRequest.WorkCompletedByName,
                UnitEntered = maintenanceRequest.UnitEntered,
                RequestedByProfile = maintenanceRequest.RequestedByProfile?.ToDto(),
                Status = maintenanceRequest.Status,
                Comments = maintenanceRequest.Comments.ToDtos(),
                DigitalAssets = maintenanceRequest.DigitalAssets.ToDtos(),
            };
        }
        
        public static async Task<List<MaintenanceRequestDto>> ToDtosAsync(this IQueryable<MaintenanceRequest> maintenanceRequests, CancellationToken cancellationToken)
        {
            return await maintenanceRequests.Select(x => x.ToDto()).ToListAsync(cancellationToken);
        }
        
        public static List<MaintenanceRequestDto> ToDtos(this IEnumerable<MaintenanceRequest> maintenanceRequests)
        {
            return maintenanceRequests.Select(x => x.ToDto()).ToList();
        }
        
        public static MaintenanceRequestCommentDto ToDto(this MaintenanceRequestComment maintenanceRequestComment)
        {
            return new MaintenanceRequestCommentDto
            {

            };
        }

        public static MaintenanceRequestDigitalAssetDto ToDto(this MaintenanceRequestDigitalAsset maintenanceRequestDigitalAsset)
        {
            return new MaintenanceRequestDigitalAssetDto
            {

            };
        }

        public static List<MaintenanceRequestCommentDto> ToDtos(this IEnumerable<MaintenanceRequestComment> maintenanceRequestComments)
        {
            return maintenanceRequestComments.Select(x => x.ToDto()).ToList();
        }

        public static List<MaintenanceRequestDigitalAssetDto> ToDtos(this IEnumerable<MaintenanceRequestDigitalAsset> maintenanceRequestDigitalAssets)
        {
            return maintenanceRequestDigitalAssets.Select(x => x.ToDto()).ToList();
        }
    }
}
