using e_ticaret_proje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace e_ticaret_proje.Controllers
{
    public class OrderController : Controller
    {
        Context context = new Context();
        public IActionResult Index(Order x)
        {
            var orders = context.Orders
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .Include(x => x.OrderStatus)
                .ToList();
            return View(orders);
        }
        [HttpGet]
        public IActionResult AddOrder()
        {
            ViewBag.customers = new SelectList(context.Customers.ToList(), "CustomerID", "Name");
            ViewBag.products = new SelectList(context.Products.ToList(), "ProductID", "Name");
            ViewBag.statuses = new SelectList(context.OrderStatuses.ToList(), "OrderStatusID", "StatusName");
            return View();
        }

        [HttpPost]
        public IActionResult AddOrder(Order o)
        {
            try
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "AddOrder";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@CustomerID", o.CustomerID));
                    command.Parameters.Add(new SqlParameter("@ProductID", o.ProductID));
                    command.Parameters.Add(new SqlParameter("@Quantity", o.Quantity));
                    command.Parameters.Add(new SqlParameter("@OrderStatusID", o.OrderStatusID));

                    context.Database.OpenConnection();
                    command.ExecuteNonQuery();
                }

                return RedirectToAction("Index");
            }
            catch (SqlException ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.customers = new SelectList(context.Customers.ToList(), "CustomerID", "Name");
                ViewBag.products = new SelectList(context.Products.ToList(), "ProductID", "Name");
                ViewBag.statuses = new SelectList(context.OrderStatuses.ToList(), "OrderStatusID", "StatusName");
                return View(o);
            }
        }

        [HttpGet]
        public IActionResult UpdateOrder(int id)
        {
            var order = context.Orders
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .Include(x => x.OrderStatus)
                .FirstOrDefault(x => x.OrderID == id);

            ViewBag.customers = new SelectList(context.Customers.ToList(), "CustomerID", "Name");
            ViewBag.products = new SelectList(context.Products.ToList(), "ProductID", "Name");
            ViewBag.statuses = new SelectList(context.OrderStatuses.ToList(), "OrderStatusID", "StatusName");
            return View(order);
        }

        [HttpPost]
        public IActionResult UpdateOrder(Order o)
        {
            try
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "UpdateOrder";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@OrderID", o.OrderID));
                    command.Parameters.Add(new SqlParameter("@ProductID", o.ProductID));
                    command.Parameters.Add(new SqlParameter("@Quantity", o.Quantity));
                    command.Parameters.Add(new SqlParameter("@OrderStatusID", o.OrderStatusID));

                    context.Database.OpenConnection();
                    command.ExecuteNonQuery();
                }

                return RedirectToAction("Index");
            }
            catch (SqlException ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.customers = new SelectList(context.Customers.ToList(), "CustomerID", "Name");
                ViewBag.products = new SelectList(context.Products.ToList(), "ProductID", "Name");
                ViewBag.statuses = new SelectList(context.OrderStatuses.ToList(), "OrderStatusID", "StatusName");
                return View(o);
            }
        }

        public IActionResult DeleteOrder(int id)
        {
            try
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "DeleteOrder";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@OrderID", id));

                    context.Database.OpenConnection();
                    command.ExecuteNonQuery();
                }

                return RedirectToAction("Index");
            }
            catch (SqlException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

    }
}
