USE $DbName$;
GO

IF OBJECT_ID(N'dbo.Tag') IS NULL
BEGIN
	CREATE TABLE Tag (
		Id          INT            NOT NULL IDENTITY(1,1),
		Name        NVARCHAR(30)   NOT NULL,
		Description NVARCHAR(2000) NULL,

		Created     DATETIME2      NOT NULL,
		CreatedBy   NVARCHAR(200)  NOT NULL,
		Modified    DATETIME2      NOT NULL,
		ModifiedBy  NVARCHAR(200)  NOT NULL,
		RowVersion  ROWVERSION,

		CONSTRAINT PK_Tag PRIMARY KEY CLUSTERED (Id ASC)
	);
END;
