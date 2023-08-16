using System;
using System.Collections.Generic;

namespace _06_MVC_NorthwindCRUD.Models
{
    public partial class ProductsAboveAveragePrice
    {
        public string ProductName { get; set; } = null!;
        public decimal? UnitPrice { get; set; }
    }
}
