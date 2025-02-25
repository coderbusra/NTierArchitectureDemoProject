using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Features.Products.CreateProduct;
using NTierArchitecture.Business.Features.Products.RemoveProduct;
using NTierArchitecture.Business.Features.Products.UpdateProduct;
using NTierArchitecture.Business.Features.Products.GetProduct;
using NTierArchitecture.WebApi.Abstractions;

namespace NTierArchitecture.WebApi.Controllers;

[Route("api/[controller]")]

[ApiController]
public sealed class ProductsController : ApiController
{
    public ProductsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        
        return NoContent();
    }

    [HttpPost("Update")]
    public async Task<IActionResult> Update(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);

        return NoContent();
    }

    [HttpPost("RemoveById")]
    public async Task<IActionResult> RemoveById(RemoveProductByIdCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);

        return NoContent();
    }

    [HttpPost("GetAll")]
    public async Task<IActionResult> GetAll(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }
}
