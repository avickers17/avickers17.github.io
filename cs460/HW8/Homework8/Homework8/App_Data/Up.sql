CREATE TABLE [dbo].[Buyers]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[FullName] NVARCHAR(50) NOT NULL,

	CONSTRAINT [PK_dbo.Buyers] PRIMARY KEY CLUSTERED ([FullName] ASC)
	);

	CREATE TABLE [dbo].[Sellers]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[FullName] NVARCHAR(50) NOT NULL,

	CONSTRAINT [PK_dbo.Sellers] PRIMARY KEY CLUSTERED ([FullName] ASC)
	);

	CREATE TABLE [dbo].[Items]
(
	[ID] INT IDENTITY (1001,1) NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(MAX) NOT NULL,
	[SellerFullName] NVARCHAR(50) NOT NULL,

	CONSTRAINT [PK_dbo.Items] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Items] FOREIGN KEY (SellerFullName) REFERENCES [dbo].[Sellers] (FullName)
	);

	CREATE TABLE [dbo].[Bids]
	(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[ItemID] INT NOT NULL,
	[BuyerFullName] NVARCHAR(50) NOT NULL,
	[Price] INT NOT NULL,
	[TimeStamp] DATETIME NOT NULL,
	
	CONSTRAINT [PK_dbo.Bids] PRIMARY KEY CLUSTERED (ID ASC),
    CONSTRAINT [FK_dbo.Bids] FOREIGN KEY (ItemID) REFERENCES [dbo].[Items] (ID),
	CONSTRAINT [FK2_dbo.Bids] FOREIGN KEY (BuyerFullName) REFERENCES [dbo].[Buyers] (FullName)
	);

	INSERT INTO [dbo].[Buyers] (FullName) VALUES
		('Jane Stone'),
		('Tom McMasters'),
		('Otto Vanderwall')

	INSERT INTO [dbo].[Sellers](FullName) VALUES
		('Gayle Hardy'),
		('Lyle Banks'),
		('Pearl Greene')

	INSERT INTO [dbo].[Items](Name, Description, SellerFullName) VALUES
		('Abraham Lincoln Hammer','A bench mallet fashioned from a broken rail-splitting maul in 1829 and owned by Abraham Lincoln', 'Pearl Greene'),
		('Albert Einsteins Telescope','A brass telescope owned by Albert Einstein in Germany, circa 1927', 'Gayle Hardy'),
		('Bob Dylan Love Poems','Five versions of an original unpublished, handwritten, love poem by Bob Dylan', 'Lyle Banks')

	INSERT INTO [dbo].[Bids](ItemID, BuyerFullName, Price, TimeStamp) VALUES
		(1001, 'Otto Vanderwall', 250000,'12/04/2017 09:04:22'),
		(1003,'Jane Stone', 95000 ,'12/04/2017 08:44:03')

		GO