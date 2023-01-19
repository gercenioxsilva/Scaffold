using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scaffold.Application.UseCases.Products.GetAllProducts;
using Scaffold.Application.UseCases.Products.GetProductById;
using Scaffold.Application.UseCases.Products.NewProduct;
using Scaffold.Application.UseCases.Products.RemoveProduct;
using Scaffold.Application.UseCases.Products.UpdateProduct;
using Scaffold.Domain.Seedwork;

namespace Scaffold.Api.Controllers.V1;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1")]
[ApiExplorerSettings(GroupName = "v1")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
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
    [ProducesResponseType(typeof(ServiceResult<PagedModel<GetAllProductsResponse>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAsunc([FromQuery] GetAllProductsRequest request,
        CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(request, cancellationToken));
    }

    [HttpGet("{productId:guid}")]
    [ProducesResponseType(typeof(ServiceResult<GetProductByIdResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid productId,
        CancellationToken cancellationToken)
    {
        var input = new GetProductByIdRequest()
        {
            Id = productId
        };

        return Ok(await _mediator.Send(input, cancellationToken));
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<IActionResult> PostAsunc([FromBody] NewProductRequest request,
        CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(request, cancellationToken));
    }

    [HttpPut("{productId:guid}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> UpdateAsync(
        [FromRoute] Guid productId,
        [FromBody] UpdateProductRequest request,
        CancellationToken cancellationToken)
    {
        request.SetId(productId);

        return Ok(await _mediator.Send(request, cancellationToken));
    }


    [HttpDelete("{productId:guid}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> DeleteById(Guid productId,
        CancellationToken cancellationToken)
    {
        var input = new RemoveProductRequest()
        {
            Id = productId
        };

        return Ok(await _mediator.Send(input, cancellationToken));
    }
}