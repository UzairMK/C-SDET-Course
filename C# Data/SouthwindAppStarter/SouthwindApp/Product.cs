using System;
using System.Collections.Generic;

namespace SouthwindApp
{
    public class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public DateTime DateAdded { get; set; }
        public bool Discontinued { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public override string ToString() => $"[{ProductId}] {ProductName}";
    }
}
