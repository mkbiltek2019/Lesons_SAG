use AdventureWorksLT2008
select 
 (SalesLT.Product.ListPrice - SalesLT.Product.StandardCost -SalesLT.SalesOrderDetail.UnitPriceDiscount) as Profit 
 from 
  SalesLT.SalesOrderDetail 
  inner join SalesLT.Product 
  on SalesLT.SalesOrderDetail.ProductID = SalesLT.Product.ProductID 