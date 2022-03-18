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
    public class MaintenanceRequestController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MaintenanceRequestController> _logger;

        public MaintenanceRequestController(IMediator mediator, ILogger<MaintenanceRequestController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [SwaggerOperation(
            Summary = "Get MaintenanceRequest by id.",
            Description = @"Get MaintenanceRequest by id."
        )]
        [HttpGet("{maintenanceRequestId:guid}", Name = "getMaintenanceRequestById")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetMaintenanceRequestByIdResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetMaintenanceRequestByIdResponse>> GetById([FromRoute]Guid maintenanceRequestId, CancellationToken cancellationToken)
        {
            var request = new GetMaintenanceRequestByIdRequest() { MaintenanceRequestId = maintenanceRequestId };
        
            var response = await _mediator.Send(request, cancellationToken);
        
            if (response.MaintenanceRequest == null)
            {
                return new NotFoundObjectResult(request.MaintenanceRequestId);
            }
        
            return response;
        }
        
        [SwaggerOperation(
            Summary = "Get MaintenanceRequests.",
            Description = @"Get MaintenanceRequests."
        )]
        [HttpGet(Name = "getMaintenanceRequests")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetMaintenanceRequestsResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetMaintenanceRequestsResponse>> Get(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetMaintenanceRequestsRequest(), cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Create MaintenanceRequest.",
            Description = @"Create MaintenanceRequest."
        )]
        [HttpPost(Name = "createMaintenanceRequest")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateMaintenanceRequestResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateMaintenanceRequestResponse>> Create([FromBody]CreateMaintenanceRequestRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName}: ({@Command})",
                nameof(CreateMaintenanceRequestRequest),
                request);
        
            return await _mediator.Send(request, cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Get MaintenanceRequest Page.",
            Description = @"Get MaintenanceRequest Page."
        )]
        [HttpGet("page/{pageSize}/{index}", Name = "getMaintenanceRequestsPage")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetMaintenanceRequestsPageResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetMaintenanceRequestsPageResponse>> Page([FromRoute]int pageSize, [FromRoute]int index, CancellationToken cancellationToken)
        {
            var request = new GetMaintenanceRequestsPageRequest { Index = index, PageSize = pageSize };
        
            return await _mediator.Send(request, cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Update MaintenanceRequest.",
            Description = @"Update MaintenanceRequest."
        )]
        [HttpPut(Name = "updateMaintenanceRequest")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateMaintenanceRequestResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateMaintenanceRequestResponse>> Update([FromBody]UpdateMaintenanceRequestRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                nameof(UpdateMaintenanceRequestRequest),
                nameof(request.MaintenanceRequest.MaintenanceRequestId),
                request.MaintenanceRequest.MaintenanceRequestId,
                request);
        
            return await _mediator.Send(request, cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Delete MaintenanceRequest.",
            Description = @"Delete MaintenanceRequest."
        )]
        [HttpDelete("{maintenanceRequestId:guid}", Name = "removeMaintenanceRequest")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveMaintenanceRequestResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveMaintenanceRequestResponse>> Remove([FromRoute]Guid maintenanceRequestId, CancellationToken cancellationToken)
        {
            var request = new RemoveMaintenanceRequestRequest() { MaintenanceRequestId = maintenanceRequestId };
        
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                nameof(RemoveMaintenanceRequestRequest),
                nameof(request.MaintenanceRequestId),
                request.MaintenanceRequestId,
                request);
        
            return await _mediator.Send(request, cancellationToken);
        }
        
    }
}
