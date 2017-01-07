USE $DbName$;
GO

IF OBJECT_ID(N'dbo.Summary') IS NULL
BEGIN
	CREATE TABLE Summary (
		Id          INT           NOT NULL IDENTITY(1,1),
		Text        NVARCHAR(200) NOT NULL,

		Created     DATETIME2     NOT NULL,
		CreatedBy   NVARCHAR(200) NOT NULL,
		Modified    DATETIME2     NOT NULL,
		ModifiedBy  NVARCHAR(200) NOT NULL,
		RowVersion  ROWVERSION,

		CONSTRAINT [PK_Summary] PRIMARY KEY CLUSTERED (ID ASC)
	);
END;