use AdventureWorksLT2008
 select
  SalesLT.Customer.FirstName + SalesLT.Customer.LastName,SalesLT.SalesOrderDetail.OrderQty
 from
   SalesLT.SalesOrderDetail,
   SalesLT.SalesOrderHeader,
   SalesLT.Customer 
  where SalesLT.Customer.CustomerID = SalesLT.SalesOrderHeader.CustomerID
		and SalesLT.SalesOrderDetail.SalesOrderID = SalesLT.SalesOrderHeader.SalesOrderID
		and SalesLT.SalesOrderDetail.OrderQty =
		(select min(SalesLT.SalesOrderDetail.OrderQty)
		from SalesLT.SalesOrderDetail
		)
order by SalesLT.SalesOrderDetail.OrderQty desc