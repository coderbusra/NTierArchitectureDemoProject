using MediatR;
using Microsoft.EntityFrameworkCore;
using NTierArchicture.Entites.Models;
using NTierArchicture.Entites.Repository;

namespace NTierArchitecture.Business.Features.Categories.GetCategories;

internal sealed class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<Category>>
{
    private readonly ICategoryRepository _categoryRepository;
    

    public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _categoryRepository.GetAll().OrderBy(p => p.Name).ToListAsync(cancellationToken);
    }
}

