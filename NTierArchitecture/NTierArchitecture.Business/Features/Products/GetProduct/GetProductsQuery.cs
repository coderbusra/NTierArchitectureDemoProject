using MediatR;
using NTierArchicture.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Products.GetProduct;

public sealed record GetProductsQuery(): IRequest<List<Product>>;
