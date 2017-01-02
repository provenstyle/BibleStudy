USE BibleStudy;
GO

IF OBJECT_ID(N'dbo.Testament') IS NULL
BEGIN
	CREATE TABLE Testament(
		Id   INT         IDENTITY(1,1),
		Name NVARCHAR(3) NOT NULL,
		CONSTRAINT PK_Testament PRIMARY KEY CLUSTERED (Id ASC)
	);

	INSERT INTO dbo.Testament
			( Name )
	VALUES  ( N'Old'),
			( N'New');
END;

IF OBJECT_ID(N'dbo.Book') IS NULL
BEGIN
	CREATE TABLE Book (
		Id          INT          IDENTITY(1,1),
		Name        NVARCHAR(30) NOT NULL,
		TestamentId INT          NOT NULL,
		CONSTRAINT PK_Book PRIMARY KEY CLUSTERED (Id ASC)
	);

	INSERT INTO dbo.Book
			(TestamentId, Name)
	VALUES  (1, N'Genesis'),(1, N'Exodus'),(1, N'Leviticus'),(1, N'Number'),(1, N'Deuteronomy'),(1, N'Joshua'),(1, N'Judges'),(1, N'Ruth'),(1, N'1 Samuel'),(1, N'2 Samuel'),(1, N'1 Kings'),(1, N'2 Kings'),(1, N'1 Chronicals'),(1, N'2 Chronicals'),(1, N'Ezra'),(1, N'Nehemiah'),(1, N'Esther'),(1, N'Job'),(1, N'Psalms'),(1, N'Proverbs'),(1, N'Ecclesiastes'),(1, N'Song of Solemon'),(1, N'Isaiah'),(1, N'Jeremiah'),(1, N'Lamentations'),(1, N'Ezekiel'),(1, N'Daniel'),(1, N'Hosea'),(1, N'Joel'),(1, N'Amos'),(1, N'Obadiah'),(1, N'Jonah'),(1, N'Micah'),(1, N'Nahum'),(1, N'Habakkuk'),(1, N'Zephaniah'),(1, N'Haggai'),(1, N'Zechariah'),(1, N'Malachi'),
			(2, N'Matthew'),(2, N'Mark'),(2, N'Luke'),(2, N'John'),(2, N'Acts'),(2, N'Romans'),(2, N'1 Corinthians'),(2, N'2 Corinthians'),(2, N'Galatians'),(2, N'Ephesians'),(2, N'Philippians'),(2, N'Colossians'),(2, N'1 Thessalonians'),(2, N'2 Thessalonians'),(2, N'1 Timothy'),(2, N'2 Timothy'),(2, N'Titus'),(2, N'Philemon'),(2, N'Hebrews'),(2, N'James'),(2, N'1 Peter'),(2, N'2 Peter'),(2, N'1 John'),(2, N'2 John'),(2, N'3 John'),(2, N'Jude'),(2, N'Revelation');

	ALTER TABLE Book WITH CHECK ADD CONSTRAINT FK_Book_Testament FOREIGN KEY(TestamentId)
	REFERENCES dbo.Testament (Id);
END;

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

IF OBJECT_ID(N'dbo.Tag') IS NULL
BEGIN
	CREATE TABLE Tag (
		Id          INT            IDENTITY(1,1),
		Name        NVARCHAR(30)   NOT NULL,
		Description NVARCHAR(2000) NULL,
		CONSTRAINT PK_Tag PRIMARY KEY CLUSTERED (Id ASC)
	);
END;

IF OBJECT_ID(N'dbo.VerseTag') IS NULL
BEGIN
	CREATE TABLE VerseTag (
		Id      INT NOT NULL,
		VerseId INT NOT NULL,
		TagId   INT NOT NULL,
		CONSTRAINT PK_VerseTag PRIMARY KEY CLUSTERED (Id ASC)
	);

	ALTER TABLE VerseTag WITH CHECK ADD CONSTRAINT FK_VerseTag_Verse FOREIGN KEY(VerseId)
	REFERENCES dbo.Verse (Id);

	ALTER TABLE VerseTag WITH CHECK ADD CONSTRAINT FK_VerseTag_Tag FOREIGN KEY(TagId)
	REFERENCES dbo.Tag (Id);
END;

IF OBJECT_ID(N'dbo.Observation') IS NULL
BEGIN
	CREATE TABLE Observation (
		Id   INT          IDENTITY(1,1),
		Text NVARCHAR(4000) NOT NULL,
		CONSTRAINT PK_Observation PRIMARY KEY CLUSTERED (Id ASC)
	);
END;

IF OBJECT_ID(N'dbo.VerseObservation') IS NULL
BEGIN
	CREATE TABLE VerseObservation (
		Id            INT IDENTITY(1,1),
		VerseId       INT NOT NULL,
		ObservationId INT NOT NULL,
		CONSTRAINT [PK_VerseObservation] PRIMARY KEY CLUSTERED (ID ASC)		 
	);

	ALTER TABLE dbo.VerseObservation WITH CHECK ADD CONSTRAINT FK_VerseObservation_Verse FOREIGN KEY(VerseId)
	REFERENCES dbo.Verse (Id);

	ALTER TABLE dbo.VerseObservation WITH CHECK ADD CONSTRAINT FK_VerseObservation_Observation FOREIGN KEY(ObservationId)
	REFERENCES dbo.Observation (Id);
END;

IF OBJECT_ID(N'dbo.Summary') IS NULL
BEGIN
	CREATE TABLE Summary (
		Id   INT          IDENTITY(1,1),
		Text NVARCHAR(200) NOT NULL,
		CONSTRAINT [PK_Summary] PRIMARY KEY CLUSTERED (ID ASC)
	);
END;

IF OBJECT_ID(N'dbo.VerseSummary') IS NULL
BEGIN
	CREATE TABLE VerseSummary (
		Id       INT IDENTITY(1,1),
		VerseId  INT NOT NULL,
		SummaryId INT NOT NULL,
		CONSTRAINT [PK_VerseSummary] PRIMARY KEY CLUSTERED (ID ASC)		 
	);

	ALTER TABLE dbo.VerseSummary WITH CHECK ADD CONSTRAINT FK_VerseSummary_Verse FOREIGN KEY(VerseId)
	REFERENCES dbo.Verse (Id);

	ALTER TABLE dbo.VerseSummary WITH CHECK ADD CONSTRAINT FK_VerseSummary_Summary FOREIGN KEY(SummaryId)
	REFERENCES dbo.Summary (Id);
END;

IF OBJECT_ID(N'dbo.Prayer') IS NULL
BEGIN
	CREATE TABLE Prayer (
		Id   INT          IDENTITY(1,1),
		Text NVARCHAR(4000) NOT NULL,
		CONSTRAINT [PK_Prayer] PRIMARY KEY CLUSTERED (ID ASC)
	);
END;

IF OBJECT_ID(N'dbo.VersePrayer') IS NULL
BEGIN
	CREATE TABLE VersePrayer (
		Id       INT IDENTITY(1,1),
		VerseId  INT NOT NULL,
		PrayerId INT NOT NULL,
		CONSTRAINT [PK_VersePrayer] PRIMARY KEY CLUSTERED (ID ASC)
	);

	ALTER TABLE dbo.VersePrayer WITH CHECK ADD CONSTRAINT FK_VersePrayer_Verse FOREIGN KEY(VerseId)
	REFERENCES dbo.Verse (Id);

	ALTER TABLE dbo.VersePrayer WITH CHECK ADD CONSTRAINT FK_VersePrayer_Prayer FOREIGN KEY(PrayerId)
	REFERENCES dbo.Prayer (Id);
END;

IF OBJECT_ID(N'dbo.Topic') IS NULL
BEGIN
	CREATE TABLE Topic (
		Id   INT          IDENTITY(1,1),
		Text NVARCHAR(50) NOT NULL,
		CONSTRAINT [PK_Topic] PRIMARY KEY CLUSTERED (ID ASC)
	);
END;

IF OBJECT_ID(N'dbo.TopicVerse') IS NULL
BEGIN
	CREATE TABLE TopicVerse (
		Id      INT IDENTITY(1,1),
		TopicId INT NOT NULL,
		VerseId INT NOT NULL,
		CONSTRAINT [PK_TopicVerse] PRIMARY KEY CLUSTERED (ID ASC)
	);

	ALTER TABLE dbo.TopicVerse WITH CHECK ADD CONSTRAINT FK_TopicVerse_Topic FOREIGN KEY(TopicId)
	REFERENCES dbo.Topic (Id);

	ALTER TABLE dbo.TopicVerse WITH CHECK ADD CONSTRAINT FK_TopicVerse_Verse FOREIGN KEY(VerseId)
	REFERENCES dbo.Verse (Id);
END;