USE [master]
GO
/****** Object:  Database [TP_DSCCR]    Script Date: 2019/11/8 下午 11:22:13 ******/
CREATE DATABASE [TP_DSCCR]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TP-DSCCR', FILENAME = N'D:\DATA\TP-DSCCR.mdf' , SIZE = 65536KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TP-DSCCR_log', FILENAME = N'D:\DATA\TP-DSCCR_log.ldf' , SIZE = 65536KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TP_DSCCR] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TP_DSCCR].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TP_DSCCR] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TP_DSCCR] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TP_DSCCR] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TP_DSCCR] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TP_DSCCR] SET ARITHABORT OFF 
GO
ALTER DATABASE [TP_DSCCR] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TP_DSCCR] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TP_DSCCR] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TP_DSCCR] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TP_DSCCR] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TP_DSCCR] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TP_DSCCR] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TP_DSCCR] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TP_DSCCR] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TP_DSCCR] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TP_DSCCR] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TP_DSCCR] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TP_DSCCR] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TP_DSCCR] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TP_DSCCR] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TP_DSCCR] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TP_DSCCR] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TP_DSCCR] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TP_DSCCR] SET RECOVERY FULL 
GO
ALTER DATABASE [TP_DSCCR] SET  MULTI_USER 
GO
ALTER DATABASE [TP_DSCCR] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TP_DSCCR] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TP_DSCCR] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TP_DSCCR] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
USE [TP_DSCCR]
GO
USE [TP_DSCCR]
GO
/****** Object:  Sequence [dbo].[AHU_SEQ]    Script Date: 2019/11/8 下午 11:22:13 ******/
CREATE SEQUENCE [dbo].[AHU_SEQ] 
 AS [int]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CYCLE 
 NO CACHE 
GO
USE [TP_DSCCR]
GO
/****** Object:  Sequence [dbo].[Chiller_SEQ]    Script Date: 2019/11/8 下午 11:22:13 ******/
CREATE SEQUENCE [dbo].[Chiller_SEQ] 
 AS [int]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CYCLE 
 NO CACHE 
GO
USE [TP_DSCCR]
GO
/****** Object:  Sequence [dbo].[COP_SEQ]    Script Date: 2019/11/8 下午 11:22:13 ******/
CREATE SEQUENCE [dbo].[COP_SEQ] 
 AS [int]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CYCLE 
 NO CACHE 
GO
USE [TP_DSCCR]
GO
/****** Object:  Sequence [dbo].[CP_SEQ]    Script Date: 2019/11/8 下午 11:22:13 ******/
CREATE SEQUENCE [dbo].[CP_SEQ] 
 AS [int]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CYCLE 
 NO CACHE 
GO
USE [TP_DSCCR]
GO
/****** Object:  Sequence [dbo].[CT_SEQ]    Script Date: 2019/11/8 下午 11:22:13 ******/
CREATE SEQUENCE [dbo].[CT_SEQ] 
 AS [int]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CYCLE 
 NO CACHE 
GO
USE [TP_DSCCR]
GO
/****** Object:  Sequence [dbo].[RRS_PVOI_SEQ]    Script Date: 2019/11/8 下午 11:22:13 ******/
CREATE SEQUENCE [dbo].[RRS_PVOI_SEQ] 
 AS [int]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CYCLE 
 NO CACHE 
GO
USE [TP_DSCCR]
GO
/****** Object:  Sequence [dbo].[RRS_PWLS_SEQ]    Script Date: 2019/11/8 下午 11:22:13 ******/
CREATE SEQUENCE [dbo].[RRS_PWLS_SEQ] 
 AS [int]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CYCLE 
 NO CACHE 
GO
USE [TP_DSCCR]
GO
/****** Object:  Sequence [dbo].[RRS_VFLH_SEQ]    Script Date: 2019/11/8 下午 11:22:13 ******/
CREATE SEQUENCE [dbo].[RRS_VFLH_SEQ] 
 AS [int]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CYCLE 
 NO CACHE 
GO
USE [TP_DSCCR]
GO
/****** Object:  Sequence [dbo].[WSDS_PVOI_SEQ]    Script Date: 2019/11/8 下午 11:22:13 ******/
CREATE SEQUENCE [dbo].[WSDS_PVOI_SEQ] 
 AS [int]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CYCLE 
 NO CACHE 
GO
USE [TP_DSCCR]
GO
/****** Object:  Sequence [dbo].[WSDS_PWLS_SEQ]    Script Date: 2019/11/8 下午 11:22:13 ******/
CREATE SEQUENCE [dbo].[WSDS_PWLS_SEQ] 
 AS [int]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CYCLE 
 NO CACHE 
GO
USE [TP_DSCCR]
GO
/****** Object:  Sequence [dbo].[ZP1_SEQ]    Script Date: 2019/11/8 下午 11:22:13 ******/
CREATE SEQUENCE [dbo].[ZP1_SEQ] 
 AS [int]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CYCLE 
 NO CACHE 
GO
/****** Object:  Table [dbo].[AHU]    Script Date: 2019/11/8 下午 11:22:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AHU](
	[SID] [int] NOT NULL,
	[CDATE] [datetime] NOT NULL,
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[LOCATION] [varchar](4) NOT NULL,
	[DEVICE_ID] [varchar](4) NOT NULL,
	[AHU01] [real] NULL,
	[AHU02] [real] NULL,
	[AHU03] [real] NULL,
	[AHU04] [real] NULL,
	[AHU05] [real] NULL,
	[AHU06] [real] NULL,
	[AHU07] [real] NULL,
	[AHU08] [real] NULL,
	[AHU09] [real] NULL,
	[AHU10] [real] NULL,
	[AHU11] [real] NULL,
 CONSTRAINT [PK_AHU] PRIMARY KEY CLUSTERED 
(
	[SID] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Chiller]    Script Date: 2019/11/8 下午 11:22:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Chiller](
	[SID] [int] NOT NULL,
	[CDATE] [datetime] NOT NULL,
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[LOCATION] [varchar](4) NOT NULL,
	[DEVICE_ID] [varchar](4) NOT NULL,
	[Chiller01] [real] NULL,
	[Chiller02] [real] NULL,
	[Chiller03] [real] NULL,
	[Chiller04] [real] NULL,
	[Chiller05] [real] NULL,
	[Chiller06] [real] NULL,
	[Chiller07] [real] NULL,
	[Chiller08] [real] NULL,
	[Chiller09] [real] NULL,
	[Chiller10] [real] NULL,
 CONSTRAINT [PK_Chiller] PRIMARY KEY CLUSTERED 
(
	[SID] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[COP]    Script Date: 2019/11/8 下午 11:22:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COP](
	[SID] [int] NOT NULL,
	[CDATE] [datetime] NOT NULL,
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[LOCATION] [varchar](4) NOT NULL,
	[DEVICE_ID] [varchar](4) NOT NULL,
	[COP01] [real] NULL,
	[COP02] [real] NULL,
	[COP03] [real] NULL,
	[COP04] [real] NULL,
	[COP05] [real] NULL,
 CONSTRAINT [PK_COP] PRIMARY KEY CLUSTERED 
(
	[SID] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CP]    Script Date: 2019/11/8 下午 11:22:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CP](
	[SID] [int] NOT NULL,
	[CDATE] [datetime] NOT NULL,
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[LOCATION] [varchar](4) NOT NULL,
	[DEVICE_ID] [varchar](4) NOT NULL,
	[CP01] [real] NULL,
	[CP02] [real] NULL,
	[CP03] [real] NULL,
	[CP04] [real] NULL,
	[CP05] [real] NULL,
	[CP06] [real] NULL,
	[CP07] [real] NULL,
 CONSTRAINT [PK_CP] PRIMARY KEY CLUSTERED 
(
	[SID] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CT]    Script Date: 2019/11/8 下午 11:22:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CT](
	[SID] [int] NOT NULL,
	[CDATE] [datetime] NOT NULL,
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[LOCATION] [varchar](4) NOT NULL,
	[DEVICE_ID] [varchar](4) NOT NULL,
	[CT01] [real] NULL,
	[CT02] [real] NULL,
	[CT03] [real] NULL,
	[CT04] [real] NULL,
	[CT05] [real] NULL,
	[CT06] [real] NULL,
	[CT07] [real] NULL,
 CONSTRAINT [PK_CT] PRIMARY KEY CLUSTERED 
(
	[SID] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RRS_PVOI]    Script Date: 2019/11/8 下午 11:22:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RRS_PVOI](
	[SID] [int] NOT NULL,
	[CDATE] [datetime] NOT NULL,
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[LOCATION] [varchar](4) NOT NULL,
	[DEVICE_ID] [varchar](4) NOT NULL,
	[RRS01_PVOI01] [real] NULL,
	[RRS02_PVOI01] [real] NULL,
	[RRS03_PVOI01] [real] NULL,
	[RRS04_PVOI01] [real] NULL,
	[RRS05_PVOI01] [real] NULL,
	[RRS06_PVOI01] [real] NULL,
	[RRS07_PVOI01] [real] NULL,
 CONSTRAINT [PK_RRS_PVOI] PRIMARY KEY CLUSTERED 
(
	[SID] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RRS_PWLS]    Script Date: 2019/11/8 下午 11:22:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RRS_PWLS](
	[SID] [int] NOT NULL,
	[CDATE] [datetime] NOT NULL,
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[LOCATION] [varchar](4) NOT NULL,
	[DEVICE_ID] [varchar](4) NOT NULL,
	[RRS01_PWLS01] [real] NULL,
	[RRS02_PWLS01] [real] NULL,
	[RRS03_PWLS01] [real] NULL,
	[RRS04_PWLS01] [real] NULL,
	[RRS05_PWLS01] [real] NULL,
	[RRS06_PWLS01] [real] NULL,
	[RRS07_PWLS01] [real] NULL,
	[RRS08_PWLS01] [real] NULL,
	[RRS09_PWLS01] [real] NULL,
	[RRS10_PWLS01] [real] NULL,
	[RRS11_PWLS01] [real] NULL,
	[RRS12_PWLS01] [real] NULL,
	[RRS13_PWLS01] [real] NULL,
 CONSTRAINT [PK_RRS_PWLS] PRIMARY KEY CLUSTERED 
(
	[SID] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RRS_VFLH]    Script Date: 2019/11/8 下午 11:22:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RRS_VFLH](
	[SID] [int] NOT NULL,
	[CDATE] [datetime] NOT NULL,
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[LOCATION] [varchar](4) NOT NULL,
	[DEVICE_ID] [varchar](4) NOT NULL,
	[RRS01_VFLH01] [real] NULL,
	[RRS02_VFLH01] [real] NULL,
	[RRS03_VFLH01] [real] NULL,
	[RRS04_VFLH01] [real] NULL,
	[RRS05_VFLH01] [real] NULL,
	[RRS06_VFLH01] [real] NULL,
 CONSTRAINT [PK_RRS_VFLH] PRIMARY KEY CLUSTERED 
(
	[SID] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WSDS_PVOI]    Script Date: 2019/11/8 下午 11:22:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WSDS_PVOI](
	[SID] [int] NOT NULL,
	[CDATE] [datetime] NOT NULL,
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[LOCATION] [varchar](4) NOT NULL,
	[DEVICE_ID] [varchar](4) NOT NULL,
	[WSDS_PVOI_STATUS] [real] NULL,
 CONSTRAINT [PK_WSDS_PVOI] PRIMARY KEY CLUSTERED 
(
	[SID] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WSDS_PWLS]    Script Date: 2019/11/8 下午 11:22:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WSDS_PWLS](
	[SID] [int] NOT NULL,
	[CDATE] [datetime] NOT NULL,
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[LOCATION] [varchar](4) NOT NULL,
	[DEVICE_ID] [varchar](4) NOT NULL,
	[WSDS_PWLS_STATUS] [real] NULL,
 CONSTRAINT [PK_WSDS_PWLS] PRIMARY KEY CLUSTERED 
(
	[SID] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ZP1]    Script Date: 2019/11/8 下午 11:22:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ZP1](
	[SID] [int] NOT NULL,
	[CDATE] [datetime] NOT NULL,
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[LOCATION] [varchar](4) NOT NULL,
	[DEVICE_ID] [varchar](4) NOT NULL,
	[ZP101] [real] NULL,
	[ZP102] [real] NULL,
	[ZP104] [real] NULL,
	[ZP105] [real] NULL,
	[ZP106] [real] NULL,
	[ZP107] [real] NULL,
	[ZP108] [real] NULL,
	[ZP109] [real] NULL,
	[ZP110] [real] NULL,
	[ZP111] [real] NULL,
 CONSTRAINT [PK_ZP1] PRIMARY KEY CLUSTERED 
(
	[SID] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AHU_CDATE_LOCATION_DEVICEID]    Script Date: 2019/11/8 下午 11:22:13 ******/
CREATE NONCLUSTERED INDEX [IX_AHU_CDATE_LOCATION_DEVICEID] ON [dbo].[AHU]
(
	[CDATE] DESC,
	[LOCATION] ASC,
	[DEVICE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Chiller_CDATE_LOCATION_DEVICEID]    Script Date: 2019/11/8 下午 11:22:13 ******/
CREATE NONCLUSTERED INDEX [IX_Chiller_CDATE_LOCATION_DEVICEID] ON [dbo].[Chiller]
(
	[CDATE] DESC,
	[LOCATION] ASC,
	[DEVICE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_COP_CDATE_LOCATION_DEVICEID]    Script Date: 2019/11/8 下午 11:22:13 ******/
CREATE NONCLUSTERED INDEX [IX_COP_CDATE_LOCATION_DEVICEID] ON [dbo].[COP]
(
	[CDATE] DESC,
	[LOCATION] ASC,
	[DEVICE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_CP_CDATE_LOCATION_DEVICEID]    Script Date: 2019/11/8 下午 11:22:13 ******/
CREATE NONCLUSTERED INDEX [IX_CP_CDATE_LOCATION_DEVICEID] ON [dbo].[CP]
(
	[CDATE] DESC,
	[LOCATION] ASC,
	[DEVICE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_CT_CDATE_LOCATION_DEVICEID]    Script Date: 2019/11/8 下午 11:22:13 ******/
CREATE NONCLUSTERED INDEX [IX_CT_CDATE_LOCATION_DEVICEID] ON [dbo].[CT]
(
	[CDATE] DESC,
	[LOCATION] ASC,
	[DEVICE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AHU] ADD  CONSTRAINT [DF_AHU_CDATE]  DEFAULT (getdate()) FOR [CDATE]
GO
ALTER TABLE [dbo].[Chiller] ADD  CONSTRAINT [DF_Chiller_CDATE]  DEFAULT (getdate()) FOR [CDATE]
GO
ALTER TABLE [dbo].[COP] ADD  CONSTRAINT [DF_COP_CDATE]  DEFAULT (getdate()) FOR [CDATE]
GO
ALTER TABLE [dbo].[CP] ADD  CONSTRAINT [DF_CP_CDATE]  DEFAULT (getdate()) FOR [CDATE]
GO
ALTER TABLE [dbo].[CT] ADD  CONSTRAINT [DF_CT_CDATE]  DEFAULT (getdate()) FOR [CDATE]
GO
ALTER TABLE [dbo].[RRS_PVOI] ADD  CONSTRAINT [DF_RRS_PVOI_CDATE]  DEFAULT (getdate()) FOR [CDATE]
GO
ALTER TABLE [dbo].[RRS_PWLS] ADD  CONSTRAINT [DF_RRS_PWLS_CDATE]  DEFAULT (getdate()) FOR [CDATE]
GO
ALTER TABLE [dbo].[RRS_VFLH] ADD  CONSTRAINT [DF_RRS_VFLH_CDATE]  DEFAULT (getdate()) FOR [CDATE]
GO
ALTER TABLE [dbo].[WSDS_PVOI] ADD  CONSTRAINT [DF_WSDS_PVOI_CDATE]  DEFAULT (getdate()) FOR [CDATE]
GO
ALTER TABLE [dbo].[WSDS_PWLS] ADD  CONSTRAINT [DF_WSDS_PWLS_CDATE]  DEFAULT (getdate()) FOR [CDATE]
GO
ALTER TABLE [dbo].[ZP1] ADD  CONSTRAINT [DF_ZP1_CDATE]  DEFAULT (getdate()) FOR [CDATE]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AHU', @level2type=N'COLUMN',@level2name=N'SID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reliable Controls 產生資料時的序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AHU', @level2type=N'COLUMN',@level2name=N'AUTOID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'資料產生時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AHU', @level2type=N'COLUMN',@level2name=N'DATETIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'空調箱所在位置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AHU', @level2type=N'COLUMN',@level2name=N'LOCATION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'偵測器編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AHU', @level2type=N'COLUMN',@level2name=N'DEVICE_ID'
GO
USE [master]
GO
ALTER DATABASE [TP_DSCCR] SET  READ_WRITE 
GO
