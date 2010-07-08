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
CREATE PROCEDURE [dbo].[AlbumInsert_SP]
	@ValueToInsert varchar(100) = null	
AS
BEGIN
    DECLARE @ValueExists int
    SET @ValueExists = 0
    
    SELECT @ValueExists = [AlbumID]
    FROM [MediaLibrary].[dbo].[Album]
    WHERE 
        [MediaLibrary].[dbo].[Album].[Name] =  @ValueToInsert  
    
	IF @ValueExists <> 0
	  RETURN @ValueExists; 
	ELSE	
	  INSERT INTO [MediaLibrary].[dbo].[Album]([Name])
	  VALUES(@ValueToInsert);

 RETURN SCOPE_IDENTITY();
END

/*
USE [MediaLibrary]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[AlbumInsert_SP]
		@ValueToInsert = N'empty'

SELECT	@return_value

GO
*/