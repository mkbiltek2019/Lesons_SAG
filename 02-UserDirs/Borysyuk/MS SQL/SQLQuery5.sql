SELECT  
	[Production].[Product].[ProductID]
	,[Production].[Product].[Name]
    ,[Production].[Product].[ProductNumber]
    ,[Production].[ProductCategory].[Name]
    ,[Production].[Product].[StandardCost]
    ,[Production].[Product].[ListPrice]
	,[extra].[ex]
        
FROM [AdventureWorks].[Production].[Product] INNER JOIN  
		(SELECT 
			[Production].[Product].[ProductID] as 'pr',
			([Production].[Product].[ListPrice] - [Production].[Product].[StandardCost])/[Production].[Product].[StandardCost]*100 as 'ex'
		FROM [AdventureWorks].[Production].[Product] 
		WHERE [Production].[Product].[StandardCost]>0

		) as extra 
ON 
 [Production].[Product].[ProductID] = extra.pr
INNER JOIN [Production].[ProductSubcategory] ON [Production].[ProductSubcategory].[ProductSubcategoryID] 
				= [Production].[Product].[ProductSubcategoryID]
INNER JOIN [Production].[ProductCategory] ON [Production].[ProductSubcategory].[ProductCategoryID] 
				= [Production].[ProductCategory].[ProductCategoryID] 
ORDER BY [Production].[ProductCategory].[Name] 