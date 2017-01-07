USE $DbName$;
GO

IF OBJECT_ID(N'dbo.Book') IS NULL
BEGIN
	CREATE TABLE Book (
		Id          INT           IDENTITY(1,1),
		Name        NVARCHAR(30)  NOT NULL,
		TestamentId INT           NOT NULL,
		CONSTRAINT PK_Book PRIMARY KEY CLUSTERED (Id ASC)
	);
END;