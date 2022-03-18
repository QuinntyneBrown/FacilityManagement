using FacilityManagement.Core;
using FacilityManagement.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace FacilityManagement.Infrastructure.Data
{
    public class FacilityManagementDbContext: DbContext, IFacilityManagementDbContext
    {
        public DbSet<MaintenanceRequest> MaintenanceRequests { get; private set; }
        public DbSet<Profile> Profiles { get; private set; }
        public DbSet<DigitalAsset> DigitalAssets { get; private set; }
        public FacilityManagementDbContext(DbContextOptions options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FacilityManagementDbContext).Assembly);
        }
        
    }
}
