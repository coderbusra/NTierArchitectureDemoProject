using MediatR;
using NTierArchicture.Entites.Models;
using NTierArchicture.Entites.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Categories.RemoveCategoryById
{
    internal sealed class RemoveCategoryByIdCommandHandler : IRequestHandler<RemoveCategoryByIdCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RemoveCategoryByIdCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetByIdAsync(p => p.Id == request.Id, cancellationToken);

            if (category is null)
            {
                throw new ArgumentException("Category not found");
            }

            _categoryRepository.Remove(category);
            await _unitOfWork.SaveChangeAsync(cancellationToken);
        }
    }
}
