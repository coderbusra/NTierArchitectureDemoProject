using AutoMapper;
using MediatR;
using NTierArchicture.Entites.Models;
using NTierArchicture.Entites.Repository;

namespace NTierArchitecture.Business.Features.Categories.UpdateCategory;

internal sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = await _categoryRepository.GetByIdAsync(p => p.Id == request.Id);
        if (category is null)
        {
            throw new ArgumentException("Category not found!");
        }

        if (category.Name != request.Name)
        {
            var isCategoryExists = await _categoryRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

            if (isCategoryExists)
            {
                throw new ArgumentException("This category has been created before!");
            }

            _mapper.Map(request, category);

            await _unitOfWork.SaveChangeAsync(cancellationToken);
        }
    }
}
