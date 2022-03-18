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

    public class RemoveMaintenanceRequestRequest: IRequest<RemoveMaintenanceRequestResponse>
    {
        public Guid MaintenanceRequestId { get; set; }
    }
    public class RemoveMaintenanceRequestResponse: ResponseBase
    {
        public MaintenanceRequestDto MaintenanceRequest { get; set; }
    }
    public class RemoveMaintenanceRequestHandler: IRequestHandler<RemoveMaintenanceRequestRequest, RemoveMaintenanceRequestResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly ILogger<RemoveMaintenanceRequestHandler> _logger;
    
        public RemoveMaintenanceRequestHandler(IFacilityManagementDbContext context, ILogger<RemoveMaintenanceRequestHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<RemoveMaintenanceRequestResponse> Handle(RemoveMaintenanceRequestRequest request, CancellationToken cancellationToken)
        {
            var maintenanceRequest = await _context.MaintenanceRequests.FindAsync(new MaintenanceRequestId(request.MaintenanceRequestId));
            
            _context.MaintenanceRequests.Remove(maintenanceRequest);
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                MaintenanceRequest = maintenanceRequest.ToDto()
            };
        }
        
    }

}
