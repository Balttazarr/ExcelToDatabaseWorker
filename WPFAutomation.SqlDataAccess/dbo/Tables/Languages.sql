CREATE TABLE [dbo].[Language]
(
	[Id] INT NOT NULL, 
    [PeopleId] INT NOT NULL, 
    [NameId] INT NOT NULL, 
    [Skill] VARCHAR(50) NOT NULL,

    CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Languages_People] FOREIGN KEY ([PeopleId]) REFERENCES [dbo].[Person] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Languages_LanguageNames] FOREIGN KEY ([NameId]) REFERENCES [dbo].[LanguageNames] ([Id])
)
