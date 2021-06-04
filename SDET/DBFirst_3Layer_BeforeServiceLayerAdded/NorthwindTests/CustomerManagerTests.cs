using NUnit.Framework;
using NorthwindBusiness;
using NorthwindData;
using System.Linq;

namespace NorthwindTests
{
    public class CustomerTests
    {
        CustomerManager _customerManager;
        [SetUp]
        public void Setup()
        {
            _customerManager = new CustomerManager();
            // remove test entry in DB if present
            using (var db = new NorthwindContext())
            {
                var selectedCustomers =
                from c in db.Customers
                where c.CustomerId == "MANDA"
                select c;

                db.Customers.RemoveRange(selectedCustomers);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenANewCustomerIsAdded_TheNumberOfCustemersIncreasesBy1()
        {
            using (var db = new NorthwindContext())
            {
                var numberOfCustomersBefore = db.Customers.Count();
                _customerManager.CreateCustomer("MANDA", "Nish Mandal", "Birmingham");
                var numberOfCustomersAfter = db.Customers.Count();

                Assert.AreEqual(numberOfCustomersBefore + 1, numberOfCustomersAfter);
            }
        }

        [Test]
        public void WhenACustomersDetailsAreChanged_TheDatabaseIsUpdated()
        {
            using (var db = new NorthwindContext())
            {
                _customerManager.CreateCustomer("MANDA", "Nish Mandal", "Paris");

                _customerManager.UpdateCustomer("MANDA", "Nish Mandal", "Birmingham", null, null, "Sparta");

                var updatedCustomer = db.Customers.Find("MANDA");
                Assert.AreEqual("Birmingham", updatedCustomer.City);
            }
        }

        [Test]

        public void WhenACustomerIsRemoved_TheyAreNoLongerInTheDatabase()
        {
            using (var db = new NorthwindContext())
            {

                var newCustomer = new Customer()
                {
                    CustomerId = "MANDA",
                    ContactName = "Nish Mandal",
                    CompanyName = "Sparta Global"
                };

                db.Customers.Add(newCustomer);

                db.SaveChanges();

                var numberOfCustomersBefore = db.Customers.ToList().Count();

                _customerManager.DeleteCustomer("MANDA");

                var numberOfCustomersAfter = db.Customers.ToList().Count();

                Assert.AreEqual(numberOfCustomersBefore - 1, numberOfCustomersAfter);


            }
        }


        [TearDown]
        public void TearDown()
        {
            using (var db = new NorthwindContext())
            {
                var selectedCustomers =
                from c in db.Customers
                where c.CustomerId == "MANDA"
                select c;

                db.Customers.RemoveRange(selectedCustomers);
                db.SaveChanges();
            }
        }
    }
}