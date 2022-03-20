using FacilityManagement.Core.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FacilityManagement.Core
{

    public class UpdateMaintenanceRequestWorkDetailsRequestValidator : AbstractValidator<UpdateMaintenanceRequestWorkDetailsRequest>
    {
        public UpdateMaintenanceRequestWorkDetailsRequestValidator()
        {

        }
    
    }
    public class UpdateMaintenanceRequestWorkDetailsRequest: IRequest<UpdateMaintenanceRequestWorkDetailsResponse>
    {
        public Guid MaintenanceRequestId { get; set; }
        public string WorkDetails { get; set; }
    }
    public class UpdateMaintenanceRequestWorkDetailsResponse : ResponseBase
    {
        public MaintenanceRequestDto MaintenanceRequest { get; set; }
    }
    public class UpdateMaintenanceRequestWorkDetailsHandler : IRequestHandler<UpdateMaintenanceRequestWorkDetailsRequest, UpdateMaintenanceRequestWorkDetailsResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly ILogger<UpdateMaintenanceRequestHandler> _logger;
    
        public UpdateMaintenanceRequestWorkDetailsHandler(IFacilityManagementDbContext context, ILogger<UpdateMaintenanceRequestHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<UpdateMaintenanceRequestWorkDetailsResponse> Handle(UpdateMaintenanceRequestWorkDetailsRequest request, CancellationToken cancellationToken)
        {
            var maintenanceRequest = await _context.MaintenanceRequests.SingleAsync(x => x.MaintenanceRequestId == new MaintenanceRequestId(request.MaintenanceRequestId));

            maintenanceRequest.UpdateWorkDetails(request.WorkDetails);

            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                MaintenanceRequest = maintenanceRequest.ToDto()
            };
        }
        
    }

}
