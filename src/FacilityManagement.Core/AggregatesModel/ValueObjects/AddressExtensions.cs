using Microsoft.EntityFrameworkCore;

namespace FacilityManagement.Core
{
    public static class AddressExtensions
    {
        public static AddressDto ToDto(this Address digitalAsset)
        {
            return new()
            {
                Street = digitalAsset.Street,
                Unit = digitalAsset.Unit,
                City = digitalAsset.City,
                PostalCode = digitalAsset.PostalCode,
                Province = digitalAsset.Province,
            };
        }

        public static async Task<List<AddressDto>> ToDtosAsync(this IQueryable<Address> addresses, CancellationToken cancellationToken)
        {
            return await addresses.Select(x => x.ToDto()).ToListAsync(cancellationToken);
        }

        public static List<AddressDto> ToDtos(this IEnumerable<Address> addresses)
        {
            return addresses.Select(x => x.ToDto()).ToList();
        }

    }
}
