USE [ElectronicDairy]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bobrovskiy
-- Create date: 30.08.10
-- Description:	Here situated all stored procedure 
--				needed to manipulate with table ItemStatus
-- ======================1=======================
ALTER PROCEDURE [dbo].[SelectItemStatus_SP]	
AS
BEGIN
    SELECT [Name],[StatusID]
    FROM [ElectronicDairy].[dbo].[ItemStatus]
END
-- ======================2==========================================
GO
ALTER PROCEDURE [dbo].[SelectItemStatusByName_SP]	
				 @Name nvarchar(50)
AS
BEGIN
    SELECT 
		[StatusID] 
    FROM 
		[ElectronicDairy].[dbo].[ItemStatus]
	WHERE 
		[ElectronicDairy].[dbo].[ItemStatus].Name = @Name    
END

GO
CREATE PROCEDURE [dbo].[SelectItemStatusByID_SP]	
				 @ID int
AS
BEGIN
    SELECT 
		[Name] 
    FROM 
		[ElectronicDairy].[dbo].[ItemStatus]
	WHERE 
		[ElectronicDairy].[dbo].[ItemStatus].[StatusID] = @ID
    
END
-- ======================3==========================================
GO
ALTER PROCEDURE [dbo].[InsertItemStatus_SP]	
				 @ValueName nvarchar(50)		
AS
BEGIN
    DECLARE @ValueExists int
    SET @ValueExists = 0
    
    SELECT @ValueExists = [ItemStatus].StatusID
    FROM [ElectronicDairy].[dbo].[ItemStatus]
    WHERE 
        [ElectronicDairy].[dbo].[ItemStatus].[Name] =  @ValueName  
    
	IF @ValueExists <> 0
		RETURN @ValueExists;	   
	ELSE
	BEGIN	
		INSERT INTO [ElectronicDairy].[dbo].[ItemStatus]([Name])
		VALUES(@ValueName);

		RETURN SCOPE_IDENTITY(); 
	END;
END
-- ======================4==========================================
GO
CREATE PROCEDURE [dbo].[UpdateItemStatus_SP]	
				@StatusID int,
				@ValueName nvarchar(50)		
AS
BEGIN    	
	  UPDATE  
		[ElectronicDairy].[dbo].[ItemStatus]
	  SET 
		[ElectronicDairy].[dbo].[ItemStatus].[Name]=@ValueName
	  WHERE
		[ElectronicDairy].[dbo].[ItemStatus].[StatusID]=@StatusID
END
-- ===========================5=======================================
GO
CREATE PROCEDURE [dbo].[DeletePriorityByID_SP]	
				@PriorityID int					
AS
BEGIN    	
	  DELETE  FROM
		[ElectronicDairy].[dbo].[Priority]	 
	  WHERE
		[ElectronicDairy].[dbo].[Priority].[PriorityID]=@PriorityID
END
