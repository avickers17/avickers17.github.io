--Forms Table
CREATE TABLE [dbo].[Tennants]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[FirstName] NVARCHAR(64) NOT NULL,
	[LastName] NVARCHAR(64) NOT NULL,
	[PhoneNumber] NVARCHAR(12) NOT NULL,
	[ApartmentName] NVARCHAR(64) NOT NULL,
	[UnitNumber] INT NOT NUll,
	[TextBox] NVARCHAR(500) NOT NULL,
	[CheckBox] BIT NOT NULL,
	[VerifiedDate] DATETIME NULL,

	CONSTRAINT [PK_dbo.Tennants] PRIMARY KEY CLUSTERED ([ID] ASC)
	);

	INSERT INTO [dbo].[Tennants] (FirstName, LastName, PhoneNumber, ApartmentName, UnitNumber, TextBox, CheckBox, VerifiedDate) VALUES
		('Jon','Jonny','888-888-8888', 'Building A', 10, 'Help with Faucet', 1, '2018-2-13'),
		('Kim','Kimberly','777-777-7777', 'Building C', 9, 'Help with Faucet', 1, '2018-3-14'),
		('Alice','Alison','555-555-5555', 'Building F', 8, 'Help with Faucet', 1, '2018-4-12')
		GO
