using MediatR;
using NTierArchicture.Entites.Models;
using NTierArchicture.Entites.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Products.RemoveProduct
{
    internal sealed class RemoveProductByIdCommandHandler : IRequestHandler<RemoveProductByIdCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RemoveProductByIdCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveProductByIdCommand request, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.GetByIdAsync(p=>p.Id == request.Id, cancellationToken);

            if(product is null)
            {
                throw new ArgumentException("Product not found");
            }

            _productRepository.Remove(product);
            await _unitOfWork.SaveChangeAsync(cancellationToken);
        }
    }
}
