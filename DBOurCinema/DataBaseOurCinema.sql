USE [master]
GO
/****** Object:  Database [OurCinema]    Script Date: 10.04.2022 14:54:07 ******/
CREATE DATABASE [OurCinema]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OurCinema', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\OurCinema.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OurCinema_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\OurCinema_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [OurCinema] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OurCinema].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OurCinema] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OurCinema] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OurCinema] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OurCinema] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OurCinema] SET ARITHABORT OFF 
GO
ALTER DATABASE [OurCinema] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OurCinema] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OurCinema] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OurCinema] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OurCinema] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OurCinema] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OurCinema] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OurCinema] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OurCinema] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OurCinema] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OurCinema] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OurCinema] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OurCinema] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OurCinema] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OurCinema] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OurCinema] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OurCinema] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OurCinema] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OurCinema] SET  MULTI_USER 
GO
ALTER DATABASE [OurCinema] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OurCinema] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OurCinema] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OurCinema] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [OurCinema] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OurCinema] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'OurCinema', N'ON'
GO
ALTER DATABASE [OurCinema] SET QUERY_STORE = OFF
GO
USE [OurCinema]
GO
/****** Object:  UserDefinedTableType [dbo].[dtIntEntity]    Script Date: 10.04.2022 14:54:07 ******/
CREATE TYPE [dbo].[dtIntEntity] AS TABLE(
	[EntityID] [int] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[EntityID] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Actors]    Script Date: 10.04.2022 14:54:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actors](
	[ActorID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Surname] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_ACTORS] PRIMARY KEY CLUSTERED 
(
	[ActorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Branch]    Script Date: 10.04.2022 14:54:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branch](
	[BranchID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[SeatsNo] [int] NOT NULL,
 CONSTRAINT [PK_Branch] PRIMARY KEY CLUSTERED 
(
	[BranchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Filmmakers]    Script Date: 10.04.2022 14:54:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Filmmakers](
	[FilmmakerID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_FILMMAKERS] PRIMARY KEY CLUSTERED 
(
	[FilmmakerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Films]    Script Date: 10.04.2022 14:54:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Films](
	[FilmID] [int] IDENTITY(1,1) NOT NULL,
	[GenreID] [int] NOT NULL,
	[StudioID] [int] NOT NULL,
	[FilmmakerID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[AgeLimit] [tinyint] NOT NULL,
	[Description] [nvarchar](2000) NOT NULL,
	[ShortDescription] [nvarchar](300) NOT NULL,
	[Rating] [int] NOT NULL,
	[Duration] [int] NOT NULL,
 CONSTRAINT [PK_FILMS] PRIMARY KEY CLUSTERED 
(
	[FilmID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FilmsActors]    Script Date: 10.04.2022 14:54:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilmsActors](
	[ActorID] [int] NOT NULL,
	[FilmID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FilmStudios]    Script Date: 10.04.2022 14:54:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilmStudios](
	[StudioID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_FILMSTUDIOS] PRIMARY KEY CLUSTERED 
(
	[StudioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 10.04.2022 14:54:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[GenreID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_GENRES] PRIMARY KEY CLUSTERED 
(
	[GenreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Halls]    Script Date: 10.04.2022 14:54:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Halls](
	[HallID] [int] NOT NULL,
	[Number] [int] NOT NULL,
 CONSTRAINT [PK_HALLS] PRIMARY KEY CLUSTERED 
(
	[HallID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posters]    Script Date: 10.04.2022 14:54:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posters](
	[PosterID] [int] IDENTITY(1,1) NOT NULL,
	[URL] [nvarchar](1000) NOT NULL,
	[FilmID] [int] NOT NULL,
 CONSTRAINT [PK_Posters] PRIMARY KEY CLUSTERED 
(
	[PosterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 10.04.2022 14:54:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[ReservationID] [int] IDENTITY(1,1) NOT NULL,
	[SessionID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[IsReserved] [bit] NOT NULL,
	[Paid] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[ReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservedSeats]    Script Date: 10.04.2022 14:54:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservedSeats](
	[ReservedSeatID] [int] IDENTITY(1,1) NOT NULL,
	[SessionID] [int] NOT NULL,
	[SeatID] [int] NOT NULL,
	[ReservationID] [int] NOT NULL,
 CONSTRAINT [PK_ReservedSeats_1] PRIMARY KEY CLUSTERED 
(
	[ReservedSeatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seats]    Script Date: 10.04.2022 14:54:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seats](
	[SeatID] [int] IDENTITY(1,1) NOT NULL,
	[Row] [int] NOT NULL,
	[Number] [int] NOT NULL,
	[BranchID] [int] NULL,
 CONSTRAINT [PK_SEATS] PRIMARY KEY CLUSTERED 
(
	[SeatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sessions]    Script Date: 10.04.2022 14:54:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sessions](
	[SessionID] [int] IDENTITY(1,1) NOT NULL,
	[FilmID] [int] NOT NULL,
	[HallID] [int] NOT NULL,
 CONSTRAINT [PK_Sessions] PRIMARY KEY CLUSTERED 
(
	[SessionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShowTimes]    Script Date: 10.04.2022 14:54:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShowTimes](
	[ShowTimeID] [int] IDENTITY(1,1) NOT NULL,
	[DateStart] [datetime] NOT NULL,
	[DateEnd] [datetime] NOT NULL,
	[FilmID] [int] NOT NULL,
 CONSTRAINT [PK_ShowTimes] PRIMARY KEY CLUSTERED 
(
	[ShowTimeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trailers]    Script Date: 10.04.2022 14:54:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trailers](
	[TrailerID] [int] IDENTITY(1,1) NOT NULL,
	[URL] [nvarchar](1000) NOT NULL,
	[FilmID] [int] NOT NULL,
 CONSTRAINT [PK_Trailers] PRIMARY KEY CLUSTERED 
(
	[TrailerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10.04.2022 14:54:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Surname] [nvarchar](200) NOT NULL,
	[Patronymic] [nvarchar](200) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Birthday] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Actors] ON 

INSERT [dbo].[Actors] ([ActorID], [Name], [Surname]) VALUES (1, N'Nikita', N'Peredreev')
INSERT [dbo].[Actors] ([ActorID], [Name], [Surname]) VALUES (2, N'Igor', N'Kazlov')
SET IDENTITY_INSERT [dbo].[Actors] OFF
GO
SET IDENTITY_INSERT [dbo].[Filmmakers] ON 

INSERT [dbo].[Filmmakers] ([FilmmakerID], [Name], [Surname]) VALUES (1, N'Barry', N'Jenkins')
INSERT [dbo].[Filmmakers] ([FilmmakerID], [Name], [Surname]) VALUES (2, N'Jordan', N'Peele')
INSERT [dbo].[Filmmakers] ([FilmmakerID], [Name], [Surname]) VALUES (3, N'Pavel', N'Kuzichkin')
SET IDENTITY_INSERT [dbo].[Filmmakers] OFF
GO
SET IDENTITY_INSERT [dbo].[Films] ON 

INSERT [dbo].[Films] ([FilmID], [GenreID], [StudioID], [FilmmakerID], [Name], [AgeLimit], [Description], [ShortDescription], [Rating], [Duration]) VALUES (2, 1, 1, 1, N'Flexair 7', 1, N'AAAAAAAAA', N'AAA', 100, 120)
SET IDENTITY_INSERT [dbo].[Films] OFF
GO
INSERT [dbo].[FilmsActors] ([ActorID], [FilmID]) VALUES (1, 2)
INSERT [dbo].[FilmsActors] ([ActorID], [FilmID]) VALUES (2, 2)
GO
SET IDENTITY_INSERT [dbo].[FilmStudios] ON 

INSERT [dbo].[FilmStudios] ([StudioID], [Name]) VALUES (1, N'Warner Bros.')
INSERT [dbo].[FilmStudios] ([StudioID], [Name]) VALUES (2, N'Paramount Pictures')
INSERT [dbo].[FilmStudios] ([StudioID], [Name]) VALUES (3, N'Союзмультфильм')
SET IDENTITY_INSERT [dbo].[FilmStudios] OFF
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([GenreID], [Name]) VALUES (1, N'Action')
INSERT [dbo].[Genres] ([GenreID], [Name]) VALUES (2, N'Drama')
INSERT [dbo].[Genres] ([GenreID], [Name]) VALUES (3, N'Anime')
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
ALTER TABLE [dbo].[Films]  WITH CHECK ADD  CONSTRAINT [FK_Films_Filmmakers] FOREIGN KEY([FilmmakerID])
REFERENCES [dbo].[Filmmakers] ([FilmmakerID])
GO
ALTER TABLE [dbo].[Films] CHECK CONSTRAINT [FK_Films_Filmmakers]
GO
ALTER TABLE [dbo].[Films]  WITH CHECK ADD  CONSTRAINT [FK_Films_FilmStudios] FOREIGN KEY([StudioID])
REFERENCES [dbo].[FilmStudios] ([StudioID])
GO
ALTER TABLE [dbo].[Films] CHECK CONSTRAINT [FK_Films_FilmStudios]
GO
ALTER TABLE [dbo].[Films]  WITH CHECK ADD  CONSTRAINT [FK_Films_Genres] FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genres] ([GenreID])
GO
ALTER TABLE [dbo].[Films] CHECK CONSTRAINT [FK_Films_Genres]
GO
ALTER TABLE [dbo].[FilmsActors]  WITH CHECK ADD  CONSTRAINT [FK_FilmsActors_Actors] FOREIGN KEY([ActorID])
REFERENCES [dbo].[Actors] ([ActorID])
GO
ALTER TABLE [dbo].[FilmsActors] CHECK CONSTRAINT [FK_FilmsActors_Actors]
GO
ALTER TABLE [dbo].[FilmsActors]  WITH CHECK ADD  CONSTRAINT [FK_FilmsActors_Films] FOREIGN KEY([FilmID])
REFERENCES [dbo].[Films] ([FilmID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FilmsActors] CHECK CONSTRAINT [FK_FilmsActors_Films]
GO
ALTER TABLE [dbo].[Posters]  WITH CHECK ADD  CONSTRAINT [FK_Posters_Posters] FOREIGN KEY([FilmID])
REFERENCES [dbo].[Films] ([FilmID])
GO
ALTER TABLE [dbo].[Posters] CHECK CONSTRAINT [FK_Posters_Posters]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Sessions] FOREIGN KEY([SessionID])
REFERENCES [dbo].[Sessions] ([SessionID])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Sessions]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Users]
GO
ALTER TABLE [dbo].[ReservedSeats]  WITH CHECK ADD  CONSTRAINT [FK_ReservedSeats_Reservation] FOREIGN KEY([ReservationID])
REFERENCES [dbo].[Reservation] ([ReservationID])
GO
ALTER TABLE [dbo].[ReservedSeats] CHECK CONSTRAINT [FK_ReservedSeats_Reservation]
GO
ALTER TABLE [dbo].[ReservedSeats]  WITH CHECK ADD  CONSTRAINT [FK_ReservedSeats_Seats] FOREIGN KEY([SeatID])
REFERENCES [dbo].[Seats] ([SeatID])
GO
ALTER TABLE [dbo].[ReservedSeats] CHECK CONSTRAINT [FK_ReservedSeats_Seats]
GO
ALTER TABLE [dbo].[ReservedSeats]  WITH CHECK ADD  CONSTRAINT [FK_ReservedSeats_Sessions] FOREIGN KEY([SessionID])
REFERENCES [dbo].[Sessions] ([SessionID])
GO
ALTER TABLE [dbo].[ReservedSeats] CHECK CONSTRAINT [FK_ReservedSeats_Sessions]
GO
ALTER TABLE [dbo].[Seats]  WITH CHECK ADD  CONSTRAINT [FK_Seats_Branch] FOREIGN KEY([BranchID])
REFERENCES [dbo].[Branch] ([BranchID])
GO
ALTER TABLE [dbo].[Seats] CHECK CONSTRAINT [FK_Seats_Branch]
GO
ALTER TABLE [dbo].[Sessions]  WITH CHECK ADD  CONSTRAINT [FK_Sessions_Films] FOREIGN KEY([FilmID])
REFERENCES [dbo].[Films] ([FilmID])
GO
ALTER TABLE [dbo].[Sessions] CHECK CONSTRAINT [FK_Sessions_Films]
GO
ALTER TABLE [dbo].[Sessions]  WITH CHECK ADD  CONSTRAINT [FK_Sessions_Halls] FOREIGN KEY([HallID])
REFERENCES [dbo].[Halls] ([HallID])
GO
ALTER TABLE [dbo].[Sessions] CHECK CONSTRAINT [FK_Sessions_Halls]
GO
ALTER TABLE [dbo].[ShowTimes]  WITH CHECK ADD  CONSTRAINT [FK_ShowTimes_Films] FOREIGN KEY([FilmID])
REFERENCES [dbo].[Films] ([FilmID])
GO
ALTER TABLE [dbo].[ShowTimes] CHECK CONSTRAINT [FK_ShowTimes_Films]
GO
ALTER TABLE [dbo].[Trailers]  WITH CHECK ADD  CONSTRAINT [FK_Trailers_Films] FOREIGN KEY([FilmID])
REFERENCES [dbo].[Films] ([FilmID])
GO
ALTER TABLE [dbo].[Trailers] CHECK CONSTRAINT [FK_Trailers_Films]
GO
/****** Object:  StoredProcedure [dbo].[GetActorByFilmIDs]    Script Date: 10.04.2022 14:54:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetActorByFilmIDs]
    @ids [dtIntEntity] READONLY
AS
BEGIN
    SELECT a.[ActorID], a.[Name], [a].[Surname], fa.FilmID FROM [dbo].[Actors] a
    LEFT JOIN [dbo].[FilmsActors] fa on fa.ActorID = a.ActorID
    WHERE fa.FilmID IN (SELECT [EntityID] FROM @ids)
END
GO
USE [master]
GO
ALTER DATABASE [OurCinema] SET  READ_WRITE 
GO
