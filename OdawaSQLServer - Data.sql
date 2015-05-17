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
INSERT [dbo].[typescuisine] ([id], [type], [description]) VALUES (1, N'Chinoise', N'Un peu bridé')
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
SET IDENTITY_INSERT [dbo].[typescuisine] OFF
GO
SET IDENTITY_INSERT [dbo].[utilisateurs] ON 

GO
INSERT [dbo].[utilisateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (1, N'GATES', N'Bill', N'bga', N'1234', N'bilou@microsoft.com', N'0123456789')
GO
INSERT [dbo].[utilisateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (2, N'JOBS', N'Steve', N'sjo', N'5678', N'stevie@apple.com', N'9876543210')
GO
INSERT [dbo].[utilisateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (3, N'FILEE', N'Frédéric', N'ffi', N'9876', N'frederic@filee.com', N'081211930')
GO
INSERT [dbo].[utilisateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (4, N'PARION', N'Frédéric', N'fpa', N'5432', N'frederic@parion.com', N'081212019')
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
INSERT [dbo].[restaurateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (5, N'GONZALEZ DE LA SIERRA', N'Pedro', N'pgo', N'arribariba', N'pgdls@vivaespana.es', N'081212121')
GO
SET IDENTITY_INSERT [dbo].[restaurateurs] OFF
GO
SET IDENTITY_INSERT [dbo].[restaurants] ON 

GO
INSERT [dbo].[restaurants] ([id], [nom], [adresse], [numero], [zipCode], [localite], [description], [budgetLow], [budgetHigh], [horaire], [premium], [genre], [idTypeCuisine], [idRestaurateur]) VALUES (1, N'La Grosse Bouffe', N'Rue de l''Indigestion', N'1', N'6200', N'Bouffioulx', N'Ici, on bouffe tout', 100, 500, '0000-0000;1000-2000;1000-2000;1000-2000;1000-2000;1000-2200;1000-2200', 1, 1, 1, 1)
GO
INSERT [dbo].[restaurants] ([id], [nom], [adresse], [numero], [zipCode], [localite], [description], [budgetLow], [budgetHigh], [horaire], [premium], [genre], [idTypeCuisine], [idRestaurateur]) VALUES (2, N'Chez Gaby', N'Square Léopold', N'1', N'5000', N'Namur', N'La meilleure friterie de Namur!', 10, 20, '0000-0000;1000-2000;1000-2000;1000-2000;1000-2000;1000-2430;1000-2430', 0, 2, 3, 2)
GO
INSERT [dbo].[restaurants] ([id], [nom], [adresse], [numero], [zipCode], [localite], [description], [budgetLow], [budgetHigh], [horaire], [premium], [genre], [idTypeCuisine], [idRestaurateur]) VALUES (3, N'Le Myconos', N'Rue de la Halle', N'8', N'5000', N'Namur', N'La crise, connait pas!', 30, 50, '0000-0000;0000-0000;0000-0000;1000-2000;1000-2000;1000-2430;1000-2200', 1, 1, 8, 3)
GO
INSERT [dbo].[restaurants] ([id], [nom], [adresse], [numero], [zipCode], [localite], [description], [budgetLow], [budgetHigh], [horaire], [premium], [genre], [idTypeCuisine], [idRestaurateur]) VALUES (4, N'Comme Chez Soi', N'Impasse de la loose', N'6', N'7000', N'Mons', N'Vous pouvez même faire la vaisselle', 50, 100, '0000-0000;0000-0000;0000-0000;0000-0000;0000-0000;1000-2430;1000-2450', 0, 1, 3, 4)
GO
INSERT [dbo].[restaurants] ([id], [nom], [adresse], [numero], [zipCode], [localite], [description], [budgetLow], [budgetHigh], [horaire], [premium], [genre], [idTypeCuisine], [idRestaurateur]) VALUES (5, N'J''ai plus d''idée', N'Rue du Trou de Mémoire', N'5', N'1000', N'Bruxelles', N'heuuuu', 60, 80, '1000-2000;1000-2000;1000-2000;1000-2000;1000-2000;1000-2430;1000-2430', 0, 1, 6, 5)
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
SET IDENTITY_INSERT [dbo].[comments] OFF
GO
SET IDENTITY_INSERT [dbo].[reservations] ON 

GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (1, N'PARION', N'Frédéric', CAST(N'2014-06-30' AS Date), 1, 2, N'blabla@blabla.be', N'0123456789', 4, 2, CAST('2014-06-28T16:35:00' AS datetime))
GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (2, N'FILEE', N'Frédéric', CAST(N'2014-08-12' AS Date), 1, 3, N'truc@machin.be', N'0123456789', 5, 2, CAST('2014-08-10T12:10:00' AS datetime))
GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (3, N'LATAUPE', N'René', CAST(N'2015-06-30' AS Date), 1, 12, N'renelataupe@ausecours.be', N'0123456789', 2, 1, CURRENT_TIMESTAMP)
GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (4, N'PARION', N'Frédéric', CAST(N'2015-07-04' AS Date), 1, 5, N'frederic@parion.com', N'0123456789', 2, 1, CURRENT_TIMESTAMP)
GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (5, N'FILEE', N'Frédéric', CAST(N'2015-07-02' AS Date), 1, 4, N'frederic@filee.com', N'0123456789', 2, 1, CURRENT_TIMESTAMP)
GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (6, N'EPOUSEX', N'Zézète', CAST(N'2015-07-10' AS Date), 1, 2, N'aucun', N'0123456789', 1, 1, CURRENT_TIMESTAMP)
GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (7, N'DUPONT', N'Jean', CAST(N'2015-07-10' AS Date), 0, 1, N'aucun', N'0123456789', 1, 1, CURRENT_TIMESTAMP)
GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant], [status], [encodedDateTime]) VALUES (8, N'DOE', N'John', CAST(N'2015-07-12' AS Date), 0, 1, N'john@doe.com', N'aucun', 3, 3, CURRENT_TIMESTAMP)
GO
SET IDENTITY_INSERT [dbo].[reservations] OFF
GO

SET ANSI_PADDING ON

GO
