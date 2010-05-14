use AdventureWorksLT2008
go
 select
  SalesLT.Customer.FirstName + SalesLT.Customer.LastName,SalesLT.SalesOrderDetail.OrderQty
 
 from
   SalesLT.SalesOrderDetail,
   SalesLT.SalesOrderHeader,
   SalesLT.Customer 
  where SalesLT.Customer.CustomerID = SalesLT.SalesOrderHeader.CustomerID
		AND SalesLT.SalesOrderDetail.SalesOrderID = SalesLT.SalesOrderHeader.SalesOrderID
		AND SalesLT.SalesOrderDetail.OrderQty >= all
		
		(select sum(SalesLT.SalesOrderDetail.OrderQty)as SUMA
		from SalesLT.SalesOrderDetail, SalesLT.SalesOrderHeader
		where SalesLT.SalesOrderDetail.SalesOrderID = SalesLT.SalesOrderHeader.SalesOrderID
		group by SalesLT.SalesOrderHeader.CustomerID)
		
order by SalesLT.SalesOrderDetail.OrderQty desc
