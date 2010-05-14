use AdventureWorksLT2008
go
select SalesLT.Product.Name, SalesLT.ProductCategory.Name
from SalesLT.Product inner join
 SalesLT.ProductCategory on 
 SalesLT.Product.ProductCategoryID = SalesLT.ProductCategory.ProductCategoryID
order by SalesLT.ProductCategory.Name;