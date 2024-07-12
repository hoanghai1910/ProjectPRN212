using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class OrderDetail
{
    public int OrderId { get; set; }

    public int ShoesId { get; set; }

    public int Quantity { get; set; }

    public int Price { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Shoe Shoes { get; set; } = null!;
}
