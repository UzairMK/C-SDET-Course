using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SQLMiniProjectCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContext())
            {
                //1.1 Write a query that lists all Customers in either Paris or London. Include Customer ID, Company Name and all address fields. 

                var customersFromParisOrLondonQuery =
                    from c in db.Customers
                    where c.City == "London" || c.City == "Paris"
                    select new
                    {
                        CustomerID = c.CustomerId,
                        CompanyName = c.CompanyName,
                        Address = c.Address + " " + c.City + " " + c.Country + " " + c.PostalCode
                    };

                var customersFromParisOrLondonMethod =
                    db.Customers
                    .Where(c => c.City == "London" || c.City == "Paris")
                    .Select(c => new
                    {
                        CustomerID = c.CustomerId,
                        CompanyName = c.CompanyName,
                        Address = c.Address + " " + c.City + " " + c.Country + " " + c.PostalCode
                    });

                //1.2 List all products stored in bottles.

                var productsInBottlesQuery =
                    from p in db.Products
                    where p.QuantityPerUnit.Contains("bottle")
                    select new
                    {
                        ProductName = p.ProductName,
                        QuantityPerUnit = p.QuantityPerUnit
                    };

                var productsInBottlesMethod =
                    db.Products
                    .Where(p => p.QuantityPerUnit.Contains("bottle"))
                    .Select(p => new
                    {
                        ProductName = p.ProductName,
                        QuantityPerUnit = p.QuantityPerUnit
                    });

                //1.3 Repeat question above, but add in the Supplier Name and Country.
                var productsInBottlesQuery2 =
                    from p in db.Products
                    join s in db.Suppliers on p.SupplierId equals s.SupplierId
                    where p.QuantityPerUnit.Contains("bottle")
                    select new
                    {
                        ProductName = p.ProductName,
                        QuantityPerUnit = p.QuantityPerUnit,
                        SupplierName = s.CompanyName,
                        Country = s.Country
                    };

                var productsInBottlesMethod2 =
                    db.Products
                    .Include(s => s.Supplier)
                    .Where(p => p.QuantityPerUnit.Contains("bottle"))
                    .Select(p => new
                    {
                        ProductName = p.ProductName,
                        QuantityPerUnit = p.QuantityPerUnit,
                        SupplierName = p.Supplier.CompanyName,
                        Country = p.Supplier.Country
                    });

                //1.4 Write an SQL Statement that shows how many products there are in each category. Include Category Name in result set and list the highest number first. 

                var productsInEachCategoryQuery =
                    from p in db.Products
                    join c in db.Categories on p.CategoryId equals c.CategoryId
                    group c by c.CategoryName into newGroup
                    orderby newGroup.Count() descending
                    select new
                    {
                        CategoryName = newGroup.Key,
                        Count = newGroup.Count()
                    };

                var productsInEachCategoryMethod =
                    db.Products
                    .Include(c => c.Category)
                    .GroupBy(c => c.Category.CategoryName)
                    .OrderByDescending(p => p.Count())
                    .Select(p => new
                    {
                        CategoryName = p.Key,
                        Count = p.Count()
                    });

                //1.5 List all UK employees using concatenation to join their title of courtesy, first name and last name together. Also include their city of residence

                var UKEmployeesQuery =
                    from e in db.Employees
                    where e.Country == "UK"
                    select new
                    {
                        Name = $"{e.TitleOfCourtesy} {e.FirstName} {e.LastName}",
                        City = e.City
                    };

                var UKEmployeesMethod =
                    db.Employees
                    .Where(e => e.Country == "UK")
                    .Select(e => new
                    {
                        Name = $"{e.TitleOfCourtesy} {e.FirstName} {e.LastName}",
                        City = e.City
                    });

                //1.6 List Sales Totals for all Sales Regions (via the Territories table using 4 joins) with a Sales Total greater than 1,000,000. Use rounding or FORMAT to present the numbers.  

                var totalSalesPerRegionQuery =
                    from t in db.Territories
                    join et in db.EmployeeTerritories on t.TerritoryId equals et.TerritoryId
                    join r in db.Regions on t.RegionId equals r.RegionId
                    join o in db.Orders on et.EmployeeId equals o.EmployeeId
                    join od in db.OrderDetails on o.OrderId equals od.OrderId
                    let sale = od.Quantity * od.UnitPrice * (1 - (decimal)od.Discount)
                    group sale by r.RegionDescription into newGroup
                    where newGroup.Sum(c => c) > 1000000
                    select new
                    {
                        Region = newGroup.Key.Trim(),
                        TotalSales = Math.Round(newGroup.Sum(c => c), 0)
                    };

                //var totalSalesPerRegionMethod =
                //    db.Territories
                //    .Include(r => r.Region)
                //    .Include(et => et.EmployeeTerritories)
                //    .ThenInclude(e => e.Employee)
                //    .ThenInclude(o => o.Orders)
                //    .ThenInclude(od => od.OrderDetails)
                //    .GroupBy(r => r.Region.RegionDescription)
                //    .Where(x => x.Sum(c => c.EmployeeTerritories.))
                //    .Select(x => new
                //    {
                //        Region = x.Key.Trim(),
                //        TotalSales = Math.Round(x.Sum(c => c), 0)
                //    });

                //1.7 Count how many Orders have a Freight amount greater than 100.00 and either USA or UK as Ship Country

                var ordersWithFreightGreaterThan100Query =
                    from o in db.Orders
                    where o.Freight > 100 && (o.ShipCountry == "UK" || o.ShipCountry == "USA")
                    select new
                    {
                        Count = o.Freight
                    };

                var ordersWithFreightGreaterThan100Method =
                    db.Orders
                    .Where(o => o.Freight > 100 && (o.ShipCountry == "UK" || o.ShipCountry == "USA"))
                    .Count();

                //1.8 Write an SQL Statement to identify the Order Number of the Order with the highest amount of discount applied to that order. 

                var highestDiscountQuery =
                    from od in db.OrderDetails
                    let discount = od.UnitPrice * od.Quantity * (decimal)od.Discount
                    orderby discount descending
                    select new
                    {
                        OrderID = od.OrderId,
                        Discount = discount
                    };

                var highestDiscountMethod =
                    db.OrderDetails 
                    .OrderByDescending(od => od.UnitPrice * od.Quantity * (decimal)od.Discount)
                    .Select(od => new
                    {
                        OrderID = od.OrderId,
                        Discount = od.UnitPrice * od.Quantity * (decimal)od.Discount
                    });

                //3.1 List all Employees from the Employees table and who they report to

                var employeesAndTheirBossQuery =
                    from e in db.Employees
                    join m in db.Employees on e.ReportsTo equals m.EmployeeId into grp
                    from g in grp.DefaultIfEmpty()
                    select new
                    {
                        Employee = $"{e.FirstName} reports to {g.FirstName}"
                    };

                //3.2 List all Suppliers with total sales over $10,000 in the Order Details table. Include the Company Name from the Suppliers Table and present as a bar chart as below:

                var suppliersWithTotalSalesOver10000Query =
                    from od in db.OrderDetails
                    join p in db.Products on od.ProductId equals p.ProductId
                    join s in db.Suppliers on p.SupplierId equals s.SupplierId
                    let sale = od.UnitPrice * od.Quantity * (decimal)(1 - od.Discount)
                    group sale by s.CompanyName into supplierSales
                    where supplierSales.Sum() > 10000
                    orderby supplierSales.Sum()
                    select new
                    {
                        SupplierName = supplierSales.Key,
                        TotalSales = supplierSales.Sum()
                    };

                var suppliersWithTotalSalesOver10000Method =
                    db.OrderDetails
                    .Include(p => p.Product)
                    .ThenInclude(s => s.Supplier)
                    .GroupBy(s => s.Product.Supplier.CompanyName)
                    .Where(x => x.Sum(y => y.UnitPrice * y.Quantity * (decimal)(1 - y.Discount)) > 10000)
                    .OrderByDescending(x => x.Sum(y => y.UnitPrice * y.Quantity * (decimal)(1 - y.Discount)))
                    .Select(x => new
                    {
                        SupplierName = x.Key,
                        TotalSales = x.Sum(y => y.UnitPrice * y.Quantity * (decimal)(1 - y.Discount))
                    });

                //3.3 List the Top 10 Customers YTD for the latest year in the Orders file. Based on total value of orders shipped.

                var top10CustomersYTDQuery =
                    from o in db.Orders
                    join od in db.OrderDetails on o.OrderId equals od.OrderId
                    join c in db.Customers on o.CustomerId equals c.CustomerId
                    where o.OrderDate >= new DateTime(1998, 01, 01)
                    let sale = od.UnitPrice * od.Quantity * (decimal)(1 - od.Discount)
                    group sale by c.ContactName into customerSale
                    orderby customerSale.Sum() descending
                    select new
                    {
                        CustomerName = customerSale.Key,
                        TotalSales = customerSale.Sum()
                    };

                var top10CustomersYTDMethod =
                    db.OrderDetails
                    .Include(o => o.Order)
                    .ThenInclude(c => c.Customer)
                    .Where(x => x.Order.OrderDate >= new DateTime(1998, 01, 01))
                    .GroupBy(x => x.Order.Customer.CompanyName)
                    .OrderByDescending(x => x.Sum(y => y.UnitPrice * y.Quantity * (decimal)(1 - y.Discount)))
                    .Select(x => new
                    {
                        CompanyName = x.Key,
                        TotalSales = x.Sum(y => y.UnitPrice * y.Quantity * (decimal)(1 - y.Discount))
                    });

                //3.4 Plot the Average Ship Time by month for all data in the Orders Table using a line chart as below.

                //var averageShipTimeByMonth = 
                //    from o in db.Orders
                //    let year_month = o.OrderDate.
                //    let days = o.ShippedDate - o.OrderDate


                //1.1
                //customersFromParisOrLondonQuery.ToList().ForEach(x => Console.WriteLine(x));
                //customersFromParisOrLondonMethod.ToList().ForEach(x => Console.WriteLine(x));

                ////1.2
                //productsInBottlesQuery.ToList().ForEach(x => Console.WriteLine(x));
                //productsInBottlesMethod.ToList().ForEach(x => Console.WriteLine(x));

                //1.3
                //productsInBottlesQuery2.ToList().ForEach(x => Console.WriteLine(x));
                //productsInBottlesMethod2.ToList().ForEach(x => Console.WriteLine(x));

                //1.4
                //productsInEachCategoryQuery.ToList().ForEach(x => Console.WriteLine(x));
                //productsInEachCategoryMethod.ToList().ForEach(x => Console.WriteLine(x));

                //1.5
                //UKEmployeesQuery.ToList().ForEach(x => Console.WriteLine(x));
                //UKEmployeesMethod.ToList().ForEach(x => Console.WriteLine(x));

                //1.6
                //totalSalesPerRegionQuery.ToList().ForEach(x => Console.WriteLine(x));
                //totalSalesPerRegionMethod.ToList().ForEach(x => Console.WriteLine(x)); //Not possible

                //1.7
                ////ordersWithFreightGreaterThan100Query.ToList().ForEach(x => Console.WriteLine(x));
                //Console.WriteLine($"There are {ordersWithFreightGreaterThan100Query.Count()} orders with freight greater than 100");
                //Console.WriteLine($"There are {ordersWithFreightGreaterThan100Method} orders with freight greater than 100");

                //1.8
                //Console.WriteLine("The highest discount is: " + highestDiscountQuery.ToList().First());
                //Console.WriteLine("The highest discount is: " + highestDiscountMethod.ToList().First());


                //3.1
                //employeesAndTheirBossQuery.ToList().ForEach(x => Console.WriteLine(x));

                //3.2
                //suppliersWithTotalSalesOver10000Query.ToList().ForEach(x => Console.WriteLine(x));
                //suppliersWithTotalSalesOver10000Method.ToList().ForEach(x => Console.WriteLine(x));

                //3.3
                //top10CustomersYTDQuery.ToList().ForEach(x => Console.WriteLine(x));
                top10CustomersYTDMethod.ToList().ForEach(x => Console.WriteLine(x));
            }
        }
    }
}
