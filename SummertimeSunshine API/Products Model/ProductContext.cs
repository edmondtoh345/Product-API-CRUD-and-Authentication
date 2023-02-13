using Microsoft.EntityFrameworkCore;

namespace SummertimeSunshine_API.Products_Model
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Productlist> Productlist { get; set; }
        public DbSet<Userlist> Userlist { get; set; }

    }
}
