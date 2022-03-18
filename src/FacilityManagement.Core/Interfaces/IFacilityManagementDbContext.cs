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
        DbSet<User> Users { get; }
        DbSet<Role> Roles { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
