USE $DbName$;
GO

IF OBJECT_ID(N'dbo.TopicVerse') IS NULL
BEGIN
	CREATE TABLE TopicVerse (
		Id          INT           NOT NULL IDENTITY(1,1),
		TopicId     INT           NOT NULL,
		VerseId     INT           NOT NULL,

		Created     DATETIME2     NOT NULL,
		CreatedBy   NVARCHAR(200) NOT NULL,
		Modified    DATETIME2     NOT NULL,
		ModifiedBy  NVARCHAR(200) NOT NULL,
		RowVersion  ROWVERSION,

		CONSTRAINT [PK_TopicVerse] PRIMARY KEY CLUSTERED (ID ASC)
	);
END;