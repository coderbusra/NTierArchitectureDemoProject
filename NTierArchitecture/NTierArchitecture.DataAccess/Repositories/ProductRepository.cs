using NTierArchicture.Entites.Models;
using NTierArchicture.Entites.Repository;
using NTierArchitecture.DataAccess.Context;

namespace NTierArchitecture.DataAccess.Repositories;

internal sealed class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {

    }

}