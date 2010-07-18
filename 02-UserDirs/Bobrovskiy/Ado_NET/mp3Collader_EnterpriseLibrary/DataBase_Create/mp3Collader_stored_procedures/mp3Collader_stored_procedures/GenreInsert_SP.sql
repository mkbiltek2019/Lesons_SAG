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
Create PROCEDURE [dbo].[GenreInsert_SP]
	@ValueToInsert varchar(50) = null	
AS
BEGIN
    DECLARE @ValueExists int
    SET @ValueExists = 0
    
    SELECT @ValueExists = [GenreID]
    FROM [MediaLibrary].[dbo].[Genre]
    WHERE 
        [MediaLibrary].[dbo].[Genre].[Name] =  @ValueToInsert  
    
	IF @ValueExists <> 0
	  RETURN @ValueExists; 
	ELSE	
	  INSERT INTO [MediaLibrary].[dbo].[Genre]([Name])
	  VALUES(@ValueToInsert);

 RETURN SCOPE_IDENTITY();
END

/*
USE [MediaLibrary]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[GenreInsert_SP]
		@ValueToInsert = N'empty'

SELECT	@return_value

GO
*/