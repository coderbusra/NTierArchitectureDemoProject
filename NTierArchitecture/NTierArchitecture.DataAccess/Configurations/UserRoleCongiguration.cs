using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierArchicture.Entites.Models;

namespace NTierArchitecture.DataAccess.Configurations;

internal sealed class UserRoleCongiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure (EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRoles");
        builder.HasKey(p=> new {p.AppUserId, p.AppRoleId});
    }
}