using StronglyTypedIds;

namespace FacilityManagement.Core
{
    [StronglyTypedId(backingType: StronglyTypedIdBackingType.Guid, converters: StronglyTypedIdConverter.EfCoreValueConverter)]
    public partial struct DigitalAssetId { }
}
