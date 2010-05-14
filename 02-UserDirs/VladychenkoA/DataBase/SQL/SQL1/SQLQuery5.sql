use AdventureWorksLT2008
go
select 
  SalesLT.Product.Name, 
  SalesLT.ProductCategory.Name,
  convert(NCHAR(5),(SalesLT.Product.StandardCost/SalesLT.Product.ListPrice)*100)+' %' as "Price Markup"
from 
  SalesLT.Product inner join
  SalesLT.ProductCategory on 
  SalesLT.Product.ProductCategoryID = SalesLT.ProductCategory.ProductCategoryID
where
  (SalesLT.Product.ListPrice<>0) AND  
  (SalesLT.Product.StandardCost<>0)
order by 
  SalesLT.ProductCategory.Name;