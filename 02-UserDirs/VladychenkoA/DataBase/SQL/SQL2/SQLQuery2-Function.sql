USE [AdventureWorksLT2008]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SalesLT.Customer.Delete]
	@CustomerID INT = NULL,
	@AffectedRows INT = 0 OUTPUT
AS
BEGIN
	DELETE FROM 
	      [SalesLT].Customer
	WHERE 
	      [SalesLT].[Customer].[CustomerID] = @CustomerID
	
	RETURN @@ROWCOUNT;
END