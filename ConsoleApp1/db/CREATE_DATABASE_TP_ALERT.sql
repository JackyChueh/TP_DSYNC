USE [master]
GO
/****** Object:  Database [TP_ALERT]    Script Date: 2020/8/6 下午 09:02:24 ******/
CREATE DATABASE [TP_ALERT]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TP_ALERT', FILENAME = N'E:\DATA\TP_ALERT.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TP_ALERT_log', FILENAME = N'E:\DATA\TP_ALERT_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TP_ALERT] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TP_ALERT].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TP_ALERT] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TP_ALERT] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TP_ALERT] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TP_ALERT] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TP_ALERT] SET ARITHABORT OFF 
GO
ALTER DATABASE [TP_ALERT] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TP_ALERT] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TP_ALERT] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TP_ALERT] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TP_ALERT] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TP_ALERT] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TP_ALERT] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TP_ALERT] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TP_ALERT] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TP_ALERT] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TP_ALERT] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TP_ALERT] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TP_ALERT] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TP_ALERT] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TP_ALERT] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TP_ALERT] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TP_ALERT] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TP_ALERT] SET RECOVERY FULL 
GO
ALTER DATABASE [TP_ALERT] SET  MULTI_USER 
GO
ALTER DATABASE [TP_ALERT] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TP_ALERT] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TP_ALERT] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TP_ALERT] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TP_ALERT] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TP_ALERT', N'ON'
GO
ALTER DATABASE [TP_ALERT] SET QUERY_STORE = OFF
GO
USE [TP_ALERT]
GO
/****** Object:  Table [dbo].[ALERT_CONFIG]    Script Date: 2020/8/6 下午 09:02:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ALERT_CONFIG](
	[SID] [int] NOT NULL,
	[DATA_TYPE] [varchar](50) NOT NULL,
	[LOCATION] [varchar](4) NOT NULL,
	[DEVICE_ID] [varchar](4) NOT NULL,
	[DATA_FIELD] [varchar](50) NOT NULL,
	[MAX_VALUE] [real] NOT NULL,
	[MIN_VALUE] [real] NOT NULL,
	[CHECK_INTERVAL] [int] NOT NULL,
	[ALERT_INTERVAL] [int] NOT NULL,
	[SUN] [bit] NOT NULL,
	[SUN_STIME] [time](0) NOT NULL,
	[SUN_ETIME] [time](0) NOT NULL,
	[MON] [bit] NOT NULL,
	[MON_STIME] [time](0) NOT NULL,
	[MON_ETIME] [time](0) NOT NULL,
	[TUE] [bit] NOT NULL,
	[TUE_STIME] [time](0) NOT NULL,
	[TUE_ETIME] [time](0) NOT NULL,
	[WED] [bit] NOT NULL,
	[WED_STIME] [time](0) NOT NULL,
	[WED_ETIME] [time](0) NOT NULL,
	[THU] [bit] NOT NULL,
	[THU_STIME] [time](0) NOT NULL,
	[THU_ETIME] [time](0) NOT NULL,
	[FRI] [bit] NOT NULL,
	[FRI_STIME] [time](0) NOT NULL,
	[FRI_ETIME] [time](0) NOT NULL,
	[STA] [bit] NOT NULL,
	[STA_STIME] [time](0) NOT NULL,
	[STA_ETIME] [time](0) NOT NULL,
	[CHECK_DATE] [smalldatetime] NOT NULL,
	[ALERT_DATE] [smalldatetime] NOT NULL,
	[MAIL_TO] [varchar](8000) NULL,
	[MODE] [bit] NOT NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [TP_ALERT] SET  READ_WRITE 
GO
