--14. Замовник з найдешевшим замовленням
 USE AdventureWorksLT2008
 SELECT 
  SalesLT.Customer.FirstName + SalesLT.Customer.LastName,SalesLT.SalesOrderDetail.OrderQty
 FROM
   SalesLT.SalesOrderDetail,
   SalesLT.SalesOrderHeader,
   SalesLT.Customer 
  WHERE SalesLT.Customer.CustomerID = SalesLT.SalesOrderHeader.CustomerID
		AND SalesLT.SalesOrderDetail.SalesOrderID = SalesLT.SalesOrderHeader.SalesOrderID
		AND SalesLT.SalesOrderDetail.OrderQty =
		(SELECT MIN(SalesLT.SalesOrderDetail.OrderQty)
		FROM SalesLT.SalesOrderDetail
		)
ORDER BY SalesLT.SalesOrderDetail.OrderQty DESC