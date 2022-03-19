using FacilityManagement.Core.Interfaces;
using FacilityManagement.SharedKernel.Identity;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json.Serialization;
using static FacilityManagement.Core.CoreConstants;

namespace FacilityManagement.Core
{

    public class CreateMaintenanceRequestValidator: AbstractValidator<CreateMaintenanceRequestRequest>
    {
        public CreateMaintenanceRequestValidator()
        {
            RuleFor(request => request.RequestedByProfileId).NotNull();
            RuleFor(request => request.RequestedByName).NotEmpty().NotNull();
            RuleFor(request => request.Phone).NotEmpty().NotNull();
            RuleFor(request => request.UnattendedUnitEntryAllowed).NotNull();

            RuleFor(request => request.Address).SetValidator(new AddressValidator());
        }
    }

    [AuthorizeResourceOperation(nameof(Operations.Write), nameof(Aggregates.MaintenanceRequest))]
    public class CreateMaintenanceRequestRequest: IRequest<CreateMaintenanceRequestResponse>
    {
        public Guid RequestedByProfileId { get; set; }
        public string RequestedByName { get; set; }
        public AddressDto Address { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public bool UnattendedUnitEntryAllowed { get; set; }

        [JsonConstructor]
        public CreateMaintenanceRequestRequest()
        {

        }

        public CreateMaintenanceRequestRequest(Guid requestedByProfileId, string requestedByName, string street, string city, string province, string postalCode, string phone, string description, bool unattendedUnitEntryAllowed)
        {
            RequestedByProfileId = requestedByProfileId;
            RequestedByName = requestedByName;
            Address = new AddressDto() { Street = street, City = city, Province = province, PostalCode = postalCode };
            Phone = phone;
            Description = description;
            UnattendedUnitEntryAllowed = unattendedUnitEntryAllowed;
        }


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
                RequestedByProfileId = request.RequestedByProfileId,
                RequestedByName = request.RequestedByName,
                Address = Address.Create(request.Address.Street, request.Address.Unit.Value, request.Address.City, request.Address.Province, request.Address.PostalCode).Value,
                Phone = request.Phone,
                Description = request.Description,
                UnattendedUnitEntryAllowed = request.UnattendedUnitEntryAllowed
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
