use AdventureWorksLT2008
select
 SalesLT.Product.Name,
 sum(SalesLT.SalesOrderDetail.UnitPrice) as sumUnitPrice, 
 sum(SalesLT.SalesOrderDetail.UnitPrice - SalesLT.SalesOrderDetail.UnitPriceDiscount ) as sumUnitPriceDiscount
from 
 SalesLT.SalesOrderDetail 
  inner join SalesLT.Product 
   on SalesLT.SalesOrderDetail.ProductID = SalesLT.Product.ProductID
group by SalesLT.Product.Name