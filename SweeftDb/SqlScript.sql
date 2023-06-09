﻿CREATE TABLE [dbo].[teachers] ( 
				FIRST_NAME NVARCHAR(50),
				LAST_NAME NVARCHAR(50),
				SEX VARCHAR(1),
				SUBJECT_NAME NVARCHAR(20)
			);

GO

CREATE TABLE [dbo].[students] (
				FIRST_NAME NVARCHAR(50),
				LAST_NAME NVARCHAR(50),
				SEX VARCHAR(1),
				CLASS VARCHAR(4)
			);

GO

CREATE TABLE [dbo].[subjects] (
				SUBJECT_NAME NVARCHAR(20),
				CLASS VARCHAR(4)
				);

GO

ALTER TABLE [dbo].[subjects] 
ADD CONSTRAINT FK_SUBJECT_TO_STUDENT
FOREIGN KEY (CLASS)
REFERENCES [dbo].[students] ( CLASS );

GO

ALTER TABLE [dbo].[subjects] 
ADD CONSTRAINT FK_SUBJECT_TO_TEACHERS
FOREIGN KEY (SUBJECT_NAME)
REFERENCES [dbo].[teachers] ( SUBJECT_NAME );
