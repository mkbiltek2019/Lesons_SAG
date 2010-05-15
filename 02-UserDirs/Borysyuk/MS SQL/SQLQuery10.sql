SELECT t.[ProductID], s1.SummTotal, s2.SummTotalWithDiscount, s3.[Quantity] as Quantity,
	(s2.SummTotalWithDiscount - t.[StandardCost]*s3.[Quantity]) as [Pofit]
FROM [AdventureWorks].[Production].[Product] t,
(
SELECT t1.[ProductID] as pr, SUM(t1.[OrderQty] * t1.[UnitPrice]) as SummTotal
FROM  [AdventureWorks].[Sales].[SalesOrderDetail] t1
GROUP BY t1.[ProductID]
) as s1,
(
SELECT t1.[ProductID] as pr, SUM(t1.[OrderQty] * t1.[UnitPrice] - t1.[OrderQty] * t1.[UnitPriceDiscount]) as SummTotalWithDiscount
FROM  [AdventureWorks].[Sales].[SalesOrderDetail] t1
GROUP BY t1.[ProductID]
) as s2,
(
SELECT  t1.[ProductID] as pr, SUM(t1.[OrderQty]) as Quantity
FROM  [AdventureWorks].[Sales].[SalesOrderDetail] t1
GROUP BY t1.[ProductID]
) as s3
WHERE t.[ProductID] = s1.pr AND s1.pr= s2.pr AND s2.pr=s3.pr