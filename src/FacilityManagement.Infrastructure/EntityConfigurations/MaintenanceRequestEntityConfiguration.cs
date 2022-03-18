using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FacilityManagement.Core;

namespace FacilityManagement.Infrastructure.EntityConfigurations
{
    public class MaintenanceRequestConfiguration : IEntityTypeConfiguration<MaintenanceRequest>
    {
        public void Configure(EntityTypeBuilder<MaintenanceRequest> builder)
        {
            builder.Property(e => e.MaintenanceRequestId).HasConversion(new MaintenanceRequestId.EfCoreValueConverter());
        }
    }
}
