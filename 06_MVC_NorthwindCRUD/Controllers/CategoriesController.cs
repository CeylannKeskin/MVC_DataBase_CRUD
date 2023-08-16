using _06_MVC_NorthwindCRUD.Models;
using _06_MVC_NorthwindCRUD.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace _06_MVC_NorthwindCRUD.Controllers
{
    public class CategoriesController : Controller
    {
        NorthwindContext db;
        public CategoriesController(NorthwindContext _db)
        {
            db = _db;
        }
        CategoriesModel model = new CategoriesModel();
        public IActionResult Liste(string name)
        {
            if (name == null)
            {
                name = "";
            }
            model.clist = db.Categories.Where(x=>x.CategoryName.Contains(name)).ToList();
            return View(model);
        }
        public IActionResult Detay(int id)
        {
            model.Category = db.Categories.FirstOrDefault(x => x.CategoryId.Equals(id));
            return View(model);
        }


        public IActionResult Güncelle(int id)
        {
            model.Category = db.Categories.FirstOrDefault(x => x.CategoryId==id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Güncelle(int id,CategoriesModel categoriesModel)
        {
            //orjinal modelle çalışılıcak çünkü veritabanındaki değeri değiştiriyor olacağız
            Category secilenCategory = db.Categories.Find(id); //listede secilen id ye ait categoryi veritabanında arar getiririz.
            secilenCategory.CategoryName = categoriesModel.Category.CategoryName;
            secilenCategory.Description = categoriesModel.Category.Description;

            db.SaveChanges();
            return RedirectToAction("Liste");
        }
        public IActionResult Sil(int id)
        {
            db.Categories.Remove(db.Categories.Find(id));
            db.SaveChanges();
            TempData["mesaj"] = "Silme İşlemi Başarılı";
            return RedirectToAction("Liste");
        }
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Ekle(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            TempData["mesaj"] = category.CategoryName +"isimli Ekleme İşlemi Başarılı";
            return RedirectToAction("Liste");
        }
    }
}
