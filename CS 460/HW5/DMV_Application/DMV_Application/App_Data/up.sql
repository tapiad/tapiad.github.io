﻿
--Creates a Table inside the Database
CREATE TABLE [dbo].[DMVRequest] (
    [ID]            INT	IDENTITY (1, 1) NOT NULL,
    [DOB]           NVARCHAR (64)   NOT NULL,
    [Name]          NVARCHAR (128)  NOT NULL,
    [Address]       NVARCHAR (128)  NOT NULL,
    [City]          NVARCHAR (64)  NOT NULL,
    [State]         NVARCHAR (64)  NOT NULL,
    [Zip]           INT            NOT NULL,
    [County]        NVARCHAR (64)  NOT NULL,
    [Email]         NVARCHAR (64)  NOT NULL,
    CONSTRAINT [PK_dbo.DMVRequest] PRIMARY KEY CLUSTERED (ID ASC)
);

--Inserts Values into the Table
INSERT INTO [dbo].[DMVRequest](ID, DOB, Name, Address, City, State, Zip, County, Email) VALUES
    (524, "2017-12-11 05:43:23", "Bob Lucas", "23142 Sand NE, Aurora", "OR", 97002, "Marion", "uTell@gmail.com"),
    (241, "2015-03-04 12:33:13", "Larry Bird", "23146 Lake Ct NE, Woodburn", "OR", 97071, "Marion", "daBird@gmail.com");
	
GO