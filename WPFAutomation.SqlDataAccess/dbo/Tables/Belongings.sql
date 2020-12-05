CREATE TABLE [dbo].[Belongings]
(
	[Id] INT IDENTITY (1,1) NOT NULL, 
    [PeopleId] INT NOT NULL, 
    [Name] VARCHAR(50) NULL, 
    [Quantity] INT NULL

    CONSTRAINT [PK_Belongigns] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Belongigns_People] FOREIGN KEY ([PeopleId]) REFERENCES [dbo].[People] ([Id]) ON DELETE CASCADE
 
)
