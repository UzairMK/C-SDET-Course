using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NorthwindData;

namespace NorthwindBusiness
{
    public class CustomerManager
    {
        public Customer SelectedCustomer { get; set; }

        private ICustomerService _service;

        public CustomerManager()
        {
            _service = new CustomerService();
        }

        public CustomerManager(ICustomerService service)
        {
            _service = service ?? throw new ArgumentException("service should not be null");
        }

        public void CreateCustomer(string customerId, string contactName = null, string city = null, string postalCode = null, string country = null, string companyName = "")
        {
            var newCust = new Customer() { CustomerId = customerId, ContactName = contactName, City = city, PostalCode = postalCode, Country = country, CompanyName = companyName };
            _service.CreateCustomer(newCust);
        }

        public bool UpdateCustomer(string customerId, string contactName, string city, string postcode, string country, string companyName)
        {
            SelectedCustomer = _service.GetCustomerById(customerId);

            if (SelectedCustomer == null)
            {
                Debug.WriteLine("no customer");
                return false;
            }

            SelectedCustomer.ContactName = contactName;
            SelectedCustomer.City = city;
            SelectedCustomer.PostalCode = postcode;
            SelectedCustomer.Country = country;
            SelectedCustomer.CompanyName = companyName;
            try
            {
                _service.SaveCustomerChanges();
            }
            catch (Exception)
            {
                Debug.WriteLine("cant save");
                return false;
            }

            return true;
        }

        public List<Customer> RetrieveAllCustomers()
        {
            return _service.GetCustomerList();
        }

        public void SetSelectedCustomer(object selectedItem)
        {
            SelectedCustomer = (Customer)selectedItem;
        }

        public bool DeleteCustomer(string customerid)
        {
            var customer = _service.GetCustomerById(customerid);
            if (customer == null)
            {
                return false;
            }

            _service.RemoveCustomer(customer);
            return true;
        }

        public bool CheckCustomerExists(string customerid)
        {
            var customer = _service.GetCustomerById(customerid);
            return customer != null;
        }
    }
}
