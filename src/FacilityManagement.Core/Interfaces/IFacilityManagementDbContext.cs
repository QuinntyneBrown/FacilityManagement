using FacilityManagement.SharedKernel.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FacilityManagement.Core.Interfaces
{
    public interface IFacilityManagementDbContext
    {
        DbSet<MaintenanceRequest> MaintenanceRequests { get; }
        DbSet<Profile> Profiles { get; }
        DbSet<DigitalAsset> DigitalAssets { get; }
        DbSet<User> Users { get; }
        DbSet<Role> Roles { get; }
        DbSet<StoredEvent> StoredEvents { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
