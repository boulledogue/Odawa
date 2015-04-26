.USE [master]
GO
/****** Object:  Database [odawa]    Script Date: 24/04/2015 11:57:32 ******/
CREATE DATABASE [odawa]

GO
ALTER DATABASE [odawa] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [odawa].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [odawa] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [odawa] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [odawa] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [odawa] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [odawa] SET ARITHABORT OFF 
GO
ALTER DATABASE [odawa] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [odawa] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [odawa] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [odawa] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [odawa] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [odawa] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [odawa] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [odawa] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [odawa] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [odawa] SET  ENABLE_BROKER 
GO
ALTER DATABASE [odawa] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [odawa] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [odawa] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [odawa] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [odawa] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [odawa] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [odawa] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [odawa] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [odawa] SET  MULTI_USER 
GO
ALTER DATABASE [odawa] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [odawa] SET DB_CHAINING OFF 
GO
ALTER DATABASE [odawa] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [odawa] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [odawa] SET DELAYED_DURABILITY = DISABLED 
GO
USE [odawa]
GO
/****** Object:  Table [dbo].[administrateurs]    Script Date: 24/04/2015 11:57:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[administrateurs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](30) NOT NULL,
	[prenom] [varchar](30) NOT NULL,
	[username] [varchar](30) NOT NULL,
	[password] [varchar](30) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[phone] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[comments]    Script Date: 24/04/2015 11:57:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[commentaire] [text] NOT NULL,
	[idUtilisateur] [int] NOT NULL,
	[idRestaurant] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[horaires]    Script Date: 24/04/2015 11:57:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[horaires](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mondayOpen] [time](0) NULL DEFAULT (NULL),
	[mondayClose] [time](0) NULL DEFAULT (NULL),
	[tuesdayOpen] [time](0) NULL DEFAULT (NULL),
	[tuesdayClose] [time](0) NULL DEFAULT (NULL),
	[wednesdayOpen] [time](0) NULL DEFAULT (NULL),
	[wednesdayClose] [time](0) NULL DEFAULT (NULL),
	[thursdayOpen] [time](0) NULL DEFAULT (NULL),
	[thursdayClose] [time](0) NULL DEFAULT (NULL),
	[fridayOpen] [time](0) NULL DEFAULT (NULL),
	[fridayClose] [time](0) NULL DEFAULT (NULL),
	[saturdayOpen] [time](0) NULL DEFAULT (NULL),
	[saturdayClose] [time](0) NULL DEFAULT (NULL),
	[sundayOpen] [time](0) NULL DEFAULT (NULL),
	[sundayClose] [time](0) NULL DEFAULT (NULL),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[reservations]    Script Date: 24/04/2015 11:57:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[reservations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](30) NOT NULL,
	[prenom] [varchar](30) NOT NULL,
	[date] [date] NOT NULL,
	[typeService] [bit] NOT NULL,
	[nbPersonnes] [int] NOT NULL,
	[email] [varchar](50) NULL DEFAULT (NULL),
	[phone] [varchar](10) NULL DEFAULT (NULL),
	[idRestaurant] [int] NOT NULL,
	[statut] [int] NOT NULL CONSTRAINT [DF_reservations_statut]  DEFAULT ((1)),
	[encodedDateTime] [smalldatetime] NOT NULL DEFAULT(CURRENT_TIMESTAMP),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[restaurants]    Script Date: 24/04/2015 11:57:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[restaurants](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](50) NOT NULL,
	[adresse] [varchar](50) NOT NULL,
	[numero] [varchar](5) NOT NULL,
	[zipCode] [varchar](4) NOT NULL,
	[localite] [varchar](50) NOT NULL,
	[description] [text] NULL DEFAULT (NULL),
	[budgetLow] [int] NULL DEFAULT (NULL),
	[budgetHigh] [int] NULL DEFAULT (NULL),
	[premium] [bit] NOT NULL DEFAULT ('0'),
	[idTypeCuisine] [int] NULL DEFAULT (NULL),
	[idRestaurateur] [int] NOT NULL,
	[idHoraire] [int] NULL DEFAULT (NULL),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[restaurateurs]    Script Date: 24/04/2015 11:57:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[restaurateurs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](30) NOT NULL,
	[prenom] [varchar](30) NOT NULL,
	[username] [varchar](30) NOT NULL,
	[password] [varchar](30) NOT NULL,
	[email] [varchar](50) NULL DEFAULT (NULL),
	[phone] [varchar](10) NULL DEFAULT (NULL),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[typescuisine]    Script Date: 24/04/2015 11:57:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[typescuisine](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[utilisateurs]    Script Date: 24/04/2015 11:57:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[utilisateurs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](30) NOT NULL,
	[prenom] [varchar](30) NOT NULL,
	[username] [varchar](30) NOT NULL,
	[password] [varchar](30) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[phone] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
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
SET IDENTITY_INSERT [dbo].[comments] ON 

GO
INSERT [dbo].[comments] ([id], [commentaire], [idUtilisateur], [idRestaurant]) VALUES (1, N'D''la bombe, bébé!', 1, 1)
GO
INSERT [dbo].[comments] ([id], [commentaire], [idUtilisateur], [idRestaurant]) VALUES (2, N'Enorme!', 2, 1)
GO
SET IDENTITY_INSERT [dbo].[comments] OFF
GO
SET IDENTITY_INSERT [dbo].[reservations] ON 

GO
INSERT [dbo].[reservations] ([id], [nom], [prenom], [date], [typeService], [nbPersonnes], [email], [phone], [idRestaurant]) VALUES (1, N'LATAUPE', N'René', CAST(N'2015-06-30' AS Date), 1, 12, N'renelataupe@ausecours.be', N'0123456789', 2)
GO
SET IDENTITY_INSERT [dbo].[reservations] OFF
GO
SET IDENTITY_INSERT [dbo].[restaurants] ON 

GO
INSERT [dbo].[restaurants] ([id], [nom], [adresse], [numero], [zipCode], [localite], [description], [budgetLow], [budgetHigh], [premium], [idTypeCuisine], [idRestaurateur], [idHoraire]) VALUES (1, N'La Grosse Bouffe', N'Rue de l''Indigestion', N'1', N'6200', N'Bouffioulx', N'Ici, on bouffe tout', 100, 500, 1, 1, 1, 1)
GO
INSERT [dbo].[restaurants] ([id], [nom], [adresse], [numero], [zipCode], [localite], [description], [budgetLow], [budgetHigh], [premium], [idTypeCuisine], [idRestaurateur], [idHoraire]) VALUES (2, N'Chez Gaby', N'Square Léopold', N'1', N'5000', N'Namur', N'La meilleure friterie de Namur!', 10, 20, 0, 3, 2, 2)
GO
SET IDENTITY_INSERT [dbo].[restaurants] OFF
GO
SET IDENTITY_INSERT [dbo].[horaires] ON 

GO
INSERT [dbo].[horaires] ([id], [mondayOpen], [mondayClose], [tuesdayOpen], [tuesdayClose], [wednesdayOpen], [wednesdayClose], [thursdayOpen], [thursdayClose], [fridayOpen], [fridayClose]) VALUES (1, '08:00', '20:00', '08:00', '20:00', '08:00', '20:00', '08:00', '20:00', '08:00', '21:00');
GO
INSERT [dbo].[horaires] ([id], [tuesdayOpen], [tuesdayClose], [wednesdayOpen], [wednesdayClose], [thursdayOpen], [thursdayClose], [fridayOpen], [fridayClose], [saturdayOpen], [saturdayClose], [sundayOpen], [sundayClose]) VALUES (2, '11:30', '20:00', '11:30', '20:00', '11:30', '20:00', '11:30', '20:00', '11:30', '21:00', '11:30', '21:00');
GO
SET IDENTITY_INSERT [dbo].[horaires] OFF
GO
SET IDENTITY_INSERT [dbo].[restaurateurs] ON 

GO
INSERT [dbo].[restaurateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (1, N'BOCUSE', N'Paul', N'pbo', N'1234', N'paul@bocuse.fr', N'0123456789')
GO
INSERT [dbo].[restaurateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (2, N'BALLE', N'Emile', N'eba', N'1234', N'gaby@namur.be', N'081212121')
GO
SET IDENTITY_INSERT [dbo].[restaurateurs] OFF
GO
SET IDENTITY_INSERT [dbo].[typescuisine] ON 

GO
INSERT [dbo].[typescuisine] ([id], [type]) VALUES (1, N'Chinoise')
GO
INSERT [dbo].[typescuisine] ([id], [type]) VALUES (2, N'Française')
GO
INSERT [dbo].[typescuisine] ([id], [type]) VALUES (3, N'Snack')
GO
SET IDENTITY_INSERT [dbo].[typescuisine] OFF
GO
SET IDENTITY_INSERT [dbo].[utilisateurs] ON 

GO
INSERT [dbo].[utilisateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (1, N'GATES', N'Bill', N'bga', N'1234', N'bilou@microsoft.com', N'0123456789')
GO
INSERT [dbo].[utilisateurs] ([id], [nom], [prenom], [username], [password], [email], [phone]) VALUES (2, N'JOBS', N'Steve', N'sjo', N'1234', N'stevie@apple.com', N'9876543210')
GO
SET IDENTITY_INSERT [dbo].[utilisateurs] OFF
GO
SET ANSI_PADDING ON

GO

ALTER TABLE [dbo].[comments]  WITH CHECK ADD  CONSTRAINT [comments_restaurants] FOREIGN KEY([idRestaurant])
REFERENCES [dbo].[restaurants] ([id])
GO
ALTER TABLE [dbo].[comments] CHECK CONSTRAINT [comments_restaurants]
GO
ALTER TABLE [dbo].[comments]  WITH CHECK ADD  CONSTRAINT [comments_utilisateurs] FOREIGN KEY([idUtilisateur])
REFERENCES [dbo].[utilisateurs] ([id])
GO
ALTER TABLE [dbo].[comments] CHECK CONSTRAINT [comments_utilisateurs]
GO
ALTER TABLE [dbo].[reservations]  WITH CHECK ADD  CONSTRAINT [reservations_restaurants] FOREIGN KEY([idRestaurant])
REFERENCES [dbo].[restaurants] ([id])
GO
ALTER TABLE [dbo].[reservations] CHECK CONSTRAINT [reservations_restaurants]
GO
ALTER TABLE [dbo].[restaurants]  WITH CHECK ADD  CONSTRAINT [restaurants_restaurateurs] FOREIGN KEY([idRestaurateur])
REFERENCES [dbo].[restaurateurs] ([id])
GO
ALTER TABLE [dbo].[restaurants] CHECK CONSTRAINT [restaurants_restaurateurs]
GO
ALTER TABLE [dbo].[restaurants]  WITH CHECK ADD  CONSTRAINT [restaurants_typescuisine] FOREIGN KEY([idTypeCuisine])
REFERENCES [dbo].[typescuisine] ([id])
GO
ALTER TABLE [dbo].[restaurants] CHECK CONSTRAINT [restaurants_typescuisine]
GO
ALTER TABLE [dbo].[restaurants]  WITH CHECK ADD  CONSTRAINT [restaurants_horaires] FOREIGN KEY([idHoraire])
REFERENCES [dbo].[horaires] ([id])
GO
ALTER TABLE [dbo].[restaurants] CHECK CONSTRAINT [restaurants_horaires]
GO
USE [master]
GO
ALTER DATABASE [odawa] SET  READ_WRITE 
GO
