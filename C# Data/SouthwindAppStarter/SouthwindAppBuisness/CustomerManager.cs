using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SouthwindApp;
using System.Linq;

namespace SouthwindAppBuisness
{
    public class CustomerManager
    {
        public Customer SelectedCustomer { get; set; }

        public void CreateNewCustomer(string customerId, string contactName, string city, string postalCode, string country)
        {
            using (var db = new SouthwindContext())
            {
                db.Add(new Customer()
                {
                    CustomerId = customerId,
                    ContactName = contactName,
                    City = city,
                    PostalCode = postalCode,
                    Country = country
                });

                db.SaveChanges();
            }
        }

        public List<Customer> RetrieveAllCustomers()
        {
            using (var db = new SouthwindContext())
            {
                return db.Customers.ToList();
            }
        }

        public void SetSelectedCustomer(string customerId)
        {
            using (var db = new SouthwindContext())
            {
                SelectedCustomer = db.Customers.Find(customerId);
            }
        }

        public void UpdateCustomer(string customerId, string contactName, string city, string postalCode, string country)
        {
            using (var db = new SouthwindContext())
            {
                var customer = db.Customers.Find(customerId);

                customer.ContactName = contactName;
                customer.City = city;
                customer.PostalCode = postalCode;
                customer.Country = country;

                db.SaveChanges();
            }
        }

        public void DeleteCustomer(string customerId)
        {
            using (var db = new SouthwindContext())
            {
                var ordersByThisCustomer =
                    from o in db.Orders
                    where o.CustomerId == customerId
                    select o.OrderId;

                foreach (var o in ordersByThisCustomer)
                {
                    DeleteOrder(o);
                }

                db.Customers.Remove(db.Customers.Find(customerId));

                db.SaveChanges();
            }
        }

        public void CreateNewOrder(string customerId, DateTime orderDate, DateTime shippedDate, string shipCountry, List<OrderDetail> orderDetails)
        {
            using (var db = new SouthwindContext())
            {
                db.Add(new Order()
                {
                    CustomerId = customerId,
                    OrderDate = orderDate,
                    ShippedDate = shippedDate,
                    ShipCountry = shipCountry,
                    OrderDetails = orderDetails
                });

                db.SaveChanges();
            }
        }

        public List<Order> RetrieveAllOrders()
        {
            using (var db = new SouthwindContext())
            {
                return db.Orders.ToList();
            }
        }

        public List<OrderDetail> RetrieveOrderDetailsList(int orderId)
        {
            using (var db = new SouthwindContext())
            {
                var orderDetailsForThisOrder =
                    from od in db.OrderDetails
                    where od.OrderId == orderId
                    select od;

                return orderDetailsForThisOrder.ToList();
            }
        }

        public double RetrieveOrderTotalCost(int orderId)
        {
            using (var db = new SouthwindContext())
            {
                var od = RetrieveOrderDetailsList(orderId);

                double totalCost = 0;
                od.ForEach(x => totalCost += (double)x.UnitPrice * x.Quantity * (1 - x.Discount));
                return totalCost;
            }
        }

        public void UpdateOrder(int orderId, DateTime shippedDate, string shipCountry)
        {
            using (var db = new SouthwindContext())
            {
                var order = db.Orders.Find(orderId);

                order.ShippedDate = shippedDate;
                order.ShipCountry = shipCountry;

                db.SaveChanges();
            }
        }

        public void DeleteOrder(int orderId)
        {
            using (var db = new SouthwindContext())
            {
                var orderDetailsForThisOrder =
                    from od in db.OrderDetails
                    where od.OrderId == orderId
                    select od.OrderDetailId;

                foreach (var od in orderDetailsForThisOrder)
                {
                    DeleteOrderDetail(od);
                }

                db.Orders.Remove(db.Orders.Find(orderId));

                db.SaveChanges();
            }
        }

        public OrderDetail ReturnOrderDetail(decimal unitPrice, short quantity, float discount, int productId)
        {
            using (var db = new SouthwindContext())
            {
                var orderDetail = new OrderDetail()
                {
                    UnitPrice = unitPrice,
                    Quantity = quantity,
                    Discount = discount,
                    ProductId = productId
                };

                return orderDetail;
            }
        }

        public void DeleteOrderDetail(int orderDetailId)
        {
            using (var db = new SouthwindContext())
            {
                db.OrderDetails.Remove(db.OrderDetails.Find(orderDetailId));

                db.SaveChanges();
            }
        }

        public void CreateNewProduct(string productName, double price, int stock = 0)
        {
            using (var db = new SouthwindContext())
            {
                db.Add(new Product()
                {
                    ProductName = productName,
                    Price = price,
                    Stock = stock,
                    DateAdded = DateTime.Now
                });

                db.SaveChanges();
            }
        }

        public List<Product> RetrieveAllProducts()
        {
            using (var db = new SouthwindContext())
            {
                return db.Products.ToList();
            }
        }

        public void UpdateProduct(int productId, string productName, double price, int stock, DateTime dateAdded)
        {
            using (var db = new SouthwindContext())
            {
                var product = db.Products.Find(productId);

                product.ProductName = productName;
                product.Price = price;
                product.Stock = stock;
                product.DateAdded = dateAdded;

                db.SaveChanges();
            }
        }

        public void DeleteProduct(int productId)
        {
            using (var db = new SouthwindContext())
            {
                db.Products.Remove(db.Products.Find(productId));

                db.SaveChanges();
            }
        }

        public List<Order> FilterOrders(string? customerId, int? productId)
        {
            using (var db = new SouthwindContext())
            {
                var orders = RetrieveAllOrders();
                var filteredCustomer = new List<Order>();
                var filteredProducts = new List<Order>();

                if (customerId == null)
                {
                    filteredCustomer = orders;
                }
                else 
                {
                    foreach (var order in orders)
                    {
                        if (order.CustomerId == customerId)
                        {
                            filteredCustomer.Add(order);
                            continue;
                        }

                    }
                }

                if (productId == null)
                {
                    filteredProducts = filteredCustomer;
                }
                else
                {
                    foreach (var order in filteredCustomer)
                    {
                        if (DoesOrderHaveThisProduct(order, productId))
                        {
                            filteredProducts.Add(order);
                            continue;
                        }
                    }
                }

                return filteredProducts;
            }
        }

        public bool DoesOrderHaveThisProduct(Order order, int? productId)
        {
            using (var db = new SouthwindContext())
            {
                var orderDetailsForThisOrder =
                    db.Orders
                    .Include(o => o.OrderDetails)
                    .Where(o => o.OrderId == order.OrderId)
                    .Select(p => p.OrderDetails)
                    .FirstOrDefault();

                foreach (var orderDetail in orderDetailsForThisOrder.ToList())
                {
                    if (orderDetail.ProductId == productId)
                        return true;
                }

                return false;
            }
        }
    }
}
