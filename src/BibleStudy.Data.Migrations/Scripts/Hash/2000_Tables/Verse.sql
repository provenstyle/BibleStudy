USE $DbName$;
GO

IF OBJECT_ID(N'dbo.Verse') IS NULL
BEGIN
	CREATE TABLE Verse (
		Id          INT            IDENTITY(1,1),
		Chapter     INT            NOT NULL,
		Number      INT            NOT NULL,
		BookId      INT            NOT NULL,
		Test        NVARCHAR(4000) NOT NULL,

		Created     DATETIME2      NOT NULL,
		CreatedBy   NVARCHAR(200)  NOT NULL,
		Modified    DATETIME2      NOT NULL,
		ModifiedBy  NVARCHAR(200)  NOT NULL,
		RowVersion  ROWVERSION,

		CONSTRAINT PK_Verse PRIMARY KEY CLUSTERED (Id ASC)
	);
END;
