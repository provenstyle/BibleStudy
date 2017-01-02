USE BibleStudy;
GO

DECLARE @bookName      NVARCHAR(30)   = '1 John',
        @chapter       INT            = 4,
        @verse         INT            = 7,
		@observation   NVARCHAR(4000) = 'Love is from God',
		@bookId        INT,
		@verseId       INT,
		@observationId INT;

SELECT @bookId = Id
FROM dbo.Book
WHERE Name = @bookName;

SELECT @verseId = v.Id
FROM dbo.Verse v
	JOIN dbo.Book b ON b.Id = v.BookId
WHERE BookId    = @bookId
	AND Chapter = @chapter 
	AND Verse   = @verse;

SELECT b.Name,
       v.Chapter,
	   v.Verse,
	   v.Text
FROM dbo.Verse v
	JOIN dbo.Book b ON b.Id = v.BookId
WHERE v.Id = @verseId;

INSERT INTO dbo.Observation
        ( Text )
VALUES  ( @observation );

SET @observationId = SCOPE_IDENTITY();

INSERT INTO dbo.VerseObservation
        ( VerseId, ObservationId )
VALUES  ( @verseId, @observationId)
