using CodeFromNorthwindModel;
using System;
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


            }
        }
    }
}
