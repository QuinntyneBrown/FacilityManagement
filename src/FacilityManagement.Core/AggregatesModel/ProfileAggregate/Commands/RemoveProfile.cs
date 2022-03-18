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

    public class RemoveProfileRequest: IRequest<RemoveProfileResponse>
    {
        public Guid ProfileId { get; set; }
    }
    public class RemoveProfileResponse: ResponseBase
    {
        public ProfileDto Profile { get; set; }
    }
    public class RemoveProfileHandler: IRequestHandler<RemoveProfileRequest, RemoveProfileResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly ILogger<RemoveProfileHandler> _logger;
    
        public RemoveProfileHandler(IFacilityManagementDbContext context, ILogger<RemoveProfileHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<RemoveProfileResponse> Handle(RemoveProfileRequest request, CancellationToken cancellationToken)
        {
            var profile = await _context.Profiles.FindAsync(new ProfileId(request.ProfileId));
            
            _context.Profiles.Remove(profile);
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                Profile = profile.ToDto()
            };
        }
        
    }

}
