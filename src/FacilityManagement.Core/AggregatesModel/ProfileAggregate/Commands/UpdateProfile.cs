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

    public class UpdateProfileValidator: AbstractValidator<UpdateProfileRequest>
    {
        public UpdateProfileValidator()
        {
            RuleFor(request => request.Profile).NotNull();
            RuleFor(request => request.Profile).SetValidator(new ProfileValidator());
        }
    
    }
    public class UpdateProfileRequest: IRequest<UpdateProfileResponse>
    {
        public ProfileDto Profile { get; set; }
    }
    public class UpdateProfileResponse: ResponseBase
    {
        public ProfileDto Profile { get; set; }
    }
    public class UpdateProfileHandler: IRequestHandler<UpdateProfileRequest, UpdateProfileResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly ILogger<UpdateProfileHandler> _logger;
    
        public UpdateProfileHandler(IFacilityManagementDbContext context, ILogger<UpdateProfileHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<UpdateProfileResponse> Handle(UpdateProfileRequest request, CancellationToken cancellationToken)
        {
            var profile = await _context.Profiles.SingleAsync(x => x.ProfileId == new ProfileId(request.Profile.ProfileId.Value));
            
            profile.FirstName = request.Profile.FirstName;
            profile.LastName = request.Profile.LastName;
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                Profile = profile.ToDto()
            };
        }
        
    }

}
