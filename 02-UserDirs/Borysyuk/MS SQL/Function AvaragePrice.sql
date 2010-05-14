ALTER FUNCTION ComponentsAvaragePrice
(

	
)
RETURNS float
AS
BEGIN
	
	DECLARE @av float

SELECT @av = Max(p.Price)
--	Select Max(p.Price)

	FROM (
			SELECT 
				Sales.SalesOrderDetail.UnitPrice as Price
			FROM
				Production.Product, Production.ProductSubcategory, 
				Production.ProductCategory,  Sales.SalesOrderDetail
				
			WHERE
				 Production.ProductCategory.ProductCategoryID = 2 AND
				 Production.Product.ProductID = Sales.SalesOrderDetail.ProductID AND
				 Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID AND
				 Production.ProductSubcategory.ProductCategoryID = Production.Product.ProductSubcategoryID
 
) as p
	
	RETURN @av

END
GO

SELECT [dbo].[ComponentsAvaragePrice]()