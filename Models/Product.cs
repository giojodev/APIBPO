using System;
using System.Collections.Generic;

namespace APIBPO.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public virtual ICollection<Storeproductmapping> Storeproductmappings { get; set; } = new List<Storeproductmapping>();
}
