--Forms Table
CREATE TABLE [dbo].[Searches]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[SearchPhrase] NVARCHAR(500) NOT NULL,
	[IpAddress] NVARCHAR(500) NOT NULL,
	[Browser] NVARCHAR(500) NOT NULL,
	[DateCreated] DATETIME NULL,

	CONSTRAINT [PK_dbo.Searches] PRIMARY KEY CLUSTERED ([ID] ASC)
	);

		GO