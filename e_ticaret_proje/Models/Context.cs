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
    }
}
