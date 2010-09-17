USE [ElectronicDairy]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bobrovskiy
-- Create date: 30.08.10
-- Description:	All for DairyDate Table
-- =====================1========================
ALTER PROCEDURE [dbo].[InsertDairyDate_SP]	
				@ValueToInsert datetime
AS
BEGIN
	SET DATEFORMAT dmy;
	
    DECLARE @ValueExists int
    SET @ValueExists = 0
    
    SELECT @ValueExists = [DairyDate].[DateID]
    FROM [ElectronicDairy].[dbo].[DairyDate]
    WHERE 
        [ElectronicDairy].[dbo].[DairyDate].[Date] =  @ValueToInsert 
    
	IF @ValueExists <> 0
	  RETURN @ValueExists;
	   
	ELSE
	BEGIN	
		INSERT INTO [ElectronicDairy].[dbo].[DairyDate]([Date])
		VALUES(@ValueToInsert);

		RETURN SCOPE_IDENTITY();
	END;
END
-- ======================2==========================================
GO
ALTER PROCEDURE [dbo].[SelectDairyDateByDate_SP]
				 @Date datetime	
AS
BEGIN
	SET DATEFORMAT dmy
    SELECT
		 [ElectronicDairy].[dbo].[DairyDate].[DateID] 
    FROM
		 [ElectronicDairy].[dbo].[DairyDate]
    WHERE
		 [ElectronicDairy].[dbo].[DairyDate].[Date] = @Date
END
-- ======================3==========================================
GO
ALTER PROCEDURE [dbo].[SelectDairyDateByDateID_SP]
				 @DateID int	
AS
BEGIN
	SET DATEFORMAT dmy;
	
    SELECT
		 [ElectronicDairy].[dbo].[DairyDate].[Date] 
    FROM
		 [ElectronicDairy].[dbo].[DairyDate]
    WHERE
		 [ElectronicDairy].[dbo].[DairyDate].[DateID] = @DateID
END

GO
ALTER PROCEDURE [dbo].[SelectDairyDate_SP]				 	
AS
BEGIN
	SET DATEFORMAT dmy;
	
    SELECT
		 [ElectronicDairy].[dbo].[DairyDate].[DateID],
		 [ElectronicDairy].[dbo].[DairyDate].[Date] 
    FROM
		 [ElectronicDairy].[dbo].[DairyDate]    
END

-- ======================4==========================================
GO
ALTER PROCEDURE [dbo].[UpdateDairyDate_SP]	
				@DateID int,
				@ValueName datetime		
AS
BEGIN  
	 SET DATEFORMAT dmy
  	
	  UPDATE  
		[ElectronicDairy].[dbo].[DairyDate]
	  SET 
		[ElectronicDairy].[dbo].[DairyDate].[Date]=@ValueName
	  WHERE
		[ElectronicDairy].[dbo].[DairyDate].[DateID]=@DateID
END
-- ======================5==========================================
GO
CREATE PROCEDURE [dbo].[DeleteDairyDateByID_SP]	
				@DateID int					
AS
BEGIN    	
	  DELETE  FROM
		[ElectronicDairy].[dbo].[DairyDate]	 
	  WHERE
		[ElectronicDairy].[dbo].[DairyDate].[DateID]=@DateID
END
-- ======================6==========================================
GO

