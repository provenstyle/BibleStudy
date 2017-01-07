USE $DbName$;
GO

IF OBJECT_ID(N'FK_VerseSummary_Verse') IS NULL
BEGIN
	ALTER TABLE dbo.VerseSummary WITH CHECK ADD CONSTRAINT FK_VerseSummary_Verse FOREIGN KEY(VerseId)
	REFERENCES dbo.Verse (Id);
END;

IF OBJECT_ID(N'FK_VerseSummary_Summary') IS NULL
BEGIN
	ALTER TABLE dbo.VerseSummary WITH CHECK ADD CONSTRAINT FK_VerseSummary_Summary FOREIGN KEY(SummaryId)
	REFERENCES dbo.Summary (Id);
END;