--=====Finding and Counting============

--SELECT COUNT(city) FROM Employees
--WHERE City = 'London';

--SELECT TitleOfCourtesy, FirstName, LastName FROM Employees
--WHERE TitleOfCourtesy = 'Dr.';

--SELECT COUNT(Discontinued) FROM Products
--WHERE Discontinued = '1';

--=====Operators and Wildcards============

--SELECT ProductName, ProductID FROM Products
--WHERE UnitPrice < 5.00;

--SELECT CategoryName FROM Categories
--WHERE CategoryName LIKE '[BS]%';

--SELECT Count(*) FROM Orders
--WHERE EmployeeID IN ('5', '7');

--=====Concatination and Alias============

--SELECT FirstName + ' ' + LastName + ': ' + HomePhone AS 'Employee Name and Contact Number' FROM Employees;

--SELECT * FROM Employees;
--SELECT * FROM Products;