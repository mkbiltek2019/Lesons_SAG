USE [MediaLibrary]
GO
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bobroovskiy
-- Create date: 02.07.10
-- Description:	Insert_SP for inserting data into simple tables
-- =============================================
ALTER PROCEDURE [dbo].[PathInsert_SP]
	@ValueToInsert varchar(500) = null	
AS
BEGIN
    DECLARE @ValueExists int
    SET @ValueExists = 0
    
    SELECT @ValueExists = [PathID]
    FROM [MediaLibrary].[dbo].[Path]
    WHERE 
        [MediaLibrary].[dbo].[Path].[Name] =  @ValueToInsert  
    
	IF @ValueExists <> 0
	  RETURN @ValueExists; 
	ELSE	
	  INSERT INTO [MediaLibrary].[dbo].[Path]([Name])
	  VALUES(@ValueToInsert);

 RETURN SCOPE_IDENTITY();
END

/*
USE [MediaLibrary]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[PathInsert_SP]
		@ValueToInsert = N'empty'

SELECT	@return_value

GO
*/