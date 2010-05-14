USE AdventureWorksLT2008
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[SalesLT.ListPrice]
(
	@inCategoryID INT
)	
RETURNS int 
BEGIN
	DECLARE @Result INT
		
	SELECT 
	  @Result = AVG(SalesLT.Product.ListPrice)
	FROM
	  SalesLT.Product INNER JOIN SalesLT.ProductCategory
	  ON SalesLT.Product.ProductCategoryID = SalesLT.ProductCategory.ProductCategoryID
	WHERE 
	  SalesLT.ProductCategory.ProductCategoryID = @inCategoryID
	
	RETURN @Result
END
GO