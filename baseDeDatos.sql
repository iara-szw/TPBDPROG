USE [master]
GO
/****** Object:  Database [BDintegrantes]    Script Date: 11/7/2025 09:07:10 ******/
CREATE DATABASE [BDintegrantes]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BDintegrantes', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BDintegrantes.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BDintegrantes_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BDintegrantes_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BDintegrantes] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDintegrantes].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BDintegrantes] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BDintegrantes] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BDintegrantes] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BDintegrantes] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BDintegrantes] SET ARITHABORT OFF 
GO
ALTER DATABASE [BDintegrantes] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BDintegrantes] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BDintegrantes] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BDintegrantes] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BDintegrantes] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BDintegrantes] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BDintegrantes] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BDintegrantes] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BDintegrantes] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BDintegrantes] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BDintegrantes] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BDintegrantes] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BDintegrantes] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BDintegrantes] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BDintegrantes] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BDintegrantes] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BDintegrantes] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BDintegrantes] SET RECOVERY FULL 
GO
ALTER DATABASE [BDintegrantes] SET  MULTI_USER 
GO
ALTER DATABASE [BDintegrantes] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BDintegrantes] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BDintegrantes] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BDintegrantes] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BDintegrantes] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BDintegrantes', N'ON'
GO
ALTER DATABASE [BDintegrantes] SET QUERY_STORE = OFF
GO
USE [BDintegrantes]
GO
/****** Object:  User [alumno]    Script Date: 11/7/2025 09:07:10 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Integrantes]    Script Date: 11/7/2025 09:07:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Integrantes](
	[nombreUsuario] [varchar](50) NOT NULL,
	[password] [varchar](64) NOT NULL,
	[DNI] [varchar](8) NOT NULL,
	[nombreCompleto] [varchar](50) NOT NULL,
	[fechaNacimiento] [datetime] NOT NULL,
	[cancionFav] [varchar](50) NOT NULL,
	[libroFav] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Integrantes] PRIMARY KEY CLUSTERED 
(
	[nombreUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Integrantes] ([nombreUsuario], [password], [DNI], [nombreCompleto], [fechaNacimiento], [cancionFav], [libroFav]) VALUES (N'iaraszw', N'7aebd0131c08cfdc3cc56c22318d71aa7633e4c07e93aa33c99bff29b34e1c16', N'49193480', N'Iara Szwarstein', CAST(N'2009-01-24T00:00:00.000' AS DateTime), N'Turn it up- The Wrecks', N'Muerte en las alturas-Agatha Christie')
GO
USE [master]
GO
ALTER DATABASE [BDintegrantes] SET  READ_WRITE 
GO
