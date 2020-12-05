CREATE TABLE [dbo].[People]
(
	[Id] INT NOT NULL IDENTITY, 
    [Firstname] VARCHAR(50) NULL, 
    [LastName] VARCHAR(50) NULL, 
    [DateOfBirth] DATE NULL, 
    [Height] INT NULL, 
    [Weight] INT NULL

    CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED ([Id] ASC)
)
