SELECT MAX(xx.q) as m, t.[CustomerID]
FROM  [AdventureWorks].[Sales].[SalesOrderHeader] t,
	(
	SELECT  s2.[CustomerID] as c,  SUM (s1.[OrderQty]) as q
	FROM [AdventureWorks].[Sales].[SalesOrderDetail] s1 INNER JOIN [AdventureWorks].[Sales].[SalesOrderHeader] s2
	ON s1.[SalesOrderID] = s2.[SalesOrderID]
	GROUP BY s2.[CustomerID]
	) as xx,
	[AdventureWorks].[Sales].[SalesOrderDetail] w
WHERE w.[SalesOrderID] = t.[SalesOrderID]

GROUP BY t.[CustomerID]
HAVING SUM (w.[OrderQty]) = MAX(xx.q)