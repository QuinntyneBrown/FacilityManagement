using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FacilityManagement.Core;

namespace FacilityManagement.Infrastructure.EntityConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(e => e.RoleId).HasConversion(new RoleId.EfCoreValueConverter());
        }
    }
}
