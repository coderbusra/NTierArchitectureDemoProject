using NTierArchicture.Entites.Models;
using NTierArchicture.Entites.Repository;
using NTierArchitecture.DataAccess.Context;

namespace NTierArchitecture.DataAccess.Repositories;

internal sealed class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context) 
    {

    }

}
