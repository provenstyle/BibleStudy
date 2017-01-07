﻿USE $DbName$;
GO

IF OBJECT_ID(N'FK_Book_Testament') IS NULL
BEGIN
	ALTER TABLE Book WITH CHECK ADD CONSTRAINT FK_Book_Testament FOREIGN KEY(TestamentId)
	REFERENCES dbo.Testament (Id);
END;
