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

    public class GetProfilesRequest: IRequest<GetProfilesResponse> { }
    public class GetProfilesResponse: ResponseBase
    {
        public List<ProfileDto> Profiles { get; set; }
    }
    public class GetProfilesHandler: IRequestHandler<GetProfilesRequest, GetProfilesResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly ILogger<GetProfilesHandler> _logger;
    
        public GetProfilesHandler(IFacilityManagementDbContext context, ILogger<GetProfilesHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetProfilesResponse> Handle(GetProfilesRequest request, CancellationToken cancellationToken)
        {
            return new () {
                Profiles = await _context.Profiles.AsNoTracking().ToDtosAsync(cancellationToken)
            };
        }
        
    }

}
