--1.1 Customers from Paris and London
SELECT CustomerID, CompanyName, Address + ', ' + City + ', ' + PostalCode + ', ' + Country AS 'Address'
FROM Customers
WHERE City IN ('Paris' , 'London');

--1.2 Products in bottles
SELECT ProductName, QuantityPerUnit
FROM Products
WHERE QuantityPerUnit LIKE '%bottle%';

--1.3 Products in bottles but with Supplier Name and Country
SELECT ProductName, QuantityPerUnit, CompanyName, Country
FROM Products p
JOIN Suppliers s ON p.SupplierID = s.SupplierID
WHERE QuantityPerUnit LIKE '%bottle%';

--1.4 How many products in each category. Include categroy name and order from highest to lowest.
SELECT CategoryName, COUNT(c.CategoryName) AS 'No of Products'
FROM Products p
JOIN Categories c ON p.CategoryID = c.CategoryID
GROUP BY CategoryName
ORDER BY [No of Products] DESC;

--1.5 List all UK employees using concatenation to join their title of courtesy, first name and last name together. Also include their city of residence
SELECT TitleOfCourtesy + ' ' + FirstName + ' ' + LastName AS Name, Country
FROM Employees
WHERE Country = 'UK';

--1.6 List Sales Totals for all Sales Regions (via the Territories table using 4 joins) with a Sales Total greater than 1,000,000. Use rounding or FORMAT to present the numbers.
SELECT r.RegionID, r.RegionDescription, FORMAT(SUM(UnitPrice*Quantity*(1-Discount)), 'C') AS 'Sales Total'
FROM EmployeeTerritories et
JOIN Territories t ON et.TerritoryID = t.TerritoryID
JOIN Region r ON t.RegionID = r.RegionID
JOIN Orders o ON o.EmployeeID = et.EmployeeID
JOIN [Order Details] od ON od.OrderID = o.OrderID
GROUP BY r.RegionID, r.RegionDescription
HAVING SUM(UnitPrice*Quantity*(1-Discount)) > 1000000
ORDER BY [Sales Total] DESC;

--1.7 Count how many Orders have a Freight amount greater than 100.00 and either USA or UK as Ship Country. 
SELECT COUNT(*) AS 'Number of orders to UK or USA with Freight > 100'
FROM Orders
WHERE Freight > 100 AND ShipCountry IN ('UK', 'USA');

--1.8 Write an SQL Statement to identify the Order Number of the Order with the highest amount of discount applied to that order. 
SELECT TOP 1 WITH TIES OrderID, UnitPrice, Quantity, Discount, FORMAT(UnitPrice*Quantity*Discount, 'C') AS 'Discount Applied'
FROM [Order Details]
WHERE UnitPrice*Quantity*Discount = (SELECT MAX(UnitPrice*Quantity*Discount) FROM [Order Details])
ORDER BY [Discount Applied] DESC;

--2.1 Create spartan table and fill with values
USE Eng86;

DROP TABLE Spartans 
CREATE TABLE Spartans
(
	SpartanID INT IDENTITY(1,1) PRIMARY KEY,
	Title VARCHAR(5),
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Age INT CHECK (Age >= 18),
	UniversityAttended VARCHAR(50),
	CourseTaken VARCHAR(50),
	MarksAchieved INT
);

--2.2 Add values to spartan table

INSERT INTO Spartans
VALUES ('Mr.','Bob','Gust',21,'University of Hull','Photography',64)
	  ,('Miss.','Sue','Sally',28,'Imperial Colleage London','History',78)
	  ,('Mr.','Joe','Mama',23,'University of Aberdeen','Teaching',51)
	  ,('Mrs.','Portia','Leatherman',22,'University of Manchester','Petroleum Engineering',65)
	  ,('Mr.','George','Boot',25,'University of Manchester','Photography',59)
	  ;

--ALTER TABLE Spartans
--DROP COLUMN FirstName;

--DELETE 
--FROM Spartans
--WHERE SpartanID = 1;

SELECT * FROM Spartans

USE Northwind;

--3.1 List all Employees from the Employees table and who they report to.
SELECT emp.FirstName + ' ' + emp.LastName AS 'Employee', mgr.FirstName + ' ' + mgr.LastName AS 'Reports to'
FROM Employees emp
LEFT JOIN Employees mgr ON emp.ReportsTo = mgr.EmployeeID
ORDER BY [Reports to];

--3.2 List all Suppliers with total sales over $10,000 in the Order Details table. Include the Company Name from the Suppliers Table.
SELECT s.CompanyName, ROUND(SUM(od.UnitPrice*od.Quantity*(1-od.Discount)), 2) AS 'Supplier Total, $'
FROM [Order Details] od
JOIN Products p ON p.ProductID = od.ProductID
JOIN Suppliers s ON s.SupplierID = p.SupplierID
GROUP BY s.CompanyName
HAVING SUM(od.UnitPrice*od.Quantity*(1-od.Discount)) > 10000
ORDER BY [Supplier Total, $] DESC;

--3.3 List the Top 10 Customers YTD for the latest year in the Orders file. Based on total value of orders shipped.
SELECT TOP 10 WITH TIES c.CustomerID, c.CompanyName, ROUND(SUM(od.UnitPrice*od.Quantity*(1-od.Discount)),2) AS 'YTD Sales'
FROM [Order Details] od
JOIN (SELECT OrderID, CustomerID, OrderDate, ShippedDate
	  FROM Orders
	  WHERE OrderDate >= '1998-01-01' AND ShippedDate IS NOT NULL)
	  o ON o.OrderID = od.OrderID
JOIN Customers c ON c.CustomerID = o.CustomerID
GROUP BY c.CustomerID, c.CompanyName
ORDER BY [YTD Sales] DESC;

--3.4 Plot the Average Ship Time by month for all data in the Orders Table using a line chart as below.
SELECT FORMAT(OrderDate, 'yyyy-MM') AS 'Year-Month', AVG(CAST(DATEDIFF(dd,OrderDate, ShippedDate) AS DECIMAL(10,2))) AS 'Average ship time'
FROM Orders
GROUP BY FORMAT(OrderDate, 'yyyy-MM')
ORDER BY [Year-Month];