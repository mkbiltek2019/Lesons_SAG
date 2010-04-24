CREATE PROCEDURE [dbo].[CategoryGetAllCount]
	@ProductCategoryName nvarchar(50) = NULL,
	@ParentProductCategoryName nvarchar(50) = NULL
AS
BEGIN
	SELECT COUNT(*)
	FROM SalesLT.ProductCategory AS Category
	INNER JOIN SalesLT.ProductCategory AS BaseCategory 
		ON BaseCategory.ProductCategoryID = Category.ParentProductCategoryID
	WHERE 
		BaseCategory.[Name] LIKE '%' + @ParentProductCategoryName + '%' AND
		Category.[Name] LIKE '%' + @ProductCategoryName + '%'
END
