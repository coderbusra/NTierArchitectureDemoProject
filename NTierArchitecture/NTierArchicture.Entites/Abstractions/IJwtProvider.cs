using NTierArchicture.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchicture.Entities.Abstractions
{
    public interface IJwtProvider
    {
        Task<string> CreateTokenAsync(AppUser user);
    }
}
