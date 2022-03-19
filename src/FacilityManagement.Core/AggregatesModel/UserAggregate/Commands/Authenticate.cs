using FacilityManagement.Core.Interfaces;
using FacilityManagement.SharedKernel;
using FacilityManagement.SharedKernel.Identity;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FacilityManagement.Core
{
    public class AuthenticateValidator : AbstractValidator<AuthenticateRequest>
    {
        public AuthenticateValidator()
        {
            RuleFor(x => x.UserName).NotNull();
            RuleFor(x => x.Password).NotNull();
        }
    }

    public record AuthenticateRequest(string UserName, string Password) : IRequest<AuthenticateResponse>;

    public record AuthenticateResponse(string AccessToken, Guid UserId);

    public class AuthenticateHandler : IRequestHandler<AuthenticateRequest, AuthenticateResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenBuilder _tokenBuilder;

        public AuthenticateHandler(IFacilityManagementDbContext context, IPasswordHasher passwordHasher, ITokenBuilder tokenBuilder)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _tokenBuilder = tokenBuilder;
        }

        public async Task<AuthenticateResponse> Handle(AuthenticateRequest request, CancellationToken cancellationToken)
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

            return new AuthenticateResponse(token, user.UserId.Value);
        }

        public bool ValidateUser(User user, string transformedPassword)
        {
            if (user == null || transformedPassword == null)
                return false;

            return user.Password == transformedPassword;
        }
    }
}
