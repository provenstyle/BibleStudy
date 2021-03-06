USE BibleStudy
GO

DECLARE @bookName NVARCHAR(30)  = '1 Corinthians',
        @chapter INT            = 13,
        @number  INT            = 1,
		@text    NVARCHAR(4000) = 'If I speak with the tongues of men and of angels, but do not have love, I have become a noisy gong or a clanging cymbal.',
		@bookId  INT;

SELECT @bookId = Id
FROM dbo.Book
WHERE Name = @bookName;

INSERT INTO dbo.Verse
        ( Chapter,  Number,  BookId,  Text )
VALUES  ( @chapter, @number, @bookId, @text)