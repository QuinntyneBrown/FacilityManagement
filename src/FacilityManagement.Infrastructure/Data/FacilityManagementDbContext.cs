using FacilityManagement.Core;
using FacilityManagement.Core.Interfaces;
using FacilityManagement.SharedKernel.Abstractions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FacilityManagement.Infrastructure.Data
{
    public class FacilityManagementDbContext: DbContext, IFacilityManagementDbContext
    {
        public DbSet<MaintenanceRequest> MaintenanceRequests { get; private set; }
        public DbSet<Profile> Profiles { get; private set; }
        public DbSet<DigitalAsset> DigitalAssets { get; private set; }
        public DbSet<User> Users { get; private set; }
        public DbSet<Role> Roles { get; private set; }
        public DbSet<StoredEvent> StoredEvents { get; private set; }

        public FacilityManagementDbContext(DbContextOptions options)
            :base(options) {
            SavingChanges += DbContext_SavingChanges;
            SavedChanges += DbContext_SavedChanges;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FacilityManagementDbContext).Assembly);
        }

        private void DbContext_SavingChanges(object sender, SavingChangesEventArgs e)
        {
            var entries = ChangeTracker.Entries<AggregateRoot>()
                .Where(
                    e => e.State == EntityState.Added ||
                    e.State == EntityState.Modified)
                .Select(e => e.Entity)
                .ToList();

            foreach (var aggregate in entries)
            {
                foreach (var storedEvent in aggregate.StoredEvents)
                {
                    StoredEvents.Add(storedEvent);
                }
            }
        }

        private void DbContext_SavedChanges(object sender, SavedChangesEventArgs e)
        {
            var entries = ChangeTracker.Entries<AggregateRoot>()
                .Select(e => e.Entity)
                .ToList();

            foreach (var aggregate in entries)
            {
                foreach (var storedEvent in aggregate.StoredEvents)
                {
                    var @event = JsonConvert.DeserializeObject(storedEvent.Data, Type.GetType(storedEvent.DotNetType));

                    // send notification
                }

                aggregate.Clear();
            }
        }

        public override void Dispose()
        {
            SavingChanges -= DbContext_SavingChanges;
            base.Dispose();
        }

        public override ValueTask DisposeAsync()
        {
            SavingChanges -= DbContext_SavingChanges;
            return base.DisposeAsync();
        }
    }
}
