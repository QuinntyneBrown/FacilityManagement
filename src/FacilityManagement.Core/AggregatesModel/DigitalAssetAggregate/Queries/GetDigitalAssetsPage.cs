using FacilityManagement.Core;
using FacilityManagement.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FacilityManagement.Core
{

    public class GetDigitalAssetsPageRequest: IRequest<GetDigitalAssetsPageResponse>
    {
        public int PageSize { get; set; }
        public int Index { get; set; }
    }
    public class GetDigitalAssetsPageResponse: ResponseBase
    {
        public int Length { get; set; }
        public List<DigitalAssetDto> Entities { get; set; }
    }
    public class GetDigitalAssetsPageHandler: IRequestHandler<GetDigitalAssetsPageRequest, GetDigitalAssetsPageResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly ILogger<GetDigitalAssetsPageHandler> _logger;
    
        public GetDigitalAssetsPageHandler(IFacilityManagementDbContext context, ILogger<GetDigitalAssetsPageHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetDigitalAssetsPageResponse> Handle(GetDigitalAssetsPageRequest request, CancellationToken cancellationToken)
        {
            var query = from digitalAsset in _context.DigitalAssets
                select digitalAsset;
            
            var length = await _context.DigitalAssets.AsNoTracking().CountAsync();
            
            var digitalAssets = await query.Page(request.Index, request.PageSize).AsNoTracking()
                .Select(x => x.ToDto()).ToListAsync();
            
            return new ()
            {
                Length = length,
                Entities = digitalAssets
            };
        }
        
    }

}
