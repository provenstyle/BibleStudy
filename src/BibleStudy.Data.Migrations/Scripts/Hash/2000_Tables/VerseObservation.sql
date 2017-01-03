USE BibleStudy;
GO

IF OBJECT_ID(N'dbo.VerseObservation') IS NULL
BEGIN
	CREATE TABLE VerseObservation (
		Id            INT IDENTITY(1,1),
		VerseId       INT NOT NULL,
		ObservationId INT NOT NULL,
		CONSTRAINT [PK_VerseObservation] PRIMARY KEY CLUSTERED (ID ASC)		 
	);

	ALTER TABLE dbo.VerseObservation WITH CHECK ADD CONSTRAINT FK_VerseObservation_Verse FOREIGN KEY(VerseId)
	REFERENCES dbo.Verse (Id);

	ALTER TABLE dbo.VerseObservation WITH CHECK ADD CONSTRAINT FK_VerseObservation_Observation FOREIGN KEY(ObservationId)
	REFERENCES dbo.Observation (Id);
END;
