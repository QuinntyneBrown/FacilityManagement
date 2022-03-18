using FacilityManagement.Core;
using FacilityManagement.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FacilityManagement.Core
{

    public class GetMaintenanceRequestByIdRequest: IRequest<GetMaintenanceRequestByIdResponse>
    {
        public Guid MaintenanceRequestId { get; set; }
    }
    public class GetMaintenanceRequestByIdResponse: ResponseBase
    {
        public MaintenanceRequestDto MaintenanceRequest { get; set; }
    }
    public class GetMaintenanceRequestByIdHandler: IRequestHandler<GetMaintenanceRequestByIdRequest, GetMaintenanceRequestByIdResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly ILogger<GetMaintenanceRequestByIdHandler> _logger;
    
        public GetMaintenanceRequestByIdHandler(IFacilityManagementDbContext context, ILogger<GetMaintenanceRequestByIdHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetMaintenanceRequestByIdResponse> Handle(GetMaintenanceRequestByIdRequest request, CancellationToken cancellationToken)
        {
            return new () {
                MaintenanceRequest = (await _context.MaintenanceRequests.AsNoTracking().SingleOrDefaultAsync(x => x.MaintenanceRequestId == new MaintenanceRequestId(request.MaintenanceRequestId))).ToDto()
            };
        }
        
    }

}
