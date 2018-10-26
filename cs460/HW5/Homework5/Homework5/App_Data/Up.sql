--Forms Table
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
		('Jon','Jonny','888-888-8888', 'Building A', 21, 'Help with faucet', 1, '2018-10-13'),
		('Kim','Kimberly','777-777-7777', 'Building C', 10, 'Broken shower head', 1, '2018-7-14'),
		('Alice','Alison','555-555-5555', 'Building F', 19, 'Closet door busted', 0, '2018-4-12'),
		('Bev','Beverly','999-999-9999','Building B', 33,'Doorknob fell off', 0, '2018-5-11'),
		('Carl','Carlson','222-222-2222','Building A', 17,'Broken sink', 1, '2018-6-10')
		GO
