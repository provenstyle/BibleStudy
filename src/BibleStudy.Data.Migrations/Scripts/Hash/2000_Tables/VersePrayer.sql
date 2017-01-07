USE $DbName$;
GO

IF OBJECT_ID(N'dbo.VersePrayer') IS NULL
BEGIN
	CREATE TABLE VersePrayer (
		Id          INT           IDENTITY(1,1),
		VerseId     INT           NOT NULL,
		PrayerId    INT           NOT NULL,

		Created     DATETIME2     NOT NULL,
		CreatedBy   NVARCHAR(200) NOT NULL,
		Modified    DATETIME2     NOT NULL,
		ModifiedBy  NVARCHAR(200) NOT NULL,
		RowVersion  ROWVERSION,

		CONSTRAINT [PK_VersePrayer] PRIMARY KEY CLUSTERED (ID ASC)
	);
END;