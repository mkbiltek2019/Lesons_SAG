SELECT t1.[ProductID], SUM(t1.[OrderQty] * t1.[UnitPrice]) as SummTotal, 
	SUM(t1.[OrderQty] * t1.[UnitPrice] - t1.[OrderQty] * t1.[UnitPriceDiscount]) as SummTotalWithDiscount

FROM  [AdventureWorks].[Sales].[SalesOrderDetail] t1

GROUP BY t1.[ProductID]
HAVING AVG ( t1.[OrderQty])>5
ORDER BY t1.[ProductID]