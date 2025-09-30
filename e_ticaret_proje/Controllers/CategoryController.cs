using e_ticaret_proje.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_ticaret_proje.Controllers
{
    public class CategoryController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var values = context.Categories.ToList();
            return View(values);
        }
        public IActionResult DeleteCategory(int id)
        {
            var category = context.Categories.Where(x => x.CategoryID == id).FirstOrDefault();
            if (category != null)
            {
                context.Remove(category);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var category = context.Categories.Where(x => x.CategoryID == id).FirstOrDefault();
            return View(category);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category c)
        {
            var category = context.Categories.Where(x => x.CategoryID == c.CategoryID).FirstOrDefault();
            if (category != null)
            {
                category.Name = c.Name;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category c)
        {
            context.Categories.Add(c);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
