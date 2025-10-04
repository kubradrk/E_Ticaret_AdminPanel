using e_ticaret_proje.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace e_ticaret_proje.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        Context context = new Context();
        public IActionResult Index()
        {
            ViewBag.TotalCustomers = context.Customers.Count();
            ViewBag.TotalProducts = context.Products.Count();
            ViewBag.PendingOrders = context.Orders.Count(o => o.OrderStatusID == 1);
            ViewBag.CompletedOrders = context.Orders.Count(o => o.OrderStatusID == 3);
            ViewBag.CancelledOrders = context.Orders.Count(o => o.OrderStatusID == 4);
            ViewBag.TotalRevenue = context.Orders.Sum(o => o.Quantity * o.Product.Price);

            return View();
        }

    }
}
