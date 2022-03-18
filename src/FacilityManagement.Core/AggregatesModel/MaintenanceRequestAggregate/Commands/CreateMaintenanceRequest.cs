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
            var maintenanceRequest = new MaintenanceRequest();
            
            _context.MaintenanceRequests.Add(maintenanceRequest);
            
            maintenanceRequest.RequestedByProfileId = new ProfileId(request.MaintenanceRequest.RequestedByProfileId.Value);
            maintenanceRequest.RequestedByName = request.MaintenanceRequest.RequestedByName;
            maintenanceRequest.Date = request.MaintenanceRequest.Date;
            maintenanceRequest.Address = request.MaintenanceRequest.Address;
            maintenanceRequest.Phone = request.MaintenanceRequest.Phone;
            maintenanceRequest.Description = request.MaintenanceRequest.Description;
            maintenanceRequest.UnattendedUnitEntryAllowed = request.MaintenanceRequest.UnattendedUnitEntryAllowed.Value;
            maintenanceRequest.ReceivedByProfileId = new ProfileId(request.MaintenanceRequest.ReceivedByProfileId.Value);
            maintenanceRequest.ReceivedByName = request.MaintenanceRequest.ReceivedByName;
            maintenanceRequest.ReceivedDate = request.MaintenanceRequest.ReceivedDate;
            maintenanceRequest.WorkDetails = request.MaintenanceRequest.WorkDetails;
            maintenanceRequest.WorkStarted = request.MaintenanceRequest.WorkStarted;
            maintenanceRequest.WorkCompleted = request.MaintenanceRequest.WorkCompleted;
            maintenanceRequest.WorkCompletedByName = request.MaintenanceRequest.WorkCompletedByName;
            maintenanceRequest.UnitEntered = request.MaintenanceRequest.UnitEntered;

            maintenanceRequest.Status = request.MaintenanceRequest.Status;

            
            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                MaintenanceRequest = maintenanceRequest.ToDto()
            };
        }
        
    }

}
