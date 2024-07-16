using System;
using System.Collections.Generic;

namespace APIBPO.Models;

public partial class Store
{
    public int StoreId { get; set; }

    public string? StoreName { get; set; }

    public virtual ICollection<Storeproductmapping> Storeproductmappings { get; set; } = new List<Storeproductmapping>();
}
