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
CREATE PROCEDURE [dbo].[BitrateInsert_SP]
	@ValueToInsert int = null	
AS
BEGIN
    DECLARE @ValueExists int
    SET @ValueExists = 0
    
    SELECT @ValueExists = [BitrateID]
    FROM [MediaLibrary].[dbo].[Bitrate]
    WHERE 
        [MediaLibrary].[dbo].[Bitrate].[Bitrate] =  @ValueToInsert  
    
	IF @ValueExists <> 0
	  RETURN @ValueExists; 
	ELSE	
	  INSERT INTO [MediaLibrary].[dbo].[Bitrate]([Bitrate])
	  VALUES(@ValueToInsert);

 RETURN SCOPE_IDENTITY();
END

/*
USE [MediaLibrary]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[BitrateInsert_SP]
		@ValueToInsert = N'1'

SELECT	@return_value

GO
*/