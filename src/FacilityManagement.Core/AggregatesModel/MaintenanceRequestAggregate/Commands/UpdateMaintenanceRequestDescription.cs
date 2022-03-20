using FacilityManagement.Core.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FacilityManagement.Core
{

    public class UpdateMaintenanceRequestDescriptionRequestValidator : AbstractValidator<UpdateMaintenanceRequestDescriptionRequest>
    {
        public UpdateMaintenanceRequestDescriptionRequestValidator()
        {
            RuleFor(request => request.Description).NotNull().NotEmpty();
        }

    }
    
    public class UpdateMaintenanceRequestDescriptionRequest : IRequest<UpdateMaintenanceRequestDescriptionResponse>
    {
        public Guid MaintenanceRequestId { get; set; }
        public string Description { get; set; }
    }

    public class UpdateMaintenanceRequestDescriptionResponse : ResponseBase
    {
        public MaintenanceRequestDto MaintenanceRequest { get; set; }
    }
    public class UpdateMaintenanceRequestDescriptionHandler : IRequestHandler<UpdateMaintenanceRequestDescriptionRequest, UpdateMaintenanceRequestDescriptionResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly ILogger<UpdateMaintenanceRequestHandler> _logger;

        public UpdateMaintenanceRequestDescriptionHandler(IFacilityManagementDbContext context, ILogger<UpdateMaintenanceRequestHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<UpdateMaintenanceRequestDescriptionResponse> Handle(UpdateMaintenanceRequestDescriptionRequest request, CancellationToken cancellationToken)
        {
            var maintenanceRequest = await _context.MaintenanceRequests.SingleAsync(x => x.MaintenanceRequestId == new MaintenanceRequestId(request.MaintenanceRequestId));

            maintenanceRequest.UpdateDescription(request.Description);

            await _context.SaveChangesAsync(cancellationToken);

            return new()
            {
                MaintenanceRequest = maintenanceRequest.ToDto()
            };
        }
    }
}
