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
CREATE PROCEDURE [dbo].[TrancateDataBase_SP]
	@ValueToInsert varchar(1) = null	
AS
BEGIN
	TRUNCATE TABLE [MediaLibrary].[dbo].[Track]
    DELETE FROM  [MediaLibrary].[dbo].[Artist]
    DELETE FROM [MediaLibrary].[dbo].[Path]
    DELETE FROM  [MediaLibrary].[dbo].[Album]
    DELETE FROM  [MediaLibrary].[dbo].[Genre]
    DELETE FROM  [MediaLibrary].[dbo].[Bitrate] 
END

/*
USE [MediaLibrary]
GO
EXEC [dbo].[TrancateDataBase_SP]
GO

*/