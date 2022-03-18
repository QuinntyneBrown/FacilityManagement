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

    public class GetProfileByIdRequest: IRequest<GetProfileByIdResponse>
    {
        public Guid ProfileId { get; set; }
    }
    public class GetProfileByIdResponse: ResponseBase
    {
        public ProfileDto Profile { get; set; }
    }
    public class GetProfileByIdHandler: IRequestHandler<GetProfileByIdRequest, GetProfileByIdResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly ILogger<GetProfileByIdHandler> _logger;
    
        public GetProfileByIdHandler(IFacilityManagementDbContext context, ILogger<GetProfileByIdHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetProfileByIdResponse> Handle(GetProfileByIdRequest request, CancellationToken cancellationToken)
        {
            return new () {
                Profile = (await _context.Profiles.AsNoTracking().SingleOrDefaultAsync(x => x.ProfileId == new ProfileId(request.ProfileId))).ToDto()
            };
        }
        
    }

}
