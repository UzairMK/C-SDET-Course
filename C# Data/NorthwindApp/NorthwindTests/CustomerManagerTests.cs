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
        public void WhenANewCustomerIsAdded_TheNumberOfCustomersIncreasesBy1()
        {
            using (var db = new NorthwindContext())
            {
                var expected = _customerManager.RetrieveAllCustomers().Count() + 1;
                _customerManager.Create("MANDA", "Nish", "Sparta Global", "Birmingham");
                var actual = _customerManager.RetrieveAllCustomers().Count();
                Assert.AreEqual(expected, actual);
            }
        }

        [Test]
        public void WhenACustomersDetailsAreChanged_TheDatabaseIsUpdated()
        {
            using (var db = new NorthwindContext())
            {
                _customerManager.Create("MANDA", "Nish", "Sparta Global", "Birmingham");
                _customerManager.SetSelectedCustomer("MANDA");
                var beforeUpdate = _customerManager.SelectedCustomer;
                Assert.IsNull(_customerManager.SelectedCustomer.PostalCode);
                _customerManager.UpdateCustomer("MANDA", "Nash", "Birmingham", "MA23 6GF", "UK");
                _customerManager.SetSelectedCustomer("MANDA");
                var afterUpdate = _customerManager.SelectedCustomer;
                Assert.AreEqual("Nash", _customerManager.SelectedCustomer.ContactName);
                Assert.AreEqual("MA23 6GF", _customerManager.SelectedCustomer.PostalCode);
                Assert.AreNotEqual(beforeUpdate, afterUpdate);
            }
        }

        [Test]
        public void WhenACustomerIsRemoved_TheyAreNoLongerInTheDatabase()
        {
            using (var db = new NorthwindContext())
            {
                _customerManager.Create("MANDA", "Nish", "Sparta Global", "Birmingham");
                _customerManager.SetSelectedCustomer("MANDA");
                Assert.AreEqual("MANDA", _customerManager.SelectedCustomer.CustomerId);
                _customerManager.DeleteCustomer("MANDA");
                _customerManager.SetSelectedCustomer("MANDA");
                Assert.IsNull(_customerManager.SelectedCustomer);
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