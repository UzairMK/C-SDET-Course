using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthwindApp
{
    public partial class Product
    {
        public override string ToString() => $"[{ProductId}] {ProductName}";
    }
}
