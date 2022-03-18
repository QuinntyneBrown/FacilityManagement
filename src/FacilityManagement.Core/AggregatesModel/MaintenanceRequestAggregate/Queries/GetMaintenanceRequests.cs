using FacilityManagement.Core;
using FacilityManagement.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FacilityManagement.Core
{

    public class GetMaintenanceRequestsRequest: IRequest<GetMaintenanceRequestsResponse> { }
    public class GetMaintenanceRequestsResponse: ResponseBase
    {
        public List<MaintenanceRequestDto> MaintenanceRequests { get; set; }
    }
    public class GetMaintenanceRequestsHandler: IRequestHandler<GetMaintenanceRequestsRequest, GetMaintenanceRequestsResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly ILogger<GetMaintenanceRequestsHandler> _logger;
    
        public GetMaintenanceRequestsHandler(IFacilityManagementDbContext context, ILogger<GetMaintenanceRequestsHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetMaintenanceRequestsResponse> Handle(GetMaintenanceRequestsRequest request, CancellationToken cancellationToken)
        {
            return new () {
                MaintenanceRequests = await _context.MaintenanceRequests.AsNoTracking().ToDtosAsync(cancellationToken)
            };
        }
        
    }

}
