﻿USE BibleStudy;
GO

IF OBJECT_ID(N'dbo.Summary') IS NULL
BEGIN
	CREATE TABLE Summary (
		Id   INT          IDENTITY(1,1),
		Text NVARCHAR(200) NOT NULL,
		CONSTRAINT [PK_Summary] PRIMARY KEY CLUSTERED (ID ASC)
	);
END;