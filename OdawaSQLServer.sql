USE [master]
GO

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

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[horaires](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mondayOpen] [time](0) NOT NULL,
	[mondayClose] [time](0) NOT NULL,
	[tuesdayOpen] [time](0) NOT NULL,
	[tuesdayClose] [time](0) NOT NULL,
	[wednesdayOpen] [time](0) NOT NULL,
	[wednesdayClose] [time](0) NOT NULL,
	[thursdayOpen] [time](0) NOT NULL,
	[thursdayClose] [time](0) NOT NULL,
	[fridayOpen] [time](0) NOT NULL,
	[fridayClose] [time](0) NOT NULL,
	[saturdayOpen] [time](0) NOT NULL,
	[saturdayClose] [time](0) NOT NULL,
	[sundayOpen] [time](0) NOT NULL,
	[sundayClose] [time](0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

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
	[status] [int] NOT NULL CONSTRAINT [DF_reservations_statut]  DEFAULT ((1)),
	[encodedDateTime] [smalldatetime] NOT NULL DEFAULT(CURRENT_TIMESTAMP),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

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
	[description] [text] NOT NULL DEFAULT ('La description du restaurant n''a pas été complétée.'),
	[budgetLow] [int] NOT NULL,
	[budgetHigh] [int] NOT NULL,
	[premium] [bit] NOT NULL DEFAULT ('0'),
	[genre] [int] NOT NULL DEFAULT ('1'),
	[idTypeCuisine] [int] NOT NULL,
	[idRestaurateur] [int] NOT NULL,
	[idHoraire] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

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
	[email] [varchar](50) NOT NULL,
	[phone] [varchar](10) NOT NULL,
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
