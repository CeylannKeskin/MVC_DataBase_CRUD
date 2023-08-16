using Microsoft.AspNetCore.Mvc.Rendering;

namespace _06_MVC_NorthwindCRUD.Models.ViewModel
{
    public class ProductsModel
    {
        public Product Product { get; set; }
        public List<ProductDto> plist { get; set; }
        public List<SelectListItem> CategoriesForDropDown { get; set; }
        public List<SelectListItem> SupplierForDropDown { get; set; }

    }
}
