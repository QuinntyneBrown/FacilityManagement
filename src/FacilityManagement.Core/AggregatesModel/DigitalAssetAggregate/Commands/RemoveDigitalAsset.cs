using FacilityManagement.Core;
using FacilityManagement.Core.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FacilityManagement.Core
{

    public class RemoveDigitalAssetRequest: IRequest<RemoveDigitalAssetResponse>
    {
        public Guid DigitalAssetId { get; set; }
    }
    public class RemoveDigitalAssetResponse: ResponseBase
    {
        public DigitalAssetDto DigitalAsset { get; set; }
    }
    public class RemoveDigitalAssetHandler: IRequestHandler<RemoveDigitalAssetRequest, RemoveDigitalAssetResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly ILogger<RemoveDigitalAssetHandler> _logger;
    
        public RemoveDigitalAssetHandler(IFacilityManagementDbContext context, ILogger<RemoveDigitalAssetHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<RemoveDigitalAssetResponse> Handle(RemoveDigitalAssetRequest request, CancellationToken cancellationToken)
        {
            var digitalAsset = await _context.DigitalAssets.FindAsync(new DigitalAssetId(request.DigitalAssetId));
            
            _context.DigitalAssets.Remove(digitalAsset);
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                DigitalAsset = digitalAsset.ToDto()
            };
        }
        
    }

}
