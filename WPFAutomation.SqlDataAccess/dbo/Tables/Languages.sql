CREATE TABLE [dbo].[Languages]
(
	[Id] INT IDENTITY NOT NULL, 
    [PeopleId] INT NOT NULL, 
    [NameId] INT NOT NULL, 
    [Skill] VARCHAR(50) NOT NULL,

    CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Languages_People] FOREIGN KEY ([PeopleId]) REFERENCES [dbo].[People] ([Id]) ON DELETE CASCADE
)
