--SELECT DISTINCT Country
--FROM Customers
--WHERE Region IS NOT NULL;

--SELECT UnitPrice, Quantity, Discount,
--UnitPrice * Quantity AS 'Gross Total',
--UnitPrice * Quantity * (1 - Discount) AS 'Net Total'
--FROM [Order Details];

--SELECT TOP 2 WITH TIES OrderID, UnitPrice, Quantity, Discount,
--UnitPrice * Quantity AS 'Gross Total',
--UnitPrice * Quantity * (1 - Discount) AS 'Net Total'
--FROM [Order Details]
--ORDER BY [Gross Total] DESC;

--SELECT SUBSTRING ('Sparta Global', 8, 6);
--SELECT CHARINDEX ('a', 'Uzair Khan');
--SELECT LEFT ('Uzair Khan', 6); -- Counting from the left to and including the index
--SELECT RIGHT ('Uzair Khan', 5); -- Counting from the right to and including the index
--SELECT LTRIM ('     Uzair      ');
--SELECT RTRIM ('     Uzair      ');
--SELECT RTRIM (LTRIM ('     Uzair      '));
--SELECT LEN ('Uzair Khan');
--SELECT REPLACE ('Uzair Khan','z','m')
--SELECT UPPER ('Uzair Khan')
--SELECT LOWER ('Uzair Khan')

--SELECT PostalCode AS 'Post Code',
--	   LEFT (PostalCode, (CHARINDEX(' ', PostalCode) - 1)) AS 'Region Code',
--	   CHARINDEX(' ', PostalCode) AS 'Space Found',
--	   Country
--FROM Customers
--WHERE Country = 'UK';

--SELECT ProductName,
--	   CHARINDEX('''', ProductName) AS 'Single Quote Found'
--FROM Products
--WHERE CHARINDEX('''', ProductName) != 0;

--SELECT FORMAT (GETDATE(), 'dd-MM-yyyy'); -- have to use MM as cap because mm is for minutes
--SELECT DATEADD (yyyy, 5, GETDATE());
--SELECT DATEDIFF (yyyy, '1997-05-11', GETDATE());
--SELECT DATEDIFF (dd, '1997-05-11', GETDATE())/365.25;
--SELECT YEAR (GETDATE());
--SELECT MONTH (GETDATE());
--SELECT DAY (GETDATE());

--SELECT FORMAT(DATEADD(dd, 5, OrderDate), 'dd-MM-yyyy') AS 'Due Date',
--	   DATEDIFF(dd, OrderDate, ShippedDate) AS 'Ship days'
--FROM Orders;

--CREATE VIEW EmployeeAges AS
--SELECT FirstName + ' ' + LastName AS 'Employee Name',
--	   FLOOR(DATEDIFF(dd, BirthDate, GETDATE())/365.25) AS 'Age'
--FROM Employees;

--SELECT OrderID,
--	   CASE WHEN DATEDIFF(dd, OrderDate, ShippedDate) < 10 THEN 'On Time'
--	   ELSE 'Overdue'
--	   END AS 'Status'
--FROM Orders

--SELECT [Employee Name],
--	   Age,
--	   CASE WHEN Age > 65 THEN 'Retired'
--	   WHEN Age > 60 THEN 'Retirement Due'
--	   ELSE 'More than 5 years to go' 
--	   END AS 'Retirement Status'
--FROM EmployeeAges
--ORDER BY Age;

--SELECT ProductID,
--	   SUM(UnitsOnOrder) AS 'Sum of units on order',
--	   AVG(UnitsOnOrder) AS 'Average of units on order',
--	   MIN(UnitsOnOrder) AS 'Minimum value in units on order',
--	   MAX(UnitsOnOrder) AS 'Maximum value in units on order'
--FROM Products
--GROUP BY ProductID
--HAVING SUM(UnitsOnOrder) > 0;

--SELECT CategoryID,
--	   AVG(ReorderLevel) AS 'Reorder level'
--FROM Products
--GROUP BY CategoryID
--ORDER BY [Reorder level] DESC;

--SELECT et.EmployeeID,
--	   e.FirstName + ' ' + e.LastName AS 'Employee Name',
--	   COUNT(TerritoryID) AS 'Number of territories'
--FROM EmployeeTerritories et
--JOIN Employees e ON e.EmployeeID = et.EmployeeID
--GROUP BY et.EmployeeID, e.FirstName + ' ' + e.LastName
--HAVING COUNT(TerritoryID) > 5;

--SELECT p.SupplierID,
--	   s.CompanyName,
--	   AVG(UnitsOnOrder) AS 'Average Units on Order'
--FROM Products p
--JOIN Suppliers s ON p.SupplierID = s.SupplierID
--GROUP BY p.SupplierID, s.CompanyName
--ORDER BY [Average Units on Order] DESC;

--SELECT c.CompanyName,
--	   e.FirstName + ' ' + e.LastName AS 'Employee Name',
--	   o.OrderID,
--	   FORMAT(o.OrderDate, 'dd/MM/yyyy') AS 'Order Date',
--	   o.Freight
--FROM Orders o
--JOIN Customers c ON o.CustomerID = c.CustomerID
--JOIN Employees e ON o.EmployeeID = e.EmployeeID;

--SELECT c.CompanyName,
--	   e.FirstName + ' ' + e.LastName AS 'Employee Name',
--	   o.OrderID,
--	   FORMAT(o.OrderDate, 'dd/MM/yyyy') AS 'Order Date',
--	   o.Freight
--FROM Orders o, Customers c, Employees e
--WHERE o.CustomerID = c.CustomerID AND o.EmployeeID = e.EmployeeID;

--SELECT CompanyName
--FROM Customers
--WHERE CustomerID NOT IN (	SELECT CustomerID 
--							FROM Orders);

--SELECT DISTINCT CompanyName
--FROM Customers c
--LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
--WHERE OrderID IS NULL;

--SELECT EmployeeID AS 'Employees/Suppliers'
--FROM Employees
--UNION ALL -- Remove ALL to get rid of dublicates.
--SELECT SupplierID
--FROM Suppliers;

--SELECT OrderID, ProductID, UnitPrice, Quantity, Discount
--FROM [Order Details]
--WHERE ProductID IN (SELECT ProductID
--					FROM Products
--					WHERE Discontinued = 1);

--SELECT o.OrderID, o.ProductID, o.UnitPrice, o.Quantity, o.Discount
--FROM [Order Details] o
--JOIN Products p ON o.ProductID = p.ProductID
--WHERE p.Discontinued = 1;

--SELECT o.OrderID, o.ProductID, o.UnitPrice, o.Quantity, o.Discount
--FROM [Order Details] o, Products p 
--WHERE o.ProductID = p.ProductID AND p.Discontinued = 1;