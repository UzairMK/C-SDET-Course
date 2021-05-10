using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthwindApp
{
    public partial class OrderDetail
    {
        public override string ToString() => $"{Quantity}x [{ProductId}] @£{UnitPrice * (decimal)(1 - Discount)}";
    }
}
