﻿USE BibleStudy;
GO

IF OBJECT_ID(N'dbo.Observation') IS NULL
BEGIN
	CREATE TABLE Observation (
		Id   INT          IDENTITY(1,1),
		Text NVARCHAR(4000) NOT NULL,
		CONSTRAINT PK_Observation PRIMARY KEY CLUSTERED (Id ASC)
	);
END;