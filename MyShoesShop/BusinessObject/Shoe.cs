using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Shoe
{
    public int ShoesId { get; set; }

    public string ShoesName { get; set; } = null!;

    public int? CategoryId { get; set; }

    public int? BrandId { get; set; }

    public decimal Size { get; set; }

    public string Color { get; set; } = null!;

    public int Price { get; set; }

    public int StockQuantity { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
