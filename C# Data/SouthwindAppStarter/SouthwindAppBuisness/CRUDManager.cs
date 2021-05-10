using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SouthwindApp;
using System.Linq;

namespace SouthwindAppBuisness
{
    public static class CRUDManager
    {
        public static void CreateNewCustomer(string customerId, string contactName, string city, string postalCode, string country)
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

        public static List<Customer> RetrieveAllCustomers()
        {
            using (var db = new SouthwindContext())
            {
                return db.Customers.ToList();
            }
        }

        public static Customer GetCustomer(string customerId)
        {
            using (var db = new SouthwindContext())
            {
                return db.Customers.Find(customerId);
            }
        }

        public static void UpdateCustomer(string customerId, string contactName, string city, string postalCode, string country)
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

        public static void DeleteCustomer(string customerId)
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

        public static void CreateNewOrder(string customerId, DateTime orderDate, string shipCountry, List<OrderDetail> orderDetails)
        {
            using (var db = new SouthwindContext())
            {
                db.Add(new Order()
                {
                    CustomerId = customerId,
                    OrderDate = orderDate,
                    ShipCountry = shipCountry,
                    OrderDetails = orderDetails
                });

                db.SaveChanges();
            }
        }

        public static List<Order> RetrieveAllOrders()
        {
            using (var db = new SouthwindContext())
            {
                return db.Orders.ToList();
            }
        }

        public static Order GetOrder(int orderId)
        {
            using (var db = new SouthwindContext())
            {
                return db.Orders.Find(orderId);
            }
        }

        public static List<OrderDetail> RetrieveOrderDetailsList(int orderId)
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

        public static double RetrieveOrderTotalCost(int orderId)
        {
            using (var db = new SouthwindContext())
            {
                var od = RetrieveOrderDetailsList(orderId);

                double totalCost = 0;
                od.ForEach(x => totalCost += (double)x.UnitPrice * x.Quantity * (1 - x.Discount));
                return totalCost;
            }
        }

        public static void UpdateOrder(int orderId, DateTime shippedDate, string shipCountry)
        {
            using (var db = new SouthwindContext())
            {
                var order = db.Orders.Find(orderId);

                order.ShippedDate = shippedDate;
                order.ShipCountry = shipCountry;

                db.SaveChanges();
            }
        }

        public static void DeleteOrder(int orderId)
        {
            using (var db = new SouthwindContext())
            {
                var orderDetailsForThisOrder =
                    from od in db.OrderDetails
                    where od.OrderId == orderId
                    select od;

                bool shipped = GetOrder(orderId).ShippedDate != null;

                foreach (var od in orderDetailsForThisOrder)
                {
                    if (!shipped)
                        DecreaseProductStock(od.ProductId, -1 * od.Quantity);
                    DeleteOrderDetail(od.OrderDetailId);
                }
            }

            using (var db = new SouthwindContext())
            {
                var orderToBeDeleted = db.Orders.Find(orderId);

                db.Orders.Remove(orderToBeDeleted);

                db.SaveChanges();
            }
        }

        public static OrderDetail CreateOrderDetail(int productId, short quantity, float discount)
        {
            var orderDetail = new OrderDetail()
            {
                ProductId = productId,
                UnitPrice = Math.Round((decimal)GetProduct(productId).Price, 2),
                Quantity = quantity,
                Discount = discount
            };

            return orderDetail;
        }

        public static OrderDetail ReturnOrderDetail(decimal unitPrice, short quantity, float discount, int productId)
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

        public static void DeleteOrderDetail(int orderDetailId)
        {
            using (var db = new SouthwindContext())
            {
                db.OrderDetails.Remove(db.OrderDetails.Find(orderDetailId));

                db.SaveChanges();
            }
        }

        public static void CreateNewProduct(string productName, double price, int stock = 0)
        {
            using (var db = new SouthwindContext())
            {
                db.Add(new Product()
                {
                    ProductName = productName,
                    Price = price,
                    Stock = stock,
                    DateAdded = DateTime.Now,
                    Discontinued = false
                });

                db.SaveChanges();
            }
        }

        public static Product GetProduct(int productId)
        {
            using (var db = new SouthwindContext())
            {
                return db.Products.Find(productId);
            }
        }

        public static List<Product> RetrieveAllProducts()
        {
            using (var db = new SouthwindContext())
            {
                var activeProducts =
                    from p in db.Products
                    where p.Discontinued == false
                    select p;

                return activeProducts.ToList();
            }
        }

        public static List<Product> RetrieveDiscontinuedProducts()
        {
            using (var db = new SouthwindContext())
            {
                var discontinuedProducts =
                    from p in db.Products
                    where p.Discontinued == true
                    select p;

                return discontinuedProducts.ToList();
            }
        }

        public static void UpdateProduct(int productId, string productName, double price, int stock, DateTime dateAdded)
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

        public static void DecreaseProductStock(int productId, int decreaseAmount)
        {
            using (var db = new SouthwindContext())
            {
                var product = db.Products.Find(productId);

                if (decreaseAmount > product.Stock)
                    throw new Exception("Should not be able to decrease stock to less than 0");
                product.Stock -= decreaseAmount;

                db.SaveChanges();
            }
        }

        public static void DeleteProduct(int productId)
        {
            using (var db = new SouthwindContext())
            {
                db.Products.Find(productId).Discontinued = true;

                db.SaveChanges();
            }
        }

        public static List<Order> FilterOrders(string? customerId, int? productId)
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

        public static bool DoesOrderHaveThisProduct(Order order, int? productId)
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
