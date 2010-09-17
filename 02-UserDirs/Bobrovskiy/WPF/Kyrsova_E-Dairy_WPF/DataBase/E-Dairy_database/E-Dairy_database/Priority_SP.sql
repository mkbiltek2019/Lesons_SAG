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
--				needed to manipulate with table Priority
-- =======================1======================
ALTER PROCEDURE [dbo].[SelectPriorityByName_SP]
				 @Name nvarchar(50)	
AS
BEGIN
    SELECT
		 [PriorityID] 
    FROM
		 [ElectronicDairy].[dbo].[Priority]
    WHERE
		 [ElectronicDairy].[dbo].[Priority].[Name]=@Name 
END
-- =========================2=========================================
GO
ALTER PROCEDURE [dbo].[SelectPriority_SP]	
AS
BEGIN
    SELECT [Name],[PriorityID] 
    FROM [ElectronicDairy].[dbo].Priority
END

GO

CREATE PROCEDURE [dbo].[SelectPriorityByID_SP]
			@ID int	
AS
BEGIN
    SELECT [Name] 
    FROM
		[ElectronicDairy].[dbo].Priority
    WHERE 
		[ElectronicDairy].[dbo].[Priority].PriorityID=@ID 
END
-- =========================3=========================================
GO
ALTER PROCEDURE [dbo].[InsertPriority_SP]	
				@ValueName nvarchar(50)		
AS
BEGIN
    DECLARE @ValueExists int
    SET @ValueExists = 0
    
    SELECT @ValueExists = [Priority].[PriorityID]
    FROM [ElectronicDairy].[dbo].[Priority]
    WHERE 
        [ElectronicDairy].[dbo].[Priority].[Name] =  @ValueName  
    
	IF @ValueExists <> 0
	  RETURN @ValueExists;
	   
	ELSE	
	  INSERT INTO [ElectronicDairy].[dbo].[Priority]([Name])
	  VALUES(@ValueName);

 RETURN SCOPE_IDENTITY();
END
-- ===========================4=======================================
GO
CREATE PROCEDURE [dbo].[UpdatePriority_SP]	
				@PriorityID int,
				@ValueName nvarchar(50)		
AS
BEGIN    	
	  UPDATE  
		[ElectronicDairy].[dbo].[Priority]
	  SET 
		[ElectronicDairy].[dbo].[Priority].[Name]=@ValueName
	  WHERE
		[ElectronicDairy].[dbo].[Priority].[PriorityID]=@PriorityID
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


