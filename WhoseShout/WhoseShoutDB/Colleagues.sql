CREATE TABLE [dbo].[Colleagues]
(
	[ColleagueId] INT NOT NULL,
	[name] NVARCHAR(100) NOT NULL,
	[email] NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_email PRIMARY KEY ([email])
)
