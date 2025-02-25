using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Products.CreateProduct
{
    public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator() 
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Product name connot be empty");
            RuleFor(p => p.Name).NotNull().WithMessage("Product name connot be empty");
            RuleFor(p => p.Name).MinimumLength(3).WithMessage("Product name must be at least 3 characters");
            RuleFor(p => p.CategoryId).NotNull().WithMessage("Product price cannot be empty");
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("The product price cannot be the same");
            RuleFor(p => p.Price).GreaterThan(0).WithMessage("Product price cannot be 0");
            RuleFor(p => p.Quantity).GreaterThan(0).WithMessage("Product quantity cannot be 0");
        }
    }
}
