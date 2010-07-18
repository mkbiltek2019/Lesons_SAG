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
-- Description:	Insert_SP for inserting data into [MediaLibrary].[Track] table
-- =============================================
CREATE PROCEDURE [dbo].[TrackInsert_SP]
	@PathID int,
	@ArtistID int = NULL,
	@AlbumID int = NULL,
	@GenreID int = NULL,
	@BitrateID int,
	@TrackTitle nvarchar(120) = NULL,
	@FileName nvarchar(120),
	@FileSize nvarchar(10),
	@NewFileName nvarchar(120)
	
AS
BEGIN
	INSERT INTO [dbo].[Track](
	   [PathID],
	   [ArtistID],
	   [AlbumID],
	   [GenreID],
	   [BitrateID],
	   [TrackTitle],
	   [FileName],
	   [FileSize],
	   [NewFileName])
	VALUES(
	    @PathID ,
		@ArtistID ,
		@AlbumID ,
		@GenreID ,
		@BitrateID ,
		@TrackTitle ,
		@FileName ,
		@FileSize ,
		@NewFileName );

 RETURN @@IDENTITY;
END

/* execution query
USE [MediaLibrary]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[TrackInsert_SP]
		@PathID = 1,
		@ArtistID = 1,
		@AlbumID = 1,
		@GenreID = 1,
		@BitrateID = 1,
		@TrackTitle = N'1',
		@FileName = N'1',
		@FileSize = N'1',
		@NewFileName = N'1'

SELECT	'Return Value' = @return_value

GO

*/