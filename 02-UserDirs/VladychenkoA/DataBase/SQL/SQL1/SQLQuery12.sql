use AdventureWorksLT2008
select (SalesLT.Customer.LastName +' '+ SalesLT.Customer.FirstName) 
from SalesLT.CustomerAddress 
     inner join[SalesLT].[Address] on SalesLT.CustomerAddress.AddressID = SalesLT.[Address].AddressID
     inner join SalesLT.Customer on SalesLT.CustomerAddress.CustomerID = SalesLT.Customer.CustomerID
 where [SalesLT].[Address].AddressLine2 IS NULL