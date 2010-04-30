USE AdventureWorksLT2008
SELECT SalesLT.Customer.*
FROM SalesLT.CustomerAddress 
	INNER JOIN SalesLT.Address ON SalesLT.Address.AddressID = SalesLT.CustomerAddress.AddressID
	INNER JOIN SalesLT.Customer ON SalesLT.Customer.CustomerID = SalesLT.CustomerAddress.CustomerID
WHERE SalesLT.Address.StateProvince LIKE 'Washington'
ORDER BY SalesLT.Address.City ASC