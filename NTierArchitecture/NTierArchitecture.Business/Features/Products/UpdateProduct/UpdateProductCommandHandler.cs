using AutoMapper;
using MediatR;
using NTierArchicture.Entites.Models;
using NTierArchicture.Entites.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Products.UpdateProduct;

internal sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        Product product = await _productRepository.GetByIdAsync(p=> p.Id == request.Id, cancellationToken);

        if(product is null)
        {
            throw new ArgumentException("Product not found");
        }

        if (product.Name != request.Name)
        {
            bool isProductNameIsExist = await _productRepository.AnyAsync(p=> p.Name == request.Name, cancellationToken);
            if (isProductNameIsExist)
            {
                throw new ArgumentException("This product name has been used before");
            }
        }

        _mapper.Map(request, product);

        await _unitOfWork.SaveChangeAsync(cancellationToken);
    }

    
}
