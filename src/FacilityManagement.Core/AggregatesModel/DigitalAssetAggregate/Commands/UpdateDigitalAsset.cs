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

    public class UpdateDigitalAssetValidator: AbstractValidator<UpdateDigitalAssetRequest>
    {
        public UpdateDigitalAssetValidator()
        {
            RuleFor(request => request.DigitalAsset).NotNull();
            RuleFor(request => request.DigitalAsset).SetValidator(new DigitalAssetValidator());
        }
    
    }
    public class UpdateDigitalAssetRequest: IRequest<UpdateDigitalAssetResponse>
    {
        public DigitalAssetDto DigitalAsset { get; set; }
    }
    public class UpdateDigitalAssetResponse: ResponseBase
    {
        public DigitalAssetDto DigitalAsset { get; set; }
    }
    public class UpdateDigitalAssetHandler: IRequestHandler<UpdateDigitalAssetRequest, UpdateDigitalAssetResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly ILogger<UpdateDigitalAssetHandler> _logger;
    
        public UpdateDigitalAssetHandler(IFacilityManagementDbContext context, ILogger<UpdateDigitalAssetHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<UpdateDigitalAssetResponse> Handle(UpdateDigitalAssetRequest request, CancellationToken cancellationToken)
        {
            var digitalAsset = await _context.DigitalAssets.SingleAsync(x => x.DigitalAssetId == new DigitalAssetId(request.DigitalAsset.DigitalAssetId.Value));
            
            digitalAsset.Name = request.DigitalAsset.Name;
            digitalAsset.Bytes = request.DigitalAsset.Bytes;
            digitalAsset.ContentType = request.DigitalAsset.ContentType;
            digitalAsset.Height = request.DigitalAsset.Height;
            digitalAsset.Width = request.DigitalAsset.Width;
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                DigitalAsset = digitalAsset.ToDto()
            };
        }
        
    }

}
