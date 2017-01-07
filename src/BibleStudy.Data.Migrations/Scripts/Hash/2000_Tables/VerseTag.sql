USE $DbName$;
GO

IF OBJECT_ID(N'dbo.VerseTag') IS NULL
BEGIN
	CREATE TABLE VerseTag (
		Id          INT           IDENTITY(1,1),
		VerseId     INT           NOT NULL,
		TagId       INT           NOT NULL,

		Created     DATETIME2     NOT NULL,
		CreatedBy   NVARCHAR(200) NOT NULL,
		Modified    DATETIME2     NOT NULL,
		ModifiedBy  NVARCHAR(200) NOT NULL,
		RowVersion  ROWVERSION,

		CONSTRAINT PK_VerseTag PRIMARY KEY CLUSTERED (Id ASC)
	);
END;