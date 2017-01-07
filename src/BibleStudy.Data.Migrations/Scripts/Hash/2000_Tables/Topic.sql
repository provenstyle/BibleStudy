USE $DbName$;
GO

IF OBJECT_ID(N'dbo.Topic') IS NULL
BEGIN
	CREATE TABLE Topic (
		Id          INT           NOT NULL IDENTITY(1,1),
		Text        NVARCHAR(50)  NOT NULL,

		Created     DATETIME2     NOT NULL,
		CreatedBy   NVARCHAR(200) NOT NULL,
		Modified    DATETIME2     NOT NULL,
		ModifiedBy  NVARCHAR(200) NOT NULL,
		RowVersion  ROWVERSION,

		CONSTRAINT [PK_Topic] PRIMARY KEY CLUSTERED (ID ASC)
	);
END;
