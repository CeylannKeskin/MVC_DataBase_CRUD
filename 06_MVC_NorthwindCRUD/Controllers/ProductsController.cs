using _06_MVC_NorthwindCRUD.Models;
using _06_MVC_NorthwindCRUD.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace _06_MVC_NorthwindCRUD.Controllers
{
    public class ProductsController : Controller
    {
        NorthwindContext dB;

        public ProductsController(NorthwindContext db)
        {
            dB = db;
        }
        ProductsModel pm=new ProductsModel();
        public IActionResult UrunListesi()
        {
            pm.plist = dB.Products.Select(x => new ProductDto()
            {
                CategoryName = x.Category.CategoryName,
                SupplierName = x.Supplier.CompanyName,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                Discontinued = x.Discontinued,
                UnitPrice = (decimal)x.UnitPrice,
            }).ToList();
            return View(pm);
        }
        public IActionResult Detay(int id)
        {
            pm.Product = dB.Products.Find(id);
            return View(pm);
        }
        public IActionResult Guncelle(int id)
        {
            pm.Product = dB.Products.Find(id);
            pm.CategoriesForDropDown = FillCategory();
            pm.SupplierForDropDown = FillSupplier();
            return View(pm);
        }
        [HttpPost]
        public IActionResult Guncelle(int id,ProductsModel pm)
        {
            Product product=dB.Products.Find(id);
            product.ProductName = pm.Product.ProductName;
            product.SupplierId = pm.Product.SupplierId;
            product.CategoryId = pm.Product.CategoryId;
            product.UnitPrice = pm.Product.UnitPrice;
            dB.SaveChanges();
            return RedirectToAction("UrunListesi");
        }
        public IActionResult Ekle()
        {
            pm.CategoriesForDropDown = FillCategory();
            pm.SupplierForDropDown = FillSupplier();
            return View(pm);
        }
        [HttpPost]
        public IActionResult Ekle(ProductsModel pm)
        {
            dB.Products.Add(pm.Product);
            dB.SaveChanges();
            return RedirectToAction("UrunListesi");
        }
        public IActionResult Sil(int id)
        {
            dB.Products.Remove(dB.Products.Find(id));
            dB.SaveChanges();
            return RedirectToAction(nameof(UrunListesi));
        }
        private List<SelectListItem> FillSupplier()
        {
            return dB.Suppliers.Select(x => new SelectListItem()
            {
                Text = x.CompanyName,
                Value = x.SupplierId.ToString()
            }).ToList();
        }

        private List<SelectListItem> FillCategory()
        {
            return dB.Categories.Select(x => new SelectListItem()
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();
        }
    }
}
