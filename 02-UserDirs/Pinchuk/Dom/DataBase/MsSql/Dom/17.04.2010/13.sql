--13. Замовник з найбільшим(по сумарній кількості продукції)
 --замовленням. Таблиці SalesOrderHeader, SalesOrderDetails, Customer
 USE AdventureWorksLT2008
 SELECT 
  SalesLT.Customer.FirstName + SalesLT.Customer.LastName,SalesLT.SalesOrderDetail.OrderQty
 FROM
   SalesLT.SalesOrderDetail,
   SalesLT.SalesOrderHeader,
   SalesLT.Customer 
  WHERE SalesLT.Customer.CustomerID = SalesLT.SalesOrderHeader.CustomerID
		AND SalesLT.SalesOrderDetail.SalesOrderID = SalesLT.SalesOrderHeader.SalesOrderID
		AND SalesLT.SalesOrderDetail.OrderQty >= 
		(SELECT MAX
		(SELECT SUM(SalesLT.SalesOrderDetail.OrderQty)as SUMA
		FROM SalesLT.SalesOrderDetail, SalesLT.SalesOrderHeader
		WHERE SalesLT.SalesOrderDetail.SalesOrderID = SalesLT.SalesOrderHeader.SalesOrderID
		GROUP BY SalesLT.SalesOrderHeader.CustomerID)
		)
ORDER BY SalesLT.SalesOrderDetail.OrderQty DESC

		
 

	