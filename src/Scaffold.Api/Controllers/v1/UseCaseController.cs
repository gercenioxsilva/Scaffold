using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scaffold.Application.Handlers;

namespace Scaffold.Api.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class UseCaseController : ControllerBase
    {
        private IMediator _mediator;

        public UseCaseController(IMediator mediator) => _mediator = mediator;
        
        [HttpPost]
        [ProducesResponseType(typeof(UseCaseRequest), StatusCodes.Status201Created)]
        public async Task<ActionResult> CreateAsync([FromBody] UseCaseRequest request)
            => Ok(_mediator.Send(request));
    }
}
