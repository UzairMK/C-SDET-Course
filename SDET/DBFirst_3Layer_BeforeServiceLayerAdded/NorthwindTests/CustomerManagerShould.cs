using NUnit.Framework;
using NorthwindBusiness;
using NorthwindData;
using System.Linq;
using Moq;
using System;

namespace NorthwindTests
{
    public class CustomerManagerShould
    {
        private CustomerManager _sut;

        [Ignore("Should Fail")]
        [Test]
        public void BeAbleToConstructCustomerManager_ShouldFail()
        {
            _sut = new CustomerManager(null);
            Assert.That(_sut, Is.InstanceOf<CustomerManager>());
        }

        //Moq as DUMMY
        [Test]
        public void BeAbleToConstructCustomerManager()
        {
            var mockCustomerService = new Mock<ICustomerService>();
            _sut = new CustomerManager(mockCustomerService.Object);
            Assert.That(_sut, Is.InstanceOf<CustomerManager>());
        }

        //Moq as STUB
        [Test]
        public void ReturnTrue_WhenUpdateIsCalled_WithValidId()
        {
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new Customer()
            {
                CustomerId = "UZAIR",
                ContactName = "Uzair",
                CompanyName = "Sparta Global",
                City = "Bedford"
            };

            mockCustomerService.Setup(cs => cs.GetCustomerById("UZAIR")).Returns(originalCustomer);

            _sut = new CustomerManager(mockCustomerService.Object);

            var result = _sut.UpdateCustomer("UZAIR", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.That(result, Is.True);
        }

        [Test]
        public void ReturnFalse_WhenUpdateIsCalled_WithInvalidId()
        {
            var mockCustomerService = new Mock<ICustomerService>();

            //mockCustomerService.Setup(cs => cs.GetCustomerById("UZAIR")).Returns((Customer)null);

            _sut = new CustomerManager(mockCustomerService.Object);

            var result = _sut.UpdateCustomer("UZAIR", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.That(result, Is.False);
        }

        [Test]
        public void ReturnTrue_WhenDeleteIsCalled_WithValidId()
        {
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new Customer()
            {
                CustomerId = "UZAIR",
                ContactName = "Uzair",
                CompanyName = "Sparta Global",
                City = "Bedford"
            };

            mockCustomerService.Setup(cs => cs.GetCustomerById("UZAIR")).Returns(originalCustomer);

            _sut = new CustomerManager(mockCustomerService.Object);

            var result = _sut.DeleteCustomer("UZAIR");

            Assert.That(result, Is.True);
        }

        [Test]
        public void ReturnFalse_WhenDeleteIsCalled_WithInvalidId()
        {
            var mockCustomerService = new Mock<ICustomerService>();

            //mockCustomerService.Setup(cs => cs.GetCustomerById("UZAIR")).Returns((Customer)null);

            _sut = new CustomerManager(mockCustomerService.Object);

            var result = _sut.DeleteCustomer("UZAIR");

            Assert.That(result, Is.False);
        }

        //Moq throws Exception
        [Test]
        public void ReturnFalse_WhenUpdateIsCalled_DatabaseExceptionIsThrown()
        {
            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(cs => cs.GetCustomerById(It.IsAny<string>())).Returns(new Customer());
            mockCustomerService.Setup(cs => cs.SaveCustomerChanges()).Throws<Exception>();

            _sut = new CustomerManager(mockCustomerService.Object);

            var result = _sut.UpdateCustomer("UZAIR", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.That(result, Is.False);
        }

        //Behavour based testing
        //Moq as Spy
        [Test]
        public void CallsSaveCustomerChanges_WhenUpdateIsCalled_WithValidId()
        {
            var mockCustomerService = new Mock<ICustomerService>(MockBehavior.Strict);
            mockCustomerService.Setup(cs => cs.GetCustomerById(It.IsAny<string>())).Returns(new Customer());
            mockCustomerService.Setup(cs => cs.SaveCustomerChanges());
            _sut = new CustomerManager(mockCustomerService.Object);

            _sut.UpdateCustomer("UZAIR", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
            mockCustomerService.Verify(cs => cs.SaveCustomerChanges(), Times.Once);
        }

        [Test]
        public void RemoveCustomer_IsNotCalled_WhenCreateCustomerIsCalled()
        {
            var mockCustomerService = new Mock<ICustomerService>(MockBehavior.Strict);
            mockCustomerService.Setup(cs => cs.CreateCustomer(It.IsAny<Customer>()));
            _sut = new CustomerManager(mockCustomerService.Object);

            _sut.CreateCustomer("UZAIR", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
            mockCustomerService.Verify(cs => cs.RemoveCustomer(It.IsAny<Customer>()), Times.Never);
        }

        [Test]
        public void GetCustomerId_IsCalled_WhenDeleteCustomerIsCalled()
        {
            var mockCustomerService = new Mock<ICustomerService>(MockBehavior.Loose);
            _sut = new CustomerManager(mockCustomerService.Object);

            _sut.DeleteCustomer(It.IsAny<string>());
            mockCustomerService.Verify(cs => cs.GetCustomerById(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void CreatCustomer_IsNotCalled_WhenDeleteCustomerIsCalled()
        {
            var mockCustomerService = new Mock<ICustomerService>(MockBehavior.Loose);
            mockCustomerService.Setup(cs => cs.GetCustomerById(It.IsAny<string>())).Returns(new Customer());
            _sut = new CustomerManager(mockCustomerService.Object);

            _sut.DeleteCustomer(It.IsAny<string>());
            mockCustomerService.Verify(cs => cs.CreateCustomer(It.IsAny<Customer>()), Times.Never);
        }
    }
}