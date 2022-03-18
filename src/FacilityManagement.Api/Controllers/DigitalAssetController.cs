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
    public class DigitalAssetController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DigitalAssetController> _logger;

        public DigitalAssetController(IMediator mediator, ILogger<DigitalAssetController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [SwaggerOperation(
            Summary = "Get DigitalAsset by id.",
            Description = @"Get DigitalAsset by id."
        )]
        [HttpGet("{digitalAssetId:guid}", Name = "getDigitalAssetById")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDigitalAssetByIdResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetDigitalAssetByIdResponse>> GetById([FromRoute]Guid digitalAssetId, CancellationToken cancellationToken)
        {
            var request = new GetDigitalAssetByIdRequest() { DigitalAssetId = digitalAssetId };
        
            var response = await _mediator.Send(request, cancellationToken);
        
            if (response.DigitalAsset == null)
            {
                return new NotFoundObjectResult(request.DigitalAssetId);
            }
        
            return response;
        }
        
        [SwaggerOperation(
            Summary = "Get DigitalAssets.",
            Description = @"Get DigitalAssets."
        )]
        [HttpGet(Name = "getDigitalAssets")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDigitalAssetsResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetDigitalAssetsResponse>> Get(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetDigitalAssetsRequest(), cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Create DigitalAsset.",
            Description = @"Create DigitalAsset."
        )]
        [HttpPost(Name = "createDigitalAsset")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateDigitalAssetResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateDigitalAssetResponse>> Create([FromBody]CreateDigitalAssetRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName}: ({@Command})",
                nameof(CreateDigitalAssetRequest),
                request);
        
            return await _mediator.Send(request, cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Get DigitalAsset Page.",
            Description = @"Get DigitalAsset Page."
        )]
        [HttpGet("page/{pageSize}/{index}", Name = "getDigitalAssetsPage")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDigitalAssetsPageResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetDigitalAssetsPageResponse>> Page([FromRoute]int pageSize, [FromRoute]int index, CancellationToken cancellationToken)
        {
            var request = new GetDigitalAssetsPageRequest { Index = index, PageSize = pageSize };
        
            return await _mediator.Send(request, cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Update DigitalAsset.",
            Description = @"Update DigitalAsset."
        )]
        [HttpPut(Name = "updateDigitalAsset")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateDigitalAssetResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateDigitalAssetResponse>> Update([FromBody]UpdateDigitalAssetRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                nameof(UpdateDigitalAssetRequest),
                nameof(request.DigitalAsset.DigitalAssetId),
                request.DigitalAsset.DigitalAssetId,
                request);
        
            return await _mediator.Send(request, cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Delete DigitalAsset.",
            Description = @"Delete DigitalAsset."
        )]
        [HttpDelete("{digitalAssetId:guid}", Name = "removeDigitalAsset")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveDigitalAssetResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveDigitalAssetResponse>> Remove([FromRoute]Guid digitalAssetId, CancellationToken cancellationToken)
        {
            var request = new RemoveDigitalAssetRequest() { DigitalAssetId = digitalAssetId };
        
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                nameof(RemoveDigitalAssetRequest),
                nameof(request.DigitalAssetId),
                request.DigitalAssetId,
                request);
        
            return await _mediator.Send(request, cancellationToken);
        }
        
    }
}
