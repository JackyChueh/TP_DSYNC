USE [master]
GO
/****** Object:  Database [TP_B3]    Script Date: 2019/10/5 上午 08:53:48 ******/
CREATE DATABASE [TP_B3]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TP_B3', FILENAME = N'D:\DATA\TP_B3.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TP_B3_log', FILENAME = N'D:\DATA\TP_B3_log.ldf' , SIZE = 401408KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TP_B3] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TP_B3].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TP_B3] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TP_B3] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TP_B3] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TP_B3] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TP_B3] SET ARITHABORT OFF 
GO
ALTER DATABASE [TP_B3] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TP_B3] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TP_B3] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TP_B3] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TP_B3] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TP_B3] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TP_B3] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TP_B3] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TP_B3] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TP_B3] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TP_B3] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TP_B3] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TP_B3] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TP_B3] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TP_B3] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TP_B3] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TP_B3] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TP_B3] SET RECOVERY FULL 
GO
ALTER DATABASE [TP_B3] SET  MULTI_USER 
GO
ALTER DATABASE [TP_B3] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TP_B3] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TP_B3] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TP_B3] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TP_B3] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TP_B3', N'ON'
GO
ALTER DATABASE [TP_B3] SET QUERY_STORE = OFF
GO
USE [TP_B3]
GO
/****** Object:  Table [dbo].[AHU_04F]    Script Date: 2019/10/5 上午 08:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AHU_04F](
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
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
	[AHU11_004F04] [real] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AHU_0B1]    Script Date: 2019/10/5 上午 08:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AHU_0B1](
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
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
	[AHU11_0B1F08] [real] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AHU_0RF]    Script Date: 2019/10/5 上午 08:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AHU_0RF](
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
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
	[AHU11_00RF09] [real] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AHU_14F]    Script Date: 2019/10/5 上午 08:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AHU_14F](
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
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
	[AHU11_014F16] [real] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AHU_S03]    Script Date: 2019/10/5 上午 08:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AHU_S03](
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
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
	[AHU11_S03F01] [real] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AHU_SB1]    Script Date: 2019/10/5 上午 08:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AHU_SB1](
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
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
	[AHU11_SB1F02] [real] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chiller]    Script Date: 2019/10/5 上午 08:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chiller](
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[Chiller01_R1] [real] NULL,
	[Chiller02_R1] [real] NULL,
	[Chiller03_R1] [real] NULL,
	[Chiller04_R1] [real] NULL,
	[Chiller05_R1] [real] NULL,
	[Chiller06_R1] [real] NULL,
	[Chiller07_R1] [real] NULL,
	[Chiller08_R1] [real] NULL,
	[Chiller09_R1] [real] NULL,
	[Chiller10_R1] [real] NULL,
	[Chiller01_R2] [real] NULL,
	[Chiller02_R2] [real] NULL,
	[Chiller03_R2] [real] NULL,
	[Chiller04_R2] [real] NULL,
	[Chiller05_R2] [real] NULL,
	[Chiller06_R2] [real] NULL,
	[Chiller07_R2] [real] NULL,
	[Chiller08_R2] [real] NULL,
	[Chiller09_R2] [real] NULL,
	[Chiller10_R2] [real] NULL,
	[Chiller01_R3] [real] NULL,
	[Chiller02_R3] [real] NULL,
	[Chiller03_R3] [real] NULL,
	[Chiller04_R3] [real] NULL,
	[Chiller05_R3] [real] NULL,
	[Chiller06_R3] [real] NULL,
	[Chiller07_R3] [real] NULL,
	[Chiller08_R3] [real] NULL,
	[Chiller09_R3] [real] NULL,
	[Chiller10_R3] [real] NULL,
	[Chiller01_R6] [real] NULL,
	[Chiller02_R6] [real] NULL,
	[Chiller03_R6] [real] NULL,
	[Chiller04_R6] [real] NULL,
	[Chiller05_R6] [real] NULL,
	[Chiller06_R6] [real] NULL,
	[Chiller07_R6] [real] NULL,
	[Chiller08_R6] [real] NULL,
	[Chiller09_R6] [real] NULL,
	[Chiller10_R6] [real] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[COP]    Script Date: 2019/10/5 上午 08:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COP](
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[COP01_001] [real] NULL,
	[COP02_001] [real] NULL,
	[COP03_001] [real] NULL,
	[COP04_001] [real] NULL,
	[COP05_001] [real] NULL,
	[COP01_002] [real] NULL,
	[COP02_002] [real] NULL,
	[COP03_002] [real] NULL,
	[COP04_002] [real] NULL,
	[COP05_002] [real] NULL,
	[COP01_003] [real] NULL,
	[COP02_003] [real] NULL,
	[COP03_003] [real] NULL,
	[COP04_003] [real] NULL,
	[COP05_003] [real] NULL,
	[COP01_006] [real] NULL,
	[COP02_006] [real] NULL,
	[COP03_006] [real] NULL,
	[COP04_006] [real] NULL,
	[COP05_006] [real] NULL,
	[COP01_12S] [real] NULL,
	[COP02_12S] [real] NULL,
	[COP03_12S] [real] NULL,
	[COP04_12S] [real] NULL,
	[COP05_12S] [real] NULL,
	[COP01_03S] [real] NULL,
	[COP02_03S] [real] NULL,
	[COP03_03S] [real] NULL,
	[COP04_03S] [real] NULL,
	[COP05_03S] [real] NULL,
	[COP01_06S] [real] NULL,
	[COP02_06S] [real] NULL,
	[COP03_06S] [real] NULL,
	[COP04_06S] [real] NULL,
	[COP05_06S] [real] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CP]    Script Date: 2019/10/5 上午 08:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CP](
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[CP01_01] [real] NULL,
	[CP02_01] [real] NULL,
	[CP03_01] [real] NULL,
	[CP04_01] [real] NULL,
	[CP05_01] [real] NULL,
	[CP06_01] [real] NULL,
	[CP07_01] [real] NULL,
	[CP01_02] [real] NULL,
	[CP02_02] [real] NULL,
	[CP03_02] [real] NULL,
	[CP04_02] [real] NULL,
	[CP05_02] [real] NULL,
	[CP06_02] [real] NULL,
	[CP07_02] [real] NULL,
	[CP01_03] [real] NULL,
	[CP02_03] [real] NULL,
	[CP03_03] [real] NULL,
	[CP04_03] [real] NULL,
	[CP05_03] [real] NULL,
	[CP06_03] [real] NULL,
	[CP07_03] [real] NULL,
	[CP01_06] [real] NULL,
	[CP02_06] [real] NULL,
	[CP03_06] [real] NULL,
	[CP04_06] [real] NULL,
	[CP05_06] [real] NULL,
	[CP06_06] [real] NULL,
	[CP07_06] [real] NULL,
	[CP01_0S] [real] NULL,
	[CP02_0S] [real] NULL,
	[CP03_0S] [real] NULL,
	[CP04_0S] [real] NULL,
	[CP05_0S] [real] NULL,
	[CP06_0S] [real] NULL,
	[CP07_0S] [real] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CT]    Script Date: 2019/10/5 上午 08:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT](
	[AUTOID] [int] IDENTITY(1,1) NOT NULL,
	[DATETIME] [datetime] NULL,
	[CT01_01] [real] NULL,
	[CT02_01] [real] NULL,
	[CT03_01] [real] NULL,
	[CT04_01] [real] NULL,
	[CT05_01] [real] NULL,
	[CT06_01] [real] NULL,
	[CT07_01] [real] NULL,
	[CT01_02] [real] NULL,
	[CT02_02] [real] NULL,
	[CT03_02] [real] NULL,
	[CT04_02] [real] NULL,
	[CT05_02] [real] NULL,
	[CT06_02] [real] NULL,
	[CT07_02] [real] NULL,
	[CT01_03] [real] NULL,
	[CT02_03] [real] NULL,
	[CT03_03] [real] NULL,
	[CT04_03] [real] NULL,
	[CT05_03] [real] NULL,
	[CT06_03] [real] NULL,
	[CT07_03] [real] NULL,
	[CT01_04] [real] NULL,
	[CT02_04] [real] NULL,
	[CT03_04] [real] NULL,
	[CT04_04] [real] NULL,
	[CT05_04] [real] NULL,
	[CT06_04] [real] NULL,
	[CT07_04] [real] NULL,
	[CT01_05] [real] NULL,
	[CT02_05] [real] NULL,
	[CT03_05] [real] NULL,
	[CT04_05] [real] NULL,
	[CT05_05] [real] NULL,
	[CT06_05] [real] NULL,
	[CT07_05] [real] NULL,
	[CT01_06] [real] NULL,
	[CT02_06] [real] NULL,
	[CT03_06] [real] NULL,
	[CT04_06] [real] NULL,
	[CT05_06] [real] NULL,
	[CT06_06] [real] NULL,
	[CT07_06] [real] NULL,
 CONSTRAINT [PK_CT] PRIMARY KEY CLUSTERED 
(
	[AUTOID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PPWT1]    Script Date: 2019/10/5 上午 08:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PPWT1](
	[AUTOID] [int] IDENTITY(1,1) NOT NULL,
	[DATETIME] [datetime] NULL,
	[PPWT01_01] [real] NULL,
	[PPWT02_01] [real] NULL,
	[PPWT03_01] [real] NULL,
	[PPWT04_01] [real] NULL,
	[PPWT05_01] [real] NULL,
	[PPWT01_02] [real] NULL,
	[PPWT02_02] [real] NULL,
	[PPWT03_02] [real] NULL,
	[PPWT04_02] [real] NULL,
	[PPWT01_03] [real] NULL,
	[PPWT02_03] [real] NULL,
	[PPWT03_03] [real] NULL,
	[PPWT04_03] [real] NULL,
	[PPWT01_04] [real] NULL,
	[PPWT02_04] [real] NULL,
	[PPWT03_04] [real] NULL,
	[PPWT04_04] [real] NULL,
	[PPWT05_04] [real] NULL,
	[PPWT06_04] [real] NULL,
	[PPWT07_04] [real] NULL,
	[PPWT08_04] [real] NULL,
	[PPWT09_04] [real] NULL,
	[PPWT01_05] [real] NULL,
	[PPWT02_05] [real] NULL,
	[PPWT03_05] [real] NULL,
	[PPWT04_05] [real] NULL,
	[PPWT05_05] [real] NULL,
	[PPWT06_05] [real] NULL,
	[PPWT07_05] [real] NULL,
	[PPWT08_05] [real] NULL,
	[PPWT09_05] [real] NULL,
	[PPWT10_05] [real] NULL,
 CONSTRAINT [PK_PPWT1] PRIMARY KEY CLUSTERED 
(
	[AUTOID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRWT1]    Script Date: 2019/10/5 上午 08:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRWT1](
	[AUTOID] [int] IDENTITY(1,1) NOT NULL,
	[DATETIME] [datetime] NULL,
	[PRWT01_01] [real] NULL,
	[PRWT02_01] [real] NULL,
	[PRWT03_01] [real] NULL,
	[PRWT04_01] [real] NULL,
	[PRWT05_01] [real] NULL,
	[PRWT06_01] [real] NULL,
	[PRWT07_01] [real] NULL,
	[PRWT08_01] [real] NULL,
	[PRWT01_02] [real] NULL,
	[PRWT02_02] [real] NULL,
	[PRWT03_02] [real] NULL,
	[PRWT04_02] [real] NULL,
	[PRWT05_02] [real] NULL,
	[PRWT06_02] [real] NULL,
	[PRWT07_02] [real] NULL,
	[PRWT08_02] [real] NULL,
	[PRWT01_03] [real] NULL,
	[PRWT02_03] [real] NULL,
	[PRWT03_03] [real] NULL,
	[PRWT04_03] [real] NULL,
	[PRWT05_03] [real] NULL,
	[PRWT06_03] [real] NULL,
	[PRWT07_03] [real] NULL,
	[PRWT08_03] [real] NULL,
	[PRWT01_04] [real] NULL,
	[PRWT02_04] [real] NULL,
	[PRWT03_04] [real] NULL,
	[PRWT04_04] [real] NULL,
	[PRWT01_05] [real] NULL,
	[PRWT02_05] [real] NULL,
	[PRWT03_05] [real] NULL,
	[PRWT04_05] [real] NULL,
	[PRWT05_05] [real] NULL,
	[PRWT06_05] [real] NULL,
	[PRWT01_06] [real] NULL,
	[PRWT02_06] [real] NULL,
	[PRWT03_06] [real] NULL,
	[PRWT04_06] [real] NULL,
	[PRWT05_06] [real] NULL,
	[PRWT06_06] [real] NULL,
	[PRWT01_07] [real] NULL,
	[PRWT02_07] [real] NULL,
	[PRWT03_07] [real] NULL,
	[PRWT04_07] [real] NULL,
	[PRWT05_07] [real] NULL,
	[PRWT06_07] [real] NULL,
	[PRWT01_08] [real] NULL,
	[PRWT02_08] [real] NULL,
	[PRWT03_08] [real] NULL,
	[PRWT04_08] [real] NULL,
	[PRWT01_09] [real] NULL,
	[PRWT02_09] [real] NULL,
	[PRWT03_09] [real] NULL,
	[PRWT04_09] [real] NULL,
	[PRWT05_09] [real] NULL,
	[PRWT06_09] [real] NULL,
	[PRWT01_10] [real] NULL,
	[PRWT02_10] [real] NULL,
	[PRWT03_10] [real] NULL,
	[PRWT04_10] [real] NULL,
	[PRWT05_10] [real] NULL,
	[PRWT06_10] [real] NULL,
	[PRWT07_10] [real] NULL,
	[PRWT08_10] [real] NULL,
 CONSTRAINT [PK_PRWT1] PRIMARY KEY CLUSTERED 
(
	[AUTOID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RT1]    Script Date: 2019/10/5 上午 08:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RT1](
	[AUTOID] [int] IDENTITY(1,1) NOT NULL,
	[DATETIME] [datetime] NULL,
	[RT01_01] [real] NULL,
	[RT02_01] [real] NULL,
	[RT03_01] [real] NULL,
	[RT04_01] [real] NULL,
	[RT05_01] [real] NULL,
	[RT06_01] [real] NULL,
	[RT07_01] [real] NULL,
	[RT08_01] [real] NULL,
	[RT01_02] [real] NULL,
	[RT02_02] [real] NULL,
	[RT03_02] [real] NULL,
	[RT04_02] [real] NULL,
	[RT01_03] [real] NULL,
	[RT02_03] [real] NULL,
	[RT03_03] [real] NULL,
	[RT04_03] [real] NULL,
	[RT05_03] [real] NULL,
	[RT06_03] [real] NULL,
 CONSTRAINT [PK_RT1] PRIMARY KEY CLUSTERED 
(
	[AUTOID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZP]    Script Date: 2019/10/5 上午 08:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZP](
	[AUTOID] [int] IDENTITY(1,1) NOT NULL,
	[DATETIME] [datetime] NULL,
	[ZP01_00] [real] NULL,
	[ZP02_00] [real] NULL,
	[ZP03_00] [real] NULL,
	[ZP04_00] [real] NULL,
	[ZP05_00] [real] NULL,
	[ZP06_00] [real] NULL,
	[ZP01_01] [real] NULL,
	[ZP02_01] [real] NULL,
	[ZP03_01] [real] NULL,
	[ZP04_01] [real] NULL,
	[ZP05_01] [real] NULL,
	[ZP06_01] [real] NULL,
	[ZP01_02] [real] NULL,
	[ZP02_02] [real] NULL,
	[ZP03_02] [real] NULL,
	[ZP04_02] [real] NULL,
	[ZP05_02] [real] NULL,
	[ZP06_02] [real] NULL,
 CONSTRAINT [PK_ZP] PRIMARY KEY CLUSTERED 
(
	[AUTOID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[TimerUpdateAHU]    Script Date: 2019/10/5 上午 08:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- select ROUND(RAND() * 1,0)  
-- =============================================
CREATE PROCEDURE [dbo].[TimerUpdateAHU]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

		--AHU_04F
	UPDATE [dbo].[AHU_04F]
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()
		  ,[AHU01_004F01] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_004F01] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_004F01] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_004F01] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_004F01] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_004F01] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_004F01] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_004F01] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_004F01] = 41                      
		  ,[AHU10_004F01] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_004F01] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_004F02] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_004F02] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_004F02] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_004F02] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_004F02] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_004F02] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_004F02] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_004F02] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_004F02] = 42                      
		  ,[AHU10_004F02] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_004F02] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_004F03] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_004F03] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_004F03] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_004F03] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_004F03] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_004F03] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_004F03] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_004F03] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_004F03] = 43                      
		  ,[AHU10_004F03] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_004F03] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_004F04] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_004F04] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_004F04] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_004F04] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_004F04] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_004F04] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_004F04] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_004F04] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_004F04] = 44                      
		  ,[AHU10_004F04] = ROUND(RAND() * 20, 5)+18
		  ,[AHU11_004F04] = ROUND(RAND() * 9, 5)+23 
	                                              
	--AHU_0B1                                     
	UPDATE [dbo].[AHU_0B1]                        
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()                   
		  ,[AHU01_0B1F01] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_0B1F01] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_0B1F01] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_0B1F01] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_0B1F01] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_0B1F01] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_0B1F01] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_0B1F01] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_0B1F01] = 1                       
		  ,[AHU10_0B1F01] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_0B1F01] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_0B1F02] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_0B1F02] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_0B1F02] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_0B1F02] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_0B1F02] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_0B1F02] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_0B1F02] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_0B1F02] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_0B1F02] = 2                       
		  ,[AHU10_0B1F02] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_0B1F02] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_0B1F03] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_0B1F03] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_0B1F03] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_0B1F03] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_0B1F03] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_0B1F03] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_0B1F03] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_0B1F03] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_0B1F03] = 3                       
		  ,[AHU10_0B1F03] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_0B1F03] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_0B1F04] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_0B1F04] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_0B1F04] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_0B1F04] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_0B1F04] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_0B1F04] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_0B1F04] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_0B1F04] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_0B1F04] = 4                       
		  ,[AHU10_0B1F04] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_0B1F04] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_0B1F05] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_0B1F05] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_0B1F05] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_0B1F05] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_0B1F05] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_0B1F05] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_0B1F05] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_0B1F05] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_0B1F05] = 5                       
		  ,[AHU10_0B1F05] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_0B1F05] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_0B1F06] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_0B1F06] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_0B1F06] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_0B1F06] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_0B1F06] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_0B1F06] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_0B1F06] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_0B1F06] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_0B1F06] = 6                       
		  ,[AHU10_0B1F06] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_0B1F06] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_0B1F07] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_0B1F07] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_0B1F07] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_0B1F07] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_0B1F07] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_0B1F07] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_0B1F07] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_0B1F07] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_0B1F07] = 7                       
		  ,[AHU10_0B1F07] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_0B1F07] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_0B1F08] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_0B1F08] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_0B1F08] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_0B1F08] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_0B1F08] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_0B1F08] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_0B1F08] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_0B1F08] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_0B1F08] = 8                       
		  ,[AHU10_0B1F08] = ROUND(RAND() * 20, 5)+18
		  ,[AHU11_0B1F08] = ROUND(RAND() * 9, 5)+23 
                                                
	--AHU_0RF                                     
	UPDATE [dbo].[AHU_0RF]                        
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()                   
		  ,[AHU01_00RF01] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_00RF01] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_00RF01] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_00RF01] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_00RF01] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_00RF01] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_00RF01] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_00RF01] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_00RF01] = 991                     
		  ,[AHU10_00RF01] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_00RF01] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_00RF02] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_00RF02] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_00RF02] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_00RF02] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_00RF02] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_00RF02] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_00RF02] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_00RF02] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_00RF02] = 992                      
		  ,[AHU10_00RF02] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_00RF02] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_00RF03] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_00RF03] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_00RF03] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_00RF03] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_00RF03] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_00RF03] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_00RF03] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_00RF03] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_00RF03] = 993                      
		  ,[AHU10_00RF03] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_00RF03] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_00RF04] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_00RF04] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_00RF04] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_00RF04] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_00RF04] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_00RF04] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_00RF04] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_00RF04] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_00RF04] = 994                      
		  ,[AHU10_00RF04] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_00RF04] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_00RF05] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_00RF05] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_00RF05] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_00RF05] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_00RF05] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_00RF05] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_00RF05] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_00RF05] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_00RF05] = 995                      
		  ,[AHU10_00RF05] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_00RF05] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_00RF06] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_00RF06] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_00RF06] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_00RF06] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_00RF06] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_00RF06] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_00RF06] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_00RF06] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_00RF06] = 996                      
		  ,[AHU10_00RF06] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_00RF06] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_00RF07] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_00RF07] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_00RF07] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_00RF07] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_00RF07] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_00RF07] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_00RF07] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_00RF07] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_00RF07] = 997                      
		  ,[AHU10_00RF07] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_00RF07] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_00RF08] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_00RF08] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_00RF08] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_00RF08] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_00RF08] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_00RF08] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_00RF08] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_00RF08] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_00RF08] = 998                      
		  ,[AHU10_00RF08] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_00RF08] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_00RF09] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_00RF09] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_00RF09] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_00RF09] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_00RF09] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_00RF09] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_00RF09] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_00RF09] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_00RF09] = 999                     
		  ,[AHU10_00RF09] = ROUND(RAND() * 20, 5)+18
		  ,[AHU11_00RF09] = ROUND(RAND() * 9, 5)+23 
                                                
	--AHU_014                                     
	UPDATE [dbo].[AHU_14F]                        
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()                   
		  ,[AHU01_014F01] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_014F01] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_014F01] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_014F01] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_014F01] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_014F01] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_014F01] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_014F01] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_014F01] = 141                     
		  ,[AHU10_014F01] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_014F01] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_014F02] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_014F02] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_014F02] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_014F02] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_014F02] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_014F02] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_014F02] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_014F02] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_014F02] = 142                      
		  ,[AHU10_014F02] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_014F02] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_014F03] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_014F03] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_014F03] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_014F03] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_014F03] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_014F03] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_014F03] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_014F03] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_014F03] = 143                      
		  ,[AHU10_014F03] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_014F03] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_014F04] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_014F04] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_014F04] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_014F04] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_014F04] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_014F04] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_014F04] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_014F04] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_014F04] = 144                      
		  ,[AHU10_014F04] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_014F04] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_014F05] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_014F05] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_014F05] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_014F05] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_014F05] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_014F05] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_014F05] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_014F05] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_014F05] = 145                      
		  ,[AHU10_014F05] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_014F05] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_014F06] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_014F06] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_014F06] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_014F06] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_014F06] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_014F06] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_014F06] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_014F06] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_014F06] = 146                      
		  ,[AHU10_014F06] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_014F06] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_014F07] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_014F07] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_014F07] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_014F07] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_014F07] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_014F07] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_014F07] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_014F07] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_014F07] = 147                      
		  ,[AHU10_014F07] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_014F07] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_014F08] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_014F08] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_014F08] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_014F08] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_014F08] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_014F08] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_014F08] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_014F08] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_014F08] = 148                      
		  ,[AHU10_014F08] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_014F08] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_014F09] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_014F09] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_014F09] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_014F09] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_014F09] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_014F09] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_014F09] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_014F09] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_014F09] = 149                     
		  ,[AHU10_014F09] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_014F09] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_014F10] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_014F10] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_014F10] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_014F10] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_014F10] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_014F10] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_014F10] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_014F10] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_014F10] = 1410                      
		  ,[AHU10_014F10] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_014F10] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_014F11] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_014F11] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_014F11] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_014F11] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_014F11] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_014F11] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_014F11] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_014F11] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_014F11] = 1411                      
		  ,[AHU10_014F11] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_014F11] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_014F12] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_014F12] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_014F12] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_014F12] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_014F12] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_014F12] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_014F12] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_014F12] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_014F12] = 1412                      
		  ,[AHU10_014F12] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_014F12] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_014F13] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_014F13] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_014F13] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_014F13] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_014F13] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_014F13] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_014F13] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_014F13] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_014F13] = 1413                      
		  ,[AHU10_014F13] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_014F13] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_014F14] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_014F14] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_014F14] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_014F14] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_014F14] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_014F14] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_014F14] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_014F14] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_014F14] = 1414                      
		  ,[AHU10_014F14] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_014F14] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_014F15] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_014F15] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_014F15] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_014F15] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_014F15] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_014F15] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_014F15] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_014F15] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_014F15] = 1415                      
		  ,[AHU10_014F15] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_014F15] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_014F16] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_014F16] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_014F16] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_014F16] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_014F16] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_014F16] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_014F16] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_014F16] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_014F16] = 1416                      
		  ,[AHU10_014F16] = ROUND(RAND() * 20, 5)+18
		  ,[AHU11_014F16] = ROUND(RAND() * 9, 5)+23 
                                                
	--AHU_S03                                     
	UPDATE [dbo].[AHU_S03]                        
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()                   
		  ,[AHU01_S03F01] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_S03F01] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_S03F01] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_S03F01] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_S03F01] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_S03F01] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_S03F01] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_S03F01] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_S03F01] = 310                     
		  ,[AHU10_S03F01] = ROUND(RAND() * 20, 5)+18
		  ,[AHU11_S03F01] = ROUND(RAND() * 9, 5)+23 
                                                
	--AHU_SB1                                     
	UPDATE [dbo].[AHU_SB1]                        
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()                   
		  ,[AHU01_SB1F01] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_SB1F01] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_SB1F01] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_SB1F01] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_SB1F01] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_SB1F01] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_SB1F01] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_SB1F01] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_SB1F01] = 311                     
		  ,[AHU10_SB1F01] = ROUND(RAND() * 10, 5)*10
		  ,[AHU11_SB1F01] = ROUND(RAND() * 1, 2)+50 
		  ,[AHU01_SB1F02] = ROUND(RAND() * 1, 5)    
		  ,[AHU02_SB1F02] = ROUND(RAND() * 1, 5)    
		  ,[AHU03_SB1F02] = ROUND(RAND() * 3, 5)*10 
		  ,[AHU04_SB1F02] = ROUND(RAND() * 10, 5)*10
		  ,[AHU05_SB1F02] = ROUND(RAND() * 8, 5)+22 
		  ,[AHU06_SB1F02] = ROUND(RAND() * 40, 5)+40
		  ,[AHU07_SB1F02] = ROUND(RAND() * 20, 5)+18
		  ,[AHU08_SB1F02] = ROUND(RAND() * 9, 5)+23 
		  ,[AHU09_SB1F02] = 312                     
		  ,[AHU10_SB1F02] = ROUND(RAND() * 20, 5)+18
		  ,[AHU11_SB1F02] = ROUND(RAND() * 9, 5)+23 

	--Chiller                                     
	UPDATE [dbo].[Chiller]
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()     
      ,[Chiller01_R1] = 0
      ,[Chiller02_R1] = ROUND(RAND() * 2, 1)*16
      ,[Chiller03_R1] = ROUND(RAND() * 2, 1)*18
      ,[Chiller04_R1] = 1
      ,[Chiller05_R1] = ROUND(RAND() * 2, 1)*26
      ,[Chiller06_R1] = ROUND(RAND() * 2, 1)*26
      ,[Chiller07_R1] = 2
      ,[Chiller08_R1] = 3
      ,[Chiller09_R1] = 4
      ,[Chiller10_R1] = 51
      ,[Chiller01_R2] = 0                      
      ,[Chiller02_R2] = ROUND(RAND() * 2, 1)*16
      ,[Chiller03_R2] = ROUND(RAND() * 2, 1)*18
      ,[Chiller04_R2] = 1                      
      ,[Chiller05_R2] = ROUND(RAND() * 2, 1)*26
      ,[Chiller06_R2] = ROUND(RAND() * 2, 1)*26
      ,[Chiller07_R2] = 2                      
      ,[Chiller08_R2] = 3                      
      ,[Chiller09_R2] = 4                      
      ,[Chiller10_R2] = 52                     
      ,[Chiller01_R3] = 0                      
      ,[Chiller02_R3] = ROUND(RAND() * 2, 1)*16
      ,[Chiller03_R3] = ROUND(RAND() * 2, 1)*18
      ,[Chiller04_R3] = 1                      
      ,[Chiller05_R3] = ROUND(RAND() * 2, 1)*26
      ,[Chiller06_R3] = ROUND(RAND() * 2, 1)*26
      ,[Chiller07_R3] = 2                      
      ,[Chiller08_R3] = 3                      
      ,[Chiller09_R3] = 4                      
      ,[Chiller10_R3] = 53                     
      ,[Chiller01_R6] = 0                      
      ,[Chiller02_R6] = ROUND(RAND() * 2, 1)*16
      ,[Chiller03_R6] = ROUND(RAND() * 2, 1)*18
      ,[Chiller04_R6] = 1                      
      ,[Chiller05_R6] = ROUND(RAND() * 2, 1)*26
      ,[Chiller06_R6] = ROUND(RAND() * 2, 1)*26
      ,[Chiller07_R6] = 2                      
      ,[Chiller08_R6] = 3                      
      ,[Chiller09_R6] = 4                      
      ,[Chiller10_R6] = 54                    

	--COP	  
	UPDATE [dbo].[COP]
		SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()     
		  ,[COP01_001] = ROUND(RAND() * 1, 0)
		  ,[COP02_001] = ROUND(RAND() * 1, 0)
		  ,[COP03_001] = ROUND(RAND() * 1, 0)
		  ,[COP04_001] = ROUND(RAND() * 1, 0)
		  ,[COP05_001] = 51
		  ,[COP01_002] = ROUND(RAND() * 1, 0) 
		  ,[COP02_002] = ROUND(RAND() * 1, 0)  
		  ,[COP03_002] = ROUND(RAND() * 1, 0) 
		  ,[COP04_002] = ROUND(RAND() * 1, 0)
		  ,[COP05_002] = 52 
		  ,[COP01_003] = ROUND(RAND() * 1, 0)
		  ,[COP02_003] = ROUND(RAND() * 1, 0)
		  ,[COP03_003] = ROUND(RAND() * 1, 0) 
		  ,[COP04_003] = ROUND(RAND() * 1, 0)
		  ,[COP05_003] = 53 
		  ,[COP01_006] = ROUND(RAND() * 1, 0) 
		  ,[COP02_006] = ROUND(RAND() * 1, 0)
		  ,[COP03_006] = ROUND(RAND() * 1, 0)
		  ,[COP04_006] = ROUND(RAND() * 1, 0)
		  ,[COP05_006] = 56
		  ,[COP01_12S] = ROUND(RAND() * 1, 0) 
		  ,[COP02_12S] = ROUND(RAND() * 1, 0) 
		  ,[COP03_12S] = ROUND(RAND() * 1, 0)
		  ,[COP04_12S] = ROUND(RAND() * 1, 0)
		  ,[COP05_12S] = 412 
		  ,[COP01_03S] = ROUND(RAND() * 1, 0)
		  ,[COP02_03S] = ROUND(RAND() * 1, 0)
		  ,[COP03_03S] = ROUND(RAND() * 1, 0)
		  ,[COP04_03S] = ROUND(RAND() * 1, 0)
		  ,[COP05_03S] = 403 
		  ,[COP01_06S] = ROUND(RAND() * 1, 0)
		  ,[COP02_06S] = ROUND(RAND() * 1, 0)
		  ,[COP03_06S] = ROUND(RAND() * 1, 0)
		  ,[COP04_06S] = ROUND(RAND() * 1, 0)
		  ,[COP05_06S] = 406       
END
GO
/****** Object:  StoredProcedure [dbo].[TimerUpdateAHU2]    Script Date: 2019/10/5 上午 08:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TimerUpdateAHU2]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

		--AHU_04F
	UPDATE [dbo].[AHU_04F]
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()
		  ,[AHU01_004F01] = 1                                                                                                                                                                                   
		  ,[AHU02_004F01] = 2                                                                                                                                                                                   
		  ,[AHU03_004F01] = 3                                                                                                                                                                                   
		  ,[AHU04_004F01] = 4                                                                                                                                                                                   
		  ,[AHU05_004F01] = 5                                                                                                                                                                                   
		  ,[AHU06_004F01] = 6                                                                                                                                                                                   
		  ,[AHU07_004F01] = 7                                                                                                                                                                                   
		  ,[AHU08_004F01] = 8                                                                                                                                                             
		  ,[AHU09_004F01] = 41                                                                                                                                                                                  
		  ,[AHU10_004F01] = 10                                                                                                                                                                                  
		  ,[AHU11_004F01] = 11                                                                                                                                                                                  
		  ,[AHU01_004F02] = 1                                                                                                                                                                                   
		  ,[AHU02_004F02] = 2                                                                                                                                                                                   
		  ,[AHU03_004F02] = 3                                                                                                                                                                                   
		  ,[AHU04_004F02] = 4                                                                                                                                                                                   
		  ,[AHU05_004F02] = 5                                                                                                                                                                                   
		  ,[AHU06_004F02] = 6                                                                                                                                                                                   
		  ,[AHU07_004F02] = 7                                                                                                                                                                                   
		  ,[AHU08_004F02] = 8                                                                                                                                                                                   
		  ,[AHU09_004F02] = 42                                                                                                                                                                                  
		  ,[AHU10_004F02] = 10                                                                                                                                                                                  
		  ,[AHU11_004F02] = 11                                                                                                                                                                                  
		  ,[AHU01_004F03] = 1                                                                                                                                                                                   
		  ,[AHU02_004F03] = 2                                                                                                                                                                                   
		  ,[AHU03_004F03] = 3                                                                                                                                                                                   
		  ,[AHU04_004F03] = 4                                                                                                                                                                                   
		  ,[AHU05_004F03] = 5                                                                                                                                                                                   
		  ,[AHU06_004F03] = 6                                                                                                                                                                                   
		  ,[AHU07_004F03] = 7                                                                                                                                                                                   
		  ,[AHU08_004F03] = 8                                                                                                                                                                                   
		  ,[AHU09_004F03] = 43                                                                                                                                                                                  
		  ,[AHU10_004F03] = 10                                                                                                                                                                                  
		  ,[AHU11_004F03] = 11                                                                                                                                                                                  
		  ,[AHU01_004F04] = 1                                                                                                                                                                                   
		  ,[AHU02_004F04] = 2                                                                                                                                                                                   
		  ,[AHU03_004F04] = 3                                                                                                                                                                                   
		  ,[AHU04_004F04] = 4                                                                                                                                                                                   
		  ,[AHU05_004F04] = 5                                                                                                                                                                                   
		  ,[AHU06_004F04] = 6                                                                                                                                                                                   
		  ,[AHU07_004F04] = 7                                                                                                                                                                                   
		  ,[AHU08_004F04] = 8                                                                                                                                                                                   
		  ,[AHU09_004F04] = 44                                                                                                                                                                                  
		  ,[AHU10_004F04] = 10                                                                                                                                                                                  
		  ,[AHU11_004F04] = 11                                                                                                                                                                                  
	                                                                                                                                                                                                          
	--AHU_0B1                                                                                                                                                                                                 
	UPDATE [dbo].[AHU_0B1]                                                                                                                                                                                    
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))                                                     
		  ,[DATETIME] = GETDATE()                                                                                                                                                                               
		  ,[AHU01_0B1F01] = 1                                                                                                                                                                                   
		  ,[AHU02_0B1F01] = 2                                                                                                                                                                                   
		  ,[AHU03_0B1F01] = 3                                                                                                                                                                                   
		  ,[AHU04_0B1F01] = 4                                                                                                                                                                                   
		  ,[AHU05_0B1F01] = 5                                                                                                                                                                                   
		  ,[AHU06_0B1F01] = 6                                                                                                                                                                                   
		  ,[AHU07_0B1F01] = 7                                                                                                                                                                                   
		  ,[AHU08_0B1F01] = 8                                                                                                                                                                                   
		  ,[AHU09_0B1F01] = 1                                                                                                                                                                                   
		  ,[AHU10_0B1F01] = 10                                                                                                                                                                                  
		  ,[AHU11_0B1F01] = 11                                                                                                                                                                                  
		  ,[AHU01_0B1F02] = 1                                                                                                                                                                                   
		  ,[AHU02_0B1F02] = 2                                                                                                                                                                                   
		  ,[AHU03_0B1F02] = 3                                                                                                                                                                                   
		  ,[AHU04_0B1F02] = 4                                                                                                                                                                                   
		  ,[AHU05_0B1F02] = 5                                                                                                                                                                                   
		  ,[AHU06_0B1F02] = 6                                                                                                                                                                                   
		  ,[AHU07_0B1F02] = 7                                                                                                                                                                                   
		  ,[AHU08_0B1F02] = 8                                                                                                                                                                                   
		  ,[AHU09_0B1F02] = 2                                                                                                                                                                                   
		  ,[AHU10_0B1F02] = 10                                                                                                                                                                                  
		  ,[AHU11_0B1F02] = 11                                                                                                                                                                                  
		  ,[AHU01_0B1F03] = 1                                                                                                                                                                                   
		  ,[AHU02_0B1F03] = 2                                                                                                                                                                                   
		  ,[AHU03_0B1F03] = 3                                                                                                                                                                                   
		  ,[AHU04_0B1F03] = 4                                                                                                                                                                                   
		  ,[AHU05_0B1F03] = 5                                                                                                                                                                                   
		  ,[AHU06_0B1F03] = 6                                                                                                                                                                                   
		  ,[AHU07_0B1F03] = 7                                                                                                                                                                                   
		  ,[AHU08_0B1F03] = 8                                                                                                                                                                                   
		  ,[AHU09_0B1F03] = 3                                                                                                                                                                                   
		  ,[AHU10_0B1F03] = 10                                                                                                                                                                                  
		  ,[AHU11_0B1F03] = 11                                                                                                                                                                                  
		  ,[AHU01_0B1F04] = 1                                                                                                                                                                                   
		  ,[AHU02_0B1F04] = 2                                                                                                                                                                                   
		  ,[AHU03_0B1F04] = 3                                                                                                                                                                                   
		  ,[AHU04_0B1F04] = 4                                                                                                                                                                                   
		  ,[AHU05_0B1F04] = 5                                                                                                                                                                                   
		  ,[AHU06_0B1F04] = 6                                                                                                                                                                                   
		  ,[AHU07_0B1F04] = 7                                                                                                                                                                                   
		  ,[AHU08_0B1F04] = 8                                                                                                                                                                                   
		  ,[AHU09_0B1F04] = 4                                                                                                                                                                                   
		  ,[AHU10_0B1F04] = 10                                                                                                                                                                                  
		  ,[AHU11_0B1F04] = 11                                                                                                                                                                                  
		  ,[AHU01_0B1F05] = 1                                                                                                                                                                                   
		  ,[AHU02_0B1F05] = 2                                                                                                                                                                                   
		  ,[AHU03_0B1F05] = 3                                                                                                                                                                                   
		  ,[AHU04_0B1F05] = 4                                                                                                                                                                                   
		  ,[AHU05_0B1F05] = 5                                                                                                                                                                                   
		  ,[AHU06_0B1F05] = 6                                                                                                                                                                                   
		  ,[AHU07_0B1F05] = 7                                                                                                                                                                                   
		  ,[AHU08_0B1F05] = 8                                                                                                                                                                                   
		  ,[AHU09_0B1F05] = 5                                                                                                                                                                                   
		  ,[AHU10_0B1F05] = 10                                                                                                                                                                                  
		  ,[AHU11_0B1F05] = 11                                                                                                                                                                                  
		  ,[AHU01_0B1F06] = 1                                                                                                                                                                                   
		  ,[AHU02_0B1F06] = 2                                                                                                                                                                                   
		  ,[AHU03_0B1F06] = 3                                                                                                                                                                                   
		  ,[AHU04_0B1F06] = 4                                                                                                                                                                                   
		  ,[AHU05_0B1F06] = 5                                                                                                                                                                                   
		  ,[AHU06_0B1F06] = 6                                                                                                                                                                                   
		  ,[AHU07_0B1F06] = 7                                                                                                                                                                                   
		  ,[AHU08_0B1F06] = 8                                                                                                                                                                                   
		  ,[AHU09_0B1F06] = 6                                                                                                                                                                                   
		  ,[AHU10_0B1F06] = 10                                                                                                                                                                                  
		  ,[AHU11_0B1F06] = 11                                                                                                                                                                                  
		  ,[AHU01_0B1F07] = 1                                                                                                                                                                                   
		  ,[AHU02_0B1F07] = 2                                                                                                                                                                                   
		  ,[AHU03_0B1F07] = 3                                                                                                                                                                                   
		  ,[AHU04_0B1F07] = 4                                                                                                                                                                                   
		  ,[AHU05_0B1F07] = 5                                                                                                                                                                                   
		  ,[AHU06_0B1F07] = 6                                                                                                                                                                                   
		  ,[AHU07_0B1F07] = 7                                                                                                                                                                                   
		  ,[AHU08_0B1F07] = 8                                                                                                                                                                                   
		  ,[AHU09_0B1F07] = 7                                                                                                                                                                                   
		  ,[AHU10_0B1F07] = 10                                                                                                                                                                                  
		  ,[AHU11_0B1F07] = 11                                                                                                                                                                                  
		  ,[AHU01_0B1F08] = 1                                                                                                                                                                                   
		  ,[AHU02_0B1F08] = 2                                                                                                                                                                                   
		  ,[AHU03_0B1F08] = 3                                                                                                                                                                                   
		  ,[AHU04_0B1F08] = 4                                                                                                                                                                                   
		  ,[AHU05_0B1F08] = 5                                                                                                                                                                                   
		  ,[AHU06_0B1F08] = 6                                                                                                                                                                                   
		  ,[AHU07_0B1F08] = 7                                                                                                                                                                                   
		  ,[AHU08_0B1F08] = 8                                                                                                                                                                                   
		  ,[AHU09_0B1F08] = 8                                                                                                                                                                                   
		  ,[AHU10_0B1F08] = 10                                                                                                                                                                                  
		  ,[AHU11_0B1F08] = 11                                                                                                                                                                                  
                                                                                                                                                                                                            
	--AHU_0RF                                                                                                                                                                                                 
	UPDATE [dbo].[AHU_0RF]                                                                                                                                                                                    
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))                                                     
		  ,[DATETIME] = GETDATE()                                                                                                                                                                               
		  ,[AHU01_00RF01] = 1                                                                                                                                                                                   
		  ,[AHU02_00RF01] = 2                                                                                                                                                                                   
		  ,[AHU03_00RF01] = 3                                                                                                                                                                                   
		  ,[AHU04_00RF01] = 4                                                                                                                                                                                   
		  ,[AHU05_00RF01] = 5                                                                                                                                                                                   
		  ,[AHU06_00RF01] = 6                                                                                                                                                                                   
		  ,[AHU07_00RF01] = 7                                                                                                                                                                                   
		  ,[AHU08_00RF01] = 8                                                                                                                                                                                   
		  ,[AHU09_00RF01] = 991                                                                                                                                                                                 
		  ,[AHU10_00RF01] = 10                                                                                                                                                                                  
		  ,[AHU11_00RF01] = 11                                                                                                                                                                                  
		  ,[AHU01_00RF02] = 1                                                                                                                                                                                   
		  ,[AHU02_00RF02] = 2                                                                                                                                                                                   
		  ,[AHU03_00RF02] = 3                                                                                                                                                                                   
		  ,[AHU04_00RF02] = 4                                                                                                                                                                                   
		  ,[AHU05_00RF02] = 5                                                                                                                                                                                   
		  ,[AHU06_00RF02] = 6                                                                                                                                                                                   
		  ,[AHU07_00RF02] = 7                                                                                                                                                                                   
		  ,[AHU08_00RF02] = 8                                                                                                                                                                                   
		  ,[AHU09_00RF02] = 992                                                                                                                                                                                 
		  ,[AHU10_00RF02] = 10                                                                                                                                                                                  
		  ,[AHU11_00RF02] = 11                                                                                                                                                                                  
		  ,[AHU01_00RF03] = 1                                                                                                                                                                                   
		  ,[AHU02_00RF03] = 2                                                                                                                                                                                   
		  ,[AHU03_00RF03] = 3                                                                                                                                                                                   
		  ,[AHU04_00RF03] = 4                                                                                                                                                                                   
		  ,[AHU05_00RF03] = 5                                                                                                                                                                                   
		  ,[AHU06_00RF03] = 6                                                                                                                                                                                   
		  ,[AHU07_00RF03] = 7                                                                                                                                                                                   
		  ,[AHU08_00RF03] = 8                                                                                                                                                                                   
		  ,[AHU09_00RF03] = 993                                                                                                                                                                                 
		  ,[AHU10_00RF03] = 10                                                                                                                                                                                  
		  ,[AHU11_00RF03] = 11                                                                                                                                                                                  
		  ,[AHU01_00RF04] = 1                                                                                                                                                                                   
		  ,[AHU02_00RF04] = 2                                                                                                                                                                                   
		  ,[AHU03_00RF04] = 3                                                                                                                                                                                   
		  ,[AHU04_00RF04] = 4                                                                                                                                                                                   
		  ,[AHU05_00RF04] = 5                                                                                                                                                                                   
		  ,[AHU06_00RF04] = 6                                                                                                                                                                                   
		  ,[AHU07_00RF04] = 7                                                                                                                                                                                   
		  ,[AHU08_00RF04] = 8                                                                                                                                                                                   
		  ,[AHU09_00RF04] = 994                                                                                                                                                                                 
		  ,[AHU10_00RF04] = 10                                                                                                                                                                                  
		  ,[AHU11_00RF04] = 11                                                                                                                                                                                  
		  ,[AHU01_00RF05] = 1                                                                                                                                                                                   
		  ,[AHU02_00RF05] = 2                                                                                                                                                                                   
		  ,[AHU03_00RF05] = 3                                                                                                                                                                                   
		  ,[AHU04_00RF05] = 4                                                                                                                                                                                   
		  ,[AHU05_00RF05] = 5                                                                                                                                                                                   
		  ,[AHU06_00RF05] = 6                                                                                                                                                                                   
		  ,[AHU07_00RF05] = 7                                                                                                                                                                                   
		  ,[AHU08_00RF05] = 8                                                                                                                                                                                   
		  ,[AHU09_00RF05] = 995                                                                                                                                                                                 
		  ,[AHU10_00RF05] = 10                                                                                                                                                                                  
		  ,[AHU11_00RF05] = 11                                                                                                                                                                                  
		  ,[AHU01_00RF06] = 1                                                                                                                                                                                   
		  ,[AHU02_00RF06] = 2                                                                                                                                                                                   
		  ,[AHU03_00RF06] = 3                                                                                                                                                                                   
		  ,[AHU04_00RF06] = 4                                                                                                                                                                                   
		  ,[AHU05_00RF06] = 5                                                                                                                                                                                   
		  ,[AHU06_00RF06] = 6                                                                                                                                                                                   
		  ,[AHU07_00RF06] = 7                                                                                                                                                                                   
		  ,[AHU08_00RF06] = 8                                                                                                                                                                                   
		  ,[AHU09_00RF06] = 996                                                                                                                                                                                 
		  ,[AHU10_00RF06] = 10                                                                                                                                                                                  
		  ,[AHU11_00RF06] = 11                                                                                                                                                                                  
		  ,[AHU01_00RF07] = 1                                                                                                                                                                                   
		  ,[AHU02_00RF07] = 2                                                                                                                                                                                   
		  ,[AHU03_00RF07] = 3                                                                                                                                                                                   
		  ,[AHU04_00RF07] = 4                                                                                                                                                                                   
		  ,[AHU05_00RF07] = 5                                                                                                                                                                                   
		  ,[AHU06_00RF07] = 6                                                                                                                                                                                   
		  ,[AHU07_00RF07] = 7                                                                                                                                                                                   
		  ,[AHU08_00RF07] = 8                                                                                                                                                                                   
		  ,[AHU09_00RF07] = 997                                                                                                                                                                                 
		  ,[AHU10_00RF07] = 10                                                                                                                                                                                  
		  ,[AHU11_00RF07] = 11                                                                                                                                                                                  
		  ,[AHU01_00RF08] = 1                                                                                                                                                                                   
		  ,[AHU02_00RF08] = 2                                                                                                                                                                                   
		  ,[AHU03_00RF08] = 3                                                                                                                                                                                   
		  ,[AHU04_00RF08] = 4                                                                                                                                                                                   
		  ,[AHU05_00RF08] = 5                                                                                                                                                                                   
		  ,[AHU06_00RF08] = 6                                                                                                                                                                                   
		  ,[AHU07_00RF08] = 7                                                                                                                                                                                   
		  ,[AHU08_00RF08] = 8                                                                                                                                                                                   
		  ,[AHU09_00RF08] = 998                                                                                                                                                                                 
		  ,[AHU10_00RF08] = 10                                                                                                                                                                                  
		  ,[AHU11_00RF08] = 11                                                                                                                                                                                  
		  ,[AHU01_00RF09] = 1                                                                                                                                                                                   
		  ,[AHU02_00RF09] = 2                                                                                                                                                                                   
		  ,[AHU03_00RF09] = 3                                                                                                                                                                                   
		  ,[AHU04_00RF09] = 4                                                                                                                                                                                   
		  ,[AHU05_00RF09] = 5                                                                                                                                                                                   
		  ,[AHU06_00RF09] = 6                                                                                                                                                                                   
		  ,[AHU07_00RF09] = 7                                                                                                                                                                                   
		  ,[AHU08_00RF09] = 8                                                                                                                                                                                   
		  ,[AHU09_00RF09] = 999                                                                                                                                                                                 
		  ,[AHU10_00RF09] = 10                                                                                                                                                                                  
		  ,[AHU11_00RF09] = 11                                                                                                                                                                                  
                                                                                                                                                                                                            
	--AHU_014                                                                                                                                                                                                 
	UPDATE [dbo].[AHU_14F]                                                                                                                                                                                    
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))                                                     
		  ,[DATETIME] = GETDATE()                                                                                                                                                                               
		  ,[AHU01_014F01] = 1                                                                                                                                                                                   
		  ,[AHU02_014F01] = 2                                                                                                                                                                                   
		  ,[AHU03_014F01] = 3                                                                                                                                                                                   
		  ,[AHU04_014F01] = 4                                                                                                                                                                                   
		  ,[AHU05_014F01] = 5                                                                                                                                                                                   
		  ,[AHU06_014F01] = 6                                                                                                                                                                                   
		  ,[AHU07_014F01] = 7                                                                                                                                                                                   
		  ,[AHU08_014F01] = 8                                                                                                                                                                                   
		  ,[AHU09_014F01] = 141                                                                                                                                                                                 
		  ,[AHU10_014F01] = 10                                                                                                                                                                                  
		  ,[AHU11_014F01] = 11                                                                                                                                                                                  
		  ,[AHU01_014F02] = 1                                                                                                                                                                                   
		  ,[AHU02_014F02] = 2                                                                                                                                                                                   
		  ,[AHU03_014F02] = 3                                                                                                                                                                                   
		  ,[AHU04_014F02] = 4                                                                                                                                                                                   
		  ,[AHU05_014F02] = 5                                                                                                                                                                                   
		  ,[AHU06_014F02] = 6                                                                                                                                                                                   
		  ,[AHU07_014F02] = 7                                                                                                                                                                                   
		  ,[AHU08_014F02] = 8                                                                                                                                                                                   
		  ,[AHU09_014F02] = 142                                                                                                                                                                                 
		  ,[AHU10_014F02] = 10                                                                                                                                                                                  
		  ,[AHU11_014F02] = 11                                                                                                                                                                                  
		  ,[AHU01_014F03] = 1                                                                                                                                                                                   
		  ,[AHU02_014F03] = 2                                                                                                                                                                                   
		  ,[AHU03_014F03] = 3                                                                                                                                                                                   
		  ,[AHU04_014F03] = 4                                                                                                                                                                                   
		  ,[AHU05_014F03] = 5                                                                                                                                                                                   
		  ,[AHU06_014F03] = 6                                                                                                                                                                                   
		  ,[AHU07_014F03] = 7                                                                                                                                                                                   
		  ,[AHU08_014F03] = 8                                                                                                                                                                                   
		  ,[AHU09_014F03] = 143                                                                                                                                                                                 
		  ,[AHU10_014F03] = 10                                                                                                                                                                                  
		  ,[AHU11_014F03] = 11                                                                                                                                                                                  
		  ,[AHU01_014F04] = 1                                                                                                                                                                                   
		  ,[AHU02_014F04] = 2                                                                                                                                                                                   
		  ,[AHU03_014F04] = 3                                                                                                                                                                                   
		  ,[AHU04_014F04] = 4                                                                                                                                                                                   
		  ,[AHU05_014F04] = 5                                                                                                                                                                                   
		  ,[AHU06_014F04] = 6                                                                                                                                                                                   
		  ,[AHU07_014F04] = 7                                                                                                                                                                                   
		  ,[AHU08_014F04] = 8                                                                                                                                                                                   
		  ,[AHU09_014F04] = 144                                                                                                                                                                                 
		  ,[AHU10_014F04] = 10                                                                                                                                                                                  
		  ,[AHU11_014F04] = 11                                                                                                                                                                                  
		  ,[AHU01_014F05] = 1                                                                                                                                                                                   
		  ,[AHU02_014F05] = 2                                                                                                                                                                                   
		  ,[AHU03_014F05] = 3                                                                                                                                                                                   
		  ,[AHU04_014F05] = 4                                                                                                                                                                                   
		  ,[AHU05_014F05] = 5                                                                                                                                                                                   
		  ,[AHU06_014F05] = 6                                                                                                                                                                                   
		  ,[AHU07_014F05] = 7                                                                                                                                                                                   
		  ,[AHU08_014F05] = 8                                                                                                                                                                                   
		  ,[AHU09_014F05] = 145                                                                                                                                                                                 
		  ,[AHU10_014F05] = 10                                                                                                                                                                                  
		  ,[AHU11_014F05] = 11                                                                                                                                                                                  
		  ,[AHU01_014F06] = 1                                                                                                                                                                                   
		  ,[AHU02_014F06] = 2                                                                                                                                                                                   
		  ,[AHU03_014F06] = 3                                                                                                                                                                                   
		  ,[AHU04_014F06] = 4                                                                                                                                                                                   
		  ,[AHU05_014F06] = 5                                                                                                                                                                                   
		  ,[AHU06_014F06] = 6                                                                                                                                                                                   
		  ,[AHU07_014F06] = 7                                                                                                                                                                                   
		  ,[AHU08_014F06] = 8                                                                                                                                                                                   
		  ,[AHU09_014F06] = 146                                                                                                                                                                                 
		  ,[AHU10_014F06] = 10                                                                                                                                                                                  
		  ,[AHU11_014F06] = 11                                                                                                                                                                                  
		  ,[AHU01_014F07] = 1                                                                                                                                                                                   
		  ,[AHU02_014F07] = 2                                                                                                                                                                                   
		  ,[AHU03_014F07] = 3                                                                                                                                                                                   
		  ,[AHU04_014F07] = 4                                                                                                                                                                                   
		  ,[AHU05_014F07] = 5                                                                                                                                                                                   
		  ,[AHU06_014F07] = 6                                                                                                                                                                                   
		  ,[AHU07_014F07] = 7                                                                                                                                                                                   
		  ,[AHU08_014F07] = 8                                                                                                                                                                                   
		  ,[AHU09_014F07] = 147                                                                                                                                                                                 
		  ,[AHU10_014F07] = 10                                                                                                                                                                                  
		  ,[AHU11_014F07] = 11                                                                                                                                                                                  
		  ,[AHU01_014F08] = 1                                                                                                                                                                                   
		  ,[AHU02_014F08] = 2                                                                                                                                                                                   
		  ,[AHU03_014F08] = 3                                                                                                                                                                                   
		  ,[AHU04_014F08] = 4                                                                                                                                                                                   
		  ,[AHU05_014F08] = 5                                                                                                                                                                                   
		  ,[AHU06_014F08] = 6                                                                                                                                                                                   
		  ,[AHU07_014F08] = 7                                                                                                                                                                                   
		  ,[AHU08_014F08] = 8                                                                                                                                                                                   
		  ,[AHU09_014F08] = 148                                                                                                                                                                                 
		  ,[AHU10_014F08] = 10                                                                                                                                                                                  
		  ,[AHU11_014F08] = 11                                                                                                                                                                                  
		  ,[AHU01_014F09] = 1                                                                                                                                                                                   
		  ,[AHU02_014F09] = 2                                                                                                                                                                                   
		  ,[AHU03_014F09] = 3                                                                                                                                                                                   
		  ,[AHU04_014F09] = 4                                                                                                                                                                                   
		  ,[AHU05_014F09] = 5                                                                                                                                                                                   
		  ,[AHU06_014F09] = 6                                                                                                                                                                                   
		  ,[AHU07_014F09] = 7                                                                                                                                                                                   
		  ,[AHU08_014F09] = 8                                                                                                                                                                                   
		  ,[AHU09_014F09] = 149                                                                                                                                                                                 
		  ,[AHU10_014F09] = 10                                                                                                                                                                                  
		  ,[AHU11_014F09] = 11                                                                                                                                                                                  
		  ,[AHU01_014F10] = 1                                                                                                                                                                                   
		  ,[AHU02_014F10] = 2                                                                                                                                                                                   
		  ,[AHU03_014F10] = 3                                                                                                                                                                                   
		  ,[AHU04_014F10] = 4                                                                                                                                                                                   
		  ,[AHU05_014F10] = 5                                                                                                                                                                                   
		  ,[AHU06_014F10] = 6                                                                                                                                                                                   
		  ,[AHU07_014F10] = 7                                                                                                                                                                                   
		  ,[AHU08_014F10] = 8                                                                                                                                                                                   
		  ,[AHU09_014F10] = 1410                                                                                                                                                                                
		  ,[AHU10_014F10] = 10                                                                                                                                                                                  
		  ,[AHU11_014F10] = 11                                                                                                                                                                                  
		  ,[AHU01_014F11] = 1                                                                                                                                                                                   
		  ,[AHU02_014F11] = 2                                                                                                                                                                                   
		  ,[AHU03_014F11] = 3                                                                                                                                                                                   
		  ,[AHU04_014F11] = 4                                                                                                                                                                                   
		  ,[AHU05_014F11] = 5                                                                                                                                                                                   
		  ,[AHU06_014F11] = 6                                                                                                                                                                                   
		  ,[AHU07_014F11] = 7                                                                                                                                                                                   
		  ,[AHU08_014F11] = 8                                                                                                                                                                                   
		  ,[AHU09_014F11] = 1411                                                                                                                                                                                
		  ,[AHU10_014F11] = 10                                                                                                                                                                                  
		  ,[AHU11_014F11] = 11                                                                                                                                                                                  
		  ,[AHU01_014F12] = 1                                                                                                                                                                                   
		  ,[AHU02_014F12] = 2                                                                                                                                                                                   
		  ,[AHU03_014F12] = 3                                                                                                                                                                                   
		  ,[AHU04_014F12] = 4                                                                                                                                                                                   
		  ,[AHU05_014F12] = 5                                                                                                                                                                                   
		  ,[AHU06_014F12] = 6                                                                                                                                                                                   
		  ,[AHU07_014F12] = 7                                                                                                                                                                                   
		  ,[AHU08_014F12] = 8                                                                                                                                                                                   
		  ,[AHU09_014F12] = 1412                                                                                                                                                                                
		  ,[AHU10_014F12] = 10                                                                                                                                                                                  
		  ,[AHU11_014F12] = 11                                                                                                                                                                                  
		  ,[AHU01_014F13] = 1                                                                                                                                                                                   
		  ,[AHU02_014F13] = 2                                                                                                                                                                                   
		  ,[AHU03_014F13] = 3                                                                                                                                                                                   
		  ,[AHU04_014F13] = 4                                                                                                                                                                                   
		  ,[AHU05_014F13] = 5                                                                                                                                                                                   
		  ,[AHU06_014F13] = 6                                                                                                                                                                                   
		  ,[AHU07_014F13] = 7                                                                                                                                                                                   
		  ,[AHU08_014F13] = 8                                                                                                                                                                                   
		  ,[AHU09_014F13] = 1413                                                                                                                                                                                
		  ,[AHU10_014F13] = 10                                                                                                                                                                                  
		  ,[AHU11_014F13] = 11                                                                                                                                                                                  
		  ,[AHU01_014F14] = 1                                                                                                                                                                                   
		  ,[AHU02_014F14] = 2                                                                                                                                                                                   
		  ,[AHU03_014F14] = 3                                                                                                                                                                                   
		  ,[AHU04_014F14] = 4                                                                                                                                                                                   
		  ,[AHU05_014F14] = 5                                                                                                                                                                                   
		  ,[AHU06_014F14] = 6                                                                                                                                                                                   
		  ,[AHU07_014F14] = 7                                                                                                                                                                                   
		  ,[AHU08_014F14] = 8                                                                                                                                                                                   
		  ,[AHU09_014F14] = 1414                                                                                                                                                                                
		  ,[AHU10_014F14] = 10                                                                                                                                                                                  
		  ,[AHU11_014F14] = 11                                                                                                                                                                                  
		  ,[AHU01_014F15] = 1                                                                                                                                                                                   
		  ,[AHU02_014F15] = 2                                                                                                                                                                                   
		  ,[AHU03_014F15] = 3                                                                                                                                                                                   
		  ,[AHU04_014F15] = 4                                                                                                                                                                                   
		  ,[AHU05_014F15] = 5                                                                                                                                                                                   
		  ,[AHU06_014F15] = 6                                                                                                                                                                                   
		  ,[AHU07_014F15] = 7                                                                                                                                                                                   
		  ,[AHU08_014F15] = 8                                                                                                                                                                                   
		  ,[AHU09_014F15] = 1415                                                                                                                                                                                
		  ,[AHU10_014F15] = 10                                                                                                                                                                                  
		  ,[AHU11_014F15] = 11                                                                                                                                                                                  
		  ,[AHU01_014F16] = 1                                                                                                                                                                                   
		  ,[AHU02_014F16] = 2                                                                                                                                                                                   
		  ,[AHU03_014F16] = 3                                                                                                                                                                                   
		  ,[AHU04_014F16] = 4                                                                                                                                                                                   
		  ,[AHU05_014F16] = 5                                                                                                                                                                                   
		  ,[AHU06_014F16] = 6                                                                                                                                                                                   
		  ,[AHU07_014F16] = 7                                                                                                                                                                                   
		  ,[AHU08_014F16] = 8                                                                                                                                                                                   
		  ,[AHU09_014F16] = 1416                                                                                                                                                                                
		  ,[AHU10_014F16] = 10                                                                                                                                                                                  
		  ,[AHU11_014F16] = 11                                                                                                                                                                                  
                                                                                                                                                                                                            
	--AHU_S03                                                                                                                                                                                                 
	UPDATE [dbo].[AHU_S03]                                                                                                                                                                                    
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))                                                     
		  ,[DATETIME] = GETDATE()                                                                                                                                                                               
		  ,[AHU01_S03F01] = 1                                                                                                                                                                                   
		  ,[AHU02_S03F01] = 2                                                                                                                                                                                   
		  ,[AHU03_S03F01] = 3                                                                                                                                                                                   
		  ,[AHU04_S03F01] = 4                                                                                                                                                                                   
		  ,[AHU05_S03F01] = 5                                                                                                                                                                                   
		  ,[AHU06_S03F01] = 6                                                                                                                                                                                   
		  ,[AHU07_S03F01] = 7                                                                                                                                                                                   
		  ,[AHU08_S03F01] = 8                                                                                                                                                                                   
		  ,[AHU09_S03F01] = 310                                                                                                                                                                                 
		  ,[AHU10_S03F01] = 10                                                                                                                                                                                  
		  ,[AHU11_S03F01] = 11                                                                                                                                                                                  
                                                                                                                                                                                                            
	--AHU_SB1                                                                                                                                                                                                 
	UPDATE [dbo].[AHU_SB1]                                                                                                                                                                                    
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))                                                     
		  ,[DATETIME] = GETDATE()                                                                                                                                                                               
		  ,[AHU01_SB1F01] = 1                                                                                                                                                                                   
		  ,[AHU02_SB1F01] = 2                                                                                                                                                                                   
		  ,[AHU03_SB1F01] = 3                                                                                                                                                                                   
		  ,[AHU04_SB1F01] = 4                                                                                                                                                                                   
		  ,[AHU05_SB1F01] = 5                                                                                                                                                                                   
		  ,[AHU06_SB1F01] = 6                                                                                                                                                                                   
		  ,[AHU07_SB1F01] = 7                                                                                                                                                                                   
		  ,[AHU08_SB1F01] = 8                                                                                                                                                                                   
		  ,[AHU09_SB1F01] = 311                                                                                                                                                                                 
		  ,[AHU10_SB1F01] = 10                                                                                                                                                                                  
		  ,[AHU11_SB1F01] = 11                                                                                                                                                                                  
		  ,[AHU01_SB1F02] = 1                                                                                                                                                                                   
		  ,[AHU02_SB1F02] = 2                                                                                                                                                                                   
		  ,[AHU03_SB1F02] = 3                                                                                                                                                                                   
		  ,[AHU04_SB1F02] = 4                                                                                                                                                                                   
		  ,[AHU05_SB1F02] = 5                                                                                                                                                                                   
		  ,[AHU06_SB1F02] = 6                                                                                                                                                                                   
		  ,[AHU07_SB1F02] = 7                                                                                                                                                                                   
		  ,[AHU08_SB1F02] = 8                                                                                                                                                                                   
		  ,[AHU09_SB1F02] = 312                                                                                                                                                                                 
		  ,[AHU10_SB1F02] = 10                                                                                                                                                                                  
		  ,[AHU11_SB1F02] = 11                                                                                                                                                                                  

	--Chiller    
	UPDATE [dbo].[Chiller]
		SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()     
		  ,[Chiller01_R1] = 1
		  ,[Chiller02_R1] = 2
		  ,[Chiller03_R1] = 3
		  ,[Chiller04_R1] = 4
		  ,[Chiller05_R1] = 5
		  ,[Chiller06_R1] = 6
		  ,[Chiller07_R1] = 7
		  ,[Chiller08_R1] = 8
		  ,[Chiller09_R1] = 9
		  ,[Chiller10_R1] = 51
		  ,[Chiller01_R2] = 1 
		  ,[Chiller02_R2] = 2 
		  ,[Chiller03_R2] = 3 
		  ,[Chiller04_R2] = 4 
		  ,[Chiller05_R2] = 5 
		  ,[Chiller06_R2] = 6 
		  ,[Chiller07_R2] = 7 
		  ,[Chiller08_R2] = 8 
		  ,[Chiller09_R2] = 9 
		  ,[Chiller10_R2] = 52
		  ,[Chiller01_R3] = 1
		  ,[Chiller02_R3] = 2
		  ,[Chiller03_R3] = 3
		  ,[Chiller04_R3] = 4
		  ,[Chiller05_R3] = 5
		  ,[Chiller06_R3] = 6
		  ,[Chiller07_R3] = 7
		  ,[Chiller08_R3] = 8
		  ,[Chiller09_R3] = 9
		  ,[Chiller10_R3] = 53                     
		  ,[Chiller01_R6] = 1
		  ,[Chiller02_R6] = 2
		  ,[Chiller03_R6] = 3
		  ,[Chiller04_R6] = 4
		  ,[Chiller05_R6] = 5
		  ,[Chiller06_R6] = 6
		  ,[Chiller07_R6] = 7
		  ,[Chiller08_R6] = 8
		  ,[Chiller09_R6] = 9
		  ,[Chiller10_R6] = 54                

	--COP	  
	UPDATE [dbo].[COP]
		SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()     
		  ,[COP01_001] = 1
		  ,[COP02_001] = 2
		  ,[COP03_001] = 3
		  ,[COP04_001] = 4
		  ,[COP05_001] = 51
		  ,[COP01_002] = 1  
		  ,[COP02_002] = 2  
		  ,[COP03_002] = 3  
		  ,[COP04_002] = 4  
		  ,[COP05_002] = 52 
		  ,[COP01_003] = 1  
		  ,[COP02_003] = 2  
		  ,[COP03_003] = 3  
		  ,[COP04_003] = 4  
		  ,[COP05_003] = 53 
		  ,[COP01_006] = 1  
		  ,[COP02_006] = 2  
		  ,[COP03_006] = 3  
		  ,[COP04_006] = 4  
		  ,[COP05_006] = 56
		  ,[COP01_12S] = 1  
		  ,[COP02_12S] = 2  
		  ,[COP03_12S] = 3  
		  ,[COP04_12S] = 4  
		  ,[COP05_12S] = 412 
		  ,[COP01_03S] = 1  
		  ,[COP02_03S] = 2  
		  ,[COP03_03S] = 3  
		  ,[COP04_03S] = 4  
		  ,[COP05_03S] = 403 
		  ,[COP01_06S] = 1  
		  ,[COP02_06S] = 2  
		  ,[COP03_06S] = 3  
		  ,[COP04_06S] = 4  
		  ,[COP05_06S] = 406
		  
	--CP	  
	--UPDATE [dbo].[CP]		  
	--	SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
	--	  ,[DATETIME] = GETDATE()     
	--	  ,[CP01_01] = 1
	--	  ,[CP02_01] = 2
	--	  ,[CP03_01] = 3
	--	  ,[CP04_01] = 4
	--	  ,[CP05_01] = 5
	--	  ,[CP06_01] = 6
	--	  ,[CP07_01] = 61
	--	  ,[CP01_02] = 1 
	--	  ,[CP02_02] = 2 
	--	  ,[CP03_02] = 3 
	--	  ,[CP04_02] = 4 
	--	  ,[CP05_02] = 5 
	--	  ,[CP06_02] = 6 
	--	  ,[CP07_02] = 62
	--	  ,[CP01_03] = 1 
	--	  ,[CP02_03] = 2 
	--	  ,[CP03_03] = 3 
	--	  ,[CP04_03] = 4 
	--	  ,[CP05_03] = 5 
	--	  ,[CP06_03] = 6 
	--	  ,[CP07_03] = 63
	--	  ,[CP01_06] = 1 
	--	  ,[CP02_06] = 2 
	--	  ,[CP03_06] = 3 
	--	  ,[CP04_06] = 4 
	--	  ,[CP05_06] = 5 
	--	  ,[CP06_06] = 6 
	--	  ,[CP07_06] = 64
	--	  ,[CP01_0S] = 1 
	--	  ,[CP02_0S] = 2 
	--	  ,[CP03_0S] = 3 
	--	  ,[CP04_0S] = 4 
	--	  ,[CP05_0S] = 5 
	--	  ,[CP06_0S] = 6 
	--	  ,[CP07_0S] = 65	 
	UPDATE [dbo].[CP]		  
		SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()     
		  ,[CP01_01] = null
		  ,[CP02_01] = null
		  ,[CP03_01] = null
		  ,[CP04_01] = null
		  ,[CP05_01] = null
		  ,[CP06_01] = null
		  ,[CP07_01] = null
		  ,[CP01_02] = null
		  ,[CP02_02] = null
		  ,[CP03_02] = null
		  ,[CP04_02] = null
		  ,[CP05_02] = null
		  ,[CP06_02] = null
		  ,[CP07_02] = null
		  ,[CP01_03] = null
		  ,[CP02_03] = null
		  ,[CP03_03] = null
		  ,[CP04_03] = null
		  ,[CP05_03] = null
		  ,[CP06_03] = null
		  ,[CP07_03] = null
		  ,[CP01_06] = null
		  ,[CP02_06] = null
		  ,[CP03_06] = null
		  ,[CP04_06] = null
		  ,[CP05_06] = null
		  ,[CP06_06] = null
		  ,[CP07_06] = null
		  ,[CP01_0S] = null
		  ,[CP02_0S] = null
		  ,[CP03_0S] = null
		  ,[CP04_0S] = null
		  ,[CP05_0S] = null
		  ,[CP06_0S] = null
		  ,[CP07_0S] = null		        
END
GO
USE [master]
GO
ALTER DATABASE [TP_B3] SET  READ_WRITE 
GO
