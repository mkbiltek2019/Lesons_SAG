USE MediaLibrary
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bobroovskiy
-- Create date: 02.07.10
-- Description:	SelectAlbumName_SP 
-- =============================================
CREATE PROCEDURE [dbo].[SelectAlbumName_SP]	
AS
BEGIN
    SELECT [Name] 
    FROM [MediaLibrary].[dbo].[Album]
END