USE [ElectronicDairy]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bobrovskiy
-- Create date: 30.08.10
-- Description:	All for DairyListItem table
-- ========================1=====================
ALTER PROCEDURE [dbo].[InsertDairyListItem_SP]
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
-- ========================2===============================================================
GO
ALTER PROCEDURE [dbo].[SelectDairyListItemByDateID_SP]
				 @Date datetime	
AS
BEGIN
	SET DATEFORMAT dmy
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
-- ========================3===============================================================
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
-- ========================4===============================================================
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
-- ========================5===============================================================
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
-- ========================6===============================================================
GO

-- ========================7===============================================================
GO

-- ========================8===============================================================
GO


