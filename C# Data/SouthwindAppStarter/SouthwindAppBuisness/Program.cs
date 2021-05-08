using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SouthwindApp;

namespace SouthwindAppBuisness
{
    public class Program
    {
        static void Main()
        {
            CustomerManager _customerManager = new();

            //_customerManager.CreateNewProduct("Mouse");
            //_customerManager.CreateNewProduct("Keyboard");
            //_customerManager.CreateNewProduct("Monitor");

            //_customerManager.CreateNewCustomer("UZAIR", "Uzair Khan", "Bedford", "MAADSA", "UK");

            //var od = new List<OrderDetail>();
            //od.Add(_customerManager.ReturnOrderDetail(10,1,0,7));
            //od.Add(_customerManager.ReturnOrderDetail(15,1,0,8));
            //od.Add(_customerManager.ReturnOrderDetail(30,1,0,9));

            //_customerManager.CreateNewOrder("UZAIR", DateTime.Now, DateTime.Now, "UK", od);

            //_customerManager.DeleteCustomer("UZAIR");

        }
    }
}
