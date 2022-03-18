using FacilityManagement.Core;
using FacilityManagement.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FacilityManagement.Core
{

    public class GetMaintenanceRequestsPageRequest: IRequest<GetMaintenanceRequestsPageResponse>
    {
        public int PageSize { get; set; }
        public int Index { get; set; }
    }
    public class GetMaintenanceRequestsPageResponse: ResponseBase
    {
        public int Length { get; set; }
        public List<MaintenanceRequestDto> Entities { get; set; }
    }
    public class GetMaintenanceRequestsPageHandler: IRequestHandler<GetMaintenanceRequestsPageRequest, GetMaintenanceRequestsPageResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly ILogger<GetMaintenanceRequestsPageHandler> _logger;
    
        public GetMaintenanceRequestsPageHandler(IFacilityManagementDbContext context, ILogger<GetMaintenanceRequestsPageHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetMaintenanceRequestsPageResponse> Handle(GetMaintenanceRequestsPageRequest request, CancellationToken cancellationToken)
        {
            var query = from maintenanceRequest in _context.MaintenanceRequests
                select maintenanceRequest;
            
            var length = await _context.MaintenanceRequests.AsNoTracking().CountAsync();
            
            var maintenanceRequests = await query.Page(request.Index, request.PageSize).AsNoTracking()
                .Select(x => x.ToDto()).ToListAsync();
            
            return new ()
            {
                Length = length,
                Entities = maintenanceRequests
            };
        }
        
    }

}
