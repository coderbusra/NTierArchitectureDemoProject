using AutoMapper;
using MediatR;
using NTierArchicture.Entites.Models;
using NTierArchicture.Entites.Repository;

namespace NTierArchitecture.Business.Features.Categories.CreatCategory;

internal sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var isCategoryNameExists = await _categoryRepository.AnyAsync(p=> p.Name == request.Name, cancellationToken);

        if (isCategoryNameExists)
        {
            throw new ArgumentException("This category has been created before!");
        }

        Category category = _mapper.Map<Category>(request);

        await _categoryRepository.AddAsync(category, cancellationToken);
        await _unitOfWork.SaveChangeAsync(cancellationToken);
    }
}
