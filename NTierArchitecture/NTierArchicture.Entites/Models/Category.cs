using NTierArchicture.Entites.Abstractions;

namespace NTierArchicture.Entites.Models;

public sealed class Category : Entity
{
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }
}
