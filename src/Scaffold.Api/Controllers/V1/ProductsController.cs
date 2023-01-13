using MediatR;
using Scaffold.Application.UseCases.Products.GetProduct;

namespace Scaffold.Api.Controllers.V1;

[ApiController]
[Route("v1/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    private readonly IMediator _mediator;

    public ProductsController(ILogger<ProductsController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    // [ProducesResponseType(typeof(ServiceResult<PagedModel<BuscarAtividadeOutput>>), (int) HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
    {
        var request = new GetProductRequest();
        var serviceResult = await _mediator.Send(request, cancellationToken);
        return Ok(serviceResult);
    }
}