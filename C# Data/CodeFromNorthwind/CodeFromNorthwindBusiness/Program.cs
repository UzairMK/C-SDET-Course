using CodeFromNorthwindModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFromNorthwindBusiness
{
    class Program
    {
        static void Main()
        {
            using (var db = new NorthwindContext())
            {
                //Read
                //foreach (var item in db.Customers)
                //{
                //    Console.WriteLine(item.ContactName);
                //}

                ////Create
                //var newCustomer = new Customer()
                //{
                //    CustomerId = "UZZEC",
                //    CompanyName = "UzzeComputers",
                //    ContactName = "Uzair Khan",
                //    ContactTitle = "Mr."
                //};

                //db.Customers.Add(newCustomer);
                //db.SaveChanges();

                //Update
                ////Select a customer
                //var selectedCustomer = db.Customers.Where(c => c.CustomerId == "UZZEC").FirstOrDefault();
                //selectedCustomer.City = "Bedford";
                //db.SaveChanges();

                ////Delete
                //selectedCustomer = db.Customers.Where(c => c.CustomerId == "UZZEC").FirstOrDefault();
                //db.Customers.Remove(selectedCustomer);
                //db.SaveChanges();

                ////Deferring query
                //IQueryable<Customer> query1 =
                //    from c in db.Customers
                //    where c.City == "London"
                //    select c;

                ////Forcing query excution
                //var queryList = query1.ToList();

                //foreach (var item in query1)
                //{
                //    Console.WriteLine(item);
                //}

                //var x = new { Name = "Uzair" };

                //var londonBerlinQuery =
                //    from c in db.Customers
                //    where c.City == "London" || c.City == "Berlin"
                //    select c;

                //foreach (var item in londonBerlinQuery)
                //{
                //    Console.WriteLine(item);
                //}

                //var londonBerlinQuery2 =
                //    from c in db.Customers
                //    where c.City == "London" || c.City == "Berlin"
                //    select new { CustomerName = c.CompanyName, ContactName = c.ContactName };

                //foreach (var item in londonBerlinQuery2)
                //{
                //    Console.WriteLine(item);
                //}

                ////Group by
                //var group =
                //    from p in db.Products
                //    group p by p.SupplierId into newGroup
                //    orderby newGroup.Sum(c => c.UnitsInStock) descending
                //    select new
                //    {
                //        SupplierID = newGroup.Key,
                //        UnitOnStock = newGroup.Sum(c => c.UnitsInStock)
                //    };

                //foreach (var item in group)
                //{
                //    Console.WriteLine(item);
                //}

                //var y = db.Products.GroupBy(c => c.CategoryId); //Doesn't work

                //foreach (var item in y)
                //{
                //    Console.WriteLine(item);
                //}

                //Order by
                //var orderProductsByUnitPrice =
                //    from p in db.Products
                //    orderby p.UnitPrice descending
                //    select p;

                //orderProductsByUnitPrice.ToList().ForEach(x => Console.WriteLine($"{x.ProductId} - {x.UnitPrice}"));


                //CRUD operations

                //Create
                //var customer = new Customer()
                //{
                //    CustomerId = "HARDI",
                //    ContactName = "Callum",
                //    CompanyName = "Sparta Global"
                //};

                //db.Customers.Add(customer);
                //db.SaveChanges();

                //var callumInCustomers =
                //    from c in db.Customers
                //    where c.CustomerId == "HARDI"
                //    select c;

                //foreach (var item in callumInCustomers)
                //{
                //    Console.WriteLine(item);
                //    db.Customers.Remove(item);
                //}

                //db.SaveChanges();

                //var nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                //var evenNums = nums.Count(IsEven);
                //Console.WriteLine(evenNums);
                //var oddNums = nums.Count(c => !IsEven(c));
                //Console.WriteLine(oddNums);
                //var evenCount = nums.Count(delegate (int x) { return x % 2 == 0; });


                ////Where clause in method syntax
                //var customerQuery = db.Customers.Where(c => c.City == "Berlin");

                //foreach (var item in customerQuery)
                //{
                //    Console.WriteLine(item);
                //}

                ////GroupBy method syntax
                //var groupProductsByUnitInStockQuery = 
                //    db.Products
                //    .GroupBy(x => x.SupplierId)
                //    .Select(newGroup => new
                //    {
                //        SupplierId = newGroup.Key,
                //        UnitInStock = newGroup.Sum(c => c.UnitsInStock)
                //    });

                //foreach (var item in groupProductsByUnitInStockQuery)
                //{
                //    Console.WriteLine(item);
                //}

                ////OrderBy method Syntax
                //var orderProductsByUnitInStockQuery =
                //    db.Products
                //    .OrderBy(x => x.UnitsInStock)
                //    .ThenByDescending(x => x.QuantityPerUnit)
                //    .Select(x => new
                //    {
                //        Name = x.Supplier,
                //        UnitsInStock = x.UnitsInStock,
                //        QuantityPerUnit = x.QuantityPerUnit
                //    });

                //foreach (var item in orderProductsByUnitInStockQuery)
                //{
                //    Console.WriteLine(item);
                //}

                //CRUD operations
                //Create
                //var newCustomer = new Customer
                //{
                //    CustomerId = "UZZEC",
                //    ContactName = "Uzair",
                //    City = "Bedford",
                //    CompanyName = "UzzeComputers"
                //};

                //db.Customers.Add(newCustomer);
                //db.SaveChanges();

                //Read
                //var read1 = db.Customers.Find("UZZEC");
                //var read2 = db.Customers.Where(x => x.CustomerId == "UZZEC");
                //var read3 = read2.FirstOrDefault();
                //var read4 = db.Customers.Where(x => x.CustomerId == "UZZEC").Select(x => x.ContactName).FirstOrDefault();
                //var read5 = db.Customers.Where(x => x.CustomerId == "UZZEC").Select(x => new { ContactName = x.ContactName });

                //Console.WriteLine(read1);
                //read2.ToList().ForEach(x => Console.WriteLine(x.ContactName));
                //Console.WriteLine(read3);
                //Console.WriteLine(read4);
                //Console.WriteLine(read5);

                ////Update
                //db.Customers.Find("UZZEC").City = "Wootton";
                //db.Customers.Where(x => x.CustomerId == "UZZEC").FirstOrDefault().City = "Wootton";

                //db.SaveChanges();

                ////Delete
                //var delete1 = db.Customers.Find("UZZEC");
                //var delete2 = db.Customers.Where(x => x.CustomerId == "UZZEC").FirstOrDefault();

                //db.Customers.Remove(delete2);

                //db.SaveChanges();

                //var orderQuery =
                //    from o in db.Orders
                //    join c in db.Customers on o.CustomerId equals c.CustomerId
                //    where o.Freight > 750
                //    select o;

                //foreach (var item in orderQuery)
                //{
                //    Console.WriteLine(item.Customer.ContactName + " " + item.OrderId);
                //}

                //var orderQuery2 =
                //    from o in db.Orders.Include(x => x.Customer).Include(x => x.Employee)
                //    where o.Freight > 750
                //    select o;

                //foreach (var item in orderQuery2)
                //{
                //    Console.WriteLine(item);
                //}

                //var orderQueryWithCust =
                //    db.Orders.Include(o => o.Customer)
                //    .Include(o => o.OrderDetails)
                //    .ThenInclude(od => od.Product);

                //foreach (var item in orderQueryWithCust)
                //{
                //    Console.WriteLine($"Order {item.OrderId} was made by {item.Customer.CompanyName}");
                //    foreach (var od in item.OrderDetails)
                //    {
                //        Console.WriteLine($"   Product: {od.Product.ProductName}, Quantity: {od.Quantity}");
                //    }
                //}

            }
        }

        public static int bMethod(int x) => x * x;

        public static bool IsEven(int x) => x % 2 == 0;
    }
}
