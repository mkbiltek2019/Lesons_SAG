
use  AdventureWorksLT2008
select SalesLT.Customer.*
from SalesLT.CustomerAddress 
	inner join SalesLT.Address on SalesLT.Address.AddressID = SalesLT.CustomerAddress.AddressID
	inner join SalesLT.Customer on SalesLT.Customer.CustomerID = SalesLT.CustomerAddress.CustomerID
Where SalesLT.Address.StateProvince LIKE 'Washington'
order by SalesLT.Address.City ASC