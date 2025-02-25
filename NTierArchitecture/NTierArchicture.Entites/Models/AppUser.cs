using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchicture.Entites.Models
{
    public sealed class AppUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
    }
}
