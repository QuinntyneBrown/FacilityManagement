using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FacilityManagement.Core;

namespace FacilityManagement.Infrastructure.EntityConfigurations
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.Property(e => e.ProfileId).HasConversion(new ProfileId.EfCoreValueConverter());
        }
    }
}
