USE $DbName$;
GO

IF NOT EXISTS (SELECT TOP 1 * FROM dbo.Testament)
BEGIN
	INSERT INTO dbo.Testament
			( Name )
	VALUES  ( N'Old'),
			( N'New');
END

IF NOT EXISTS(SELECT TOP 1 * FROM dbo.Book)
BEGIN
	INSERT INTO dbo.Book
			(TestamentId, Name)
	VALUES  (1, N'Genesis'),(1, N'Exodus'),(1, N'Leviticus'),(1, N'Number'),(1, N'Deuteronomy'),(1, N'Joshua'),(1, N'Judges'),(1, N'Ruth'),(1, N'1 Samuel'),(1, N'2 Samuel'),(1, N'1 Kings'),(1, N'2 Kings'),(1, N'1 Chronicals'),(1, N'2 Chronicals'),(1, N'Ezra'),(1, N'Nehemiah'),(1, N'Esther'),(1, N'Job'),(1, N'Psalms'),(1, N'Proverbs'),(1, N'Ecclesiastes'),(1, N'Song of Solemon'),(1, N'Isaiah'),(1, N'Jeremiah'),(1, N'Lamentations'),(1, N'Ezekiel'),(1, N'Daniel'),(1, N'Hosea'),(1, N'Joel'),(1, N'Amos'),(1, N'Obadiah'),(1, N'Jonah'),(1, N'Micah'),(1, N'Nahum'),(1, N'Habakkuk'),(1, N'Zephaniah'),(1, N'Haggai'),(1, N'Zechariah'),(1, N'Malachi'),
			(2, N'Matthew'),(2, N'Mark'),(2, N'Luke'),(2, N'John'),(2, N'Acts'),(2, N'Romans'),(2, N'1 Corinthians'),(2, N'2 Corinthians'),(2, N'Galatians'),(2, N'Ephesians'),(2, N'Philippians'),(2, N'Colossians'),(2, N'1 Thessalonians'),(2, N'2 Thessalonians'),(2, N'1 Timothy'),(2, N'2 Timothy'),(2, N'Titus'),(2, N'Philemon'),(2, N'Hebrews'),(2, N'James'),(2, N'1 Peter'),(2, N'2 Peter'),(2, N'1 John'),(2, N'2 John'),(2, N'3 John'),(2, N'Jude'),(2, N'Revelation');
END
