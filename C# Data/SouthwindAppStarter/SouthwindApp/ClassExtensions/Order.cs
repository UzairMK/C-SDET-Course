using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthwindApp
{
    public partial class Order
    {
        public override string ToString()
        {
            if (ShippedDate != null)
                return $"S[{OrderId}] ({CustomerId}) {OrderDate}";
            return $"[{OrderId}] ({CustomerId}) {OrderDate}";
        }
    }
}
