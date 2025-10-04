using e_ticaret_proje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace e_ticaret_proje.Controllers
{
    public class ProductController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var values = context.Products.Include(x => x.Category).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.Categories = new SelectList(context.Categories.ToList(), "CategoryID", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            context.Products.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            var product = context.Products.Where(x => x.ProductID == id).FirstOrDefault();
            context.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var product = context.Products.Where(x => x.ProductID == id).FirstOrDefault();
            return View(product);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product p)
        {
            var product = context.Products.Where(x => x.ProductID == p.ProductID).FirstOrDefault();
            product.Name = p.Name;
            product.Price = p.Price;
            product.Stock = p.Stock;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
