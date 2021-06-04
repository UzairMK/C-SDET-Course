using NUnit.Framework;
using NorthwindBusiness;
using NorthwindData;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NorthwindTests
{
    public class CustomerServiceTests
    {
        private CustomerService _sut;
        private NorthwindContext _context;

        [OneTimeSetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<NorthwindContext>().UseInMemoryDatabase(databaseName: "Example_Db").Options;
            _context = new NorthwindContext(options);
            _sut = new CustomerService(_context);

            _sut.CreateCustomer(new Customer() { CustomerId="UZAIR", ContactName="Uzair", CompanyName="Sparta Global", City="Bedford" });
            _sut.CreateCustomer(new Customer() { CustomerId="UZAI2", ContactName="Uzair2", CompanyName="Sparta Global", City="Bedford" });
        }

        [Test]
        public void GivenANewCustomer_NewCustomerAddedToDatabase()
        {
            var numberOfCustomersBefore = _context.Customers.Count();
            var newCustomer = new Customer() { CustomerId = "UZAI3", ContactName = "Uzair3", CompanyName = "Sparta Global", City = "Bedford" };
            _sut.CreateCustomer(newCustomer);
            var numberOfCustomersAfter = _context.Customers.Count();

            Assert.That(numberOfCustomersAfter, Is.EqualTo(numberOfCustomersBefore + 1));
            var result = _sut.GetCustomerById("UZAI3");
            Assert.That(result.ContactName, Is.EqualTo("Uzair3"));
            Assert.That(result.CompanyName, Is.EqualTo("Sparta Global"));
            Assert.That(result.City, Is.EqualTo("Bedford"));

            _context.Customers.Remove(newCustomer);
            _context.SaveChanges();
        }

        [Test]
        public void GivenWrongCustomerId_ReturnNull()
        {
            Assert.That(_sut.GetCustomerById("UZAI3"), Is.Null);
        }

        [Test]
        public void GivenAValidId_CorrectCustomerIsReturned()
        {
            var result = _sut.GetCustomerById("UZAIR");
            Assert.That(result, Is.TypeOf<Customer>());
            Assert.That(result.ContactName, Is.EqualTo("Uzair"));
            Assert.That(result.CompanyName, Is.EqualTo("Sparta Global"));
            Assert.That(result.City, Is.EqualTo("Bedford"));
        }

        [Test]
        public void GivenACustomer_RemoveThatCustomerFromDatabase()
        {
            var numberOfCustomersBefore = _context.Customers.Count();
            var customer = _context.Customers.Find("UZAI2");
            Assert.That(customer, Is.Not.Null);
            _sut.RemoveCustomer(customer);
            var numberOfCustomersAfter = _context.Customers.Count();

            Assert.That(_context.Customers.Find("UZAI2"), Is.Null);
            Assert.That(numberOfCustomersAfter, Is.EqualTo(numberOfCustomersBefore - 1));
        }
    }
}