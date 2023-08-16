using System;
using System.Collections.Generic;

namespace _06_MVC_NorthwindCRUD.Models
{
    public partial class PahaliUrun
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string SupplierName { get; set; } = null!;
    }
}
