using FacilityManagement.Core;
using FacilityManagement.Core.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FacilityManagement.Core
{

    public class CreateDigitalAssetValidator: AbstractValidator<CreateDigitalAssetRequest>
    {
        public CreateDigitalAssetValidator()
        {
            RuleFor(request => request.DigitalAsset).NotNull();
            RuleFor(request => request.DigitalAsset).SetValidator(new DigitalAssetValidator());
        }
    
    }
    public class CreateDigitalAssetRequest: IRequest<CreateDigitalAssetResponse>
    {
        public DigitalAssetDto DigitalAsset { get; set; }
    }
    public class CreateDigitalAssetResponse: ResponseBase
    {
        public DigitalAssetDto DigitalAsset { get; set; }
    }
    public class CreateDigitalAssetHandler: IRequestHandler<CreateDigitalAssetRequest, CreateDigitalAssetResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly ILogger<CreateDigitalAssetHandler> _logger;
    
        public CreateDigitalAssetHandler(IFacilityManagementDbContext context, ILogger<CreateDigitalAssetHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<CreateDigitalAssetResponse> Handle(CreateDigitalAssetRequest request, CancellationToken cancellationToken)
        {
            var digitalAsset = new DigitalAsset();
            
            _context.DigitalAssets.Add(digitalAsset);
            
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
