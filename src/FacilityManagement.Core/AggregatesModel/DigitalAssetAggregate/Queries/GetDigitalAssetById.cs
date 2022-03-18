using FacilityManagement.Core;
using FacilityManagement.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FacilityManagement.Core
{

    public class GetDigitalAssetByIdRequest: IRequest<GetDigitalAssetByIdResponse>
    {
        public Guid DigitalAssetId { get; set; }
    }
    public class GetDigitalAssetByIdResponse: ResponseBase
    {
        public DigitalAssetDto DigitalAsset { get; set; }
    }
    public class GetDigitalAssetByIdHandler: IRequestHandler<GetDigitalAssetByIdRequest, GetDigitalAssetByIdResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly ILogger<GetDigitalAssetByIdHandler> _logger;
    
        public GetDigitalAssetByIdHandler(IFacilityManagementDbContext context, ILogger<GetDigitalAssetByIdHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetDigitalAssetByIdResponse> Handle(GetDigitalAssetByIdRequest request, CancellationToken cancellationToken)
        {
            return new () {
                DigitalAsset = (await _context.DigitalAssets.AsNoTracking().SingleOrDefaultAsync(x => x.DigitalAssetId == new DigitalAssetId(request.DigitalAssetId))).ToDto()
            };
        }
        
    }

}
