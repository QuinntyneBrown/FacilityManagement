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

    public class GetRolesRequest: IRequest<GetRolesResponse> { }
    public class GetRolesResponse: ResponseBase
    {
        public List<RoleDto> Roles { get; set; }
    }
    public class GetRolesHandler: IRequestHandler<GetRolesRequest, GetRolesResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly ILogger<GetRolesHandler> _logger;
    
        public GetRolesHandler(IFacilityManagementDbContext context, ILogger<GetRolesHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetRolesResponse> Handle(GetRolesRequest request, CancellationToken cancellationToken)
        {
            return new () {
                Roles = await _context.Roles.AsNoTracking().ToDtosAsync(cancellationToken)
            };
        }
        
    }

}
