using e_ticaret_proje.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_ticaret_proje.Controllers
{
    public class CustomerController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var values = context.Customers.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer c)
        {
            context.Customers.Add(c);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteCustomer(int id)
        {
            var customer = context.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
            if (customer != null) {
                context.Remove(customer);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var customer = context.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
            return View(customer);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer c)
        {
            var customer = context.Customers.Where(x => x.CustomerID == c.CustomerID).FirstOrDefault();
            if (customer != null)
            {
                customer.Name = c.Name;
                customer.Email = c.Email;
                customer.Phone = c.Phone;
                customer.City = c.City;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
