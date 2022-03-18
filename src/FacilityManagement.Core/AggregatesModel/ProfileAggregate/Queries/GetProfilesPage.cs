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

    public class GetProfilesPageRequest: IRequest<GetProfilesPageResponse>
    {
        public int PageSize { get; set; }
        public int Index { get; set; }
    }
    public class GetProfilesPageResponse: ResponseBase
    {
        public int Length { get; set; }
        public List<ProfileDto> Entities { get; set; }
    }
    public class GetProfilesPageHandler: IRequestHandler<GetProfilesPageRequest, GetProfilesPageResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly ILogger<GetProfilesPageHandler> _logger;
    
        public GetProfilesPageHandler(IFacilityManagementDbContext context, ILogger<GetProfilesPageHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetProfilesPageResponse> Handle(GetProfilesPageRequest request, CancellationToken cancellationToken)
        {
            var query = from profile in _context.Profiles
                select profile;
            
            var length = await _context.Profiles.AsNoTracking().CountAsync();
            
            var profiles = await query.Page(request.Index, request.PageSize).AsNoTracking()
                .Select(x => x.ToDto()).ToListAsync();
            
            return new ()
            {
                Length = length,
                Entities = profiles
            };
        }
        
    }

}
