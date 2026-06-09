use Northwind


CREATE PROCEDURE GetCustomersByCountry
    @Country NVARCHAR(50)
AS
BEGIN
    SELECT * FROM Customers WHERE Country = @Country
END
