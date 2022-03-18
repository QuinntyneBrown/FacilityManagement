using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FacilityManagement.Core;
using MediatR;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace FacilityManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class ProfileController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(IMediator mediator, ILogger<ProfileController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [SwaggerOperation(
            Summary = "Get Profile by id.",
            Description = @"Get Profile by id."
        )]
        [HttpGet("{profileId:guid}", Name = "getProfileById")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProfileByIdResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProfileByIdResponse>> GetById([FromRoute]Guid profileId, CancellationToken cancellationToken)
        {
            var request = new GetProfileByIdRequest() { ProfileId = profileId };
        
            var response = await _mediator.Send(request, cancellationToken);
        
            if (response.Profile == null)
            {
                return new NotFoundObjectResult(request.ProfileId);
            }
        
            return response;
        }
        
        [SwaggerOperation(
            Summary = "Get Profiles.",
            Description = @"Get Profiles."
        )]
        [HttpGet(Name = "getProfiles")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProfilesResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProfilesResponse>> Get(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetProfilesRequest(), cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Create Profile.",
            Description = @"Create Profile."
        )]
        [HttpPost(Name = "createProfile")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateProfileResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateProfileResponse>> Create([FromBody]CreateProfileRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName}: ({@Command})",
                nameof(CreateProfileRequest),
                request);
        
            return await _mediator.Send(request, cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Get Profile Page.",
            Description = @"Get Profile Page."
        )]
        [HttpGet("page/{pageSize}/{index}", Name = "getProfilesPage")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProfilesPageResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProfilesPageResponse>> Page([FromRoute]int pageSize, [FromRoute]int index, CancellationToken cancellationToken)
        {
            var request = new GetProfilesPageRequest { Index = index, PageSize = pageSize };
        
            return await _mediator.Send(request, cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Update Profile.",
            Description = @"Update Profile."
        )]
        [HttpPut(Name = "updateProfile")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateProfileResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateProfileResponse>> Update([FromBody]UpdateProfileRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                nameof(UpdateProfileRequest),
                nameof(request.Profile.ProfileId),
                request.Profile.ProfileId,
                request);
        
            return await _mediator.Send(request, cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Delete Profile.",
            Description = @"Delete Profile."
        )]
        [HttpDelete("{profileId:guid}", Name = "removeProfile")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveProfileResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveProfileResponse>> Remove([FromRoute]Guid profileId, CancellationToken cancellationToken)
        {
            var request = new RemoveProfileRequest() { ProfileId = profileId };
        
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                nameof(RemoveProfileRequest),
                nameof(request.ProfileId),
                request.ProfileId,
                request);
        
            return await _mediator.Send(request, cancellationToken);
        }
        
    }
}
