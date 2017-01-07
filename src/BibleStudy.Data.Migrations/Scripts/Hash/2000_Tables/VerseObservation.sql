USE $DbName$;
GO

IF OBJECT_ID(N'dbo.VerseObservation') IS NULL
BEGIN
	CREATE TABLE VerseObservation (
		Id            INT         IDENTITY(1,1),
		VerseId       INT         NOT NULL,
		ObservationId INT         NOT NULL,

		Created     DATETIME2     NOT NULL,
		CreatedBy   NVARCHAR(200) NOT NULL,
		Modified    DATETIME2     NOT NULL,
		ModifiedBy  NVARCHAR(200) NOT NULL,
		RowVersion  ROWVERSION,

		CONSTRAINT [PK_VerseObservation] PRIMARY KEY CLUSTERED (Id ASC)
	);
END;
GO;