--Artists Table
CREATE TABLE dbo.Artists
(
	Name		VARCHAR(50)		NOT NULL,
	BirthDate	DATE			NOT NULL,
	BirthCity	VARCHAR(100)	NOT NULL

	CONSTRAINT [PK_dbo.Artists] PRIMARY KEY (Name)
);

--ArtWorks Table
CREATE TABLE dbo.ArtWorks
(
	Title	VARCHAR(100)	NOT NULL,
	Artist	VARCHAR(50)		NULL
	
	CONSTRAINT [PK_dbo.ArtWorks] PRIMARY KEY (Title),
	CONSTRAINT [FK_dbo.ArtWorks] FOREIGN KEY (Artist)
	REFERENCES dbo.Artists (Name)
);

--Genres Table
CREATE TABLE dbo.Genres
(
	Name	VARCHAR(50)	NOT NULL

	CONSTRAINT [PK_dbo.Genres] PRIMARY KEY (Name)
);

--Classifications Table
CREATE TABLE dbo.Classifications
(
	ArtWork	VARCHAR(100)	NOT NULL,
	Genre	VARCHAR(50)		NOT NULL

	CONSTRAINT [FK1_dbo.Classifications] FOREIGN KEY (ArtWork)
	REFERENCES dbo.Artworks(Title),

	CONSTRAINT [FK2_dbo.Classifications] FOREIGN KEY (Genre)
	REFERENCES dbo.Genres(Name)
);


--Insert data into Artists Table
INSERT INTO dbo.Artists (Name, BirthDate, BirthCity) VALUES
('M C Escher', '1898-06-17', 'Leeuwarden, Netherlands'),
('Leonardo Da Vinci', '1519-05-02', 'Vinci, Italy'),
('Hatip Mehmed Efendi', '1680-11-18', 'Unknown'),
('Salvador Dali', '1904-05-11', 'Figueres, Spain');

--Insert data into ArtWorks Table
INSERT INTO dbo.ArtWorks (Title, Artist) VALUES
('Circle Limit III', 'M C Escher'),
('Twon Tree', 'M C Escher'),
('Mona Lisa', 'Leonardo Da Vinci'),
('The Vitruvian Man', 'Leonardo Da Vinci'),
('Ebru', 'Hatip Mehmed Efendi'),
('Honey Is Sweeter Than Blood', 'Salvador Dali');

--Insert data into Genres Table
INSERT INTO dbo.Genres(Name) VALUES
('Tesselation'),
('Surrealism'),
('Portrait'),
('Renaissance');

--Insert data into Classifications Table
INSERT INTO dbo.Classifications(ArtWork, Genre) VALUES
('Circle Limit III', 'Tesselation'),
('Twon Tree', 'Tesselation'),
('Twon Tree', 'Surrealism'),
('Mona Lisa', 'Portrait'),
('Mona Lisa', 'Renaissance'),
('The Vitruvian Man', 'Renaissance'),
('Ebru', 'Tesselation'),
('Honey Is Sweeter Than Blood', 'Surrealism');

GO