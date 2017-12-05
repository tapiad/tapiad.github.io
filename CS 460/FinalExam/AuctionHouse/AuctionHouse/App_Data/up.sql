--Create Buyers Table
CREATE TABLE dbo.Buyers
(
	Name		VARCHAR(50)		NOT NULL,

	CONSTRAINT [PK_dbo.Buyers] PRIMARY KEY (Name)
);

--Create Sellers Table
CREATE TABLE dbo.Sellers
(
	Name		VARCHAR(50)		NOT NULL,

	CONSTRAINT [PK_dbo.Sellers] PRIMARY KEY (Name)
);

--Create Items Table
CREATE TABLE dbo.Items
(
	ID			INT				NOT NULL,
	Name		VARCHAR(50)		NOT NULL,
	Description	VARCHAR(100)	NULL,
	Seller		VARCHAR(50)		NOT NULL

	CONSTRAINT [PK_dbo.Items] PRIMARY KEY (ID,Name),
	CONSTRAINT [UC_dbo.Items] UNIQUE (Description),
	CONSTRAINT [FK_dbo.Items] FOREIGN KEY (Seller)
		REFERENCES dbo.Sellers(Name)
);

--Create Bids Table
CREATE TABLE dbo.Bids
(
	Item		INT				NOT NULL,
	Buyer		VARCHAR(50)		NOT NULL,
	Price		INT				NOT NULL,
	Timestamp	Date			NULL

	CONSTRAINT [FK1_dbo.Bids] FOREIGN KEY (Item)
		REFERENCES dbo.Items(ID),
	CONSTRAINT [FK2_dbo.Bids] FOREIGN KEY (Buyer)
		REFERENCES dbo.Buyers(Name)
);


-- Buyers
INSERT INTO dbo.Buyers (Name) VALUES
('Jane Stone'),
('Tom McMasters'),
('Otto Vanderwall');

-- Sellers
INSERT INTO dbo.Sellers (Name) VALUES
('Gayle Hardy'),
('Lyle Banks'),
('Pearl Greene');

-- Items
INSERT INTO dbo.Items (ID, Name, Description, Seller) VALUES
(1001, 'Abraham Lincoln Hammer', 'A bench mallet fashioned from a broken rail-splitting maul in 1829 and owned by Abraham Lincoln', 'Pearl Greene'),
(1002, 'Albert Einsteins Telescope', 'A brass telescope owned by Albert Einstein in Germany, circa 1927', 'Gayle Hardy'),
(1003, 'Bob Dylan Love Poems', 'Five versions of an original unpublished, handwritten, love poem by Bob Dylan', 'Lyle Banks');

--Bids
INSERT INTO dbo.Bids (Item, Buyer, Price, Timestamp) VALUES
(1001, 'Otto Vanderwall', 250000,'12/04/2017 09:04:22'),
(1003, 'Jane Stone', 95000 ,'12/04/2017 08:44:03');

GO