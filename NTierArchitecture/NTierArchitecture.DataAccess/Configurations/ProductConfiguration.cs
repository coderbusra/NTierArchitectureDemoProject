using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierArchicture.Entites.Models;

namespace NTierArchitecture.DataAccess.Configurations;

internal sealed class ProductConfiguration: IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");
        builder.HasKey(x=>x.Id);
        builder.Property(p=>p.Price).HasColumnType("money");
    }

}