using AutoMapper;
using MediatR;
using NTierArchicture.Entites.Models;
using NTierArchicture.Entites.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Products.CreateProduct
{
    internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            bool isProductNameIsExists = await _productRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

            if (isProductNameIsExists)
            {
                throw new ArgumentException("This product name has been used before!");
            }

            Product product = _mapper.Map<Product>(request);

            await _productRepository.AddAsync(product, cancellationToken);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
