using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scaffold.Application.Handlers;

namespace Scaffold.Api.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class UseCaseController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(UseCaseRequest), StatusCodes.Status201Created)]
        public async Task<ActionResult> Create([FromServices] IMediator _mediator, [FromBody] UseCaseRequest request)
            => Ok(_mediator.Send(request));
    }
}
