using DeliveryService.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DeliveryService.DAL
{
    internal class OrdersDBInitializer : DropCreateDatabaseIfModelChanges<OrdersContext>
    {
        protected override void Seed(OrdersContext context)
        {
            IList<Customer> defaultCustomers = new List<Customer>();
            defaultCustomers.Add(new Customer() { Name = "Allen", HasCoupon = true });
            defaultCustomers.Add(new Customer() { Name = "Bob", IsNewCustomer = true });
            defaultCustomers.Add(new Customer() { Name = "Chez", IsGoldRatedCustomer = true });
            defaultCustomers.Add(new Customer() { Name = "Don", Distance = 5 });
            defaultCustomers.Add(new Customer() { Name = "Elf", Distance = 5, FloorNumber = 3 });
            defaultCustomers.Add(new Customer() { Name = "Franck", Distance = 5, FloorNumber = 6 });
            defaultCustomers.Add(new Customer() { Name = "George", Distance = 15, FloorNumber = 6 });
            defaultCustomers.Add(new Customer() { Name = "Harry", Distance = 55, FloorNumber = 6 });
            context.Customers.AddRange(defaultCustomers);
            context.SaveChanges();

            var customers = context.Customers.ToDictionary(c => c.Name, c => c);
            IList<Order> defaultOrders = new List<Order>();
            defaultOrders.Add(new Order() { BaseCost = 999, IsPlacedOnWeekend = true });
            defaultOrders.Add(new Order() { BaseCost = 999, OrderedCustomer = customers["Allen"] });
            defaultOrders.Add(new Order() { BaseCost = 999, OrderedCustomer = customers["Bob"] });
            defaultOrders.Add(new Order() { BaseCost = 999, OrderedCustomer = customers["Chez"] });
            defaultOrders.Add(new Order() { BaseCost = 999, OrderedCustomer = customers["Don"] });
            defaultOrders.Add(new Order() { BaseCost = 999, OrderedCustomer = customers["Elf"] });
            defaultOrders.Add(new Order() { BaseCost = 999, OrderedCustomer = customers["Franck"] });
            defaultOrders.Add(new Order() { BaseCost = 999, OrderedCustomer = customers["George"] });
            defaultOrders.Add(new Order() { BaseCost = 999, OrderedCustomer = customers["Harry"] });
            context.Orders.AddRange(defaultOrders);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}