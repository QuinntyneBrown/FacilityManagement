using FacilityManagement.Core;
using FacilityManagement.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FacilityManagement.Core
{

    public class GetDigitalAssetsRequest: IRequest<GetDigitalAssetsResponse> { }
    public class GetDigitalAssetsResponse: ResponseBase
    {
        public List<DigitalAssetDto> DigitalAssets { get; set; }
    }
    public class GetDigitalAssetsHandler: IRequestHandler<GetDigitalAssetsRequest, GetDigitalAssetsResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly ILogger<GetDigitalAssetsHandler> _logger;
    
        public GetDigitalAssetsHandler(IFacilityManagementDbContext context, ILogger<GetDigitalAssetsHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetDigitalAssetsResponse> Handle(GetDigitalAssetsRequest request, CancellationToken cancellationToken)
        {
            return new () {
                DigitalAssets = await _context.DigitalAssets.AsNoTracking().ToDtosAsync(cancellationToken)
            };
        }
        
    }

}
