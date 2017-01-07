USE $DbName$;
GO

IF OBJECT_ID(N'dbo.Prayer') IS NULL
BEGIN
	CREATE TABLE Prayer (
		Id          INT            IDENTITY(1,1),
		Text        NVARCHAR(4000) NOT NULL,

		Created     DATETIME2      NOT NULL,
		CreatedBy   NVARCHAR(200)  NOT NULL,
		Modified    DATETIME2      NOT NULL,
		ModifiedBy  NVARCHAR(200)  NOT NULL,
		RowVersion  ROWVERSION

		CONSTRAINT [PK_Prayer] PRIMARY KEY CLUSTERED (ID ASC)
	);
END;
