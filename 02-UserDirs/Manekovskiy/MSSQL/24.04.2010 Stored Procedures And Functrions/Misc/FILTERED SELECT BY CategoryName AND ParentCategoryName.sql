DECLARE @ParentProductCategoryName nvarchar(50)
SET @ParentProductCategoryName = 'Comp'

DECLARE @ProductCategoryName nvarchar(50)
SET @ProductCategoryName = 'B'

SELECT 
	Category.[ParentProductCategoryID], 
	Category.[ProductCategoryID], 
	Category.[Name]
FROM SalesLT.ProductCategory AS Category
INNER JOIN SalesLT.ProductCategory AS BaseCategory 
	ON BC.ProductCategoryID = Category.ParentProductCategoryID
WHERE 
	BaseCategory.[Name] LIKE '%' + @ParentProductCategoryName + '%' AND
	Category.[Name] LIKE '%' + @ProductCategoryName + '%'