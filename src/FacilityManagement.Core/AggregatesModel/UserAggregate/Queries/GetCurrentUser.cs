using FacilityManagement.Core.Interfaces;
using FacilityManagement.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace FacilityManagement.Core
{
    public class CurrentUserRequest : IRequest<CurrentUserResponse> { }

    public class CurrentUserResponse
    {
        public UserDto User { get; set; }
    }

    public class CurrentUserHandler : IRequestHandler<CurrentUserRequest, CurrentUserResponse>
    {
        private readonly IFacilityManagementDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserHandler(IFacilityManagementDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CurrentUserResponse> Handle(CurrentUserRequest request, CancellationToken cancellationToken)
        {

            if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return new();
            }

            var userId = new Guid(_httpContextAccessor.HttpContext.User.FindFirst(SharedKernelConstants.ClaimTypes.UserId).Value);

            User user = _context.Users
                .Include(x => x.Profiles)
                .Include(x => x.Roles)
                .ThenInclude(x => x.Privileges)
                .Single(x => x.UserId == new UserId(userId));

            return new()
            {
                User = user.ToDto()
            };
        }
    }
}