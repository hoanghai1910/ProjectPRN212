using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Brand
{
    public int BrandId { get; set; }

    public string BrandName { get; set; } = null!;

    public virtual ICollection<Shoe> Shoes { get; set; } = new List<Shoe>();
}
