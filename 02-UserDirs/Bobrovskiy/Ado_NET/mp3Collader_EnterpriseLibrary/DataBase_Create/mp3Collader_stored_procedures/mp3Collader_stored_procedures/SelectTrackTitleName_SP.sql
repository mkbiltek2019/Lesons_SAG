USE MediaLibrary
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bobroovskiy
-- Create date: 02.07.10
-- Description:	SelectTrackTitleName_SP 
-- =============================================
ALTER PROCEDURE [dbo].[SelectTrackTitleName_SP]	
AS
BEGIN
    SELECT [TrackTitle]as [Name] 
    FROM [MediaLibrary].[dbo].[Track]
END