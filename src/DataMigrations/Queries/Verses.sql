USE BibleStudy;
GO

SELECT TOP 100
	   v.Id AS VerseId,
	   b.Id AS BookId,
	   b.Name,
       v.Chapter ,
       v.Verse ,
	   v.Text
FROM dbo.Verse v
JOIN dbo.Book b ON v.BookId = b.Id
ORDER BY BookId, v.Chapter, v.Verse