USE MediaLibrary
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bobroovskiy
-- Create date: 02.07.10
-- Description:	Select_SP for inserting 
-- =============================================
CREATE PROCEDURE [dbo].[SelectArtistName_SP]	
AS
BEGIN
    SELECT [Name] 
	FROM [MediaLibrary].[dbo].[Artist]
END
  

   