using FacilityManagement.Core.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FacilityManagement.Core
{

    public class CompleteMaintenanceRequestValidator: AbstractValidator<CompleteMaintenanceRequestRequest>
    {
        public CompleteMaintenanceRequestValidator()
        {

        }
    
    }
    public class CompleteMaintenanceRequestRequest: IRequest<CompleteMaintenanceRequestResponse>
    {
        public Guid MaintenanceRequestId { get; set; }
        public string? WorkCompletedByName { get; set; }
        public DateTime WorkCompleted { get; set; } = DateTime.UtcNow;
    }

    public class CompleteMaintenanceRequestResponse: ResponseBase
    {
        public MaintenanceRequestDto MaintenanceRequest { get; set; }
    }

    public class CompleteMaintenanceRequestHandler: IRequestHandler<CompleteMaintenanceRequestRequest, CompleteMaintenanceRequestResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly ILogger<CompleteMaintenanceRequestHandler> _logger;
    
        public CompleteMaintenanceRequestHandler(IFacilityManagementDbContext context, ILogger<CompleteMaintenanceRequestHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<CompleteMaintenanceRequestResponse> Handle(CompleteMaintenanceRequestRequest request, CancellationToken cancellationToken)
        {
            var maintenanceRequest = await _context.MaintenanceRequests.SingleAsync(x => x.MaintenanceRequestId == new MaintenanceRequestId(request.MaintenanceRequestId));

            maintenanceRequest.Complete(request.WorkCompleted, request.WorkCompletedByName);

            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                MaintenanceRequest = maintenanceRequest.ToDto()
            };
        }
        
    }

}
