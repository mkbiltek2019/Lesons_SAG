SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SalesLT.Customer.Insert]	 
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
      @PasswordHash NVARCHAR(128) = NULL,
      @PasswordSalt NVARCHAR(10) = NULL,
      @rowguid      UNIQUEIDENTIFIER = NULL,
      @ModifiedDate DATETIME = NULL,    
		@InsertedID INT OUTPUT
AS
BEGIN
	INSERT INTO [SalesLT].[Customer](
			[NameStyle]
           ,[Title]
           ,[FirstName]
           ,[MiddleName]
           ,[LastName]
           ,[Suffix]
           ,[CompanyName]
           ,[SalesPerson]
           ,[EmailAddress]
           ,[Phone]
           ,[PasswordHash]
           ,[PasswordSalt]
           ,[rowguid]
           ,[ModifiedDate])
	VALUES(
			  @NameStyle,
			  @Title,
			  @FirstName,
			  @MiddleName,
			  @LastName,
			  @Suffix,
			  @CompanyName,
			  @SalesPerson,
			  @EmailAddress,
			  @Phone,
			  @PasswordHash,
			  @PasswordSalt,
			  @rowguid,
			  @ModifiedDate    
	);
 RETURN @@IDENTITY;
END
