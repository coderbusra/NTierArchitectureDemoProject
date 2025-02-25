using NTierArchicture.Entites.Models;
using NTierArchicture.Entites.Repository;
using NTierArchitecture.DataAccess.Context;

namespace NTierArchitecture.DataAccess.Repositories;

internal sealed class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(ApplicationDbContext context) : base(context)
    {

    }

}