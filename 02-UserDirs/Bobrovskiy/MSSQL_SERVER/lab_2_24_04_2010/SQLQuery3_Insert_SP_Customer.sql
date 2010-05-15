-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- 
-- =============================================
CREATE PROCEDURE [dbo].[SalesLT.Customer.Insert]	 
      @NameStyle    [dbo].[NameStyle] = null,
      @Title        nvarchar(8) = null,
      @FirstName    [dbo].[Name] = null,
      @MiddleName   [dbo].[Name] = null,
      @LastName     [dbo].[Name] = null,
      @Suffix       nvarchar(10) = null,
      @CompanyName  nvarchar(128) = null,
      @SalesPerson  nvarchar(256) = null,
      @EmailAddress nvarchar(50) = null,
      @Phone        nvarchar(25) = null,
      @PasswordHash varchar(128) = null,
      @PasswordSalt varchar(10) = null,
      @rowguid      uniqueidentifier = null,
      @ModifiedDate datetime = null,    
	

	@InsertedID int OUTPUT
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

--go

--DECLARE @RC int
--DECLARE @NameStyle NameStyle
--DECLARE @Title nvarchar(8)
--DECLARE @FirstName Name
--DECLARE @MiddleName Name
--DECLARE @LastName Name
--DECLARE @Suffix nvarchar(10)
--DECLARE @CompanyName nvarchar(128)
--DECLARE @SalesPerson nvarchar(256)
--DECLARE @EmailAddress nvarchar(50)
--DECLARE @Phone nvarchar(25)
--DECLARE @PasswordHash varchar(128)
--DECLARE @PasswordSalt varchar(10)
--DECLARE @rowguid uniqueidentifier
--DECLARE @ModifiedDate datetime
--DECLARE @InsertedID int

--SET @NameStyle = 0
--SET @Title = 'Mr.'
--SET @FirstName = 'Valeriy'
--SET @MiddleName= 'Vladimirevich'
--SET @LastName = 'Bobrovskiy'
--SET @Suffix = null
--SET @CompanyName = 'A Bike Store'
--SET @SalesPerson = 'adventure-works\pamela0'
--SET @EmailAddress = 'valnet13@gmail.com'
--SET @Phone = '245-555-0173'
--SET @PasswordHash = 'kjhgfiytr765ryfjhgf76rifhh'
--SET @PasswordSalt = '5476546'
--SET @rowguid = NEWID()
--SET @ModifiedDate = GETDATE()

--EXECUTE @RC = [dbo].[SalesLT.Customer.Insert] 
--   @NameStyle
--  ,@Title
--  ,@FirstName
--  ,@MiddleName
--  ,@LastName
--  ,@Suffix
--  ,@CompanyName
--  ,@SalesPerson
--  ,@EmailAddress
--  ,@Phone
--  ,@PasswordHash
--  ,@PasswordSalt
--  ,@rowguid
--  ,@ModifiedDate
--  ,@InsertedID OUTPUT
--GO


