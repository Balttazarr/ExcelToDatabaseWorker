﻿CREATE TABLE [dbo].[LanguageNames]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[LanguageName] VARCHAR(50) NOT NULL,

	CONSTRAINT [PK_LanguageNames] PRIMARY KEY CLUSTERED ([Id] ASC)
)
