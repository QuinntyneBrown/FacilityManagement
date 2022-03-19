using FacilityManagement.Core;
using FacilityManagement.Core.Interfaces;
using FacilityManagement.SharedKernel.Identity;
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
        private readonly IPasswordHasher _passwordHasher;
    
        public CreateUserHandler(IFacilityManagementDbContext context, ILogger<CreateUserHandler> logger, IPasswordHasher passwordHasher)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        }
    
        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = new User(new CreateUser(request.User.UserName,request.User.Password, _passwordHasher));
            
            _context.Users.Add(user);

            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                User = user.ToDto()
            };
        }
        
    }

}
