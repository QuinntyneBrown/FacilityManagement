using FacilityManagement.Core.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FacilityManagement.Core
{

    public class CreateMaintenanceRequestValidator: AbstractValidator<CreateMaintenanceRequestRequest>
    {
        public CreateMaintenanceRequestValidator()
        {
            RuleFor(request => request.MaintenanceRequest).NotNull();
            RuleFor(request => request.MaintenanceRequest).SetValidator(new MaintenanceRequestValidator());
        }
    }

    public class CreateMaintenanceRequestRequest: IRequest<CreateMaintenanceRequestResponse>
    {
        public MaintenanceRequestDto MaintenanceRequest { get; set; }
    }

    public class CreateMaintenanceRequestResponse: ResponseBase
    {
        public MaintenanceRequestDto MaintenanceRequest { get; set; }
    }

    public class CreateMaintenanceRequestHandler: IRequestHandler<CreateMaintenanceRequestRequest, CreateMaintenanceRequestResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly ILogger<CreateMaintenanceRequestHandler> _logger;
    
        public CreateMaintenanceRequestHandler(IFacilityManagementDbContext context, ILogger<CreateMaintenanceRequestHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CreateMaintenanceRequestResponse> Handle(CreateMaintenanceRequestRequest request, CancellationToken cancellationToken)
        {
            var maintenanceRequest = new MaintenanceRequest(new CreateMaintenanceRequest()
            {
                RequestedByProfileId = request.MaintenanceRequest.RequestedByProfileId.Value,
                RequestedByName = request.MaintenanceRequest.RequestedByName,
                Address = Address.Create(request.MaintenanceRequest.Address.Street, request.MaintenanceRequest.Address.Unit.Value, request.MaintenanceRequest.Address.City, request.MaintenanceRequest.Address.Province, request.MaintenanceRequest.Address.PostalCode).Value,
                Phone = request.MaintenanceRequest.Phone,
                Description = request.MaintenanceRequest.Description,
                UnattendedUnitEntryAllowed = request.MaintenanceRequest.UnattendedUnitEntryAllowed.Value
            });
            
            _context.MaintenanceRequests.Add(maintenanceRequest);

            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                MaintenanceRequest = maintenanceRequest.ToDto()
            };
        }
        
    }

}
