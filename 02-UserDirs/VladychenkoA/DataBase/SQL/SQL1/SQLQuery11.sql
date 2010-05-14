use AdventureWorksLT2008
select SalesLT.Product.Name
from SalesLT.Product
where 5<( select avg (SalesLT.SalesOrderDetail.ProductID)
		  from SalesLT.SalesOrderDetail
)