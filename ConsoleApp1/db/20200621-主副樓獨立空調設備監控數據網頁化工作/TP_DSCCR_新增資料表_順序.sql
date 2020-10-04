USE [TP_DSCCR]
GO
/****** Object:  Table [dbo].[MSPCAI]    Script Date: 2020/10/4 下午 12:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MSPCAI](
	[SID] [int] NOT NULL,
	[CDATE] [datetime] NOT NULL,
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[LOCATION] [varchar](50) NOT NULL,
	[DEVICE_ID] [varchar](50) NOT NULL,
	[WATER_TOWER] [varchar](50) NOT NULL,
	[SEF16] [real] NULL,
	[SEF17] [real] NULL,
	[SEF18] [real] NULL,
 CONSTRAINT [PK_MSPCAI] PRIMARY KEY CLUSTERED 
(
	[SID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MSPCALARS]    Script Date: 2020/10/4 下午 12:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MSPCALARS](
	[SID] [int] NOT NULL,
	[CDATE] [datetime] NOT NULL,
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[LOCATION] [varchar](50) NOT NULL,
	[DEVICE_ID] [varchar](50) NOT NULL,
	[WATER_TOWER] [varchar](50) NOT NULL,
	[SEF09] [real] NULL,
	[SEF10] [real] NULL,
	[SEF11] [real] NULL,
	[SEF12] [real] NULL,
	[SEF13] [real] NULL,
	[SEF14] [real] NULL,
	[SEF15] [real] NULL,
 CONSTRAINT [PK_MSPCALARS] PRIMARY KEY CLUSTERED 
(
	[SID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MSPCSTATS]    Script Date: 2020/10/4 下午 12:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MSPCSTATS](
	[SID] [int] NOT NULL,
	[CDATE] [datetime] NOT NULL,
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[LOCATION] [varchar](50) NOT NULL,
	[DEVICE_ID] [varchar](50) NOT NULL,
	[WATER_TOWER] [varchar](50) NOT NULL,
	[SEF01] [real] NULL,
	[SEF02] [real] NULL,
	[SEF03] [real] NULL,
	[SEF04] [real] NULL,
	[SEF05] [real] NULL,
	[SEF06] [real] NULL,
	[SEF07] [real] NULL,
	[SEF08] [real] NULL,
 CONSTRAINT [PK_MSPCSTATS] PRIMARY KEY CLUSTERED 
(
	[SID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MSPCAI_CDATE_LOCATION_DEVICEID]    Script Date: 2020/10/4 下午 12:15:06 ******/
CREATE NONCLUSTERED INDEX [IX_MSPCAI_CDATE_LOCATION_DEVICEID] ON [dbo].[MSPCAI]
(
	[CDATE] DESC,
	[LOCATION] ASC,
	[DEVICE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MSPCALARS_CDATE_LOCATION_DEVICEID]    Script Date: 2020/10/4 下午 12:15:06 ******/
CREATE NONCLUSTERED INDEX [IX_MSPCALARS_CDATE_LOCATION_DEVICEID] ON [dbo].[MSPCALARS]
(
	[CDATE] DESC,
	[LOCATION] ASC,
	[DEVICE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MSPCSTATS_CDATE_LOCATION_DEVICEID]    Script Date: 2020/10/4 下午 12:15:06 ******/
CREATE NONCLUSTERED INDEX [IX_MSPCSTATS_CDATE_LOCATION_DEVICEID] ON [dbo].[MSPCSTATS]
(
	[CDATE] DESC,
	[LOCATION] ASC,
	[DEVICE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MSPCAI] ADD  CONSTRAINT [DF_MSPCAI_CDATE]  DEFAULT (getdate()) FOR [CDATE]
GO
ALTER TABLE [dbo].[MSPCALARS] ADD  CONSTRAINT [DF_MSPCALARS_CDATE]  DEFAULT (getdate()) FOR [CDATE]
GO
ALTER TABLE [dbo].[MSPCSTATS] ADD  CONSTRAINT [DF_MSPCSTATS_CDATE]  DEFAULT (getdate()) FOR [CDATE]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MSPCAI', @level2type=N'COLUMN',@level2name=N'SID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reliable Controls 產生資料時的序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MSPCAI', @level2type=N'COLUMN',@level2name=N'AUTOID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'資料產生時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MSPCAI', @level2type=N'COLUMN',@level2name=N'DATETIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'空調箱所在位置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MSPCAI', @level2type=N'COLUMN',@level2name=N'LOCATION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'偵測器編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MSPCAI', @level2type=N'COLUMN',@level2name=N'DEVICE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MSPCALARS', @level2type=N'COLUMN',@level2name=N'SID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reliable Controls 產生資料時的序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MSPCALARS', @level2type=N'COLUMN',@level2name=N'AUTOID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'資料產生時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MSPCALARS', @level2type=N'COLUMN',@level2name=N'DATETIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'空調箱所在位置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MSPCALARS', @level2type=N'COLUMN',@level2name=N'LOCATION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'偵測器編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MSPCALARS', @level2type=N'COLUMN',@level2name=N'DEVICE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MSPCSTATS', @level2type=N'COLUMN',@level2name=N'SID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reliable Controls 產生資料時的序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MSPCSTATS', @level2type=N'COLUMN',@level2name=N'AUTOID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'資料產生時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MSPCSTATS', @level2type=N'COLUMN',@level2name=N'DATETIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'空調箱所在位置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MSPCSTATS', @level2type=N'COLUMN',@level2name=N'LOCATION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'偵測器編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MSPCSTATS', @level2type=N'COLUMN',@level2name=N'DEVICE_ID'
GO




CREATE SEQUENCE [dbo].[MSPCSTATS_SEQ] 
 AS [int]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CYCLE 
 NO CACHE 
GO

CREATE SEQUENCE [dbo].[MSPCALARS_SEQ] 
 AS [int]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CYCLE 
 NO CACHE 
GO

CREATE SEQUENCE [dbo].[MSPCAI_SEQ] 
 AS [int]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CYCLE 
 NO CACHE 
GO
