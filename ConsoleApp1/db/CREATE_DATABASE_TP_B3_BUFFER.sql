USE [master]
GO
/****** Object:  Database [TP_B3_BUFFER]    Script Date: 2019/9/18 �U�� 08:05:30 ******/
CREATE DATABASE [TP_B3_BUFFER]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TP_B3_BUFFER', FILENAME = N'D:\DATA\TP_B3_BUFFER.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TP_B3_BUFFER_log', FILENAME = N'D:\DATA\TP_B3_BUFFER_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TP_B3_BUFFER] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TP_B3_BUFFER].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TP_B3_BUFFER] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TP_B3_BUFFER] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TP_B3_BUFFER] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TP_B3_BUFFER] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TP_B3_BUFFER] SET ARITHABORT OFF 
GO
ALTER DATABASE [TP_B3_BUFFER] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TP_B3_BUFFER] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TP_B3_BUFFER] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TP_B3_BUFFER] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TP_B3_BUFFER] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TP_B3_BUFFER] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TP_B3_BUFFER] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TP_B3_BUFFER] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TP_B3_BUFFER] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TP_B3_BUFFER] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TP_B3_BUFFER] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TP_B3_BUFFER] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TP_B3_BUFFER] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TP_B3_BUFFER] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TP_B3_BUFFER] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TP_B3_BUFFER] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TP_B3_BUFFER] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TP_B3_BUFFER] SET RECOVERY FULL 
GO
ALTER DATABASE [TP_B3_BUFFER] SET  MULTI_USER 
GO
ALTER DATABASE [TP_B3_BUFFER] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TP_B3_BUFFER] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TP_B3_BUFFER] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TP_B3_BUFFER] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TP_B3_BUFFER] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TP_B3_BUFFER', N'ON'
GO
ALTER DATABASE [TP_B3_BUFFER] SET QUERY_STORE = OFF
GO
USE [TP_B3_BUFFER]
GO
/****** Object:  Table [dbo].[AHU_04F]    Script Date: 2019/9/18 �U�� 08:05:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AHU_04F](
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[ACTIVE] [varchar](1) NOT NULL,
	[AHU01_004F01] [real] NULL,
	[AHU02_004F01] [real] NULL,
	[AHU03_004F01] [real] NULL,
	[AHU04_004F01] [real] NULL,
	[AHU05_004F01] [real] NULL,
	[AHU06_004F01] [real] NULL,
	[AHU07_004F01] [real] NULL,
	[AHU08_004F01] [real] NULL,
	[AHU09_004F01] [real] NULL,
	[AHU10_004F01] [real] NULL,
	[AHU11_004F01] [real] NULL,
	[AHU01_004F02] [real] NULL,
	[AHU02_004F02] [real] NULL,
	[AHU03_004F02] [real] NULL,
	[AHU04_004F02] [real] NULL,
	[AHU05_004F02] [real] NULL,
	[AHU06_004F02] [real] NULL,
	[AHU07_004F02] [real] NULL,
	[AHU08_004F02] [real] NULL,
	[AHU09_004F02] [real] NULL,
	[AHU10_004F02] [real] NULL,
	[AHU11_004F02] [real] NULL,
	[AHU01_004F03] [real] NULL,
	[AHU02_004F03] [real] NULL,
	[AHU03_004F03] [real] NULL,
	[AHU04_004F03] [real] NULL,
	[AHU05_004F03] [real] NULL,
	[AHU06_004F03] [real] NULL,
	[AHU07_004F03] [real] NULL,
	[AHU08_004F03] [real] NULL,
	[AHU09_004F03] [real] NULL,
	[AHU10_004F03] [real] NULL,
	[AHU11_004F03] [real] NULL,
	[AHU01_004F04] [real] NULL,
	[AHU02_004F04] [real] NULL,
	[AHU03_004F04] [real] NULL,
	[AHU04_004F04] [real] NULL,
	[AHU05_004F04] [real] NULL,
	[AHU06_004F04] [real] NULL,
	[AHU07_004F04] [real] NULL,
	[AHU08_004F04] [real] NULL,
	[AHU09_004F04] [real] NULL,
	[AHU10_004F04] [real] NULL,
	[AHU11_004F04] [real] NULL,
 CONSTRAINT [PK_AHU_04F] PRIMARY KEY CLUSTERED 
(
	[AUTOID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AHU_0B1]    Script Date: 2019/9/18 �U�� 08:05:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AHU_0B1](
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[ACTIVE] [varchar](1) NOT NULL,
	[AHU01_0B1F01] [real] NULL,
	[AHU02_0B1F01] [real] NULL,
	[AHU03_0B1F01] [real] NULL,
	[AHU04_0B1F01] [real] NULL,
	[AHU05_0B1F01] [real] NULL,
	[AHU06_0B1F01] [real] NULL,
	[AHU07_0B1F01] [real] NULL,
	[AHU08_0B1F01] [real] NULL,
	[AHU09_0B1F01] [real] NULL,
	[AHU10_0B1F01] [real] NULL,
	[AHU11_0B1F01] [real] NULL,
	[AHU01_0B1F02] [real] NULL,
	[AHU02_0B1F02] [real] NULL,
	[AHU03_0B1F02] [real] NULL,
	[AHU04_0B1F02] [real] NULL,
	[AHU05_0B1F02] [real] NULL,
	[AHU06_0B1F02] [real] NULL,
	[AHU07_0B1F02] [real] NULL,
	[AHU08_0B1F02] [real] NULL,
	[AHU09_0B1F02] [real] NULL,
	[AHU10_0B1F02] [real] NULL,
	[AHU11_0B1F02] [real] NULL,
	[AHU01_0B1F03] [real] NULL,
	[AHU02_0B1F03] [real] NULL,
	[AHU03_0B1F03] [real] NULL,
	[AHU04_0B1F03] [real] NULL,
	[AHU05_0B1F03] [real] NULL,
	[AHU06_0B1F03] [real] NULL,
	[AHU07_0B1F03] [real] NULL,
	[AHU08_0B1F03] [real] NULL,
	[AHU09_0B1F03] [real] NULL,
	[AHU10_0B1F03] [real] NULL,
	[AHU11_0B1F03] [real] NULL,
	[AHU01_0B1F04] [real] NULL,
	[AHU02_0B1F04] [real] NULL,
	[AHU03_0B1F04] [real] NULL,
	[AHU04_0B1F04] [real] NULL,
	[AHU05_0B1F04] [real] NULL,
	[AHU06_0B1F04] [real] NULL,
	[AHU07_0B1F04] [real] NULL,
	[AHU08_0B1F04] [real] NULL,
	[AHU09_0B1F04] [real] NULL,
	[AHU10_0B1F04] [real] NULL,
	[AHU11_0B1F04] [real] NULL,
	[AHU01_0B1F05] [real] NULL,
	[AHU02_0B1F05] [real] NULL,
	[AHU03_0B1F05] [real] NULL,
	[AHU04_0B1F05] [real] NULL,
	[AHU05_0B1F05] [real] NULL,
	[AHU06_0B1F05] [real] NULL,
	[AHU07_0B1F05] [real] NULL,
	[AHU08_0B1F05] [real] NULL,
	[AHU09_0B1F05] [real] NULL,
	[AHU10_0B1F05] [real] NULL,
	[AHU11_0B1F05] [real] NULL,
	[AHU01_0B1F06] [real] NULL,
	[AHU02_0B1F06] [real] NULL,
	[AHU03_0B1F06] [real] NULL,
	[AHU04_0B1F06] [real] NULL,
	[AHU05_0B1F06] [real] NULL,
	[AHU06_0B1F06] [real] NULL,
	[AHU07_0B1F06] [real] NULL,
	[AHU08_0B1F06] [real] NULL,
	[AHU09_0B1F06] [real] NULL,
	[AHU10_0B1F06] [real] NULL,
	[AHU11_0B1F06] [real] NULL,
	[AHU01_0B1F07] [real] NULL,
	[AHU02_0B1F07] [real] NULL,
	[AHU03_0B1F07] [real] NULL,
	[AHU04_0B1F07] [real] NULL,
	[AHU05_0B1F07] [real] NULL,
	[AHU06_0B1F07] [real] NULL,
	[AHU07_0B1F07] [real] NULL,
	[AHU08_0B1F07] [real] NULL,
	[AHU09_0B1F07] [real] NULL,
	[AHU10_0B1F07] [real] NULL,
	[AHU11_0B1F07] [real] NULL,
	[AHU01_0B1F08] [real] NULL,
	[AHU02_0B1F08] [real] NULL,
	[AHU03_0B1F08] [real] NULL,
	[AHU04_0B1F08] [real] NULL,
	[AHU05_0B1F08] [real] NULL,
	[AHU06_0B1F08] [real] NULL,
	[AHU07_0B1F08] [real] NULL,
	[AHU08_0B1F08] [real] NULL,
	[AHU09_0B1F08] [real] NULL,
	[AHU10_0B1F08] [real] NULL,
	[AHU11_0B1F08] [real] NULL,
 CONSTRAINT [PK_AHU_0B1] PRIMARY KEY CLUSTERED 
(
	[AUTOID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AHU_0RF]    Script Date: 2019/9/18 �U�� 08:05:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AHU_0RF](
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[ACTIVE] [varchar](1) NOT NULL,
	[AHU01_00RF01] [real] NULL,
	[AHU02_00RF01] [real] NULL,
	[AHU03_00RF01] [real] NULL,
	[AHU04_00RF01] [real] NULL,
	[AHU05_00RF01] [real] NULL,
	[AHU06_00RF01] [real] NULL,
	[AHU07_00RF01] [real] NULL,
	[AHU08_00RF01] [real] NULL,
	[AHU09_00RF01] [real] NULL,
	[AHU10_00RF01] [real] NULL,
	[AHU11_00RF01] [real] NULL,
	[AHU01_00RF02] [real] NULL,
	[AHU02_00RF02] [real] NULL,
	[AHU03_00RF02] [real] NULL,
	[AHU04_00RF02] [real] NULL,
	[AHU05_00RF02] [real] NULL,
	[AHU06_00RF02] [real] NULL,
	[AHU07_00RF02] [real] NULL,
	[AHU08_00RF02] [real] NULL,
	[AHU09_00RF02] [real] NULL,
	[AHU10_00RF02] [real] NULL,
	[AHU11_00RF02] [real] NULL,
	[AHU01_00RF03] [real] NULL,
	[AHU02_00RF03] [real] NULL,
	[AHU03_00RF03] [real] NULL,
	[AHU04_00RF03] [real] NULL,
	[AHU05_00RF03] [real] NULL,
	[AHU06_00RF03] [real] NULL,
	[AHU07_00RF03] [real] NULL,
	[AHU08_00RF03] [real] NULL,
	[AHU09_00RF03] [real] NULL,
	[AHU10_00RF03] [real] NULL,
	[AHU11_00RF03] [real] NULL,
	[AHU01_00RF04] [real] NULL,
	[AHU02_00RF04] [real] NULL,
	[AHU03_00RF04] [real] NULL,
	[AHU04_00RF04] [real] NULL,
	[AHU05_00RF04] [real] NULL,
	[AHU06_00RF04] [real] NULL,
	[AHU07_00RF04] [real] NULL,
	[AHU08_00RF04] [real] NULL,
	[AHU09_00RF04] [real] NULL,
	[AHU10_00RF04] [real] NULL,
	[AHU11_00RF04] [real] NULL,
	[AHU01_00RF05] [real] NULL,
	[AHU02_00RF05] [real] NULL,
	[AHU03_00RF05] [real] NULL,
	[AHU04_00RF05] [real] NULL,
	[AHU05_00RF05] [real] NULL,
	[AHU06_00RF05] [real] NULL,
	[AHU07_00RF05] [real] NULL,
	[AHU08_00RF05] [real] NULL,
	[AHU09_00RF05] [real] NULL,
	[AHU10_00RF05] [real] NULL,
	[AHU11_00RF05] [real] NULL,
	[AHU01_00RF06] [real] NULL,
	[AHU02_00RF06] [real] NULL,
	[AHU03_00RF06] [real] NULL,
	[AHU04_00RF06] [real] NULL,
	[AHU05_00RF06] [real] NULL,
	[AHU06_00RF06] [real] NULL,
	[AHU07_00RF06] [real] NULL,
	[AHU08_00RF06] [real] NULL,
	[AHU09_00RF06] [real] NULL,
	[AHU10_00RF06] [real] NULL,
	[AHU11_00RF06] [real] NULL,
	[AHU01_00RF07] [real] NULL,
	[AHU02_00RF07] [real] NULL,
	[AHU03_00RF07] [real] NULL,
	[AHU04_00RF07] [real] NULL,
	[AHU05_00RF07] [real] NULL,
	[AHU06_00RF07] [real] NULL,
	[AHU07_00RF07] [real] NULL,
	[AHU08_00RF07] [real] NULL,
	[AHU09_00RF07] [real] NULL,
	[AHU10_00RF07] [real] NULL,
	[AHU11_00RF07] [real] NULL,
	[AHU01_00RF08] [real] NULL,
	[AHU02_00RF08] [real] NULL,
	[AHU03_00RF08] [real] NULL,
	[AHU04_00RF08] [real] NULL,
	[AHU05_00RF08] [real] NULL,
	[AHU06_00RF08] [real] NULL,
	[AHU07_00RF08] [real] NULL,
	[AHU08_00RF08] [real] NULL,
	[AHU09_00RF08] [real] NULL,
	[AHU10_00RF08] [real] NULL,
	[AHU11_00RF08] [real] NULL,
	[AHU01_00RF09] [real] NULL,
	[AHU02_00RF09] [real] NULL,
	[AHU03_00RF09] [real] NULL,
	[AHU04_00RF09] [real] NULL,
	[AHU05_00RF09] [real] NULL,
	[AHU06_00RF09] [real] NULL,
	[AHU07_00RF09] [real] NULL,
	[AHU08_00RF09] [real] NULL,
	[AHU09_00RF09] [real] NULL,
	[AHU10_00RF09] [real] NULL,
	[AHU11_00RF09] [real] NULL,
 CONSTRAINT [PK_AHU_0RF] PRIMARY KEY CLUSTERED 
(
	[AUTOID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AHU_14F]    Script Date: 2019/9/18 �U�� 08:05:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AHU_14F](
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[ACTIVE] [varchar](1) NOT NULL,
	[AHU01_014F01] [real] NULL,
	[AHU02_014F01] [real] NULL,
	[AHU03_014F01] [real] NULL,
	[AHU04_014F01] [real] NULL,
	[AHU05_014F01] [real] NULL,
	[AHU06_014F01] [real] NULL,
	[AHU07_014F01] [real] NULL,
	[AHU08_014F01] [real] NULL,
	[AHU09_014F01] [real] NULL,
	[AHU10_014F01] [real] NULL,
	[AHU11_014F01] [real] NULL,
	[AHU01_014F02] [real] NULL,
	[AHU02_014F02] [real] NULL,
	[AHU03_014F02] [real] NULL,
	[AHU04_014F02] [real] NULL,
	[AHU05_014F02] [real] NULL,
	[AHU06_014F02] [real] NULL,
	[AHU07_014F02] [real] NULL,
	[AHU08_014F02] [real] NULL,
	[AHU09_014F02] [real] NULL,
	[AHU10_014F02] [real] NULL,
	[AHU11_014F02] [real] NULL,
	[AHU01_014F03] [real] NULL,
	[AHU02_014F03] [real] NULL,
	[AHU03_014F03] [real] NULL,
	[AHU04_014F03] [real] NULL,
	[AHU05_014F03] [real] NULL,
	[AHU06_014F03] [real] NULL,
	[AHU07_014F03] [real] NULL,
	[AHU08_014F03] [real] NULL,
	[AHU09_014F03] [real] NULL,
	[AHU10_014F03] [real] NULL,
	[AHU11_014F03] [real] NULL,
	[AHU01_014F04] [real] NULL,
	[AHU02_014F04] [real] NULL,
	[AHU03_014F04] [real] NULL,
	[AHU04_014F04] [real] NULL,
	[AHU05_014F04] [real] NULL,
	[AHU06_014F04] [real] NULL,
	[AHU07_014F04] [real] NULL,
	[AHU08_014F04] [real] NULL,
	[AHU09_014F04] [real] NULL,
	[AHU10_014F04] [real] NULL,
	[AHU11_014F04] [real] NULL,
	[AHU01_014F05] [real] NULL,
	[AHU02_014F05] [real] NULL,
	[AHU03_014F05] [real] NULL,
	[AHU04_014F05] [real] NULL,
	[AHU05_014F05] [real] NULL,
	[AHU06_014F05] [real] NULL,
	[AHU07_014F05] [real] NULL,
	[AHU08_014F05] [real] NULL,
	[AHU09_014F05] [real] NULL,
	[AHU10_014F05] [real] NULL,
	[AHU11_014F05] [real] NULL,
	[AHU01_014F06] [real] NULL,
	[AHU02_014F06] [real] NULL,
	[AHU03_014F06] [real] NULL,
	[AHU04_014F06] [real] NULL,
	[AHU05_014F06] [real] NULL,
	[AHU06_014F06] [real] NULL,
	[AHU07_014F06] [real] NULL,
	[AHU08_014F06] [real] NULL,
	[AHU09_014F06] [real] NULL,
	[AHU10_014F06] [real] NULL,
	[AHU11_014F06] [real] NULL,
	[AHU01_014F07] [real] NULL,
	[AHU02_014F07] [real] NULL,
	[AHU03_014F07] [real] NULL,
	[AHU04_014F07] [real] NULL,
	[AHU05_014F07] [real] NULL,
	[AHU06_014F07] [real] NULL,
	[AHU07_014F07] [real] NULL,
	[AHU08_014F07] [real] NULL,
	[AHU09_014F07] [real] NULL,
	[AHU10_014F07] [real] NULL,
	[AHU11_014F07] [real] NULL,
	[AHU01_014F08] [real] NULL,
	[AHU02_014F08] [real] NULL,
	[AHU03_014F08] [real] NULL,
	[AHU04_014F08] [real] NULL,
	[AHU05_014F08] [real] NULL,
	[AHU06_014F08] [real] NULL,
	[AHU07_014F08] [real] NULL,
	[AHU08_014F08] [real] NULL,
	[AHU09_014F08] [real] NULL,
	[AHU10_014F08] [real] NULL,
	[AHU11_014F08] [real] NULL,
	[AHU01_014F09] [real] NULL,
	[AHU02_014F09] [real] NULL,
	[AHU03_014F09] [real] NULL,
	[AHU04_014F09] [real] NULL,
	[AHU05_014F09] [real] NULL,
	[AHU06_014F09] [real] NULL,
	[AHU07_014F09] [real] NULL,
	[AHU08_014F09] [real] NULL,
	[AHU09_014F09] [real] NULL,
	[AHU10_014F09] [real] NULL,
	[AHU11_014F09] [real] NULL,
	[AHU01_014F10] [real] NULL,
	[AHU02_014F10] [real] NULL,
	[AHU03_014F10] [real] NULL,
	[AHU04_014F10] [real] NULL,
	[AHU05_014F10] [real] NULL,
	[AHU06_014F10] [real] NULL,
	[AHU07_014F10] [real] NULL,
	[AHU08_014F10] [real] NULL,
	[AHU09_014F10] [real] NULL,
	[AHU10_014F10] [real] NULL,
	[AHU11_014F10] [real] NULL,
	[AHU01_014F11] [real] NULL,
	[AHU02_014F11] [real] NULL,
	[AHU03_014F11] [real] NULL,
	[AHU04_014F11] [real] NULL,
	[AHU05_014F11] [real] NULL,
	[AHU06_014F11] [real] NULL,
	[AHU07_014F11] [real] NULL,
	[AHU08_014F11] [real] NULL,
	[AHU09_014F11] [real] NULL,
	[AHU10_014F11] [real] NULL,
	[AHU11_014F11] [real] NULL,
	[AHU01_014F12] [real] NULL,
	[AHU02_014F12] [real] NULL,
	[AHU03_014F12] [real] NULL,
	[AHU04_014F12] [real] NULL,
	[AHU05_014F12] [real] NULL,
	[AHU06_014F12] [real] NULL,
	[AHU07_014F12] [real] NULL,
	[AHU08_014F12] [real] NULL,
	[AHU09_014F12] [real] NULL,
	[AHU10_014F12] [real] NULL,
	[AHU11_014F12] [real] NULL,
	[AHU01_014F13] [real] NULL,
	[AHU02_014F13] [real] NULL,
	[AHU03_014F13] [real] NULL,
	[AHU04_014F13] [real] NULL,
	[AHU05_014F13] [real] NULL,
	[AHU06_014F13] [real] NULL,
	[AHU07_014F13] [real] NULL,
	[AHU08_014F13] [real] NULL,
	[AHU09_014F13] [real] NULL,
	[AHU10_014F13] [real] NULL,
	[AHU11_014F13] [real] NULL,
	[AHU01_014F14] [real] NULL,
	[AHU02_014F14] [real] NULL,
	[AHU03_014F14] [real] NULL,
	[AHU04_014F14] [real] NULL,
	[AHU05_014F14] [real] NULL,
	[AHU06_014F14] [real] NULL,
	[AHU07_014F14] [real] NULL,
	[AHU08_014F14] [real] NULL,
	[AHU09_014F14] [real] NULL,
	[AHU10_014F14] [real] NULL,
	[AHU11_014F14] [real] NULL,
	[AHU01_014F15] [real] NULL,
	[AHU02_014F15] [real] NULL,
	[AHU03_014F15] [real] NULL,
	[AHU04_014F15] [real] NULL,
	[AHU05_014F15] [real] NULL,
	[AHU06_014F15] [real] NULL,
	[AHU07_014F15] [real] NULL,
	[AHU08_014F15] [real] NULL,
	[AHU09_014F15] [real] NULL,
	[AHU10_014F15] [real] NULL,
	[AHU11_014F15] [real] NULL,
	[AHU01_014F16] [real] NULL,
	[AHU02_014F16] [real] NULL,
	[AHU03_014F16] [real] NULL,
	[AHU04_014F16] [real] NULL,
	[AHU05_014F16] [real] NULL,
	[AHU06_014F16] [real] NULL,
	[AHU07_014F16] [real] NULL,
	[AHU08_014F16] [real] NULL,
	[AHU09_014F16] [real] NULL,
	[AHU10_014F16] [real] NULL,
	[AHU11_014F16] [real] NULL,
 CONSTRAINT [PK_AHU_14F] PRIMARY KEY CLUSTERED 
(
	[AUTOID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AHU_S03]    Script Date: 2019/9/18 �U�� 08:05:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AHU_S03](
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[ACTIVE] [varchar](1) NOT NULL,
	[AHU01_S03F01] [real] NULL,
	[AHU02_S03F01] [real] NULL,
	[AHU03_S03F01] [real] NULL,
	[AHU04_S03F01] [real] NULL,
	[AHU05_S03F01] [real] NULL,
	[AHU06_S03F01] [real] NULL,
	[AHU07_S03F01] [real] NULL,
	[AHU08_S03F01] [real] NULL,
	[AHU09_S03F01] [real] NULL,
	[AHU10_S03F01] [real] NULL,
	[AHU11_S03F01] [real] NULL,
 CONSTRAINT [PK_AHU_S03] PRIMARY KEY CLUSTERED 
(
	[AUTOID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AHU_SB1]    Script Date: 2019/9/18 �U�� 08:05:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AHU_SB1](
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[ACTIVE] [varchar](1) NOT NULL,
	[AHU01_SB1F01] [real] NULL,
	[AHU02_SB1F01] [real] NULL,
	[AHU03_SB1F01] [real] NULL,
	[AHU04_SB1F01] [real] NULL,
	[AHU05_SB1F01] [real] NULL,
	[AHU06_SB1F01] [real] NULL,
	[AHU07_SB1F01] [real] NULL,
	[AHU08_SB1F01] [real] NULL,
	[AHU09_SB1F01] [real] NULL,
	[AHU10_SB1F01] [real] NULL,
	[AHU11_SB1F01] [real] NULL,
	[AHU01_SB1F02] [real] NULL,
	[AHU02_SB1F02] [real] NULL,
	[AHU03_SB1F02] [real] NULL,
	[AHU04_SB1F02] [real] NULL,
	[AHU05_SB1F02] [real] NULL,
	[AHU06_SB1F02] [real] NULL,
	[AHU07_SB1F02] [real] NULL,
	[AHU08_SB1F02] [real] NULL,
	[AHU09_SB1F02] [real] NULL,
	[AHU10_SB1F02] [real] NULL,
	[AHU11_SB1F02] [real] NULL,
 CONSTRAINT [PK_AHU_SB1] PRIMARY KEY CLUSTERED 
(
	[AUTOID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [TP_B3_BUFFER] SET  READ_WRITE 
GO