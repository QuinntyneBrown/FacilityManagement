using FacilityManagement.Core.Interfaces;
using FacilityManagement.SharedKernel;
using FacilityManagement.SharedKernel.Identity;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FacilityManagement.Core
{
    public class Authenticate
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.UserName).NotNull();
                RuleFor(x => x.Password).NotNull();
            }
        }

        public record Request(string UserName, string Password) : IRequest<Response>;

        public record Response(string AccessToken, Guid UserId);

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IFacilityManagementDbContext _context;
            private readonly IPasswordHasher _passwordHasher;
            private readonly ITokenBuilder _tokenBuilder;

            public Handler(IFacilityManagementDbContext context, IPasswordHasher passwordHasher, ITokenBuilder tokenBuilder)
            {
                _context = context;
                _passwordHasher = passwordHasher;
                _tokenBuilder = tokenBuilder;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var user = await _context.Users
                    .SingleOrDefaultAsync(x => x.UserName == request.UserName);

                if (user == null)
                    throw new Exception();

                if (!ValidateUser(user, _passwordHasher.HashPassword(user.Salt, request.Password)))
                    throw new Exception();

                var token = _tokenBuilder
                    .AddUsername(user.UserName)
                    .AddClaim(new System.Security.Claims.Claim(SharedKernelConstants.ClaimTypes.UserId, $"{user.UserId}"))
                    .AddClaim(new System.Security.Claims.Claim(SharedKernelConstants.ClaimTypes.Username, $"{user.UserName}"))
                    .Build();

                return new(token, user.UserId.Value);
            }

            public bool ValidateUser(User user, string transformedPassword)
            {
                if (user == null || transformedPassword == null)
                    return false;

                return user.Password == transformedPassword;
            }
        }
    }
}
