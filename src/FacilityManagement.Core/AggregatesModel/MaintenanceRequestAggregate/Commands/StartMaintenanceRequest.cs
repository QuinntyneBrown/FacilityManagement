using FacilityManagement.Core.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FacilityManagement.Core
{

    public class StartMaintenanceRequestValidator: AbstractValidator<StartMaintenanceRequestRequest>
    {
        public StartMaintenanceRequestValidator()
        {

        }
    
    }
    public class StartMaintenanceRequestRequest: IRequest<StartMaintenanceRequestResponse>
    {
        public Guid MaintenanceRequestId { get; set; }
        public UnitEntered UnitEntered { get; set; }
        public DateTime WorkStarted { get; set; } = DateTime.UtcNow;
    }

    public class StartMaintenanceRequestResponse: ResponseBase
    {
        public MaintenanceRequestDto MaintenanceRequest { get; set; }
    }

    public class StartMaintenanceRequestHandler: IRequestHandler<StartMaintenanceRequestRequest, StartMaintenanceRequestResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly ILogger<StartMaintenanceRequestHandler> _logger;
    
        public StartMaintenanceRequestHandler(IFacilityManagementDbContext context, ILogger<StartMaintenanceRequestHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<StartMaintenanceRequestResponse> Handle(StartMaintenanceRequestRequest request, CancellationToken cancellationToken)
        {
            var maintenanceRequest = await _context.MaintenanceRequests.SingleAsync(x => x.MaintenanceRequestId == new MaintenanceRequestId(request.MaintenanceRequestId));

            maintenanceRequest.Start(request.UnitEntered, request.WorkStarted);

            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                MaintenanceRequest = maintenanceRequest.ToDto()
            };
        }
        
    }

}
