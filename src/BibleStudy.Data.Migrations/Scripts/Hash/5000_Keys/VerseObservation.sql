USE $DbName$;
GO

IF OBJECT_ID(N'FK_VerseObservation_Verse') IS NULL
BEGIN
	ALTER TABLE dbo.VerseObservation WITH CHECK ADD CONSTRAINT FK_VerseObservation_Verse FOREIGN KEY(VerseId)
	REFERENCES dbo.Verse (Id);
END;

IF OBJECT_ID(N'FK_VerseObservation_Observation') IS NULL
BEGIN
	ALTER TABLE dbo.VerseObservation WITH CHECK ADD CONSTRAINT FK_VerseObservation_Observation FOREIGN KEY(ObservationId)
	REFERENCES dbo.Observation (Id);
END;
