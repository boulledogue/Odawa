USE odawa;
GO
SET IDENTITY_INSERT [dbo].[administrateurs] ON 

GO
INSERT [dbo].[administrateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (1, N'CHARETTE', N'Denis', N'dcr', N'1234', N'denis@odawa.be', N'0123456')
GO
INSERT [dbo].[administrateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (2, N'DAL', N'Kevin', N'dke', N'1234', N'kevin@odawa.be', N'6543210')
GO
INSERT [dbo].[administrateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (3, N'GUERET', N'Laurent', N'lgu', N'1234', N'laurent@odawa.be', N'024680')
GO
SET IDENTITY_INSERT [dbo].[administrateurs] OFF
GO
SET IDENTITY_INSERT [dbo].[typescuisine] ON 

GO
INSERT [dbo].[typescuisine] ([id], [type], [description]) VALUES (1, N'Chinoise', N'Il vaut mieux secouer les nouilles que l''inverse')
GO
INSERT [dbo].[typescuisine] ([id], [type], [description]) VALUES (2, N'Française', N'Les célèbres froggies')
GO
INSERT [dbo].[typescuisine] ([id], [type], [description]) VALUES (3, N'Friterie', N'Le gras, c''est la vie')
GO
INSERT [dbo].[typescuisine] ([id], [type], [description]) VALUES (4, N'Italienne', N'Gigi, c''est toi là-bas dans le noir?')
GO
INSERT [dbo].[typescuisine] ([id], [type], [description]) VALUES (5, N'Japonaise', N'Si vous n''aimez pas, on se fait harakiri')
GO
INSERT [dbo].[typescuisine] ([id], [type], [description]) VALUES (6, N'Indienne', N'Ici, on ne mange pas de vache')
GO
INSERT [dbo].[typescuisine] ([id], [type], [description]) VALUES (7, N'Thaïlandaise', N'Méfiez-vous des petits pois')
GO
INSERT [dbo].[typescuisine] ([id], [type], [description]) VALUES (8, N'Grecque', N'Ne tournez jamais le dos au serveur')
GO
INSERT [dbo].[typescuisine] ([id], [type], [description]) VALUES (9, N'Tex-Mex', N'On mange des trucs qui arrachent avec les mains')
GO
INSERT [dbo].[typescuisine] ([id], [type], [description]) VALUES (10, N'Gastronomique', N'Vous enlevez le G et ça vous donne le montant à payer...')
GO
SET IDENTITY_INSERT [dbo].[typescuisine] OFF
GO
SET IDENTITY_INSERT [dbo].[utilisateurs] ON 

GO
INSERT [dbo].[utilisateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (1, N'GATES', N'Bill', N'bga', N'1234', N'bilou@microsoft.com', N'0123456789')
GO
INSERT [dbo].[utilisateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (2, N'JOBS', N'Steve', N'sjo', N'5678', N'stevie@apple.com', N'081202122')
GO
INSERT [dbo].[utilisateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (3, N'WILFART', N'Johanna', N'jwi', N'abcd', N'johanna@wilfart.com', N'0477600717')
GO
INSERT [dbo].[utilisateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (4, N'FILEE', N'Frédéric', N'ffi', N'9876', N'frederic@filee.com', N'081211930')
GO
INSERT [dbo].[utilisateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (5, N'PARION', N'Frédéric', N'fpa', N'5432', N'frederic@parion.com', N'081212019')
GO
INSERT [dbo].[utilisateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (6, N'DERMINE', N'Luc', N'lde', N'Manager', N'luc@dermine.test', N'0499123456')
GO
INSERT [dbo].[utilisateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (7, N'MINE', N'Yves', N'ymi', N'compta', N'yves.mine@testons.be', N'081212626')
GO
INSERT [dbo].[utilisateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (8, N'GUILLAUME', N'Arnaud', N'agu', N'analyse', N'ag@ag.ag.be', N'071809060')
GO
INSERT [dbo].[utilisateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (9, N'BOTHY', N'Germaine', N'gbo', N'commu', N'bothy@surpapier.be', N'010304050')
GO
INSERT [dbo].[utilisateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (10, N'LIBERT', N'Thierry', N'tli', N'nostalgie', N'thierry@nostalgie.eu', N'021234567')
GO
SET IDENTITY_INSERT [dbo].[utilisateurs] OFF
GO
SET IDENTITY_INSERT [dbo].[restaurateurs] ON 

GO
INSERT [dbo].[restaurateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (1, N'BOCUSE', N'Paul', N'pbo', N'1234', N'paul@bocuse.fr', N'0123456789')
GO
INSERT [dbo].[restaurateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (2, N'BALLE', N'Emile', N'eba', N'1234', N'gaby@namur.be', N'081212121')
GO
INSERT [dbo].[restaurateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (3, N'USSAY', N'James', N'jus', N'abcd', N'james@ussay.be', N'081987654')
GO
INSERT [dbo].[restaurateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (4, N'JOYEUX', N'Noel', N'njo', N'efgh', N'hohoho@joyeuxnoel.be', N'081212121')
GO
INSERT [dbo].[restaurateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (5, N'LAFRONDE', N'Thierry', N'tla', N'aeiou', N'thierry@lafronde.fr', N'065103050')
GO
INSERT [dbo].[restaurateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (6, N'ENFANT', N'Ludivine', N'len', N'1234', N'helene.et.ludivine@enfant.be', N'077777777')
GO
INSERT [dbo].[restaurateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (7, N'TALON', N'Achile', N'ata', N',;:!', N'achile@monfilsuniqueetprefere.be', N'041605040')
GO
INSERT [dbo].[restaurateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (8, N'CUISBOUFFE', N'Dominique', N'dcu', N'abcd', N'dominique.c@bouffe.be', N'010123456')
GO
INSERT [dbo].[restaurateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (9, N'DEVOS-LEMMENS', N'Atable', N'adl', N'devos', N'atable@dl.be', N'081304050')
GO
INSERT [dbo].[restaurateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (10, N'NOUVELINSCRIT', N'Raymond', N'rno', N'ornicar', N'raymond@newbie.be', N'022201717')
GO
SET IDENTITY_INSERT [dbo].[restaurateurs] OFF
GO
SET IDENTITY_INSERT [dbo].[restaurants] ON 

GO
INSERT [dbo].[restaurants] ([id], [nom], [adresse], [numero], [zipCode], [localite], [description], [budgetLow], [budgetHigh], [horaire], [premium], [genre], [idTypeCuisine], [idRestaurateur]) VALUES (1, N'La Grosse Bouffe', N'Rue de l''Indigestion', N'1', N'6200', N'Bouffioulx', N'Ici, on bouffe tout', 100, 500, '0000-0000;1000-2000;1000-2000;1000-2000;1000-2000;1000-2200;1000-2200', 1, 1, 1, 1)
GO
INSERT [dbo].[restaurants] ([id], [nom], [adresse], [numero], [zipCode], [localite], [description], [budgetLow], [budgetHigh], [horaire], [premium], [genre], [idTypeCuisine], [idRestaurateur]) VALUES (2, N'Chez Gaby', N'Square Léopold', N'1', N'5000', N'Namur', N'La meilleure friterie de Namur!', 10, 20, '0000-0000;1000-2000;1000-2000;1000-2000;1000-2000;1000-0030;1000-0030', 0, 2, 3, 2)
GO
INSERT [dbo].[restaurants] ([id], [nom], [adresse], [numero], [zipCode], [localite], [description], [budgetLow], [budgetHigh], [horaire], [premium], [genre], [idTypeCuisine], [idRestaurateur]) VALUES (3, N'Le Myconos', N'Rue de la Halle', N'8', N'5000', N'Namur', N'La crise, connait pas!', 30, 50, '0000-0000;0000-0000;0000-0000;1000-2000;1000-2000;1000-0030;1000-2200', 1, 1, 8, 3)
GO
INSERT [dbo].[restaurants] ([id], [nom], [adresse], [numero], [zipCode], [localite], [description], [budgetLow], [budgetHigh], [horaire], [premium], [genre], [idTypeCuisine], [idRestaurateur]) VALUES (4, N'Comme Chez Soi', N'Impasse de la loose', N'6', N'7000', N'Mons', N'Vous pouvez même faire la vaisselle', 50, 100, '0000-0000;0000-0000;0000-0000;0000-0000;0000-0000;1000-0030;1000-0100', 0, 1, 3, 4)
GO
INSERT [dbo].[restaurants] ([id], [nom], [adresse], [numero], [zipCode], [localite], [description], [budgetLow], [budgetHigh], [horaire], [premium], [genre], [idTypeCuisine], [idRestaurateur]) VALUES (5, N'J''ai plus d''idée', N'Rue du Trou de Mémoire', N'5', N'1000', N'Bruxelles', N'heuuuu', 60, 80, '1000-2000;1000-2000;1000-2000;1000-2000;1000-2000;1000-0030;1000-0030', 0, 1, 6, 5)
GO
INSERT [dbo].[restaurants] ([id], [nom], [adresse], [numero], [zipCode], [localite], [description], [budgetLow], [budgetHigh], [horaire], [premium], [genre], [idTypeCuisine], [idRestaurateur]) VALUES (6, N'Bon Appétit', N'Avenue du repas', N'7', N'5100', N'Jambes', N'Tout est dans le titre', 50, 75, '1000-2000;1000-2000;1000-2000;1000-2000;1000-2000;1000-0030;1000-0030', 0, 1, 2, 5)
GO
INSERT [dbo].[restaurants] ([id], [nom], [adresse], [numero], [zipCode], [localite], [description], [budgetLow], [budgetHigh], [horaire], [premium], [genre], [idTypeCuisine], [idRestaurateur]) VALUES (7, N'La Corne d''Abondance', N'Chaussée du débordement', N'140', N'6000', N'Charleroi', N'Jusqu''à plus soif', 60, 80, '1111-1111;1000-2000;1000-2000;1000-2000;1000-2000;1000-0030;1000-0030', 0, 1, 6, 6)
GO
INSERT [dbo].[restaurants] ([id], [nom], [adresse], [numero], [zipCode], [localite], [description], [budgetLow], [budgetHigh], [horaire], [premium], [genre], [idTypeCuisine], [idRestaurateur]) VALUES (8, N'Miam Miam', N'Rue du doublon', N'66', N'5050', N'Quelquepart', N'miam x2', 50, 80, '0000-0000;1000-2000;1000-2000;1000-2000;1000-2000;1000-0030;1000-0030', 0, 2, 6, 7)
GO
INSERT [dbo].[restaurants] ([id], [nom], [adresse], [numero], [zipCode], [localite], [description], [budgetLow], [budgetHigh], [horaire], [premium], [genre], [idTypeCuisine], [idRestaurateur]) VALUES (9, N'Le Cat''s', N'Place Chanoine Descamps', N'10', N'5000', N'Namur', N'miaou...', 60, 80, '0000-0000;0000-0000;1000-2000;1000-2000;1000-2000;1000-0030;1000-0030', 1, 2, 6, 8)
GO
INSERT [dbo].[restaurants] ([id], [nom], [adresse], [numero], [zipCode], [localite], [description], [budgetLow], [budgetHigh], [horaire], [premium], [genre], [idTypeCuisine], [idRestaurateur]) VALUES (10, N'Le Chateau de Namur', N'La Citadelle', N'1', N'5000', N'Namur', N'La classe', 100, 200, '0000-0000;1111-1111;1111-1111;1111-1111;1000-2000;1000-0030;1000-0030', 1, 1, 10, 1)
GO
SET IDENTITY_INSERT [dbo].[restaurants] OFF
GO
SET IDENTITY_INSERT [dbo].[comments] ON 

GO
INSERT [dbo].[comments] ([id], [commentaire], [idUtilisateur], [idRestaurant]) VALUES (1, N'D''la bombe, bébé!', 1, 1)
GO
INSERT [dbo].[comments] ([id], [commentaire], [idUtilisateur], [idRestaurant]) VALUES (2, N'Enorme!', 2, 1)
GO
INSERT [dbo].[comments] ([id], [commentaire], [idUtilisateur], [idRestaurant]) VALUES (3, N'Commentaire!', 3, 2)
GO
INSERT [dbo].[comments] ([id], [commentaire], [idUtilisateur], [idRestaurant]) VALUES (4, N'je sais pas quoi dire!', 4, 3)
GO
INSERT [dbo].[comments] ([id], [commentaire], [idUtilisateur], [idRestaurant]) VALUES (5, N'Encore un', 2, 4)
GO
INSERT [dbo].[comments] ([id], [commentaire], [idUtilisateur], [idRestaurant]) VALUES (6, N'Pour la route', 3, 5)
GO
INSERT [dbo].[comments] ([id], [commentaire], [idUtilisateur], [idRestaurant]) VALUES (7, N'Super', 3, 5)
GO
INSERT [dbo].[comments] ([id], [commentaire], [idUtilisateur], [idRestaurant]) VALUES (8, N'Rien à ajouter', 7, 10)
GO
INSERT [dbo].[comments] ([id], [commentaire], [idUtilisateur], [idRestaurant]) VALUES (9, N'Je le recommande', 7, 10)
GO
INSERT [dbo].[comments] ([id], [commentaire], [idUtilisateur], [idRestaurant]) VALUES (10, N'Extra', 7, 10)
GO
SET IDENTITY_INSERT [dbo].[comments] OFF
GO
SET IDENTITY_INSERT [dbo].[reservations] ON 

GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (1, N'PARION', N'Frédéric', CAST(N'2015-06-30' AS Date), 1, 2, N'blabla@blabla.be', N'012345678', 4, 2, CAST('2014-06-28T16:35:00' AS datetime))
GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (2, N'TEST', N'Refus', CAST(N'2015-07-01' AS Date), 1, 20, N'refus@blabla.be', N'012345678', 4, 3, CAST('2014-06-28T16:35:00' AS datetime))
GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (3, N'FILEE', N'Frédéric', CAST(N'2014-08-12' AS Date), 1, 3, N'truc@machin.be', N'012345678', 5, 2, CAST('2014-08-10T12:10:00' AS datetime))
GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (4, N'LATAUPE', N'René', CAST(N'2015-06-30' AS Date), 1, 12, N'renelataupe@ausecours.be', N'012345678', 2, 1, CURRENT_TIMESTAMP)
GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (5, N'PARION', N'Frédéric', CAST(N'2015-07-04' AS Date), 1, 5, N'frederic@parion.com', N'012345678', 2, 1, CURRENT_TIMESTAMP)
GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (6, N'FILEE', N'Frédéric', CAST(N'2015-07-02' AS Date), 1, 4, N'frederic@filee.com', N'012345678', 2, 3, CURRENT_TIMESTAMP)
GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (7, N'EPOUSEX', N'Zézète', CAST(N'2015-07-10' AS Date), 0, 2, N'zezete@epousex.fr', N'012345678', 1, 1, CURRENT_TIMESTAMP)
GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (8, N'DUPONT', N'Jean', CAST(N'2015-09-21' AS Date), 0, 1, N'jeand@skyn.net', N'012345678', 1, 1, CURRENT_TIMESTAMP)
GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (9, N'DOE', N'John', CAST(N'2014-07-12' AS Date), 0, 55, N'john@doe.com', N'0477777777', 3, 2, CAST('2014-06-10T12:10:00' AS datetime))
GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (10, N'GERARD', N'Georges', CAST(N'2014-07-10' AS Date), 0, 70, N'georges@gerard.be', N'0477102030', 3, 3, CAST('2014-06-20T14:50:00' AS datetime))
GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (11, N'MARCEL', N'Jacques', CAST(N'2014-07-08' AS Date), 0, 2, N'marcel@doe.com', N'0477777777', 3, 2, CAST('2014-03-01T08:34:00' AS datetime))
GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (12, N'CHARETTE', N'Denis', CAST(N'2015-07-02' AS Date), 1, 2, N'denis@charette.be', N'0477777777', 10, 1, CURRENT_TIMESTAMP)
GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (13, N'MARCHAL', N'Amaury', CAST(N'2015-07-02' AS Date), 1, 10, N'amaury@mar.be', N'0474746523', 10, 1, CURRENT_TIMESTAMP)
GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (14, N'TURNER', N'Tina', CAST(N'2015-07-10' AS Date), 1, 22, N'john@doe.com', N'0477777777', 10, 1, CURRENT_TIMESTAMP)
GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (15, N'BREL', N'Jacques', CAST(N'2015-07-20' AS Date), 0, 24, N'john@doe.com', N'0477777777', 10, 2, CURRENT_TIMESTAMP)
GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (16, N'BRASSENS', N'Georges', CAST(N'2015-10-20' AS Date), 0, 7, N'john@doe.com', N'0477777777', 10, 2, CURRENT_TIMESTAMP)
GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (17, N'ROUSSOS', N'Demis', CAST(N'2016-01-02' AS Date), 0, 15, N'john@doe.com', N'0477777777', 10, 3, CURRENT_TIMESTAMP)
GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (18, N'HALLIDAY', N'Johnny', CAST(N'2016-01-08' AS Date), 0, 6, N'john@doe.com', N'0477777777', 3, 1, CURRENT_TIMESTAMP)
GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (19, N'MORGANE', N'Clara', CAST(N'2015-07-02' AS Date), 1, 3, N'john@doe.com', N'0477777777', 3, 2, CURRENT_TIMESTAMP)
GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (20, N'DORCEL', N'Marc', CAST(N'2015-07-02' AS Date), 1, 3, N'john@doe.com', N'0477777777', 3, 2, CURRENT_TIMESTAMP)
GO
SET IDENTITY_INSERT [dbo].[reservations] OFF
GO

SET ANSI_PADDING ON

GO
