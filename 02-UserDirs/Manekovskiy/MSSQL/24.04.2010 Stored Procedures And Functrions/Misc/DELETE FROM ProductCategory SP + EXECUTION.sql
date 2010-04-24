ALTER PROCEDURE [dbo].[CategoryDelete]
	@ProductCategoryID int = NULL,
	@AffectedRows int = 0 OUTPUT
AS
BEGIN
	DELETE FROM [SalesLT].[ProductCategory]
	WHERE [SalesLT].[ProductCategory].[ProductCategoryID] = @ProductCategoryID
	
	RETURN @@ROWCOUNT;
END

DECLARE @RC int
DECLARE @ProductCategoryID int
SET @ProductCategoryID = 44

EXECUTE @RC = [AdventureWorksLT].[dbo].[CategoryDelete] 
   @ProductCategoryID

SELECT @RC