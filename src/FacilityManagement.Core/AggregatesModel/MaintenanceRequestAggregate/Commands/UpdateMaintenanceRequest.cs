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

    public class UpdateMaintenanceRequestValidator: AbstractValidator<UpdateMaintenanceRequestRequest>
    {
        public UpdateMaintenanceRequestValidator()
        {
            RuleFor(request => request.MaintenanceRequest).NotNull();
            RuleFor(request => request.MaintenanceRequest).SetValidator(new MaintenanceRequestValidator());
        }
    
    }
    public class UpdateMaintenanceRequestRequest: IRequest<UpdateMaintenanceRequestResponse>
    {
        public MaintenanceRequestDto MaintenanceRequest { get; set; }
    }
    public class UpdateMaintenanceRequestResponse: ResponseBase
    {
        public MaintenanceRequestDto MaintenanceRequest { get; set; }
    }
    public class UpdateMaintenanceRequestHandler: IRequestHandler<UpdateMaintenanceRequestRequest, UpdateMaintenanceRequestResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly ILogger<UpdateMaintenanceRequestHandler> _logger;
    
        public UpdateMaintenanceRequestHandler(IFacilityManagementDbContext context, ILogger<UpdateMaintenanceRequestHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<UpdateMaintenanceRequestResponse> Handle(UpdateMaintenanceRequestRequest request, CancellationToken cancellationToken)
        {
            var maintenanceRequest = await _context.MaintenanceRequests.SingleAsync(x => x.MaintenanceRequestId == new MaintenanceRequestId(request.MaintenanceRequest.MaintenanceRequestId.Value));
            
            maintenanceRequest.RequestedByProfileId = new ProfileId(request.MaintenanceRequest.RequestedByProfileId.Value);
            maintenanceRequest.RequestedByName = request.MaintenanceRequest.RequestedByName;
            maintenanceRequest.Date = request.MaintenanceRequest.Date;

            var addressDto = request.MaintenanceRequest.Address;
            maintenanceRequest.Address = Address.Create(addressDto.Street, addressDto.City, addressDto.Province, addressDto.PostalCode).Value;

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
