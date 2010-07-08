use MediaLibrary
go

ALTER PROCEDURE [dbo].[MediaLibrary.GetAllWithPaging]
    @Album nvarchar(50),
    @Artist nvarchar(50),
    @Genre nvarchar(50),
    @FileName nvarchar(50),
	@PageSize int = 20,
	@PageIndex int = 1
AS
BEGIN
   SET NOCOUNT ON
   DECLARE @totalRowsNumber int 
   DECLARE @firstSelectedRowNumber int 
   DECLARE @FirstSelectedRowID int
   
   --  Album filter
   --  -----------------------------------------------------------
   IF @Album <> ' '
   BEGIN       
   SELECT
       @totalRowsNumber = COUNT([MediaLibrary].[dbo].[MainView].[TrackID]) 
   FROM 
       [MediaLibrary].[dbo].[MainView]
   WHERE
	   [MediaLibrary].[dbo].[MainView].[AlbumName] LIKE @Album
       
   SELECT 
       @firstSelectedRowNumber = (@PageIndex - 1) * @PageSize + 1
   
   IF (@firstSelectedRowNumber <= @totalRowsNumber)
   BEGIN
      SET ROWCOUNT @firstSelectedRowNumber
      
      SELECT 
          @FirstSelectedRowID = [MediaLibrary].[dbo].[MainView].[TrackID]
      FROM  
          [MediaLibrary].[dbo].[MainView]
      WHERE
		  [MediaLibrary].[dbo].[MainView].[AlbumName] LIKE @Album
      ORDER BY 
          [MediaLibrary].[dbo].[MainView].[TrackID]

      SET ROWCOUNT @PageSize
      
      SELECT *  
      FROM 
         [MediaLibrary].[dbo].[MainView]
      WHERE 
         ([MediaLibrary].[dbo].[MainView].[TrackID] >= @FirstSelectedRowID)
         AND 
         ([MediaLibrary].[dbo].[MainView].[AlbumName] LIKE @Album) 
      ORDER BY 
         [MediaLibrary].[dbo].[MainView].[TrackID]
          
   END
   SET NOCOUNT OFF      
   END
   -- ------------------------------------------------------------
   
   -- Artist filter
   --  -----------------------------------------------------------
   IF @Artist <> ' '
   BEGIN       
   SELECT
       @totalRowsNumber = COUNT([MediaLibrary].[dbo].[MainView].[TrackID]) 
   FROM 
       [MediaLibrary].[dbo].[MainView]
   WHERE
	   [MediaLibrary].[dbo].[MainView].[ArtistName] LIKE @Artist
       
   SELECT 
       @firstSelectedRowNumber = (@PageIndex - 1) * @PageSize + 1
   
   IF (@firstSelectedRowNumber <= @totalRowsNumber)
   BEGIN
      SET ROWCOUNT @firstSelectedRowNumber
      
      SELECT 
          @FirstSelectedRowID = [MediaLibrary].[dbo].[MainView].[TrackID]
      FROM  
          [MediaLibrary].[dbo].[MainView]
      WHERE
		  [MediaLibrary].[dbo].[MainView].[ArtistName] LIKE @Artist
      ORDER BY 
          [MediaLibrary].[dbo].[MainView].[TrackID]

      SET ROWCOUNT @PageSize
      
      SELECT *  
      FROM 
         [MediaLibrary].[dbo].[MainView]
      WHERE 
         ([MediaLibrary].[dbo].[MainView].[TrackID] >= @FirstSelectedRowID)
         AND 
         ([MediaLibrary].[dbo].[MainView].[ArtistName] LIKE @Artist) 
      ORDER BY 
         [MediaLibrary].[dbo].[MainView].[TrackID]
          
   END
   SET NOCOUNT OFF      
   END
   -- ------------------------------------------------------------ 
   -- Genre filter
   --  -----------------------------------------------------------
   IF @Genre <> ' '
   BEGIN       
   SELECT
       @totalRowsNumber = COUNT([MediaLibrary].[dbo].[MainView].[TrackID]) 
   FROM 
       [MediaLibrary].[dbo].[MainView]
   WHERE
	   [MediaLibrary].[dbo].[MainView].[GenreName] LIKE @Genre
       
   SELECT 
       @firstSelectedRowNumber = (@PageIndex - 1) * @PageSize + 1
   
   IF (@firstSelectedRowNumber <= @totalRowsNumber)
   BEGIN
      SET ROWCOUNT @firstSelectedRowNumber
      
      SELECT 
          @FirstSelectedRowID = [MediaLibrary].[dbo].[MainView].[TrackID]
      FROM  
          [MediaLibrary].[dbo].[MainView]
      WHERE
		  [MediaLibrary].[dbo].[MainView].[GenreName] LIKE @Genre
      ORDER BY 
          [MediaLibrary].[dbo].[MainView].[TrackID]

      SET ROWCOUNT @PageSize
      
      SELECT *  
      FROM 
         [MediaLibrary].[dbo].[MainView]
      WHERE 
         ([MediaLibrary].[dbo].[MainView].[TrackID] >= @FirstSelectedRowID)
         AND 
         ([MediaLibrary].[dbo].[MainView].[GenreName] LIKE @Genre) 
      ORDER BY 
         [MediaLibrary].[dbo].[MainView].[TrackID]
          
   END
   SET NOCOUNT OFF      
   END
   -- ------------------------------------------------------------
   
   -- FileName filter
   --  -----------------------------------------------------------
   IF @FileName <> ' '
   BEGIN       
   SELECT
       @totalRowsNumber = COUNT([MediaLibrary].[dbo].[MainView].[TrackID]) 
   FROM 
       [MediaLibrary].[dbo].[MainView]
   WHERE
	   [MediaLibrary].[dbo].[MainView].[FileName] LIKE @FileName
       
   SELECT 
       @firstSelectedRowNumber = (@PageIndex - 1) * @PageSize + 1
   
   IF (@firstSelectedRowNumber <= @totalRowsNumber)
   BEGIN
      SET ROWCOUNT @firstSelectedRowNumber
      
      SELECT 
          @FirstSelectedRowID = [MediaLibrary].[dbo].[MainView].[TrackID]
      FROM  
          [MediaLibrary].[dbo].[MainView]
      WHERE
		  [MediaLibrary].[dbo].[MainView].[FileName] LIKE @FileName
      ORDER BY 
          [MediaLibrary].[dbo].[MainView].[TrackID]

      SET ROWCOUNT @PageSize
      
      SELECT *  
      FROM 
         [MediaLibrary].[dbo].[MainView]
      WHERE 
         ([MediaLibrary].[dbo].[MainView].[TrackID] >= @FirstSelectedRowID)
         AND 
         ([MediaLibrary].[dbo].[MainView].[FileName] LIKE @FileName) 
      ORDER BY 
         [MediaLibrary].[dbo].[MainView].[TrackID]
          
   END
   SET NOCOUNT OFF      
   END
   -- ------------------------------------------------------------
   	   
RETURN;
END

--USE [MediaLibrary]
--GO

--DECLARE	@return_value int

--EXEC	@return_value = [dbo].[Singer.GetAllWithPaging]
--		@PageSize = 20,
--		@PageIndex = 2

--SELECT	'Return Value' = @return_value

--GO