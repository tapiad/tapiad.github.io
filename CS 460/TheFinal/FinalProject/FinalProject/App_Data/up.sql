
CREATE TABLE dbo.Movies
(
	Title		VARCHAR(50)		NOT NULL,
	Year		INT				NULL,
	Director	VARCHAR(50)		NOT NULL,

	CONSTRAINT [PK_dbo.Movies] PRIMARY KEY (Title)
);

CREATE TABLE dbo.Actors
(
	Name		VARCHAR(50)		NOT NULL,

	CONSTRAINT [PK_dbo.Actors] PRIMARY KEY (Name)
);

CREATE TABLE dbo.Directors
(
	Name		VARCHAR(50)		NOT NULL,

	CONSTRAINT [PK_dbo.Directors] PRIMARY KEY (Name)
);

CREATE TABLE dbo.Casts
(
	Actor		VARCHAR(50)		NOT NULL,
	Movie		VARCHAR(50)		NOT NULL,

	CONSTRAINT [PK_dbo.Casts] PRIMARY KEY CLUSTERED (Actor ASC, Movie ASC),
	CONSTRAINT [FK1_dbo.Casts] FOREIGN KEY (Actor)
		REFERENCES dbo.Actors(Name),
	CONSTRAINT [FK2_dbo.Casts] FOREIGN KEY (Movie)
		REFERENCES dbo.Movies(Title)
);


-- Movies
INSERT INTO dbo.Movies (Title, Year, Director) VALUES
('Star Wars: The Last Jedi',                    2017, 'Rian Johnson'),
('Murder on the Orient Express',                2017, 'Kenneth Branagh'),
('Pirates of the Caribbean: On Stranger Tides', 2011, 'Rob Marshall'),
('The Theory of Everything',                    2014, 'James Marsh');

-- Actors
INSERT INTO dbo.Actors (Name) VALUES
('Daisy Ridley'),
('Andy Serkis'),
('Benicio Del Toro'),
('Penelope Cruz');

-- Directors
INSERT INTO dbo.Directors (Name) VALUES
('Rian Johnson'),
('Kenneth Branagh'),
('Rob Marshall'),
('James Marsh');

-- Casts
INSERT INTO dbo.Casts (Actor, Movie) VALUES
('Daisy Ridley',    'Star Wars: The Last Jedi'),
('Andy Serkis',     'Star Wars: The Last Jedi'),
('Benicio Del Toro','Star Wars: The Last Jedi'),
('Daisy Ridley',    'Murder on the Orient Express'),
('Penelope Cruz',   'Murder on the Orient Express'),
('Penelope Cruz',   'Pirates of the Caribbean: On Stranger Tides');