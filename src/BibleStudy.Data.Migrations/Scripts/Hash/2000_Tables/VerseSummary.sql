USE BibleStudy;
GO

IF OBJECT_ID(N'dbo.VerseSummary') IS NULL
BEGIN
	CREATE TABLE VerseSummary (
		Id       INT IDENTITY(1,1),
		VerseId  INT NOT NULL,
		SummaryId INT NOT NULL,
		CONSTRAINT [PK_VerseSummary] PRIMARY KEY CLUSTERED (ID ASC)		 
	);

	ALTER TABLE dbo.VerseSummary WITH CHECK ADD CONSTRAINT FK_VerseSummary_Verse FOREIGN KEY(VerseId)
	REFERENCES dbo.Verse (Id);

	ALTER TABLE dbo.VerseSummary WITH CHECK ADD CONSTRAINT FK_VerseSummary_Summary FOREIGN KEY(SummaryId)
	REFERENCES dbo.Summary (Id);
END;