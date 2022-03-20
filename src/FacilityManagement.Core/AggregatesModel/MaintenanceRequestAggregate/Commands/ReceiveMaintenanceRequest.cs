using FacilityManagement.Core.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace FacilityManagement.Core
{
    public class ReceiveMaintenanceRequestValidator: AbstractValidator<ReceiveMaintenanceRequestRequest>
    {
        public ReceiveMaintenanceRequestValidator()
        {
            RuleFor(x => x.MaintenanceRequestId).NotNull().NotEmpty();
            RuleFor(x => x.ReceivedByName).NotNull();
            RuleFor(x => x.ReceivedByProfileId).NotNull();
        }
    
    }
    public class ReceiveMaintenanceRequestRequest: IRequest<ReceiveMaintenanceRequestResponse>
    {
        public Guid MaintenanceRequestId { get; set; }
        public string? ReceivedByName { get; init; }
        public Guid ReceivedByProfileId { get; init; }
    }

    public class ReceiveMaintenanceRequestResponse: ResponseBase
    {
        public MaintenanceRequestDto? MaintenanceRequest { get; set; }
    }

    public class ReceiveMaintenanceRequestHandler: IRequestHandler<ReceiveMaintenanceRequestRequest, ReceiveMaintenanceRequestResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly ILogger<ReceiveMaintenanceRequestHandler> _logger;
    
        public ReceiveMaintenanceRequestHandler(IFacilityManagementDbContext context, ILogger<ReceiveMaintenanceRequestHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<ReceiveMaintenanceRequestResponse> Handle(ReceiveMaintenanceRequestRequest request, CancellationToken cancellationToken)
        {
            var maintenanceRequest = await _context.MaintenanceRequests.SingleAsync(x => x.MaintenanceRequestId == new MaintenanceRequestId(request.MaintenanceRequestId));

            maintenanceRequest.Receive(request.ReceivedByName, request.ReceivedByProfileId);

            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                MaintenanceRequest = maintenanceRequest.ToDto()
            };
        }
        
    }

}
