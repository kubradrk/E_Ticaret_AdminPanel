using Microsoft.EntityFrameworkCore;

namespace e_ticaret_proje.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "server=DESKTOP-45MQEVD\\SQLEXPRESS;database=E_TicaretDB;integrated security=true;TrustServerCertificate=True;"
            );

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
    }
}
