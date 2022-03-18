using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FacilityManagement.Core;

namespace FacilityManagement.Infrastructure.EntityConfigurations
{
    public class DigitalAssetConfiguration : IEntityTypeConfiguration<DigitalAsset>
    {
        public void Configure(EntityTypeBuilder<DigitalAsset> builder)
        {
            builder.Property(e => e.DigitalAssetId).HasConversion(new DigitalAssetId.EfCoreValueConverter());
        }
    }
}
