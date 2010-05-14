use AdventureWorksLT2008

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SalesLT.Customer.Update]	
	  @ParentCustomerID INT = null,
      @NameStyle    [dbo].[NameStyle] = NULL,
      @Title        NVARCHAR(8) = NULL,
      @FirstName    [dbo].[Name] = NULL,
      @MiddleName   [dbo].[Name] = NULL,
      @LastName     [dbo].[Name] = NULL,
      @Suffix       NVARCHAR(10) = NULL,
      @CompanyName  NVARCHAR(128) = NULL,
      @SalesPerson  NVARCHAR(256) = NULL,
      @EmailAddress NVARCHAR(50) = NULL,
      @Phone        NVARCHAR(25) = NULL,
      @PasswordHash VARCHAR(128) = NULL,
      @PasswordSalt VARCHAR(10) = NULL,
      @rowguid      UNIQUEIDENTIFIER = NULL,
      @ModifiedDate DATETIME = NULL,	

	@UpdatedID INT OUTPUT
AS
BEGIN
    
	UPDATE  [SalesLT].[Customer]
	SET
			[NameStyle] =@NameStyle
           ,[Title] =  @Title
           ,[FirstName] = @FirstName
           ,[MiddleName] = @MiddleName
           ,[LastName] = @LastName
           ,[Suffix] = @Suffix
           ,[CompanyName] = @CompanyName
           ,[SalesPerson] = @SalesPerson
           ,[EmailAddress] = @EmailAddress
           ,[Phone] = @Phone
           ,[PasswordHash] = @PasswordHash
           ,[PasswordSalt] = @PasswordSalt
           ,[rowguid] = @rowguid
           ,[ModifiedDate] = @ModifiedDate    
	FROM 
	    [AdventureWorksLT2008].[SalesLT].[Customer]
	WHERE
	   [SalesLT].[Customer].CustomerID = @ParentCustomerID		    

 RETURN @@IDENTITY;
END