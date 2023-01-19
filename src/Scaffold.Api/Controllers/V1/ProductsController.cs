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
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetAsunc([FromQuery] GetAllProductsRequest request,
        CancellationToken cancellationToken)
    {
        var serviceResult = await _mediator.Send(request, cancellationToken);

        if (serviceResult.StatusCode == HttpStatusCode.BadRequest)
            return BadRequest(serviceResult);

        if (serviceResult.StatusCode == HttpStatusCode.NotFound)
            return NotFound(serviceResult);

        return Ok(serviceResult);
    }

    [HttpGet("{productId:guid}")]
    [ProducesResponseType(typeof(ServiceResult<GetProductByIdResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid productId,
        CancellationToken cancellationToken)
    {
        var input = new GetProductByIdRequest()
        {
            Id = productId
        };

        var serviceResult = await _mediator.Send(input, cancellationToken);

        if (serviceResult.StatusCode == HttpStatusCode.BadRequest)
            return BadRequest(serviceResult);

        if (serviceResult.StatusCode == HttpStatusCode.NotFound)
            return NotFound(serviceResult);

        return Ok(serviceResult);
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> PostAsunc([FromBody] NewProductRequest request,
        CancellationToken cancellationToken)
    {
        var serviceResult = await _mediator.Send(request, cancellationToken);

        if (serviceResult.StatusCode == HttpStatusCode.BadRequest)
            return BadRequest(serviceResult);

        return Created($"{Request.Scheme}://{Request.Host}/v1/products/{serviceResult.Data.Id}", serviceResult);
    }

    [HttpPut("{productId:guid}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> UpdateAsync(
        [FromRoute] Guid productId,
        [FromBody] UpdateProductRequest request,
        CancellationToken cancellationToken)
    {
        request.SetId(productId);

        var serviceResult = await _mediator.Send(request, cancellationToken);

        if (serviceResult.StatusCode == HttpStatusCode.BadRequest)
            return BadRequest(serviceResult);

        if (serviceResult.StatusCode == HttpStatusCode.NotFound)
            return NotFound(serviceResult);

        return NoContent();
    }


    [HttpDelete("{productId:guid}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> DeleteById(Guid productId,
        CancellationToken cancellationToken)
    {
        var input = new RemoveProductRequest()
        {
            Id = productId
        };

        var serviceResult = await _mediator.Send(input, cancellationToken);

        if (serviceResult.StatusCode == HttpStatusCode.BadRequest)
            return BadRequest(serviceResult);

        if (serviceResult.StatusCode == HttpStatusCode.NotFound)
            return NotFound(serviceResult);

        return NoContent();
    }
}