-- =============================================
-- Author:		Manekovskiy Alexander
-- Create date: 04/24/2010
-- Description:	Insert SP for Category table
-- =============================================
CREATE PROCEDURE [dbo].[CategoryInsert]
	@ParentProductCategoryID int = NULL,
	@Name varchar(50) = null,
	@rowguid uniqueidentifier = null,
	@ModifiedDate datetime = null,

	@InsertedID int OUTPUT
AS
BEGIN
	INSERT INTO [SalesLT].[ProductCategory](
		[ParentProductCategoryID],
		[Name],
		[rowguid],
		[ModifiedDate])
	VALUES(
		@ParentProductCategoryID,
		@Name,
		@rowguid,
		@ModifiedDate
	);

 RETURN @@IDENTITY;
END

DECLARE @RC int
DECLARE @ParentProductCategoryID int
DECLARE @Name varchar(50)
DECLARE @rowguid uniqueidentifier
DECLARE @ModifiedDate datetime
DECLARE @InsertedID int

SET @ParentProductCategoryID = null
SET @Name = 'Test category'
SET @rowguid = NEWID()
SET @ModifiedDate = GETDATE()

-- TODO: Set parameter values here.

EXECUTE @RC = [AdventureWorksLT].[dbo].[CategoryInsert] 
   @ParentProductCategoryID
  ,@Name
  ,@rowguid
  ,@ModifiedDate
  ,@InsertedID OUTPUT

SELECT @RC