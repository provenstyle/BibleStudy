USE BibleStudy;
GO

IF OBJECT_ID(N'dbo.VersePrayer') IS NULL
BEGIN
	CREATE TABLE VersePrayer (
		Id       INT IDENTITY(1,1),
		VerseId  INT NOT NULL,
		PrayerId INT NOT NULL,
		CONSTRAINT [PK_VersePrayer] PRIMARY KEY CLUSTERED (ID ASC)
	);

	ALTER TABLE dbo.VersePrayer WITH CHECK ADD CONSTRAINT FK_VersePrayer_Verse FOREIGN KEY(VerseId)
	REFERENCES dbo.Verse (Id);

	ALTER TABLE dbo.VersePrayer WITH CHECK ADD CONSTRAINT FK_VersePrayer_Prayer FOREIGN KEY(PrayerId)
	REFERENCES dbo.Prayer (Id);
END;