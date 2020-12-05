/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


/***** SEED DATA FOR PEOPLE TABLE *****/

INSERT INTO [People] VALUES ('Radek', 'Lyzwa', '1995-07-17', 180 , 87);
INSERT INTO [People] VALUES ('Tomasz', 'Lyzwa', '1972-01-17', 182 , 100);
INSERT INTO [People] VALUES ('Giannis', 'Antetokounmpo', '2000-08-16', 165 , 92);
INSERT INTO [People] VALUES ('Mike', 'Ekim', '1972-05-29', 178 , 45);
INSERT INTO [People] VALUES ('Peter', 'Retep', '1972-11-11', 198 , 65);
INSERT INTO [People] VALUES ('Geoff', 'Ffoeg', '1967-07-01', 182 , 45);
INSERT INTO [People] VALUES ('Sylwia', 'Peneke ', '2001-11-05', 182 , 99);
INSERT INTO [People] VALUES ('Cris', 'Sirc', '2005-07-17', 194 , 33);
INSERT INTO [People] VALUES ('Paul', 'Laup', '1979-08-31', 192 , 23);
INSERT INTO [People] VALUES ('George', 'Egroeg', '2000-03-21', 153 , 45);
INSERT INTO [People] VALUES ('Tim', 'Corey', '1988-04-15', 166 , 23);
INSERT INTO [People] VALUES ('Chris', 'Sirhc', '1966-06-25', 178 , 25);
INSERT INTO [People] VALUES ('Sophie', 'Ele', '1962-06-09', 155 , 70);
INSERT INTO [People] VALUES ('Miranda', 'Amanda', '1992-01-01', 342 , 80);
INSERT INTO [People] VALUES ('Giannis', 'Antetokounmpo', '1972-11-17', 202 , 90);
INSERT INTO [People] VALUES ('Imran', 'Namir', '1982-12-12', 179 , 68);
INSERT INTO [People] VALUES ('Marry', 'Yrram', '1979-12-24', 168 , 100);
INSERT INTO [People] VALUES ('Test', 'Name', '1973-02-19', 170 , 100);


/***** SEED DATA FOR BELONGINGS TABLE *****/
INSERT INTO [Belongings] VALUES(1,'Scissors',1);
INSERT INTO [Belongings] VALUES(1, 'Glue', 2);
INSERT INTO [Belongings] VALUES(8, 'Ruler', 2);
INSERT INTO [Belongings] VALUES(2, 'Wallet', 2);
INSERT INTO [Belongings] VALUES(3, 'Keys', 3);
INSERT INTO [Belongings] VALUES(4, 'Bubblegum', 5);
INSERT INTO [Belongings] VALUES(1, 'Sandwich', 1);
INSERT INTO [Belongings] VALUES(5, 'Headphones', 1);
INSERT INTO [Belongings] VALUES(7, 'Gloves', 2);
INSERT INTO [Belongings] VALUES(6, 'Tissues', 10);
INSERT INTO [Belongings] VALUES(1, 'Pen', 4);
INSERT INTO [Belongings] VALUES(7, 'Lipstick', 2);
INSERT INTO [Belongings] VALUES(10, 'Hair comb', 1);
INSERT INTO [Belongings] VALUES(10, 'Car keys', 1);
INSERT INTO [Belongings] VALUES(16, 'Shopping bag', 2);
INSERT INTO [Belongings] VALUES(10, 'Phone charger', 1);
INSERT INTO [Belongings] VALUES(16, 'Phone', 2);
INSERT INTO [Belongings] VALUES(17, 'Receipt', 99);
INSERT INTO [Belongings] VALUES(17, 'Glasses', 2);
INSERT INTO [Belongings] VALUES(18, 'Headphones', 1);
INSERT INTO [Belongings] VALUES(1, 'Pen', 4);
INSERT INTO [Belongings] VALUES(9, 'Pen', 4);
INSERT INTO [Belongings] VALUES(4, 'Bubblegum', 5);
INSERT INTO [Belongings] VALUES(8, 'Sandwich', 1);
INSERT INTO [Belongings] VALUES(5, 'Headphones', 1);
INSERT INTO [Belongings] VALUES(1, 'Gloves', 2);
INSERT INTO [Belongings] VALUES(6, 'Tissues', 10);
INSERT INTO [Belongings] VALUES(14,'Scissors',1);
INSERT INTO [Belongings] VALUES(13, 'Glue', 2);
INSERT INTO [Belongings] VALUES(12, 'Ruler', 2);
INSERT INTO [Belongings] VALUES(12, 'Wallet', 2);
INSERT INTO [Belongings] VALUES(13, 'Keys', 3);
INSERT INTO [Belongings] VALUES(11, 'Gloves', 2);
INSERT INTO [Belongings] VALUES(8, 'Tissues', 10);
INSERT INTO [Belongings] VALUES(14,'Scissors',1);
INSERT INTO [Belongings] VALUES(13, 'Glue', 2);
INSERT INTO [Belongings] VALUES(15, 'Ruler', 2);
INSERT INTO [Belongings] VALUES(16, 'Wallet', 2);
INSERT INTO [Belongings] VALUES(13, 'Keys', 3);


/***** SEED DATA FOR LANGUAGES TABLE *****/
INSERT [Languages] VALUES (1,1, 'Native')
INSERT [Languages] VALUES (1,2, 'C2')
INSERT [Languages] VALUES (2,3, 'B1')
INSERT [Languages] VALUES (2,4, 'A2')
INSERT [Languages] VALUES (3,5, 'C2')
INSERT [Languages] VALUES (4,18, 'A1')
INSERT [Languages] VALUES (5,10, 'Native')
INSERT [Languages] VALUES (5,11, 'B1')
INSERT [Languages] VALUES (6,4, 'C1')
INSERT [Languages] VALUES (6,16, 'C1')
INSERT [Languages] VALUES (6,7, 'B1')
INSERT [Languages] VALUES (7,8, 'C1')
INSERT [Languages] VALUES (7,9, 'C2')
INSERT [Languages] VALUES (8,9, 'Native')
INSERT [Languages] VALUES (8,1, 'C1')
INSERT [Languages] VALUES (8,1, 'C1')
INSERT [Languages] VALUES (9,9, 'Native')
INSERT [Languages] VALUES (9,10, 'C2')
INSERT [Languages] VALUES (9,13, 'C2')
INSERT [Languages] VALUES (9,15, 'B2')
INSERT [Languages] VALUES (10,12, 'B2')
INSERT [Languages] VALUES (10,1, 'B1')
INSERT [Languages] VALUES (11,12, 'A2')
INSERT [Languages] VALUES (12,2, 'C2')
INSERT [Languages] VALUES (13,3, 'C1')
INSERT [Languages] VALUES (14,8, 'A1')
INSERT [Languages] VALUES (14,18, 'A2')
INSERT [Languages] VALUES (14,11, 'Native')
INSERT [Languages] VALUES (14,17, 'Native')
INSERT [Languages] VALUES (14,20, 'Native')
INSERT [Languages] VALUES (15,1, 'A1')
INSERT [Languages] VALUES (15,13, 'B1')
INSERT [Languages] VALUES (15,1, 'C1')
INSERT [Languages] VALUES (16,20, 'Native')
INSERT [Languages] VALUES (16,19, 'A2')



/***** SEED DATA FOR LANGUAGENAMES TABLE *****/
INSERT [LanguageNames] ([Id], [LanguageName]) VALUES (1, 'Polish')
INSERT [LanguageNames] ([Id], [LanguageName]) VALUES (2, 'English')
INSERT [LanguageNames] ([Id], [LanguageName]) VALUES (3, 'German')
INSERT [LanguageNames] ([Id], [LanguageName]) VALUES (4, 'Spanish')
INSERT [LanguageNames] ([Id], [LanguageName]) VALUES (5, 'Swedesh')
INSERT [LanguageNames] ([Id], [LanguageName]) VALUES (6, 'Finnish')
INSERT [LanguageNames] ([Id], [LanguageName]) VALUES (7, 'Danish')
INSERT [LanguageNames] ([Id], [LanguageName]) VALUES (8, 'French')
INSERT [LanguageNames] ([Id], [LanguageName]) VALUES (9, 'Norwegian ')
INSERT [LanguageNames] ([Id], [LanguageName]) VALUES (10, 'Mandarin')
INSERT [LanguageNames] ([Id], [LanguageName]) VALUES (11, 'Japanese')
INSERT [LanguageNames] ([Id], [LanguageName]) VALUES (12, 'Korean')
INSERT [LanguageNames] ([Id], [LanguageName]) VALUES (13, 'Urdu')
INSERT [LanguageNames] ([Id], [LanguageName]) VALUES (14, 'Greek')
INSERT [LanguageNames] ([Id], [LanguageName]) VALUES (15, 'Turkish')
INSERT [LanguageNames] ([Id], [LanguageName]) VALUES (16, 'Arabic')
INSERT [LanguageNames] ([Id], [LanguageName]) VALUES (17, 'Portugese')
INSERT [LanguageNames] ([Id], [LanguageName]) VALUES (18, 'Dutch')
INSERT [LanguageNames] ([Id], [LanguageName]) VALUES (19, 'Javanese')
INSERT [LanguageNames] ([Id], [LanguageName]) VALUES (20, 'Hungarian')