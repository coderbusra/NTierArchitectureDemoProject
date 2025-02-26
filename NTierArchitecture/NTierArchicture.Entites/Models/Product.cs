﻿using NTierArchicture.Entites.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchicture.Entites.Models;
public sealed class Product : Entity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public Guid CategoryId { get; set; }
}
