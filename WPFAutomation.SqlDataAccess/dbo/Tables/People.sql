CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL IDENTITY, 
    [FirstName] VARCHAR(50) NULL, 
    [LastName] VARCHAR(50) NULL, 
    [Height] INT NULL, 
    [Weight] INT NULL, 
    [Sex] NVARCHAR(MAX) NULL, 
    [Race] NVARCHAR(MAX) NULL, 
    [Nationality] NVARCHAR(MAX) NULL, 
    [Profession] NVARCHAR(MAX) NULL, 

    CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED ([Id] ASC)
)
