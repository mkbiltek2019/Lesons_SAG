USE MediaLibrary
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bobroovskiy
-- Create date: 02.07.10
-- Description:	SelectFileName_SP 
-- =============================================
Alter PROCEDURE [dbo].[SelectFileName_SP]	
AS
BEGIN
    SELECT [FileName] as [Name] 
    FROM [MediaLibrary].[dbo].[Track]
END