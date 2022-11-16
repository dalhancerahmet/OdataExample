using Microsoft.EntityFrameworkCore;

namespace OdataExample
{
    public class OdataContext : DbContext
    {
        public OdataContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
