/*using FacilityManagement.Core.Interfaces;
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
                RuleFor(x => x.Username).NotNull();
                RuleFor(x => x.Password).NotNull();
            }
        }

        public record Request(string Username, string Password) : IRequest<Response>;

        public record Response(string AccessToken, Guid UserId);

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IFacilityManagementDbContext _context;
            private readonly IPasswordHasher _passwordHasher;
            private readonly IDiagnosticContext _diagnosticContext;
            private readonly IOrchestrationHandler _orchestrationHandler;

            public Handler(IFacilityManagementDbContext context, IPasswordHasher passwordHasher, IOrchestrationHandler orchestrationHandler, IDiagnosticContext diagnosticContext)
            {
                _context = context;
                _passwordHasher = passwordHasher;
                _diagnosticContext = diagnosticContext;
                _orchestrationHandler = orchestrationHandler;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                using (Operation.Time("Users.Authenticate"))
                {
                    var user = await _context.Users
                        .Include(x => x.Roles)
                        .ThenInclude(x => x.Privileges)
                        .SingleOrDefaultAsync(x => x.Username == request.Username);

                    if (user == null)
                        throw new Exception();

                    if (!ValidateUser(user, _passwordHasher.HashPassword(user.Salt, request.Password)))
                        throw new Exception();

                    return await _orchestrationHandler.Handle<Response>(new BuildToken(user.Username), (tcs) => async message =>
                    {
                        switch (message)
                        {
                            case BuiltToken builtToken:
                                await _orchestrationHandler.Publish(new AuthenticatedUser(user.Username));
                                _diagnosticContext.Set("Username", request.Username);
                                tcs.SetResult(new Response(builtToken.AccessToken, builtToken.UserId));
                                break;
                        }
                    });
                }
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
*/