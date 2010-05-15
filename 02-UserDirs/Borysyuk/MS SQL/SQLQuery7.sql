SELECT 2*x.pr+3*y.pr as [TotalPrice]
FROM
(
SELECT t1.[ListPrice] as pr
FROM [AdventureWorks].[Production].[Product] t1 INNER JOIN [AdventureWorks].[Production].[ProductModel] t2
ON t1.[ProductModelID] = t2.[ProductModelID] 
WHERE t2.[Name] = 'Men''s Sports Shorts' 
AND t1.[Size] = 'XL'
) as x,

(
SELECT t1.[ListPrice] as pr
FROM [AdventureWorks].[Production].[Product] t1 INNER JOIN [AdventureWorks].[Production].[ProductModel] t2
ON t1.[ProductModelID] = t2.[ProductModelID] 
WHERE t2.[Name] = 'Women''s Mountain Shorts'  
AND t1.[Size] = 'M'
) as y
