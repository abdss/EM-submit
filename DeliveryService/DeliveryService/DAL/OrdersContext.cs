using DeliveryService.Models;
using System.Data.Entity;

namespace DeliveryService.DAL
{
    public class OrdersContext : DbContext
    {
        public OrdersContext()
            : base("MyConnectionString")
        {
            Database.SetInitializer(new OrdersDBInitializer());
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}