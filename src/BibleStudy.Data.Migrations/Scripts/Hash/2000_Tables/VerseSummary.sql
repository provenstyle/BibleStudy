USE $DbName$;
GO

IF OBJECT_ID(N'dbo.VerseSummary') IS NULL
BEGIN
	CREATE TABLE VerseSummary (
		Id          INT           NOT NULL IDENTITY(1,1),
		VerseId     INT           NOT NULL,
		SummaryId   INT           NOT NULL,

		Created     DATETIME2     NOT NULL,
		CreatedBy   NVARCHAR(200) NOT NULL,
		Modified    DATETIME2     NOT NULL,
		ModifiedBy  NVARCHAR(200) NOT NULL,
		RowVersion  ROWVERSION,

		CONSTRAINT [PK_VerseSummary] PRIMARY KEY CLUSTERED (ID ASC)
	);
END;