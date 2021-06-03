using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SouthwindApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SouthwindContext())
            {
                //db.Add(new Customer { City = "Bedford", ContactName = "Uzair", Country = "UK", CustomerId = "UZZEC", PostalCode = "MAD45AS" });
                //db.Add(new Customer { City = "Bedford", ContactName = "Uzair", Country = "UK", CustomerId = "UZZEG", PostalCode = "MAD45AS" });

                //db.SaveChanges();

                //db.Customers.Remove(db.Customers.Find("UZZEC"));
                //db.Customers.Remove(db.Customers.Find("UZZEG"));

                //db.SaveChanges();

                //Create order
                //var customer = db.Customers.Find("UZZEC");
                //customer.Orders.Add(new() { CustomerId = "UZZEC", OrderDate = DateTime.Now, ShipCountry = "UK" });
                //db.SaveChanges();

                //db.Add(new Order() { CustomerId = "UZZEC", Customer = customer, OrderDate = DateTime.Now, ShipCountry = "USA" });
                //db.SaveChanges();

                //db.Add(new Order() { CustomerId = "UZZEC", OrderDate = DateTime.Now, ShipCountry = "USA" });
                //db.SaveChanges();

                //db.Add(new Order() { OrderDate = DateTime.Now, ShipCountry = "USA" });
                //db.SaveChanges();

                //customer.Orders.ToList().ForEach(x => Console.WriteLine(x.ShipCountry));

                //customer =
                //    db.Customers
                //    .Include(x => x.Orders)
                //    .Where(x => x.CustomerId == "UZZEC")
                //    .FirstOrDefault();

                //customer.Orders.ToList().ForEach(x => Console.WriteLine(x.ShipCountry));


                //db.Orders.ToList().ForEach(x => Console.WriteLine(x.ShipCountry));
                //db.Orders.ToList().ForEach(x => Console.WriteLine(x.Customer.ContactName));

                //var order = db.Orders.Find(9);

                //var orderDetail1 = new OrderDetail() { Discount = 0.05f, Quantity = 2, UnitPrice = 6, ProductId = 7 };
                //var orderDetail2 = new OrderDetail() { Discount = 0.1f, Quantity = 1, UnitPrice = 8 ,ProductId = 8 };

                //var orderDetailList = new List<OrderDetail>();

                //orderDetailList.Add(orderDetail1);
                //orderDetailList.Add(orderDetail2);

                //order.OrderDetails = orderDetailList;
                //db.SaveChanges();

                //var custQuery = db.Customers.OrderBy(c => c.ContactName);

                //foreach (var item in custQuery.Include(c => c.Orders))
                //{
                //    Console.WriteLine($"{item.ContactName} lives in {item.City}");

                //    foreach (var o in item.Orders)
                //    {
                //        Console.WriteLine($"   {o.OrderId} was made on {o.OrderDate}");
                //    }
                //}

                //var orderDetails = db.OrderDetails.Include(c => c.Order).ThenInclude(c => c.Customer);

                //orderDetails.ToList().ForEach(x => Console.WriteLine($"Customer: {x.Order.Customer.ContactName}, Order: {x.Order.OrderId}, OrderPrice: {x.UnitPrice}"));

                var customers =
                    from Customer c in db.Customers
                    where c.CustomerId == "UZAIR"
                    select c;
            }
        }
    }
}
