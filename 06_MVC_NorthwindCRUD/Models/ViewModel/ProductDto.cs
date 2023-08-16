namespace _06_MVC_NorthwindCRUD.Models.ViewModel
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string SupplierName { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Discontinued { get; set; }
    }
}
