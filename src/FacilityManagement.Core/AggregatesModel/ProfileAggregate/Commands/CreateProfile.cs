using FacilityManagement.Core;
using FacilityManagement.Core.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FacilityManagement.Core
{

    public class CreateProfileValidator: AbstractValidator<CreateProfileRequest>
    {
        public CreateProfileValidator()
        {
            RuleFor(request => request.Profile).NotNull();
            RuleFor(request => request.Profile).SetValidator(new ProfileValidator());
        }
    
    }
    public class CreateProfileRequest: IRequest<CreateProfileResponse>
    {
        public ProfileDto Profile { get; set; }
    }
    public class CreateProfileResponse: ResponseBase
    {
        public ProfileDto Profile { get; set; }
    }
    public class CreateProfileHandler: IRequestHandler<CreateProfileRequest, CreateProfileResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly ILogger<CreateProfileHandler> _logger;
    
        public CreateProfileHandler(IFacilityManagementDbContext context, ILogger<CreateProfileHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<CreateProfileResponse> Handle(CreateProfileRequest request, CancellationToken cancellationToken)
        {
            var profile = new Profile();
            
            _context.Profiles.Add(profile);
            
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
