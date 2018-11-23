CREATE TABLE [dbo].[coffeeDate]
(
	[coffeeDateID] INT NOT NULL,
	[name] NVARCHAR(100) NOT NULL,
	[email] NVARCHAR(100) NOT NULL,
	[dateTime] DATETIME NOT NULL,
	[venue] NVARCHAR(100) NOT NULL,
	[spent] MONEY NULL,
	CONSTRAINT PK_coffeeDateID PRIMARY KEY ([coffeeDateID]),
	CONSTRAINT FK_email FOREIGN KEY (email) REFERENCES Colleagues (email)

)
