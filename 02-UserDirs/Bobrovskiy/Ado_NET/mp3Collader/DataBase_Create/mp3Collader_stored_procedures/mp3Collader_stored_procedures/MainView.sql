USE [MediaLibrary]
GO

/****** Object:  View [dbo].[MainView]    Script Date: 07/04/2010 19:35:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[MainView]
AS
SELECT DISTINCT
		[dbo].[Track].TrackID,   
		[dbo].[Genre].[Name] as [GenreName],
		[dbo].[Album].[Name] AS [AlbumName], 
		[dbo].[Artist].[Name] AS [ArtistName], 
		[dbo].[Path].[Name] AS [FullPath], 
		[dbo].[Bitrate].[Bitrate] as [Bitrate], 
		[dbo].[Track].[FileSize] as [FileSize], 
		[dbo].[Track].[NewFileName] as [NewName], 
		[dbo].[Track].[FileName] as [FileName], 
		[dbo].[Track].[TrackTitle] as [TrackTitle]
		
FROM          
		[dbo].[Album] INNER JOIN
		[dbo].[Track] ON [dbo].[Album].[AlbumID] = [dbo].[Track].[AlbumID] INNER JOIN
		[dbo].[Artist] ON [dbo].[Track].[ArtistID] = [dbo].[Artist].[ArtistID] INNER JOIN
		[dbo].[Bitrate] ON [dbo].[Track].[BitrateID] = [dbo].[Bitrate].[BitrateID] INNER JOIN
		[dbo].[Genre] ON [dbo].[Track].[GenreID] = [dbo].[Genre].[GenreID] INNER JOIN
		[dbo].[Path] ON [dbo].[Track].[PathID] = [dbo].[Path].[PathID]


GO


