﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace FacilityManagement.SharedKernel.Identity
{
    public class ResourceOperationAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, object>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, object resource)
        {
            try
            {
                var resourceName = resource as string;

                var privilegeClaims = context.User.Claims.Where(x => x.Type == SharedKernelConstants.ClaimTypes.Privilege).ToList();

                var aggregatePrivilegeClaims = privilegeClaims.Where(x => x.Value.EndsWith(resourceName)).ToList();

                var claim = aggregatePrivilegeClaims.FirstOrDefault(x => x.Value.StartsWith(requirement.Name));

                if (claim != null)
                {
                    context.Succeed(requirement);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            await Task.CompletedTask;
        }
    }
}
