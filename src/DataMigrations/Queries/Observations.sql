USE BibleStudy;
GO

DECLARE @bookName NVARCHAR(30)  = '1 John',
        @chapter INT            = 4,
        @verse   INT            = 7,
		@bookId  INT,
		@verseId INT;

SELECT @bookId = Id
FROM dbo.Book
WHERE Name = @bookName;

SELECT @verseId = v.Id
FROM dbo.Verse v
	JOIN dbo.Book b ON b.Id = v.BookId
WHERE BookId    = @bookId
	AND chapter = @chapter 
	AND Verse   = @verse

SELECT b.Name,
       v.Chapter,
	   v.Verse,
	   v.Text
FROM dbo.Verse v
	JOIN dbo.Book b ON b.Id = v.BookId
WHERE v.Id = @verseId

SELECT o.Id, 
       o.Text 
FROM dbo.Observation o
JOIN dbo.VerseObservation vo ON o.id = vo.ObservationId
JOIN dbo.Verse v ON v.id = vo.VerseId
WHERE v.Id = @verseId;

