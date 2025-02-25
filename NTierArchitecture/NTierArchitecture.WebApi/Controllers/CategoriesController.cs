using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Features.Categories.CreatCategory;
using NTierArchitecture.Business.Features.Categories.GetCategories;
using NTierArchitecture.Business.Features.Categories.RemoveCategoryById;
using NTierArchitecture.Business.Features.Categories.UpdateCategory;
using NTierArchitecture.WebApi.Abstractions;

namespace NTierArchitecture.WebApi.Controllers;

[Route("api/[controller]")]

[ApiController]
public sealed class CategoriesController : ApiController
{
    public CategoriesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);

        return NoContent();
    }

    [HttpPost("Update")]
    public async Task<IActionResult> Update(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);

        return NoContent();
    }

    [HttpPost("RemoveById")]
    public async Task<IActionResult> RemoveById(RemoveCategoryByIdCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);

        return NoContent();
    }

    [HttpPost("GetAll")]
    public async Task<IActionResult> GetAll(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }
}
