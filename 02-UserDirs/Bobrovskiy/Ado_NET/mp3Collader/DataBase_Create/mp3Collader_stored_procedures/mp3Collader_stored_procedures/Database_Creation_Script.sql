USE [MediaLibrary]
GO
/****** Object:  User [WINXP_WITH_MSSQ\user]    Script Date: 07/07/2010 22:33:25 ******/
CREATE USER [WINXP_WITH_MSSQ\user] FOR LOGIN [WINXP_WITH_MSSQ\user] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Path]    Script Date: 07/07/2010 22:33:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Path](
	[PathID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Path] PRIMARY KEY CLUSTERED 
(
	[PathID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 1) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Album]    Script Date: 07/07/2010 22:33:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Album](
	[AlbumID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED 
(
	[AlbumID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 1) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Artist]    Script Date: 07/07/2010 22:33:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artist](
	[ArtistID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
 CONSTRAINT [PK_Artist] PRIMARY KEY CLUSTERED 
(
	[ArtistID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 1) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bitrate]    Script Date: 07/07/2010 22:33:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitrate](
	[BitrateID] [int] IDENTITY(1,1) NOT NULL,
	[Bitrate] [int] NULL,
 CONSTRAINT [PK_Bitrate] PRIMARY KEY CLUSTERED 
(
	[BitrateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 1) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 07/07/2010 22:33:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[GenreID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[GenreID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 1) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[BitrateInsert_SP]    Script Date: 07/07/2010 22:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bobroovskiy
-- Create date: 02.07.10
-- Description:	Insert_SP for inserting data into simple tables
-- =============================================
CREATE PROCEDURE [dbo].[BitrateInsert_SP]
	@ValueToInsert int = null	
AS
BEGIN
    DECLARE @ValueExists int
    SET @ValueExists = 0
    
    SELECT @ValueExists = [BitrateID]
    FROM [MediaLibrary].[dbo].[Bitrate]
    WHERE 
        [MediaLibrary].[dbo].[Bitrate].[Bitrate] =  @ValueToInsert  
    
	IF @ValueExists <> 0
	  RETURN @ValueExists; 
	ELSE	
	  INSERT INTO [MediaLibrary].[dbo].[Bitrate]([Bitrate])
	  VALUES(@ValueToInsert);

 RETURN SCOPE_IDENTITY();
END

/*
USE [MediaLibrary]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[BitrateInsert_SP]
		@ValueToInsert = N'1'

SELECT	@return_value

GO
*/
GO
/****** Object:  StoredProcedure [dbo].[ArtistInsert_SP]    Script Date: 07/07/2010 22:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bobroovskiy
-- Create date: 02.07.10
-- Description:	Insert_SP for inserting data into simple tables
-- =============================================
CREATE PROCEDURE [dbo].[ArtistInsert_SP]
	@ValueToInsert varchar(150) = null	
AS
BEGIN
    DECLARE @ValueExists int
    SET @ValueExists = 0
    
    SELECT @ValueExists = [ArtistID]
    FROM [MediaLibrary].[dbo].[Artist]
    WHERE 
        [MediaLibrary].[dbo].[Artist].[Name] =  @ValueToInsert  
    
	IF @ValueExists <> 0
	  RETURN @ValueExists; 
	ELSE	
	  INSERT INTO [MediaLibrary].[dbo].[Artist]([Name])
	  VALUES(@ValueToInsert);

 RETURN SCOPE_IDENTITY();
END

/*
USE [MediaLibrary]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[ArtistInsert_SP]
		@ValueToInsert = N'empty'

SELECT	@return_value

GO
*/
GO
/****** Object:  StoredProcedure [dbo].[AlbumInsert_SP]    Script Date: 07/07/2010 22:33:31 ******/
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
GO
/****** Object:  Table [dbo].[Track]    Script Date: 07/07/2010 22:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Track](
	[TrackID] [int] IDENTITY(1,1) NOT NULL,
	[PathID] [int] NOT NULL,
	[ArtistID] [int] NULL,
	[AlbumID] [int] NULL,
	[GenreID] [int] NULL,
	[BitrateID] [int] NULL,
	[TrackTitle] [nvarchar](120) NULL,
	[FileName] [nvarchar](120) NOT NULL,
	[FileSize] [nchar](10) NOT NULL,
	[NewFileName] [nvarchar](120) NULL,
 CONSTRAINT [PK_Track] PRIMARY KEY CLUSTERED 
(
	[TrackID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 1) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[PathInsert_SP]    Script Date: 07/07/2010 22:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bobroovskiy
-- Create date: 02.07.10
-- Description:	Insert_SP for inserting data into simple tables
-- =============================================
CREATE PROCEDURE [dbo].[PathInsert_SP]
	@ValueToInsert varchar(500) = null	
AS
BEGIN
    DECLARE @ValueExists int
    SET @ValueExists = 0
    
    SELECT @ValueExists = [PathID]
    FROM [MediaLibrary].[dbo].[Path]
    WHERE 
        [MediaLibrary].[dbo].[Path].[Name] =  @ValueToInsert  
    
	IF @ValueExists <> 0
	  RETURN @ValueExists; 
	ELSE	
	  INSERT INTO [MediaLibrary].[dbo].[Path]([Name])
	  VALUES(@ValueToInsert);

 RETURN SCOPE_IDENTITY();
END

/*
USE [MediaLibrary]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[PathInsert_SP]
		@ValueToInsert = N'empty'

SELECT	@return_value

GO
*/
GO
/****** Object:  StoredProcedure [dbo].[GenreInsert_SP]    Script Date: 07/07/2010 22:33:31 ******/
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
GO
/****** Object:  StoredProcedure [dbo].[TrancateDataBase_SP]    Script Date: 07/07/2010 22:33:31 ******/
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
   -- Drop all tables
    DELETE FROM  [MediaLibrary].[dbo].[Artist]
    DELETE FROM [MediaLibrary].[dbo].[Path]
    DELETE FROM  [MediaLibrary].[dbo].[Album]
    DELETE FROM  [MediaLibrary].[dbo].[Genre]
   DELETE FROM  [MediaLibrary].[dbo].[Bitrate]
    
 -- -- Create all tables
  
 --   CREATE TABLE [dbo].[Artist](
	--[ArtistID] [int] IDENTITY(1,1) NOT NULL,
	--[Name] [nvarchar](150) NULL,
	-- CONSTRAINT [PK_Artist] PRIMARY KEY CLUSTERED 
	--(
	--	[ArtistID] ASC
	--)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 1) ON [PRIMARY]
	--) ON [PRIMARY]  
 -- -- ===============================================
 -- CREATE TABLE [dbo].[Path](
	--[PathID] [int] IDENTITY(1,1) NOT NULL,
	--[Name] [nvarchar](500) NOT NULL,
	-- CONSTRAINT [PK_Path] PRIMARY KEY CLUSTERED 
	--(
	--	[PathID] ASC
	--)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 1) ON [PRIMARY]
	--) ON [PRIMARY]
 -- -- ===============================================
 -- CREATE TABLE [dbo].[Album](
	--[AlbumID] [int] IDENTITY(1,1) NOT NULL,
	--[Name] [nvarchar](100) NULL,
	-- CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED 
	--(
	--	[AlbumID] ASC
	--)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 1) ON [PRIMARY]
	--) ON [PRIMARY]
 -- -- ===============================================
 -- CREATE TABLE [dbo].[Genre](
	--[GenreID] [int] IDENTITY(1,1) NOT NULL,
	--[Name] [nvarchar](50) NULL,
	-- CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
	--(
	--	[GenreID] ASC
	--)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 1) ON [PRIMARY]
	--) ON [PRIMARY]
 -- -- =============================================== 
 -- CREATE TABLE [dbo].[Bitrate](
	--[BitrateID] [int] IDENTITY(1,1) NOT NULL,
	--[Bitrate] [int] NULL,
	-- CONSTRAINT [PK_Bitrate] PRIMARY KEY CLUSTERED 
	--(
	--	[BitrateID] ASC
	--)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 1) ON [PRIMARY]
	--) ON [PRIMARY]
  -- ===============================================   
END

/*
USE [MediaLibrary]
GO
EXEC [dbo].[TrancateDataBase_SP]
GO

*/
GO
/****** Object:  StoredProcedure [dbo].[TrackInsert_SP]    Script Date: 07/07/2010 22:33:31 ******/
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
END

/* execution query


*/
GO
/****** Object:  View [dbo].[MainView]    Script Date: 07/07/2010 22:33:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[MainView]
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
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -90
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Album"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 84
               Right = 189
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Artist"
            Begin Extent = 
               Top = 6
               Left = 227
               Bottom = 84
               Right = 378
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Bitrate"
            Begin Extent = 
               Top = 6
               Left = 416
               Bottom = 84
               Right = 567
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Genre"
            Begin Extent = 
               Top = 84
               Left = 38
               Bottom = 162
               Right = 189
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Path"
            Begin Extent = 
               Top = 121
               Left = 225
               Bottom = 199
               Right = 376
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Track"
            Begin Extent = 
               Top = 147
               Left = 449
               Bottom = 352
               Right = 600
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
      ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'MainView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'   Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'MainView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'MainView'
GO
/****** Object:  StoredProcedure [dbo].[MediaLibrary.GetAllWithPaging]    Script Date: 07/07/2010 22:33:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MediaLibrary.GetAllWithPaging]
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
GO
/****** Object:  ForeignKey [FK_Track_Album]    Script Date: 07/07/2010 22:33:31 ******/
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [FK_Track_Album] FOREIGN KEY([AlbumID])
REFERENCES [dbo].[Album] ([AlbumID])
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [FK_Track_Album]
GO
/****** Object:  ForeignKey [FK_Track_Artist]    Script Date: 07/07/2010 22:33:31 ******/
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [FK_Track_Artist] FOREIGN KEY([ArtistID])
REFERENCES [dbo].[Artist] ([ArtistID])
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [FK_Track_Artist]
GO
/****** Object:  ForeignKey [FK_Track_Bitrate]    Script Date: 07/07/2010 22:33:31 ******/
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [FK_Track_Bitrate] FOREIGN KEY([BitrateID])
REFERENCES [dbo].[Bitrate] ([BitrateID])
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [FK_Track_Bitrate]
GO
/****** Object:  ForeignKey [FK_Track_Genre]    Script Date: 07/07/2010 22:33:31 ******/
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [FK_Track_Genre] FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genre] ([GenreID])
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [FK_Track_Genre]
GO
/****** Object:  ForeignKey [FK_Track_Path]    Script Date: 07/07/2010 22:33:31 ******/
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [FK_Track_Path] FOREIGN KEY([PathID])
REFERENCES [dbo].[Path] ([PathID])
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [FK_Track_Path]
GO
