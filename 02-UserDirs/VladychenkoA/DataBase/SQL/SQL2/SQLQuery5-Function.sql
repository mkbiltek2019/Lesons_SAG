USE AdventureWorksLT2008
GO
CREATE PROCEDURE [dbo].[ProductCategory.GetAllWithPaging]
	@PageSize int = 20,
	@PageIndex int = 1
AS
BEGIN
   SET NOCOUNT ON
   DECLARE @totalRowsNumber INT 
   DECLARE @firstSelectedRowNumber INT 
   DECLARE @FirstSelectedRowID INT

   SELECT 
       @totalRowsNumber = COUNT([ProductCategory].[ProductCategoryID]) 
   FROM 
       [SalesLT].[ProductCategory]
       
   SELECT 
       @firstSelectedRowNumber = (@PageIndex - 1) * @PageSize + 1

   IF (@firstSelectedRowNumber <= @totalRowsNumber)
   BEGIN
      SET ROWCOUNT @firstSelectedRowNumber
      
      SELECT 
         @FirstSelectedRowID = [ProductCategoryID]
      FROM  
         [SalesLT].[ProductCategory]
      ORDER BY [ProductCategoryID]

      SET ROWCOUNT @PageSize
      
      SELECT * 
      FROM 
         [SalesLT].[ProductCategory]
      WHERE 
         [ProductCategoryID] >= @FirstSelectedRowID  
      ORDER BY [ProductCategoryID]
          
   END
   SET NOCOUNT OFF
   
RETURN;
END