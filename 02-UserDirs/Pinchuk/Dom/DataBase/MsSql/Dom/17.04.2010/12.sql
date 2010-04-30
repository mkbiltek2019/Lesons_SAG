--12. Замовники у яких немає другої адреси(Address.AddressLine2)
USE AdventureWorksLT2008
SELECT (SalesLT.Customer.LastName +' '+ SalesLT.Customer.FirstName) 
FROM SalesLT.CustomerAddress 
     INNER JOIN [SalesLT].[Address] ON SalesLT.CustomerAddress.AddressID = SalesLT.[Address].AddressID
     INNER JOIN SalesLT.Customer ON SalesLT.CustomerAddress.CustomerID = SalesLT.Customer.CustomerID
 WHERE [SalesLT].[Address].AddressLine2 IS NULL