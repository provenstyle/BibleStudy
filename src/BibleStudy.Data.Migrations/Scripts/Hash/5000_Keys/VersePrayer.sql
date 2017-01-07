USE $DbName$;
GO

IF OBJECT_ID(N'FK_VersePrayer_Verse') IS NULL
BEGIN
	ALTER TABLE dbo.VersePrayer WITH CHECK ADD CONSTRAINT FK_VersePrayer_Verse FOREIGN KEY(VerseId)
	REFERENCES dbo.Verse (Id);
END;

IF OBJECT_ID(N'FK_VersePrayer_Prayer ') IS NULL
BEGIN
	ALTER TABLE dbo.VersePrayer WITH CHECK ADD CONSTRAINT FK_VersePrayer_Prayer FOREIGN KEY(PrayerId)
	REFERENCES dbo.Prayer (Id);
END;