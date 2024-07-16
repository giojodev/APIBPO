using System;
using System.Collections.Generic;

namespace APIBPO.Models;

public partial class Storeproductmapping
{
    public int MappingId { get; set; }

    public int StoreId { get; set; }

    public int ProductId { get; set; }

    public int? Stock { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
