using Microsoft.EntityFrameworkCore;
using TheShop.Domain.Model;

namespace TheShop.Dal.InMemory
{
    public class TheShopDbContext : DbContext 
    {
        public TheShopDbContext(DbContextOptions<TheShopDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasKey(x => x.ArticleRef);
            modelBuilder.Entity<Customer>().HasKey(x => x.CustomerRef);
            modelBuilder.Entity<BasketItem>().HasKey(x => x.BasketItemRef);
            modelBuilder.Entity<Order>().HasKey(x => x.OrderRef);
            modelBuilder.Entity<OrderItem>().HasKey(x => x.OrderItemRef);
        }
    }
}
