using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace FacilityManagement.Core
{
    public static class DigitalAssetExtensions
    {
        public static DigitalAssetDto ToDto(this DigitalAsset digitalAsset)
        {
            return new ()
            {
                DigitalAssetId = digitalAsset.DigitalAssetId.Value,
                Name = digitalAsset.Name,
                Bytes = digitalAsset.Bytes,
                ContentType = digitalAsset.ContentType,
                Height = digitalAsset.Height,
                Width = digitalAsset.Width,
            };
        }
        
        public static async Task<List<DigitalAssetDto>> ToDtosAsync(this IQueryable<DigitalAsset> digitalAssets, CancellationToken cancellationToken)
        {
            return await digitalAssets.Select(x => x.ToDto()).ToListAsync(cancellationToken);
        }
        
        public static List<DigitalAssetDto> ToDtos(this IEnumerable<DigitalAsset> digitalAssets)
        {
            return digitalAssets.Select(x => x.ToDto()).ToList();
        }
        
    }
}
