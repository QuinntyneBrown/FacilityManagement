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

    public class CreateUserValidator: AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(request => request.User).NotNull();
            RuleFor(request => request.User).SetValidator(new UserValidator());
        }
    
    }
    public class CreateUserRequest: IRequest<CreateUserResponse>
    {
        public UserDto User { get; set; }
    }
    public class CreateUserResponse: ResponseBase
    {
        public UserDto User { get; set; }
    }
    public class CreateUserHandler: IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly ILogger<CreateUserHandler> _logger;
    
        public CreateUserHandler(IFacilityManagementDbContext context, ILogger<CreateUserHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = new User();
            
            _context.Users.Add(user);
            
            user.UserName = request.User.UserName;
            user.Password = request.User.Password;
            user.Salt = request.User.Salt;
            user.Roles = request.User.Roles;
            user.Profiles = request.User.Profiles;
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                User = user.ToDto()
            };
        }
        
    }

}
