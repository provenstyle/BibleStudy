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