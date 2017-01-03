USE BibleStudy;
GO

IF OBJECT_ID(N'dbo.Verse') IS NULL
BEGIN
	CREATE TABLE Verse (
		Id      INT IDENTITY(1,1),
		Chapter INT            NOT NULL,
		Number  INT            NOT NULL,
		BookId  INT            NOT NULL,
		Test    NVARCHAR(4000) NOT NULL
		CONSTRAINT PK_Verse PRIMARY KEY CLUSTERED (Id ASC)
	);

	ALTER TABLE Verse WITH CHECK ADD CONSTRAINT FK_Verse_Book FOREIGN KEY(BookId)
	REFERENCES dbo.Book (Id);
END;
