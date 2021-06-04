using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindData
{
    public interface ICustomerService
    {
        public void CreateCustomer(Customer c);
        public Customer GetCustomerById(string customerId);
        public List<Customer> GetCustomerList();
        public void SaveCustomerChanges();
        public void RemoveCustomer(Customer c);
    }
}
