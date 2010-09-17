USE [master]
GO

/****** Object:  Database [ElectronicDairy]    Script Date: 09/17/2010 07:32:32 ******/
CREATE DATABASE [ElectronicDairy] ON  PRIMARY 
( NAME = N'ElectronicDairy', FILENAME = N'E:\SQL_SERVER\MSSQL10.MSSQLSERVER\MSSQL\DATA\ElectronicDairy.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ElectronicDairy_log', FILENAME = N'E:\SQL_SERVER\MSSQL10.MSSQLSERVER\MSSQL\DATA\ElectronicDairy_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [ElectronicDairy] SET COMPATIBILITY_LEVEL = 90
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ElectronicDairy].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [ElectronicDairy] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [ElectronicDairy] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [ElectronicDairy] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [ElectronicDairy] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [ElectronicDairy] SET ARITHABORT OFF 
GO

ALTER DATABASE [ElectronicDairy] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [ElectronicDairy] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [ElectronicDairy] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [ElectronicDairy] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [ElectronicDairy] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [ElectronicDairy] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [ElectronicDairy] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [ElectronicDairy] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [ElectronicDairy] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [ElectronicDairy] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [ElectronicDairy] SET  DISABLE_BROKER 
GO

ALTER DATABASE [ElectronicDairy] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [ElectronicDairy] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [ElectronicDairy] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [ElectronicDairy] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [ElectronicDairy] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [ElectronicDairy] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [ElectronicDairy] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [ElectronicDairy] SET  READ_WRITE 
GO

ALTER DATABASE [ElectronicDairy] SET RECOVERY FULL 
GO

ALTER DATABASE [ElectronicDairy] SET  MULTI_USER 
GO

ALTER DATABASE [ElectronicDairy] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [ElectronicDairy] SET DB_CHAINING OFF 
GO


-- //=============================================



USE [ElectronicDairy]
GO
/****** Object:  User [WINXP_WITH_MSSQ\user]    Script Date: 09/17/2010 07:31:26 ******/
CREATE USER [WINXP_WITH_MSSQ\user] FOR LOGIN [WINXP_WITH_MSSQ\user] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [Admin]    Script Date: 09/17/2010 07:31:26 ******/
CREATE USER [Admin] FOR LOGIN [WINXP_WITH_MSSQ\Администратор] WITH DEFAULT_SCHEMA=[db_accessadmin]
GO
/****** Object:  Table [dbo].[Priority]    Script Date: 09/17/2010 07:31:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Priority](
	[PriorityID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Priority] PRIMARY KEY CLUSTERED 
(
	[PriorityID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 1) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemStatus]    Script Date: 09/17/2010 07:31:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemStatus](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ItemStatus] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 1) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DairyDate]    Script Date: 09/17/2010 07:31:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DairyDate](
	[DateID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_DairyDate] PRIMARY KEY CLUSTERED 
(
	[DateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 1) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[InsertDairyDate_SP]    Script Date: 09/17/2010 07:31:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertDairyDate_SP]	
				@Date datetime
AS
BEGIN
	
	
    DECLARE @ValueExists int
    SET @ValueExists = 0
    
    SELECT @ValueExists = [DairyDate].[DateID]
    FROM [ElectronicDairy].[dbo].[DairyDate]
    WHERE 
        [ElectronicDairy].[dbo].[DairyDate].[Date] =  @Date 
    
	IF @ValueExists <> 0
	  RETURN @ValueExists;
	   
	ELSE
	INSERT INTO [ElectronicDairy].[dbo].[DairyDate]([Date])
		VALUES(@Date);

	RETURN SCOPE_IDENTITY();
END
GO
/****** Object:  Table [dbo].[DiaryListItem]    Script Date: 09/17/2010 07:31:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiaryListItem](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[PriorityID] [int] NOT NULL,
	[StatusID] [int] NOT NULL,
	[DateID] [int] NOT NULL,
	[ItemTitle] [nvarchar](150) NULL,
	[ItemContent] [nvarchar](350) NULL,
 CONSTRAINT [PK_DiaryListItem] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 1) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[DeletePriorityByID_SP]    Script Date: 09/17/2010 07:31:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeletePriorityByID_SP]	
				@PriorityID int					
AS
BEGIN    	
	  DELETE  FROM
		[ElectronicDairy].[dbo].[Priority]	 
	  WHERE
		[ElectronicDairy].[dbo].[Priority].[PriorityID]=@PriorityID
END
GO
/****** Object:  StoredProcedure [dbo].[InsertPriority_SP]    Script Date: 09/17/2010 07:31:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertPriority_SP]	
				@ValueName nvarchar(50)		
AS
BEGIN
    DECLARE @ValueExists int
    SET @ValueExists = 0
    
    SELECT @ValueExists = [Priority].[PriorityID]
    FROM [ElectronicDairy].[dbo].[Priority]
    WHERE 
        [ElectronicDairy].[dbo].[Priority].[Name] =  @ValueName  
    
	IF @ValueExists <> 0
	  RETURN @ValueExists;
	   
	ELSE	
	  INSERT INTO [ElectronicDairy].[dbo].[Priority]([Name])
	  VALUES(@ValueName);

 RETURN SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[InsertItemStatus_SP]    Script Date: 09/17/2010 07:31:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertItemStatus_SP]	
				 @ValueName nvarchar(50)		
AS
BEGIN
    DECLARE @ValueExists int
    SET @ValueExists = 0
    
    SELECT @ValueExists = [ItemStatus].StatusID
    FROM [ElectronicDairy].[dbo].[ItemStatus]
    WHERE 
        [ElectronicDairy].[dbo].[ItemStatus].[Name] =  @ValueName  
    
	IF @ValueExists <> 0
		RETURN @ValueExists;	   
	ELSE
	BEGIN	
		INSERT INTO [ElectronicDairy].[dbo].[ItemStatus]([Name])
		VALUES(@ValueName);

		RETURN SCOPE_IDENTITY(); 
	END;
END
GO
/****** Object:  StoredProcedure [dbo].[SelectPriorityByName_SP]    Script Date: 09/17/2010 07:31:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bobroovskiy
-- Create date: 02.07.10
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[SelectPriorityByName_SP]
		@Name nvarchar(50)	
AS
BEGIN
    SELECT
		 [PriorityID] 
    FROM
		 [ElectronicDairy].[dbo].[Priority]
    WHERE
		 [ElectronicDairy].[dbo].[Priority].[Name]=@Name 
END;
GO
/****** Object:  StoredProcedure [dbo].[SelectPriorityByID_SP]    Script Date: 09/17/2010 07:31:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectPriorityByID_SP]
			@ID int	
AS
BEGIN
    SELECT [Name] 
    FROM
		[ElectronicDairy].[dbo].Priority
    WHERE 
		[ElectronicDairy].[dbo].[Priority].PriorityID=@ID 
END
GO
/****** Object:  StoredProcedure [dbo].[SelectPriority_SP]    Script Date: 09/17/2010 07:31:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectPriority_SP]	
AS
BEGIN
    SELECT [Name],[PriorityID] 
    FROM [ElectronicDairy].[dbo].Priority
END
GO
/****** Object:  StoredProcedure [dbo].[SelectItemStatusByName_SP]    Script Date: 09/17/2010 07:31:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectItemStatusByName_SP]	
				 @Name nvarchar(50)
AS
BEGIN
    SELECT 
		[StatusID] 
    FROM 
		[ElectronicDairy].[dbo].[ItemStatus]
	WHERE 
		[ElectronicDairy].[dbo].[ItemStatus].Name = @Name    
END
GO
/****** Object:  StoredProcedure [dbo].[SelectItemStatusByID_SP]    Script Date: 09/17/2010 07:31:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectItemStatusByID_SP]	
				 @ID int
AS
BEGIN
    SELECT 
		[Name] 
    FROM 
		[ElectronicDairy].[dbo].[ItemStatus]
	WHERE 
		[ElectronicDairy].[dbo].[ItemStatus].[StatusID] = @ID
    
END
GO
/****** Object:  StoredProcedure [dbo].[SelectItemStatus_SP]    Script Date: 09/17/2010 07:31:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectItemStatus_SP]	
AS
BEGIN
    SELECT [Name],[StatusID]
    FROM [ElectronicDairy].[dbo].[ItemStatus]
END
GO
/****** Object:  StoredProcedure [dbo].[SelectDairyDateByDateID_SP]    Script Date: 09/17/2010 07:31:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectDairyDateByDateID_SP]
				 @DateID int	
AS
BEGIN
	SET DATEFORMAT dmy;
	
    SELECT
		 [ElectronicDairy].[dbo].[DairyDate].[Date] 
    FROM
		 [ElectronicDairy].[dbo].[DairyDate]
    WHERE
		 [ElectronicDairy].[dbo].[DairyDate].[DateID] = @DateID
END
GO
/****** Object:  StoredProcedure [dbo].[SelectDairyDateByDate_SP]    Script Date: 09/17/2010 07:31:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectDairyDateByDate_SP]
				 @Date datetime	
AS
BEGIN
	SET DATEFORMAT dmy
    SELECT
		 [ElectronicDairy].[dbo].[DairyDate].[DateID] 
    FROM
		 [ElectronicDairy].[dbo].[DairyDate]
    WHERE
		 [ElectronicDairy].[dbo].[DairyDate].[Date] = @Date
END
GO
/****** Object:  StoredProcedure [dbo].[SelectDairyDate_SP]    Script Date: 09/17/2010 07:31:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectDairyDate_SP]				 	
AS
BEGIN
	SET DATEFORMAT dmy;
	
    SELECT
		 [ElectronicDairy].[dbo].[DairyDate].[DateID],
		 [ElectronicDairy].[dbo].[DairyDate].[Date] 
    FROM
		 [ElectronicDairy].[dbo].[DairyDate]    
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateDairyDate_SP]    Script Date: 09/17/2010 07:31:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateDairyDate_SP]	
				@DateID int,
				@ValueName datetime		
AS
BEGIN  
	 SET DATEFORMAT dmy
  	
	  UPDATE  
		[ElectronicDairy].[dbo].[DairyDate]
	  SET 
		[ElectronicDairy].[dbo].[DairyDate].[Date]=@ValueName
	  WHERE
		[ElectronicDairy].[dbo].[DairyDate].[DateID]=@DateID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteDairyDateByID_SP]    Script Date: 09/17/2010 07:31:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteDairyDateByID_SP]	
				@DateID int					
AS
BEGIN    	
	  DELETE  FROM
		[ElectronicDairy].[dbo].[DairyDate]	 
	  WHERE
		[ElectronicDairy].[dbo].[DairyDate].[DateID]=@DateID
END
GO
/****** Object:  StoredProcedure [dbo].[UpdatePriority_SP]    Script Date: 09/17/2010 07:31:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdatePriority_SP]	
				@PriorityID int,
				@ValueName nvarchar(50)		
AS
BEGIN    	
	  UPDATE  
		[ElectronicDairy].[dbo].[Priority]
	  SET 
		[ElectronicDairy].[dbo].[Priority].[Name]=@ValueName
	  WHERE
		[ElectronicDairy].[dbo].[Priority].[PriorityID]=@PriorityID
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateItemStatus_SP]    Script Date: 09/17/2010 07:31:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateItemStatus_SP]	
				@StatusID int,
				@ValueName nvarchar(50)		
AS
BEGIN    	
	  UPDATE  
		[ElectronicDairy].[dbo].[ItemStatus]
	  SET 
		[ElectronicDairy].[dbo].[ItemStatus].[Name]=@ValueName
	  WHERE
		[ElectronicDairy].[dbo].[ItemStatus].[StatusID]=@StatusID
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateDairyListItemByListItemID_SP]    Script Date: 09/17/2010 07:31:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateDairyListItemByListItemID_SP]	
				 @ItemID int,
				 @PriorityID int,
				 @StatusID int,
				 @DateID int,	
				 @ItemTitle nvarchar(150),
				 @ItemContent nvarchar(350)		
AS
BEGIN    	
	  UPDATE  
		[ElectronicDairy].[dbo].[DiaryListItem]
	  SET 
		[ElectronicDairy].[dbo].[DiaryListItem].[PriorityID]=@PriorityID,
		[ElectronicDairy].[dbo].[DiaryListItem].[StatusID]=@StatusID,
		[ElectronicDairy].[dbo].[DiaryListItem].[DateID]=@DateID,
		[ElectronicDairy].[dbo].[DiaryListItem].[ItemTitle]=@ItemTitle,
		[ElectronicDairy].[dbo].[DiaryListItem].[ItemContent]=@ItemContent
	  WHERE
		[ElectronicDairy].[dbo].[DiaryListItem].[ItemID]=@ItemID
END
GO
/****** Object:  StoredProcedure [dbo].[SelectTaskListByDate_SP]    Script Date: 09/17/2010 07:31:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectTaskListByDate_SP]
    @currentDate datetime   
AS
BEGIN
	SELECT 
		[dbo].[DairyDate].[Date],
		[dbo].[DiaryListItem].[ItemContent],
		[dbo].[DiaryListItem].[ItemTitle],
		[dbo].[ItemStatus].[Name],
		[dbo].[Priority].[Name]
	FROM         
		[dbo].[DairyDate] INNER JOIN [dbo].DiaryListItem ON 
		[dbo].[DairyDate].ItemID = [dbo].[DiaryListItem].[ItemID] 
		INNER JOIN	[dbo].[ItemStatus] ON 
		[dbo].[DiaryListItem].[StatusID] = [dbo].[ItemStatus].[StatusID] 
		INNER JOIN	[dbo].[Priority] ON 
		[dbo].[DiaryListItem].[PriorityID] = [dbo].[Priority].[PriorityID]
	WHERE
	   [dbo].[DairyDate].[Date] = @currentDate
	ORDER BY [dbo].[DiaryListItem].[ItemTitle]
	
END;
GO
/****** Object:  StoredProcedure [dbo].[SelectDateIDByDairyListItemID_SP]    Script Date: 09/17/2010 07:31:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectDateIDByDairyListItemID_SP]
				 @ItemID int	
AS
BEGIN
	DECLARE @Result int
	SET @Result=0
	
    SELECT
		@Result=[ElectronicDairy].[dbo].[DiaryListItem].[DateID]
    FROM
		 [ElectronicDairy].[dbo].[DiaryListItem]
    WHERE
		 [ElectronicDairy].[dbo].[DiaryListItem].[ItemID]=@ItemID 
		 
	RETURN @Result
END
GO
/****** Object:  StoredProcedure [dbo].[SelectDairyListItemByDateID_SP]    Script Date: 09/17/2010 07:31:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectDairyListItemByDateID_SP]
				 @Date datetime	
AS
BEGIN
	
    SELECT
		 [ElectronicDairy].[dbo].[DiaryListItem].[ItemID],
		 [ElectronicDairy].[dbo].[DiaryListItem].[PriorityID],
		 [ElectronicDairy].[dbo].[DiaryListItem].[StatusID],
		 [ElectronicDairy].[dbo].[DairyDate].[DateID],
		 [ElectronicDairy].[dbo].[DiaryListItem].[ItemTitle],
		 [ElectronicDairy].[dbo].[DiaryListItem].[ItemContent]
    FROM
		 [ElectronicDairy].[dbo].[DiaryListItem] JOIN
		 [ElectronicDairy].[dbo].[DairyDate] ON
		 [ElectronicDairy].[dbo].[DiaryListItem].[DateID]=
		 [ElectronicDairy].[dbo].[DairyDate].[DateID]
    WHERE
		 [ElectronicDairy].[dbo].[DairyDate].[Date]=@Date 
END
GO
/****** Object:  StoredProcedure [dbo].[InsertDairyListItem_SP]    Script Date: 09/17/2010 07:31:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertDairyListItem_SP]
	@PriorityID	int,
	@StatusID int,
	@DateID int,	
	@ItemTitle nvarchar(150),
	@ItemContent nvarchar(350)		
AS
BEGIN
	INSERT INTO 
		[ElectronicDairy].[dbo].[DiaryListItem]([PriorityID],[StatusID],[DateID],[ItemTitle],[ItemContent])
	VALUES(@PriorityID,@StatusID,@DateID,@ItemTitle,@ItemContent)
	
	RETURN SCOPE_IDENTITY()	
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteDiaryListItemByListItemID_SP]    Script Date: 09/17/2010 07:31:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteDiaryListItemByListItemID_SP]	
				@ItemID int				
AS
BEGIN    	
	DELETE  FROM
		[ElectronicDairy].[dbo].[DiaryListItem]	 
	WHERE
		[ElectronicDairy].[dbo].[DiaryListItem].[ItemID]=@ItemID
	
END
GO
/****** Object:  ForeignKey [FK_DiaryListItem_DairyDate]    Script Date: 09/17/2010 07:31:33 ******/
ALTER TABLE [dbo].[DiaryListItem]  WITH CHECK ADD  CONSTRAINT [FK_DiaryListItem_DairyDate] FOREIGN KEY([DateID])
REFERENCES [dbo].[DairyDate] ([DateID])
GO
ALTER TABLE [dbo].[DiaryListItem] CHECK CONSTRAINT [FK_DiaryListItem_DairyDate]
GO
/****** Object:  ForeignKey [FK_DiaryListItem_ItemStatus]    Script Date: 09/17/2010 07:31:33 ******/
ALTER TABLE [dbo].[DiaryListItem]  WITH CHECK ADD  CONSTRAINT [FK_DiaryListItem_ItemStatus] FOREIGN KEY([StatusID])
REFERENCES [dbo].[ItemStatus] ([StatusID])
GO
ALTER TABLE [dbo].[DiaryListItem] CHECK CONSTRAINT [FK_DiaryListItem_ItemStatus]
GO
/****** Object:  ForeignKey [FK_DiaryListItem_Priority]    Script Date: 09/17/2010 07:31:33 ******/
ALTER TABLE [dbo].[DiaryListItem]  WITH CHECK ADD  CONSTRAINT [FK_DiaryListItem_Priority] FOREIGN KEY([PriorityID])
REFERENCES [dbo].[Priority] ([PriorityID])
GO
ALTER TABLE [dbo].[DiaryListItem] CHECK CONSTRAINT [FK_DiaryListItem_Priority]
GO
