using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace FacilityManagement.Core.Interfaces
{
    public interface IFacilityManagementDbContext
    {
        DbSet<MaintenanceRequest> MaintenanceRequests { get; }
        DbSet<Profile> Profiles { get; }
        DbSet<DigitalAsset> DigitalAssets { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
