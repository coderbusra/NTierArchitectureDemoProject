using MediatR;
using NTierArchicture.Entites.Models;
using NTierArchicture.Entites.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Categories.RemoveCategory
{
    internal class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unityOfWork;

        public RemoveCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unityOfWork)
        {
            _categoryRepository = categoryRepository;
            _unityOfWork = unityOfWork;
        }

        public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetByIdAsync(p=> p.Id == request.Id, cancellationToken);
            if(category is null)
            {
                throw new ArgumentException("Category not found");
            }

            _categoryRepository.Remove(category);
            await _unityOfWork.SaveChangeAsync(cancellationToken);
        }
    }
}
