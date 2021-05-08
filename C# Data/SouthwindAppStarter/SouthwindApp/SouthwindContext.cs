using Microsoft.EntityFrameworkCore;

namespace SouthwindApp
{
    public partial class SouthwindContext : DbContext
    {
        public static SouthwindContext Instance { get; } = new SouthwindContext();

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Southwind;");
            }
        }
    }
}
