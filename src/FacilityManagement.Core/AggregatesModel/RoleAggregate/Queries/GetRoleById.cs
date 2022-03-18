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

    public class GetRoleByIdRequest: IRequest<GetRoleByIdResponse>
    {
        public Guid RoleId { get; set; }
    }
    public class GetRoleByIdResponse: ResponseBase
    {
        public RoleDto Role { get; set; }
    }
    public class GetRoleByIdHandler: IRequestHandler<GetRoleByIdRequest, GetRoleByIdResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly ILogger<GetRoleByIdHandler> _logger;
    
        public GetRoleByIdHandler(IFacilityManagementDbContext context, ILogger<GetRoleByIdHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetRoleByIdResponse> Handle(GetRoleByIdRequest request, CancellationToken cancellationToken)
        {
            return new () {
                Role = (await _context.Roles.AsNoTracking().SingleOrDefaultAsync(x => x.RoleId == new RoleId(request.RoleId))).ToDto()
            };
        }
        
    }

}
