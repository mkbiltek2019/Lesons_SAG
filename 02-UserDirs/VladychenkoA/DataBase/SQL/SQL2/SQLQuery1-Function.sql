USE [AdventureWorksLT2008]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProductCategory.Update]
	@ParentProductCategoryID INT = NULL,
	@Name VARCHAR(50) = NULL,
	@rowguid UNIQUEIDENTIFIER = NULL,
	@ModifiedDate DATETIME = NULL,
	@UpdatedID INT OUTPUT
AS
BEGIN
	UPDATE [AdventureWorksLT2008].[SalesLT].[ProductCategory]
	SET [ProductCategory].[Name] = @Name,
	    [ProductCategory].[rowguid] = @rowguid,
	    [ProductCategory].[ModifiedDate] = @ModifiedDate
	FROM 
	    [AdventureWorksLT2008].[SalesLT].[ProductCategory]
	WHERE
	    [ProductCategory].[ProductCategoryID] = @ParentProductCategoryID
	

 RETURN @@IDENTITY;
END