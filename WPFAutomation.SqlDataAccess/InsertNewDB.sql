/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


/***** SEED DATA FOR PERSON TABLE *****/


INSERT INTO [People] VALUES ('Radek', 'Lyzwa', 1995-07-17, 180 , 87);
INSERT INTO [People] VALUES ('Tomasz', 'Lyzwa', 1972-07-17, 182 , 100);
INSERT INTO [People] VALUES ('Giannis', 'Antetokounmpo', 2000-09-16, 165 , 92);
INSERT INTO [People] VALUES ('Mike', 'Ekim', 1972-07-29, 178 , 45);
INSERT INTO [People] VALUES ('Peter', 'Retep', 1972-07-11, 198 , 65);
INSERT INTO [People] VALUES ('Geoff', 'Ffoeg', 1967-07-01, 182 , 45);
INSERT INTO [People] VALUES ('Sylwia', 'Peneke ', 2001-07-05, 182 , 99);
INSERT INTO [People] VALUES ('Cris', 'Sirc', 2005-07-17, 194 , 33);
INSERT INTO [People] VALUES ('Paul', 'Laup',1972-07-17, 192 , 23);
INSERT INTO [People] VALUES ('George', 'Egroeg', 2000-07-17, 153 , 45);
INSERT INTO [People] VALUES ('Tim', 'Corey', 1988-07-17, 166 , 23);
INSERT INTO [People] VALUES ('Chris', 'Sirhc', 1966-07-17, 178 , 25);
INSERT INTO [People] VALUES ('Sophie', 'Ele', 1962-07-17, 155 , 70);
INSERT INTO [People] VALUES ('Miranda', 'Amanda', 1992-07-17, 342 , 80);
INSERT INTO [People] VALUES ('Giannis', 'Antetokounmpo', 1972-11-17, 202 , 90);
INSERT INTO [People] VALUES ('Imran', 'Namir', 1982-12-12, 179 , 68);
INSERT INTO [People] VALUES ('Marry', 'Yrram', 1979-12-24, 168 , 100);
INSERT INTO [People] VALUES ('Test', 'Name', 1973-02-19, 170 , 100);


/***** SEED DATA FOR BELONGINGS TABLE *****/
INSERT INTO [Addresses] VALUES(1,'Scissors',1);
INSERT INTO [Addresses] VALUES(1, 'Glue', 2);
INSERT INTO [Addresses] VALUES(8, 'Ruler', 2);
INSERT INTO [Addresses] VALUES(2, 'Wallet', 2);
INSERT INTO [Addresses] VALUES(3, 'Keys', 3);
INSERT INTO [Addresses] VALUES(4, 'Bubblegum', 5);
INSERT INTO [Addresses] VALUES(1, 'Sandwich', 1);
INSERT INTO [Addresses] VALUES(5, 'Headphones', 1);
INSERT INTO [Addresses] VALUES(7, 'Gloves', 2);
INSERT INTO [Addresses] VALUES(6, 'Tissues', 10);
INSERT INTO [Addresses] VALUES(1, 'Pen', 4);
INSERT INTO [Addresses] VALUES(7, 'Lipstick', 2);
INSERT INTO [Addresses] VALUES(10, 'Hair comb', 1);
INSERT INTO [Addresses] VALUES(10, 'Car keys', 1);
INSERT INTO [Addresses] VALUES(16, 'Shopping bag', 2);
INSERT INTO [Addresses] VALUES(10, 'Phone charger', 1);
INSERT INTO [Addresses] VALUES(16, 'Phone', 2);
INSERT INTO [Addresses] VALUES(17, 'Receipt', 99);
INSERT INTO [Addresses] VALUES(17, 'Glasses', 2);
INSERT INTO [Addresses] VALUES(18, 'Headphones', 1);
INSERT INTO [Addresses] VALUES(1, 'Pen', 4);
INSERT INTO [Addresses] VALUES(9, 'Pen', 4);
INSERT INTO [Addresses] VALUES(4, 'Bubblegum', 5);
INSERT INTO [Addresses] VALUES(8, 'Sandwich', 1);
INSERT INTO [Addresses] VALUES(5, 'Headphones', 1);
INSERT INTO [Addresses] VALUES(1, 'Gloves', 2);
INSERT INTO [Addresses] VALUES(6, 'Tissues', 10);
INSERT INTO [Addresses] VALUES(14,'Scissors',1);
INSERT INTO [Addresses] VALUES(13, 'Glue', 2);
INSERT INTO [Addresses] VALUES(12, 'Ruler', 2);
INSERT INTO [Addresses] VALUES(12, 'Wallet', 2);
INSERT INTO [Addresses] VALUES(13, 'Keys', 3);
INSERT INTO [Addresses] VALUES(11, 'Gloves', 2);
INSERT INTO [Addresses] VALUES(8, 'Tissues', 10);
INSERT INTO [Addresses] VALUES(14,'Scissors',1);
INSERT INTO [Addresses] VALUES(13, 'Glue', 2);
INSERT INTO [Addresses] VALUES(15, 'Ruler', 2);
INSERT INTO [Addresses] VALUES(16, 'Wallet', 2);
INSERT INTO [Addresses] VALUES(13, 'Keys', 3);

/***** SEED DATA FOR STATES TABLE *****/
INSERT [dbo].[LanguageNames]([Id], [StateName]) VALUES (1, 'Polish')
INSERT [dbo].[LanguageNames] ([Id], [StateName]) VALUES (2, 'English')
INSERT [dbo].[LanguageNames] ([Id], [StateName]) VALUES (4, 'German')
INSERT [dbo].[LanguageNames] ([Id], [StateName]) VALUES (5, 'Spanish')
INSERT [dbo].[LanguageNames] ([Id], [StateName]) VALUES (6, 'Swedesh')
INSERT [dbo].[LanguageNames] ([Id], [StateName]) VALUES (8, 'Finnish')
INSERT [dbo].[LanguageNames] ([Id], [StateName]) VALUES (9, 'Danish')
INSERT [dbo].[LanguageNames] ([Id], [StateName]) VALUES (10, 'French')
INSERT [dbo].[LanguageNames] ([Id], [StateName]) VALUES (11, 'Norwegian ')
INSERT [dbo].[LanguageNames] ([Id], [StateName]) VALUES (12, 'Mandarin')
INSERT [dbo].[LanguageNames] ([Id], [StateName]) VALUES (13, 'Japanese')
INSERT [dbo].[LanguageNames] ([Id], [StateName]) VALUES (15, 'Korean')
INSERT [dbo].[LanguageNames] ([Id], [StateName]) VALUES (16, 'Urdu')
INSERT [dbo].[LanguageNames] ([Id], [StateName]) VALUES (17, 'Greek')
INSERT [dbo].[LanguageNames] ([Id], [StateName]) VALUES (18, 'Turkish')
INSERT [dbo].[LanguageNames] ([Id], [StateName]) VALUES (19, 'Arabic')
INSERT [dbo].[LanguageNames] ([Id], [StateName]) VALUES (20, 'Portugese')