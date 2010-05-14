use AdventureWorksLT2008
go
select 
  SalesLT.Product.Name, 
  SalesLT.ProductCategory.Name
from 
  SalesLT.Product inner join
  SalesLT.ProductCategory on 
  SalesLT.Product.ProductCategoryID = SalesLT.ProductCategory.ProductCategoryID
where
  SalesLT.ProductCategory.Name = 'Wheels'
order by 
  SalesLT.Product.StandardCost;