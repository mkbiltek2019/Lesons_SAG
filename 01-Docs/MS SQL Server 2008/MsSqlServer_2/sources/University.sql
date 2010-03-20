DROP TABLE community.Articles;
DROP TABLE mgmt.Reports;
DROP TABLE mgmt.Workers;
DROP TABLE mgmt.Departaments;

DROP TYPE common.PersonName;

DROP SCHEMA mgmt;
DROP SCHEMA common;
DROP SCHEMA edu;
DROP SCHEMA community;
GO
CREATE SCHEMA mgmt;
GO
CREATE SCHEMA common;
GO
CREATE SCHEMA edu;
GO
CREATE SCHEMA community;
GO
CREATE TYPE common.PersonName FROM NVARCHAR(32) NOT NULL;
GO
CREATE TABLE mgmt.Departaments (
	DepartamentId INT IDENTITY NOT NULL
		CONSTRAINT PK_DepartamentId PRIMARY KEY,
	DepartamentName NCHAR(32) NOT NULL 
		CONSTRAINT UNIQUE_DepartamentName UNIQUE,
	DepartamentDescription NVARCHAR(1024)
);
GO
CREATE TABLE mgmt.Workers (
	WorkerId INT IDENTITY NOT NULL
		CONSTRAINT PK_WorkerId PRIMARY KEY,
	WorkerFirstName common.PersonName,
	WorkerMiddleName common.PersonName,
	WorkerLastName common.PersonName,
	WorkerPosition NCHAR(16) 
		CONSTRAINT CHECK_WorkerPosition
		CHECK (WorkerPosition IN ('Common', 'Teacher', 'Manager', 'Administrator') )
		DEFAULT ('Common'),
	WorkerFullName AS (WorkerFirstName + N' ' + WorkerMiddleName + N' ' + WorkerLastName),
	WorkerDepartamentId INT 
		CONSTRAINT FK_WorkerDepartamentId FOREIGN KEY
		REFERENCES mgmt.Departaments(DepartamentId)
		ON DELETE SET NULL
		ON UPDATE CASCADE
);
GO
CREATE TABLE mgmt.Reports (
	ReportId INT IDENTITY NOT NULL
		CONSTRAINT PK_ReportId PRIMARY KEY,
	ReportWorkerId INT  
		CONSTRAINT FK_ReportWorkerId FOREIGN KEY
		REFERENCES mgmt.Workers(WorkerId)
		ON DELETE SET NULL
		ON UPDATE CASCADE,
	ReportDate DATETIME NOT NULL DEFAULT ( GETDATE() ),
	ReportStatus NCHAR(16) NOT NULL 
		CHECK ( ReportStatus IN (N'NORMAL', N'IMPORTANT', N'CRITICAL' ) )
		DEFAULT ( N'NORMAL' ),
	ReportApprovedById INT 
		CONSTRAINT FK_ApprovedById FOREIGN KEY
		REFERENCES mgmt.Workers(WorkerId)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	ReportText NTEXT NOT NULL
);
GO
CREATE TABLE community.Articles (
	ArticleId INT IDENTITY NOT NULL
		CONSTRAINT PK_ArticleId PRIMARY KEY,
	ArticleAuthorId INT
		CONSTRAINT FK_ArticleAuthorId FOREIGN KEY
		REFERENCES mgmt.Workers(WorkerId)
		ON DELETE SET NULL
		ON UPDATE CASCADE,
	ArticleCategory INT 
		CONSTRAINT FK_ArticleCategory FOREIGN KEY
		REFERENCES community.ArticleCategories(ArticleCategoryId)
		ON DELETE SET NULL
		ON UPDATE CASCADE,
	ArticleRating INT NOT NULL 
		CONSTRAINT CHECK_ArticleRating
		CHECK (ArticleRating >= 0 AND ArticleRating <= 10)
		DEFAULT (0),
	ArticleContent XML
);

CREATE TABLE community.Comments (
	CommentId INT IDENTITY NOT NULL
		CONSTRAINT PK_CommentId PRIMARY KEY,
	CommentUserName common.PersonName,
	CommentText NTEXT NOT NULL
);


