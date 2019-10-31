USE [master]
GO
/****** Object:  Database [TP_B3]    Script Date: 2019/10/31 下午 11:44:19 ******/
CREATE DATABASE [TP_B3]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TP_B3', FILENAME = N'D:\DATA\TP_B3.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TP_B3_log', FILENAME = N'D:\DATA\TP_B3_log.ldf' , SIZE = 65536KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TP_B3] SET COMPATIBILITY_LEVEL = 110
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
ALTER DATABASE [TP_B3] SET AUTO_CREATE_STATISTICS ON 
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
EXEC sys.sp_db_vardecimal_storage_format N'TP_B3', N'ON'
GO
USE [TP_B3]
GO
/****** Object:  StoredProcedure [dbo].[TimerUpdateAHU]    Script Date: 2019/10/31 下午 11:44:19 ******/
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
	/*
INSERT INTO [dbo].[AHU_04F]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[AHU_0B1]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[AHU_0RF]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[AHU_14F]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[AHU_S03]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[AHU_SB1]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[Chiller]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[COP]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[CP]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[CT]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[ZP]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[RRS_PVOI]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[RRS_PWLS]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[RRS_VFLH]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[WSDS_PVOI]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[WSDS_PWLS]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
	*/
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

	--CP	  
	UPDATE [dbo].[CP]		  
		SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()     
		  ,[CP01_01] = ROUND(RAND() * 1, 0)
		  ,[CP02_01] = ROUND(RAND() * 1, 0)
		  ,[CP03_01] = ROUND(RAND() * 1, 0)
		  ,[CP04_01] = ROUND(RAND() * 1, 0)
		  ,[CP05_01] = ROUND(RAND() * 1, 0)
		  ,[CP06_01] = ROUND(RAND() * 1, 0)
		  ,[CP07_01] = 61
		  ,[CP01_02] = ROUND(RAND() * 1, 0) 
		  ,[CP02_02] = ROUND(RAND() * 1, 0) 
		  ,[CP03_02] = ROUND(RAND() * 1, 0) 
		  ,[CP04_02] = ROUND(RAND() * 1, 0) 
		  ,[CP05_02] = ROUND(RAND() * 1, 0) 
		  ,[CP06_02] = ROUND(RAND() * 1, 0) 
		  ,[CP07_02] = 62
		  ,[CP01_03] = ROUND(RAND() * 1, 0) 
		  ,[CP02_03] = ROUND(RAND() * 1, 0) 
		  ,[CP03_03] = ROUND(RAND() * 1, 0) 
		  ,[CP04_03] = ROUND(RAND() * 1, 0) 
		  ,[CP05_03] = ROUND(RAND() * 1, 0) 
		  ,[CP06_03] = ROUND(RAND() * 1, 0) 
		  ,[CP07_03] = 63
		  ,[CP01_06] = ROUND(RAND() * 1, 0) 
		  ,[CP02_06] = ROUND(RAND() * 1, 0) 
		  ,[CP03_06] = ROUND(RAND() * 1, 0) 
		  ,[CP04_06] = ROUND(RAND() * 1, 0) 
		  ,[CP05_06] = ROUND(RAND() * 1, 0) 
		  ,[CP06_06] = ROUND(RAND() * 1, 0) 
		  ,[CP07_06] = 66
		  ,[CP01_0S] = ROUND(RAND() * 1, 0) 
		  ,[CP02_0S] = ROUND(RAND() * 1, 0) 
		  ,[CP03_0S] = ROUND(RAND() * 1, 0) 
		  ,[CP04_0S] = ROUND(RAND() * 1, 0) 
		  ,[CP05_0S] = ROUND(RAND() * 1, 0) 
		  ,[CP06_0S] = ROUND(RAND() * 1, 0) 
		  ,[CP07_0S] = 69	     
	
	--CT
	UPDATE [dbo].[CT]
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()     
		  ,[CT01_01] = ROUND(RAND() * 1, 0)
		  ,[CT02_01] = ROUND(RAND() * 1, 0)
		  ,[CT03_01] = ROUND(RAND() * 1, 0)
		  ,[CT04_01] = ROUND(RAND() * 1, 0)
		  ,[CT05_01] = ROUND(RAND() * 1, 0)
		  ,[CT06_01] = ROUND(RAND() * 1, 0)
		  ,[CT07_01] = ROUND(RAND() * 1, 0)
		  ,[CT01_02] = ROUND(RAND() * 1, 0)
		  ,[CT02_02] = ROUND(RAND() * 1, 0)
		  ,[CT03_02] = ROUND(RAND() * 1, 0)
		  ,[CT04_02] = ROUND(RAND() * 1, 0)
		  ,[CT05_02] = ROUND(RAND() * 1, 0)
		  ,[CT06_02] = ROUND(RAND() * 1, 0)
		  ,[CT07_02] = ROUND(RAND() * 1, 0)
		  ,[CT01_03] = ROUND(RAND() * 1, 0)
		  ,[CT02_03] = ROUND(RAND() * 1, 0)
		  ,[CT03_03] = ROUND(RAND() * 1, 0)
		  ,[CT04_03] = ROUND(RAND() * 1, 0)
		  ,[CT05_03] = ROUND(RAND() * 1, 0)
		  ,[CT06_03] = ROUND(RAND() * 1, 0)
		  ,[CT07_03] = ROUND(RAND() * 1, 0)
		  ,[CT01_04] = ROUND(RAND() * 1, 0)
		  ,[CT02_04] = ROUND(RAND() * 1, 0)
		  ,[CT03_04] = ROUND(RAND() * 1, 0)
		  ,[CT04_04] = ROUND(RAND() * 1, 0)
		  ,[CT05_04] = ROUND(RAND() * 1, 0)
		  ,[CT06_04] = ROUND(RAND() * 1, 0)
		  ,[CT07_04] = ROUND(RAND() * 1, 0)
		  ,[CT01_05] = ROUND(RAND() * 1, 0)
		  ,[CT02_05] = ROUND(RAND() * 1, 0)
		  ,[CT03_05] = ROUND(RAND() * 1, 0)
		  ,[CT04_05] = ROUND(RAND() * 1, 0)
		  ,[CT05_05] = ROUND(RAND() * 1, 0)
		  ,[CT06_05] = ROUND(RAND() * 1, 0)
		  ,[CT07_05] = ROUND(RAND() * 1, 0)
		  ,[CT01_06] = ROUND(RAND() * 1, 0)
		  ,[CT02_06] = ROUND(RAND() * 1, 0)
		  ,[CT03_06] = ROUND(RAND() * 1, 0)
		  ,[CT04_06] = ROUND(RAND() * 1, 0)
		  ,[CT05_06] = ROUND(RAND() * 1, 0)
		  ,[CT06_06] = ROUND(RAND() * 1, 0)
		  ,[CT07_06] = ROUND(RAND() * 1, 0)

	--ZP  
	UPDATE [dbo].[ZP]
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()     
		  ,[ZP01_00] = ROUND(RAND() * 40, 4)+300
		  ,[ZP02_00] = ROUND(RAND() * 10, 4)
		  ,[ZP03_00] = ROUND(RAND() * 1, 0)
		  ,[ZP04_00] = ROUND(RAND() * 5, 0)+18
		  ,[ZP05_00] = ROUND(RAND() * 5, 0)+14
		  ,[ZP06_00] = ROUND(RAND() * 1, 0)
		  ,[ZP01_01] = ROUND(RAND() * 40, 4)+300
		  ,[ZP02_01] = ROUND(RAND() * 10, 4)    
		  ,[ZP03_01] = ROUND(RAND() * 1, 0)     
		  ,[ZP04_01] = ROUND(RAND() * 5, 0)+18  
		  ,[ZP05_01] = ROUND(RAND() * 5, 0)+14  
		  ,[ZP06_01] = ROUND(RAND() * 1, 0)     
		  ,[ZP01_02] = ROUND(RAND() * 40, 4)+300
		  ,[ZP02_02] = ROUND(RAND() * 10, 4)    
		  ,[ZP03_02] = ROUND(RAND() * 1, 0)     
		  ,[ZP04_02] = ROUND(RAND() * 5, 0)+18  
		  ,[ZP05_02] = ROUND(RAND() * 5, 0)+14  
		  ,[ZP06_02] = ROUND(RAND() * 1, 0)     

	--RRS_VFLH
	UPDATE [dbo].[RRS_VFLH]
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()     
		  ,[RRS01_VFLH01] = 11
		  ,[RRS02_VFLH01] = 21
		  ,[RRS03_VFLH01] = 31
		  ,[RRS04_VFLH01] = 41
		  ,[RRS05_VFLH01] = 51
		  ,[RRS06_VFLH01] = 61

	--RRS_PVOI
	UPDATE [dbo].[RRS_PVOI]
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()     
		  ,[RRS01_PVOI01] = 11
		  ,[RRS02_PVOI01] = 21
		  ,[RRS03_PVOI01] = 31
		  ,[RRS04_PVOI01] = 41
		  ,[RRS05_PVOI01] = 51
		  ,[RRS06_PVOI01] = 61
		  ,[RRS07_PVOI01] = 71

	--RRS_PWLS
	UPDATE [dbo].[RRS_PWLS]
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()     
		  ,[RRS01_PWLS01] = 11
		  ,[RRS02_PWLS01] = 21
		  ,[RRS03_PWLS01] = 31
		  ,[RRS04_PWLS01] = 41
		  ,[RRS05_PWLS01] = 51
		  ,[RRS06_PWLS01] = 61
		  ,[RRS07_PWLS01] = 71
		  ,[RRS08_PWLS01] = 81
		  ,[RRS09_PWLS01] = 91
		  ,[RRS10_PWLS01] = 101
		  ,[RRS11_PWLS01] = 111
		  ,[RRS12_PWLS01] = 121
		  ,[RRS13_PWLS01] = 131
		  
	--WSDS_PVOI
	UPDATE [dbo].[WSDS_PVOI]
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()     
			,[WSDS01_PVOI01]=11
			,[WSDS02_PVOI01]=21
			,[WSDS03_PVOI01]=31
			,[WSDS04_PVOI01]=41
			,[WSDS05_PVOI01]=51
			,[WSDS06_PVOI01]=61
			,[WSDS07_PVOI01]=71
			,[WSDS08_PVOI01]=81
			,[WSDS09_PVOI01]=91
			,[WSDS10_PVOI01]=101
			,[WSDS11_PVOI01]=111
			,[WSDS12_PVOI01]=121
			,[WSDS13_PVOI01]=131
			,[WSDS14_PVOI01]=141
			,[WSDS15_PVOI01]=151
			,[WSDS16_PVOI01]=161
			,[WSDS17_PVOI01]=171
			,[WSDS18_PVOI01]=181
			,[WSDS19_PVOI01]=191
			,[WSDS20_PVOI01]=201
			,[WSDS21_PVOI01]=211
			,[WSDS22_PVOI01]=221
			,[WSDS23_PVOI01]=231
			,[WSDS24_PVOI01]=241
			,[WSDS25_PVOI01]=251
			,[WSDS26_PVOI01]=261


	--WSDS_PWLS
	UPDATE [dbo].[WSDS_PWLS]
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()   
			,[WSDS01_PWLS01]=11
			,[WSDS02_PWLS01]=21
			,[WSDS03_PWLS01]=31
			,[WSDS04_PWLS01]=41
			,[WSDS05_PWLS01]=51
			,[WSDS06_PWLS01]=61
			,[WSDS07_PWLS01]=71
			,[WSDS08_PWLS01]=81
			,[WSDS09_PWLS01]=91
			,[WSDS10_PWLS01]=101
			,[WSDS11_PWLS01]=111
			,[WSDS12_PWLS01]=121
			,[WSDS13_PWLS01]=131
			,[WSDS14_PWLS01]=141
			,[WSDS15_PWLS01]=151
			,[WSDS16_PWLS01]=161
			,[WSDS17_PWLS01]=171
			,[WSDS18_PWLS01]=181
			,[WSDS19_PWLS01]=191
			,[WSDS20_PWLS01]=201
			,[WSDS21_PWLS01]=211
			,[WSDS22_PWLS01]=221
			,[WSDS23_PWLS01]=231
			,[WSDS24_PWLS01]=241
			,[WSDS25_PWLS01]=251
			,[WSDS26_PWLS01]=261
			,[WSDS27_PWLS01]=271
			,[WSDS28_PWLS01]=281
			,[WSDS29_PWLS01]=291
			,[WSDS30_PWLS01]=301
			,[WSDS31_PWLS01]=311
			,[WSDS32_PWLS01]=321
			,[WSDS33_PWLS01]=331
			,[WSDS34_PWLS01]=341
			,[WSDS35_PWLS01]=351
			,[WSDS36_PWLS01]=361
			,[WSDS37_PWLS01]=371
			,[WSDS38_PWLS01]=381
			,[WSDS39_PWLS01]=391
			,[WSDS40_PWLS01]=401
			,[WSDS41_PWLS01]=411
			,[WSDS42_PWLS01]=421
			,[WSDS43_PWLS01]=431
			,[WSDS44_PWLS01]=441
			,[WSDS45_PWLS01]=451
			,[WSDS46_PWLS01]=461
			,[WSDS47_PWLS01]=471
			,[WSDS48_PWLS01]=481
			,[WSDS49_PWLS01]=491
			,[WSDS50_PWLS01]=501
			,[WSDS51_PWLS01]=511
			,[WSDS52_PWLS01]=521
			,[WSDS53_PWLS01]=531
			,[WSDS54_PWLS01]=541
			,[WSDS55_PWLS01]=551
			,[WSDS56_PWLS01]=561
			,[WSDS57_PWLS01]=571
			,[WSDS58_PWLS01]=581
END

GO
/****** Object:  StoredProcedure [dbo].[TimerUpdateAHU2]    Script Date: 2019/10/31 下午 11:44:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
	/*
INSERT INTO [dbo].[AHU_04F]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[AHU_0B1]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[AHU_0RF]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[AHU_14F]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[AHU_S03]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[AHU_SB1]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[Chiller]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[COP]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[CP]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[CT]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[ZP]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[RRS_PVOI]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[RRS_PWLS]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[RRS_VFLH]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[WSDS_PVOI]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[WSDS_PWLS]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
	*/
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
		  ,[AHU01_004F01] = 141                                                                                                                                                                                   
		  ,[AHU02_004F01] = 241                                                                                                                                                                                   
		  ,[AHU03_004F01] = 341                                                                                                                                                                                   
		  ,[AHU04_004F01] = 441                                                                                                                                                                                   
		  ,[AHU05_004F01] = 541                                                                                                                                                                                   
		  ,[AHU06_004F01] = 641                                                                                                                                                                                   
		  ,[AHU07_004F01] = 741                                                                                                                                                                                   
		  ,[AHU08_004F01] = 841                                                                                                                                                             
		  ,[AHU09_004F01] = 941                                                                                                                                                                                  
		  ,[AHU10_004F01] = 1041                                                                                                                                                                                  
		  ,[AHU11_004F01] = 1141                                                                                                                                                                                  
		  ,[AHU01_004F02] = 142                                                                                                                                                                                   
		  ,[AHU02_004F02] = 242                                                                                                                                                                                   
		  ,[AHU03_004F02] = 342                                                                                                                                                                                   
		  ,[AHU04_004F02] = 442                                                                                                                                                                                   
		  ,[AHU05_004F02] = 542                                                                                                                                                                                   
		  ,[AHU06_004F02] = 642                                                                                                                                                                                   
		  ,[AHU07_004F02] = 742                                                                                                                                                                                   
		  ,[AHU08_004F02] = 842                                                                                                                                                                                   
		  ,[AHU09_004F02] = 942                                                                                                                                                                                  
		  ,[AHU10_004F02] = 1042                                                                                                                                                                                  
		  ,[AHU11_004F02] = 1142                                                                                                                                                                                  
		  ,[AHU01_004F03] = 143                                                                                                                                                                                   
		  ,[AHU02_004F03] = 243                                                                                                                                                                                   
		  ,[AHU03_004F03] = 343                                                                                                                                                                                   
		  ,[AHU04_004F03] = 443                                                                                                                                                                                   
		  ,[AHU05_004F03] = 543                                                                                                                                                                                   
		  ,[AHU06_004F03] = 643                                                                                                                                                                                   
		  ,[AHU07_004F03] = 743                                                                                                                                                                                   
		  ,[AHU08_004F03] = 843                                                                                                                                                                                   
		  ,[AHU09_004F03] = 943                                                                                                                                                                                  
		  ,[AHU10_004F03] = 1043                                                                                                                                                                                  
		  ,[AHU11_004F03] = 1143                                                                                                                                                                                  
		  ,[AHU01_004F04] = 144                                                                                                                                                                                   
		  ,[AHU02_004F04] = 244                                                                                                                                                                                   
		  ,[AHU03_004F04] = 344                                                                                                                                                                                   
		  ,[AHU04_004F04] = 444                                                                                                                                                                                   
		  ,[AHU05_004F04] = 544                                                                                                                                                                                   
		  ,[AHU06_004F04] = 644                                                                                                                                                                                   
		  ,[AHU07_004F04] = 744                                                                                                                                                                                   
		  ,[AHU08_004F04] = 844                                                                                                                                                                                   
		  ,[AHU09_004F04] = 944                                                                                                                                                                                  
		  ,[AHU10_004F04] = 1044                                                                                                                                                                                  
		  ,[AHU11_004F04] = 1144                                                                                                                                                                                  
	                                                                                                                                                                                                          
	--AHU_0B1                                                                                                                                                                                                 
	UPDATE [dbo].[AHU_0B1]                                                                                                                                                                                    
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))                                                     
		  ,[DATETIME] = GETDATE()                                                                                                                                                                               
		  ,[AHU01_0B1F01] = 101                                                                                                                                                                                   
		  ,[AHU02_0B1F01] = 201                                                                                                                                                                                   
		  ,[AHU03_0B1F01] = 301                                                                                                                                                                                   
		  ,[AHU04_0B1F01] = 401                                                                                                                                                                                   
		  ,[AHU05_0B1F01] = 501                                                                                                                                                                                   
		  ,[AHU06_0B1F01] = 601                                                                                                                                                                                   
		  ,[AHU07_0B1F01] = 701                                                                                                                                                                                   
		  ,[AHU08_0B1F01] = 801                                                                                                                                                                                   
		  ,[AHU09_0B1F01] = 901                                                                                                                                                                                   
		  ,[AHU10_0B1F01] = 1001                                                                                                                                                                                  
		  ,[AHU11_0B1F01] = 1101                                                                                                                                                                                  
		  ,[AHU01_0B1F02] = 102                                                                                                                                                                                   
		  ,[AHU02_0B1F02] = 202                                                                                                                                                                                   
		  ,[AHU03_0B1F02] = 302                                                                                                                                                                                   
		  ,[AHU04_0B1F02] = 402                                                                                                                                                                                   
		  ,[AHU05_0B1F02] = 502                                                                                                                                                                                   
		  ,[AHU06_0B1F02] = 602                                                                                                                                                                                   
		  ,[AHU07_0B1F02] = 702                                                                                                                                                                                   
		  ,[AHU08_0B1F02] = 802                                                                                                                                                                                   
		  ,[AHU09_0B1F02] = 902                                                                                                                                                                                   
		  ,[AHU10_0B1F02] = 1002                                                                                                                                                                                  
		  ,[AHU11_0B1F02] = 1102                                                                                                                                                                                  
		  ,[AHU01_0B1F03] = 103                                                                                                                                                                                   
		  ,[AHU02_0B1F03] = 203                                                                                                                                                                                   
		  ,[AHU03_0B1F03] = 303                                                                                                                                                                                   
		  ,[AHU04_0B1F03] = 403                                                                                                                                                                                   
		  ,[AHU05_0B1F03] = 503                                                                                                                                                                                   
		  ,[AHU06_0B1F03] = 603                                                                                                                                                                                   
		  ,[AHU07_0B1F03] = 703                                                                                                                                                                                   
		  ,[AHU08_0B1F03] = 803                                                                                                                                                                                   
		  ,[AHU09_0B1F03] = 903                                                                                                                                                                                   
		  ,[AHU10_0B1F03] = 1003                                                                                                                                                                                  
		  ,[AHU11_0B1F03] = 1103                                                                                                                                                                                  
		  ,[AHU01_0B1F04] = 104                                                                                                                                                                                   
		  ,[AHU02_0B1F04] = 204                                                                                                                                                                                   
		  ,[AHU03_0B1F04] = 304                                                                                                                                                                                   
		  ,[AHU04_0B1F04] = 404                                                                                                                                                                                   
		  ,[AHU05_0B1F04] = 504                                                                                                                                                                                   
		  ,[AHU06_0B1F04] = 604                                                                                                                                                                                   
		  ,[AHU07_0B1F04] = 704                                                                                                                                                                                   
		  ,[AHU08_0B1F04] = 804                                                                                                                                                                                   
		  ,[AHU09_0B1F04] = 904                                                                                                                                                                                   
		  ,[AHU10_0B1F04] = 1004                                                                                                                                                                                  
		  ,[AHU11_0B1F04] = 1104                                                                                                                                                                                  
		  ,[AHU01_0B1F05] = 105                                                                                                                                                                                   
		  ,[AHU02_0B1F05] = 205                                                                                                                                                                                   
		  ,[AHU03_0B1F05] = 305                                                                                                                                                                                   
		  ,[AHU04_0B1F05] = 405                                                                                                                                                                                   
		  ,[AHU05_0B1F05] = 505                                                                                                                                                                                   
		  ,[AHU06_0B1F05] = 605                                                                                                                                                                                   
		  ,[AHU07_0B1F05] = 705                                                                                                                                                                                   
		  ,[AHU08_0B1F05] = 805                                                                                                                                                                                   
		  ,[AHU09_0B1F05] = 905                                                                                                                                                                                   
		  ,[AHU10_0B1F05] = 1005                                                                                                                                                                                  
		  ,[AHU11_0B1F05] = 1105                                                                                                                                                                                  
		  ,[AHU01_0B1F06] = 106                                                                                                                                                                                   
		  ,[AHU02_0B1F06] = 206                                                                                                                                                                                   
		  ,[AHU03_0B1F06] = 306                                                                                                                                                                                   
		  ,[AHU04_0B1F06] = 406                                                                                                                                                                                   
		  ,[AHU05_0B1F06] = 506                                                                                                                                                                                   
		  ,[AHU06_0B1F06] = 606                                                                                                                                                                                   
		  ,[AHU07_0B1F06] = 706                                                                                                                                                                                   
		  ,[AHU08_0B1F06] = 806                                                                                                                                                                                   
		  ,[AHU09_0B1F06] = 906                                                                                                                                                                                   
		  ,[AHU10_0B1F06] = 1006                                                                                                                                                                                  
		  ,[AHU11_0B1F06] = 1106                                                                                                                                                                                  
		  ,[AHU01_0B1F07] = 107                                                                                                                                                                                   
		  ,[AHU02_0B1F07] = 207                                                                                                                                                                                   
		  ,[AHU03_0B1F07] = 307                                                                                                                                                                                   
		  ,[AHU04_0B1F07] = 407                                                                                                                                                                                   
		  ,[AHU05_0B1F07] = 507                                                                                                                                                                                   
		  ,[AHU06_0B1F07] = 607                                                                                                                                                                                   
		  ,[AHU07_0B1F07] = 707                                                                                                                                                                                   
		  ,[AHU08_0B1F07] = 807                                                                                                                                                                                   
		  ,[AHU09_0B1F07] = 907                                                                                                                                                                                   
		  ,[AHU10_0B1F07] = 1007                                                                                                                                                                                  
		  ,[AHU11_0B1F07] = 1107                                                                                                                                                                                  
		  ,[AHU01_0B1F08] = 108                                                                                                                                                                                   
		  ,[AHU02_0B1F08] = 208                                                                                                                                                                                   
		  ,[AHU03_0B1F08] = 308                                                                                                                                                                                   
		  ,[AHU04_0B1F08] = 408                                                                                                                                                                                   
		  ,[AHU05_0B1F08] = 508                                                                                                                                                                                   
		  ,[AHU06_0B1F08] = 608                                                                                                                                                                                   
		  ,[AHU07_0B1F08] = 708                                                                                                                                                                                   
		  ,[AHU08_0B1F08] = 808                                                                                                                                                                                   
		  ,[AHU09_0B1F08] = 908                                                                                                                                                                                   
		  ,[AHU10_0B1F08] = 1008                                                                                                                                                                                  
		  ,[AHU11_0B1F08] = 1108                                                                                                                                                                                  
                                                                                                                                                                                                            
	--AHU_0RF                                                                                                                                                                                                 
	UPDATE [dbo].[AHU_0RF]                                                                                                                                                                                    
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))                                                     
		  ,[DATETIME] = GETDATE()                                                                                                                                                                               
		  ,[AHU01_00RF01] = 1271                                                                                                                                                                                   
		  ,[AHU02_00RF01] = 2271                                                                                                                                                                                   
		  ,[AHU03_00RF01] = 3271                                                                                                                                                                                   
		  ,[AHU04_00RF01] = 4271                                                                                                                                                                                   
		  ,[AHU05_00RF01] = 5271                                                                                                                                                                                   
		  ,[AHU06_00RF01] = 6271                                                                                                                                                                                   
		  ,[AHU07_00RF01] = 7271                                                                                                                                                                                   
		  ,[AHU08_00RF01] = 8271                                                                                                                                                                                   
		  ,[AHU09_00RF01] = 9271                                                                                                                                                                                 
		  ,[AHU10_00RF01] = 10271                                                                                                                                                                                  
		  ,[AHU11_00RF01] = 11271                                                                                                                                                                                  
		  ,[AHU01_00RF02] = 1272                                                                                                                                                                                   
		  ,[AHU02_00RF02] = 2272                                                                                                                                                                                   
		  ,[AHU03_00RF02] = 3272                                                                                                                                                                                   
		  ,[AHU04_00RF02] = 4272                                                                                                                                                                                   
		  ,[AHU05_00RF02] = 5272                                                                                                                                                                                   
		  ,[AHU06_00RF02] = 6272                                                                                                                                                                                   
		  ,[AHU07_00RF02] = 7272                                                                                                                                                                                   
		  ,[AHU08_00RF02] = 8272                                                                                                                                                                                   
		  ,[AHU09_00RF02] = 9272                                                                                                                                                                                 
		  ,[AHU10_00RF02] = 10272                                                                                                                                                                                  
		  ,[AHU11_00RF02] = 11272                                                                                                                                                                                  
		  ,[AHU01_00RF03] = 1273                                                                                                                                                                                   
		  ,[AHU02_00RF03] = 2273                                                                                                                                                                                   
		  ,[AHU03_00RF03] = 3273                                                                                                                                                                                   
		  ,[AHU04_00RF03] = 4273                                                                                                                                                                                   
		  ,[AHU05_00RF03] = 5273                                                                                                                                                                                   
		  ,[AHU06_00RF03] = 6273                                                                                                                                                                                   
		  ,[AHU07_00RF03] = 7273                                                                                                                                                                                   
		  ,[AHU08_00RF03] = 8273                                                                                                                                                                                   
		  ,[AHU09_00RF03] = 9273                                                                                                                                                                                 
		  ,[AHU10_00RF03] = 10273                                                                                                                                                                                  
		  ,[AHU11_00RF03] = 11273                                                                                                                                                                                  
		  ,[AHU01_00RF04] = 1274                                                                                                                                                                                 
		  ,[AHU02_00RF04] = 2274                                                                                                                                                                                 
		  ,[AHU03_00RF04] = 3274                                                                                                                                                                                 
		  ,[AHU04_00RF04] = 4274                                                                                                                                                                                 
		  ,[AHU05_00RF04] = 5274                                                                                                                                                                                 
		  ,[AHU06_00RF04] = 6274                                                                                                                                                                                 
		  ,[AHU07_00RF04] = 7274                                                                                                                                                                                 
		  ,[AHU08_00RF04] = 8274                                                                                                                                                                                 
		  ,[AHU09_00RF04] = 9274                                                                                                                                                                                 
		  ,[AHU10_00RF04] = 10274                                                                                                                                                                                  
		  ,[AHU11_00RF04] = 11274                                                                                                                                                                                  
		  ,[AHU01_00RF05] = 1275                                                                                                                                                                                 
		  ,[AHU02_00RF05] = 2275                                                                                                                                                                                 
		  ,[AHU03_00RF05] = 3275                                                                                                                                                                                 
		  ,[AHU04_00RF05] = 4275                                                                                                                                                                                 
		  ,[AHU05_00RF05] = 5275                                                                                                                                                                                 
		  ,[AHU06_00RF05] = 6275                                                                                                                                                                                 
		  ,[AHU07_00RF05] = 7275                                                                                                                                                                                 
		  ,[AHU08_00RF05] = 8275                                                                                                                                                                                 
		  ,[AHU09_00RF05] = 9275                                                                                                                                                                                 
		  ,[AHU10_00RF05] = 10275                                                                                                                                                                                  
		  ,[AHU11_00RF05] = 11275                                                                                                                                                                                  
		  ,[AHU01_00RF06] = 1276                                                                                                                                                                                 
		  ,[AHU02_00RF06] = 2276                                                                                                                                                                                 
		  ,[AHU03_00RF06] = 3276                                                                                                                                                                                 
		  ,[AHU04_00RF06] = 4276                                                                                                                                                                                 
		  ,[AHU05_00RF06] = 5276                                                                                                                                                                                 
		  ,[AHU06_00RF06] = 6276                                                                                                                                                                                 
		  ,[AHU07_00RF06] = 7276                                                                                                                                                                                 
		  ,[AHU08_00RF06] = 8276                                                                                                                                                                                 
		  ,[AHU09_00RF06] = 9276                                                                                                                                                                                 
		  ,[AHU10_00RF06] = 10276                                                                                                                                                                                  
		  ,[AHU11_00RF06] = 11276                                                                                                                                                                                  
		  ,[AHU01_00RF07] = 1277                                                                                                                                                                                 
		  ,[AHU02_00RF07] = 2277                                                                                                                                                                                 
		  ,[AHU03_00RF07] = 3277                                                                                                                                                                                 
		  ,[AHU04_00RF07] = 4277                                                                                                                                                                                 
		  ,[AHU05_00RF07] = 5277                                                                                                                                                                                 
		  ,[AHU06_00RF07] = 6277                                                                                                                                                                                 
		  ,[AHU07_00RF07] = 7277                                                                                                                                                                                 
		  ,[AHU08_00RF07] = 8277                                                                                                                                                                                 
		  ,[AHU09_00RF07] = 9277                                                                                                                                                                                 
		  ,[AHU10_00RF07] = 10277                                                                                                                                                                                  
		  ,[AHU11_00RF07] = 11277                                                                                                                                                                                  
		  ,[AHU01_00RF08] = 1278                                                                                                                                                                                 
		  ,[AHU02_00RF08] = 2278                                                                                                                                                                                 
		  ,[AHU03_00RF08] = 3278                                                                                                                                                                                 
		  ,[AHU04_00RF08] = 4278                                                                                                                                                                                 
		  ,[AHU05_00RF08] = 5278                                                                                                                                                                                 
		  ,[AHU06_00RF08] = 6278                                                                                                                                                                                 
		  ,[AHU07_00RF08] = 7278                                                                                                                                                                                 
		  ,[AHU08_00RF08] = 8278                                                                                                                                                                                 
		  ,[AHU09_00RF08] = 9278                                                                                                                                                                                 
		  ,[AHU10_00RF08] = 10278                                                                                                                                                                                  
		  ,[AHU11_00RF08] = 11278                                                                                                                                                                                  
		  ,[AHU01_00RF09] = 1279                                                                                                                                                                                 
		  ,[AHU02_00RF09] = 2279                                                                                                                                                                                 
		  ,[AHU03_00RF09] = 3279                                                                                                                                                                                 
		  ,[AHU04_00RF09] = 4279                                                                                                                                                                                 
		  ,[AHU05_00RF09] = 5279                                                                                                                                                                                 
		  ,[AHU06_00RF09] = 6279                                                                                                                                                                                 
		  ,[AHU07_00RF09] = 7279                                                                                                                                                                                 
		  ,[AHU08_00RF09] = 8279                                                                                                                                                                                 
		  ,[AHU09_00RF09] = 9279                                                                                                                                                                                 
		  ,[AHU10_00RF09] = 10279                                                                                                                                                                                  
		  ,[AHU11_00RF09] = 11279                                                                                                                                                                                  
                                                                                                                                                                                                            
	--AHU_014                                                                                                                                                                                                 
	UPDATE [dbo].[AHU_14F]                                                                                                                                                                                    
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))                                                     
		  ,[DATETIME] = GETDATE()                                                                                                                                                                               
		  ,[AHU01_014F01] = 1141                                                                                                                                                                                   
		  ,[AHU02_014F01] = 2141                                                                                                                                                                                   
		  ,[AHU03_014F01] = 3141                                                                                                                                                                                   
		  ,[AHU04_014F01] = 4141                                                                                                                                                                                   
		  ,[AHU05_014F01] = 5141                                                                                                                                                                                   
		  ,[AHU06_014F01] = 6141                                                                                                                                                                                   
		  ,[AHU07_014F01] = 7141                                                                                                                                                                                   
		  ,[AHU08_014F01] = 8141                                                                                                                                                                                   
		  ,[AHU09_014F01] = 9141                                                                                                                                                                                 
		  ,[AHU10_014F01] = 10141                                                                                                                                                                                  
		  ,[AHU11_014F01] = 11141                                                                                                                                                                                  
		  ,[AHU01_014F02] = 1142                                                                                                                                                                                 
		  ,[AHU02_014F02] = 2142                                                                                                                                                                                 
		  ,[AHU03_014F02] = 3142                                                                                                                                                                                 
		  ,[AHU04_014F02] = 4142                                                                                                                                                                                 
		  ,[AHU05_014F02] = 5142                                                                                                                                                                                 
		  ,[AHU06_014F02] = 6142                                                                                                                                                                                 
		  ,[AHU07_014F02] = 7142                                                                                                                                                                                 
		  ,[AHU08_014F02] = 8142                                                                                                                                                                                 
		  ,[AHU09_014F02] = 9142                                                                                                                                                                                 
		  ,[AHU10_014F02] = 10142                                                                                                                                                                                  
		  ,[AHU11_014F02] = 11142                                                                                                                                                                                  
		  ,[AHU01_014F03] = 1143                                                                                                                                                                                 
		  ,[AHU02_014F03] = 2143                                                                                                                                                                                 
		  ,[AHU03_014F03] = 3143                                                                                                                                                                                 
		  ,[AHU04_014F03] = 4143                                                                                                                                                                                 
		  ,[AHU05_014F03] = 5143                                                                                                                                                                                 
		  ,[AHU06_014F03] = 6143                                                                                                                                                                                 
		  ,[AHU07_014F03] = 7143                                                                                                                                                                                 
		  ,[AHU08_014F03] = 8143                                                                                                                                                                                 
		  ,[AHU09_014F03] = 9143                                                                                                                                                                                 
		  ,[AHU10_014F03] = 10143                                                                                                                                                                                  
		  ,[AHU11_014F03] = 11143                                                                                                                                                                                  
		  ,[AHU01_014F04] = 1144                                                                                                                                                                                   
		  ,[AHU02_014F04] = 2144                                                                                                                                                                                   
		  ,[AHU03_014F04] = 3144                                                                                                                                                                                   
		  ,[AHU04_014F04] = 4144                                                                                                                                                                                   
		  ,[AHU05_014F04] = 5144                                                                                                                                                                                   
		  ,[AHU06_014F04] = 6144                                                                                                                                                                                   
		  ,[AHU07_014F04] = 7144                                                                                                                                                                                   
		  ,[AHU08_014F04] = 8144                                                                                                                                                                                   
		  ,[AHU09_014F04] = 9144                                                                                                                                                                                 
		  ,[AHU10_014F04] = 10144                                                                                                                                                                                  
		  ,[AHU11_014F04] = 11144                                                                                                                                                                                
		  ,[AHU01_014F05] = 1145                                                                                                                                                                                   
		  ,[AHU02_014F05] = 2145                                                                                                                                                                                   
		  ,[AHU03_014F05] = 3145                                                                                                                                                                                   
		  ,[AHU04_014F05] = 4145                                                                                                                                                                                   
		  ,[AHU05_014F05] = 5145                                                                                                                                                                                   
		  ,[AHU06_014F05] = 6145                                                                                                                                                                                   
		  ,[AHU07_014F05] = 7145                                                                                                                                                                                   
		  ,[AHU08_014F05] = 8145                                                                                                                                                                                   
		  ,[AHU09_014F05] = 9145                                                                                                                                                                                 
		  ,[AHU10_014F05] = 10145                                                                                                                                                                                  
		  ,[AHU11_014F05] = 11145                                                                                                                                                                                  
		  ,[AHU01_014F06] = 1146                                                                                                                                                                                   
		  ,[AHU02_014F06] = 2146                                                                                                                                                                                   
		  ,[AHU03_014F06] = 3146                                                                                                                                                                                   
		  ,[AHU04_014F06] = 4146                                                                                                                                                                                   
		  ,[AHU05_014F06] = 5146                                                                                                                                                                                   
		  ,[AHU06_014F06] = 6146                                                                                                                                                                                   
		  ,[AHU07_014F06] = 7146                                                                                                                                                                                   
		  ,[AHU08_014F06] = 8146                                                                                                                                                                                   
		  ,[AHU09_014F06] = 9146                                                                                                                                                                                 
		  ,[AHU10_014F06] = 10146                                                                                                                                                                                  
		  ,[AHU11_014F06] = 11146                                                                                                                                                                                  
		  ,[AHU01_014F07] = 1147                                                                                                                                                                                   
		  ,[AHU02_014F07] = 2147                                                                                                                                                                                   
		  ,[AHU03_014F07] = 3147                                                                                                                                                                                   
		  ,[AHU04_014F07] = 4147                                                                                                                                                                                   
		  ,[AHU05_014F07] = 5147                                                                                                                                                                                   
		  ,[AHU06_014F07] = 6147                                                                                                                                                                                   
		  ,[AHU07_014F07] = 7147                                                                                                                                                                                   
		  ,[AHU08_014F07] = 8147                                                                                                                                                                                   
		  ,[AHU09_014F07] = 9147                                                                                                                                                                                 
		  ,[AHU10_014F07] = 10147                                                                                                                                                                                  
		  ,[AHU11_014F07] = 11147                                                                                                                                                                                  
		  ,[AHU01_014F08] = 1148                                                                                                                                                                                   
		  ,[AHU02_014F08] = 2148                                                                                                                                                                                   
		  ,[AHU03_014F08] = 3148                                                                                                                                                                                   
		  ,[AHU04_014F08] = 4148                                                                                                                                                                                   
		  ,[AHU05_014F08] = 5148                                                                                                                                                                                   
		  ,[AHU06_014F08] = 6148                                                                                                                                                                                   
		  ,[AHU07_014F08] = 7148                                                                                                                                                                                   
		  ,[AHU08_014F08] = 8148                                                                                                                                                                                   
		  ,[AHU09_014F08] = 9148                                                                                                                                                                                 
		  ,[AHU10_014F08] = 10148                                                                                                                                                                                  
		  ,[AHU11_014F08] = 11148                                                                                                                                                                                  
		  ,[AHU01_014F09] = 1149                                                                                                                                                                                   
		  ,[AHU02_014F09] = 2149                                                                                                                                                                                   
		  ,[AHU03_014F09] = 3149                                                                                                                                                                                   
		  ,[AHU04_014F09] = 4149                                                                                                                                                                                   
		  ,[AHU05_014F09] = 5149                                                                                                                                                                                   
		  ,[AHU06_014F09] = 6149                                                                                                                                                                                   
		  ,[AHU07_014F09] = 7149                                                                                                                                                                                   
		  ,[AHU08_014F09] = 8149                                                                                                                                                                                   
		  ,[AHU09_014F09] = 9149                                                                                                                                                                                 
		  ,[AHU10_014F09] = 10149                                                                                                                                                                                  
		  ,[AHU11_014F09] = 11149                                                                                                                                                                                  
		  ,[AHU01_014F10] = 11410                                                                                                                                                                                   
		  ,[AHU02_014F10] = 21410                                                                                                                                                                                   
		  ,[AHU03_014F10] = 31410                                                                                                                                                                                   
		  ,[AHU04_014F10] = 41410                                                                                                                                                                                   
		  ,[AHU05_014F10] = 51410                                                                                                                                                                                   
		  ,[AHU06_014F10] = 61410                                                                                                                                                                                   
		  ,[AHU07_014F10] = 71410                                                                                                                                                                                   
		  ,[AHU08_014F10] = 81410                                                                                                                                                                                   
		  ,[AHU09_014F10] = 91410                                                                                                                                                                                
		  ,[AHU10_014F10] = 101410                                                                                                                                                                                  
		  ,[AHU11_014F10] = 111410                                                                                                                                                                                  
		  ,[AHU01_014F11] = 11411                                                                                                                                                                                   
		  ,[AHU02_014F11] = 21411                                                                                                                                                                                   
		  ,[AHU03_014F11] = 31411                                                                                                                                                                                   
		  ,[AHU04_014F11] = 41411                                                                                                                                                                                   
		  ,[AHU05_014F11] = 51411                                                                                                                                                                                   
		  ,[AHU06_014F11] = 61411                                                                                                                                                                                   
		  ,[AHU07_014F11] = 71411                                                                                                                                                                                   
		  ,[AHU08_014F11] = 81411                                                                                                                                                                                   
		  ,[AHU09_014F11] = 91411                                                                                                                                                                                
		  ,[AHU10_014F11] = 101411                                                                                                                                                                                  
		  ,[AHU11_014F11] = 111411                                                                                                                                                                                  
		  ,[AHU01_014F12] = 11412                                                                                                                                                                                   
		  ,[AHU02_014F12] = 21412                                                                                                                                                                                   
		  ,[AHU03_014F12] = 31412                                                                                                                                                                                   
		  ,[AHU04_014F12] = 41412                                                                                                                                                                                   
		  ,[AHU05_014F12] = 51412                                                                                                                                                                                   
		  ,[AHU06_014F12] = 61412                                                                                                                                                                                   
		  ,[AHU07_014F12] = 71412                                                                                                                                                                                   
		  ,[AHU08_014F12] = 81412                                                                                                                                                                                   
		  ,[AHU09_014F12] = 91412                                                                                                                                                                                
		  ,[AHU10_014F12] = 101412                                                                                                                                                                                  
		  ,[AHU11_014F12] = 111412                                                                                                                                                                                  
		  ,[AHU01_014F13] = 11413                                                                                                                                                                                   
		  ,[AHU02_014F13] = 21413                                                                                                                                                                                   
		  ,[AHU03_014F13] = 31413                                                                                                                                                                                   
		  ,[AHU04_014F13] = 41413                                                                                                                                                                                   
		  ,[AHU05_014F13] = 51413                                                                                                                                                                                   
		  ,[AHU06_014F13] = 61413                                                                                                                                                                                   
		  ,[AHU07_014F13] = 71413                                                                                                                                                                                   
		  ,[AHU08_014F13] = 81413                                                                                                                                                                                   
		  ,[AHU09_014F13] = 91413                                                                                                                                                                                
		  ,[AHU10_014F13] = 101413                                                                                                                                                                                  
		  ,[AHU11_014F13] = 111413                                                                                                                                                                                  
		  ,[AHU01_014F14] = 11414                                                                                                                                                                                   
		  ,[AHU02_014F14] = 21414                                                                                                                                                                                   
		  ,[AHU03_014F14] = 31414                                                                                                                                                                                   
		  ,[AHU04_014F14] = 41414                                                                                                                                                                                   
		  ,[AHU05_014F14] = 51414                                                                                                                                                                                   
		  ,[AHU06_014F14] = 61414                                                                                                                                                                                   
		  ,[AHU07_014F14] = 71414                                                                                                                                                                                   
		  ,[AHU08_014F14] = 81414                                                                                                                                                                                   
		  ,[AHU09_014F14] = 91414                                                                                                                                                                                
		  ,[AHU10_014F14] = 101414                                                                                                                                                                                  
		  ,[AHU11_014F14] = 111414                                                                                                                                                                                  
		  ,[AHU01_014F15] = 11415                                                                                                                                                                                   
		  ,[AHU02_014F15] = 21415                                                                                                                                                                                   
		  ,[AHU03_014F15] = 31415                                                                                                                                                                                   
		  ,[AHU04_014F15] = 41415                                                                                                                                                                                   
		  ,[AHU05_014F15] = 51415                                                                                                                                                                                   
		  ,[AHU06_014F15] = 61415                                                                                                                                                                                   
		  ,[AHU07_014F15] = 71415                                                                                                                                                                                   
		  ,[AHU08_014F15] = 81415                                                                                                                                                                                   
		  ,[AHU09_014F15] = 91415                                                                                                                                                                                
		  ,[AHU10_014F15] = 101415                                                                                                                                                                                  
		  ,[AHU11_014F15] = 111415                                                                                                                                                                                  
		  ,[AHU01_014F16] = 11416                                                                                                                                                                                   
		  ,[AHU02_014F16] = 21416                                                                                                                                                                                   
		  ,[AHU03_014F16] = 31416                                                                                                                                                                                   
		  ,[AHU04_014F16] = 41416                                                                                                                                                                                   
		  ,[AHU05_014F16] = 51416                                                                                                                                                                                   
		  ,[AHU06_014F16] = 61416                                                                                                                                                                                   
		  ,[AHU07_014F16] = 71416                                                                                                                                                                                   
		  ,[AHU08_014F16] = 81416                                                                                                                                                                                   
		  ,[AHU09_014F16] = 91416                                                                                                                                                                                
		  ,[AHU10_014F16] = 101416                                                                                                                                                                                  
		  ,[AHU11_014F16] = 111416                                                                                                                                                                                  
                                                                                                                                                                                                            
	--AHU_S03                                                                                                                                                                                                 
	UPDATE [dbo].[AHU_S03]                                                                                                                                                                                    
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))                                                     
		  ,[DATETIME] = GETDATE()                                                                                                                                                                               
		  ,[AHU01_S03F01] = 131                                                                                                                                                                                   
		  ,[AHU02_S03F01] = 231                                                                                                                                                                                 
		  ,[AHU03_S03F01] = 331                                                                                                                                                                                 
		  ,[AHU04_S03F01] = 431                                                                                                                                                                                 
		  ,[AHU05_S03F01] = 531                                                                                                                                                                                 
		  ,[AHU06_S03F01] = 631                                                                                                                                                                                 
		  ,[AHU07_S03F01] = 731                                                                                                                                                                                 
		  ,[AHU08_S03F01] = 831                                                                                                                                                                                 
		  ,[AHU09_S03F01] = 931                                                                                                                                                                                 
		  ,[AHU10_S03F01] = 1031                                                                                                                                                                                 
		  ,[AHU11_S03F01] = 1131                                                                                                                                                                                 
                                                                                                                                                                                                            
	--AHU_SB1                                                                                                                                                                                                 
	UPDATE [dbo].[AHU_SB1]                                                                                                                                                                                    
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))                                                     
		  ,[DATETIME] = GETDATE()                                                                                                                                                                               
			,[AHU01_SB1F01] = 101
			,[AHU02_SB1F01] = 201
			,[AHU03_SB1F01] = 301
			,[AHU04_SB1F01] = 401
			,[AHU05_SB1F01] = 501
			,[AHU06_SB1F01] = 601
			,[AHU07_SB1F01] = 701
			,[AHU08_SB1F01] = 801
			,[AHU09_SB1F01] = 901
			,[AHU10_SB1F01] = 1001
			,[AHU11_SB1F01] = 1101
			,[AHU01_SB1F02] = 102
			,[AHU02_SB1F02] = 202
			,[AHU03_SB1F02] = 302
			,[AHU04_SB1F02] = 402
			,[AHU05_SB1F02] = 502
			,[AHU06_SB1F02] = 602
			,[AHU07_SB1F02] = 702
			,[AHU08_SB1F02] = 802
			,[AHU09_SB1F02] = 902
			,[AHU10_SB1F02] = 1002
			,[AHU11_SB1F02] = 1102                                                                                                                                                                           

	--Chiller    
	UPDATE [dbo].[Chiller]
		SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()     
		  ,[Chiller01_R1] = 11
		  ,[Chiller02_R1] = 21
		  ,[Chiller03_R1] = 31
		  ,[Chiller04_R1] = 41
		  ,[Chiller05_R1] = 51
		  ,[Chiller06_R1] = 61
		  ,[Chiller07_R1] = 71
		  ,[Chiller08_R1] = 81
		  ,[Chiller09_R1] = 91
		  ,[Chiller10_R1] = 101
		  ,[Chiller01_R2] = 12 
		  ,[Chiller02_R2] = 22 
		  ,[Chiller03_R2] = 32 
		  ,[Chiller04_R2] = 42 
		  ,[Chiller05_R2] = 52 
		  ,[Chiller06_R2] = 62 
		  ,[Chiller07_R2] = 72 
		  ,[Chiller08_R2] = 82 
		  ,[Chiller09_R2] = 92 
		  ,[Chiller10_R2] = 102
		  ,[Chiller01_R3] = 13
		  ,[Chiller02_R3] = 23
		  ,[Chiller03_R3] = 33
		  ,[Chiller04_R3] = 43
		  ,[Chiller05_R3] = 53
		  ,[Chiller06_R3] = 63
		  ,[Chiller07_R3] = 73
		  ,[Chiller08_R3] = 83
		  ,[Chiller09_R3] = 93
		  ,[Chiller10_R3] = 103                     
		  ,[Chiller01_R6] = 16
		  ,[Chiller02_R6] = 26
		  ,[Chiller03_R6] = 36
		  ,[Chiller04_R6] = 46
		  ,[Chiller05_R6] = 56
		  ,[Chiller06_R6] = 66
		  ,[Chiller07_R6] = 76
		  ,[Chiller08_R6] = 86
		  ,[Chiller09_R6] = 96
		  ,[Chiller10_R6] = 106          

	--COP	  
	UPDATE [dbo].[COP]
		SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()     
		  ,[COP01_001] = 11
		  ,[COP02_001] = 21
		  ,[COP03_001] = 31
		  ,[COP04_001] = 41
		  ,[COP05_001] = 51
		  ,[COP01_002] = 12  
		  ,[COP02_002] = 22  
		  ,[COP03_002] = 32  
		  ,[COP04_002] = 42  
		  ,[COP05_002] = 52 
		  ,[COP01_003] = 13  
		  ,[COP02_003] = 23  
		  ,[COP03_003] = 33  
		  ,[COP04_003] = 43  
		  ,[COP05_003] = 53 
		  ,[COP01_006] = 16  
		  ,[COP02_006] = 26  
		  ,[COP03_006] = 36  
		  ,[COP04_006] = 46  
		  ,[COP05_006] = 56
		  ,[COP01_12S] = 1129
		  ,[COP02_12S] = 2129
		  ,[COP03_12S] = 3129
		  ,[COP04_12S] = 4129
		  ,[COP05_12S] = 5129 
		  ,[COP01_03S] = 1039
		  ,[COP02_03S] = 2039
		  ,[COP03_03S] = 3039
		  ,[COP04_03S] = 4039
		  ,[COP05_03S] = 5039 
		  ,[COP01_06S] = 1069
		  ,[COP02_06S] = 2069
		  ,[COP03_06S] = 3069
		  ,[COP04_06S] = 4069
		  ,[COP05_06S] = 5069
		  
	--CP	  
	UPDATE [dbo].[CP]		  
		SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()     
		  ,[CP01_01] = 11
		  ,[CP02_01] = 21
		  ,[CP03_01] = 31
		  ,[CP04_01] = 41
		  ,[CP05_01] = 51
		  ,[CP06_01] = 61
		  ,[CP07_01] = 71
		  ,[CP01_02] = 12 
		  ,[CP02_02] = 22 
		  ,[CP03_02] = 32 
		  ,[CP04_02] = 42 
		  ,[CP05_02] = 52 
		  ,[CP06_02] = 62 
		  ,[CP07_02] = 72
		  ,[CP01_03] = 13 
		  ,[CP02_03] = 23 
		  ,[CP03_03] = 33 
		  ,[CP04_03] = 43 
		  ,[CP05_03] = 53 
		  ,[CP06_03] = 63 
		  ,[CP07_03] = 73
		  ,[CP01_06] = 16 
		  ,[CP02_06] = 26 
		  ,[CP03_06] = 36 
		  ,[CP04_06] = 46 
		  ,[CP05_06] = 56 
		  ,[CP06_06] = 66 
		  ,[CP07_06] = 76
		  ,[CP01_0S] = 19 
		  ,[CP02_0S] = 29 
		  ,[CP03_0S] = 39 
		  ,[CP04_0S] = 49 
		  ,[CP05_0S] = 59 
		  ,[CP06_0S] = 69 
		  ,[CP07_0S] = 79	   
		  
	--CT
	UPDATE [dbo].[CT]
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()     
		  ,[CT01_01] = 11
		  ,[CT02_01] = 21
		  ,[CT03_01] = 31
		  ,[CT04_01] = 41
		  ,[CT05_01] = 51
		  ,[CT06_01] = 61
		  ,[CT07_01] = 71
		  ,[CT01_02] = 12
		  ,[CT02_02] = 22
		  ,[CT03_02] = 32
		  ,[CT04_02] = 42
		  ,[CT05_02] = 52
		  ,[CT06_02] = 62
		  ,[CT07_02] = 72
		  ,[CT01_03] = 13
		  ,[CT02_03] = 23
		  ,[CT03_03] = 33
		  ,[CT04_03] = 43
		  ,[CT05_03] = 53
		  ,[CT06_03] = 63
		  ,[CT07_03] = 73
		  ,[CT01_04] = 14
		  ,[CT02_04] = 24
		  ,[CT03_04] = 34
		  ,[CT04_04] = 44
		  ,[CT05_04] = 54
		  ,[CT06_04] = 64
		  ,[CT07_04] = 74
		  ,[CT01_05] = 15
		  ,[CT02_05] = 25
		  ,[CT03_05] = 35
		  ,[CT04_05] = 45
		  ,[CT05_05] = 55
		  ,[CT06_05] = 65
		  ,[CT07_05] = 75
		  ,[CT01_06] = 16
		  ,[CT02_06] = 26
		  ,[CT03_06] = 36
		  ,[CT04_06] = 46
		  ,[CT05_06] = 56
		  ,[CT06_06] = 66
		  ,[CT07_06] = 76

	--ZP
	UPDATE [dbo].[ZP]
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()     
		  ,[ZP01_00] = 10 
		  ,[ZP02_00] = 20
		  ,[ZP03_00] = 30
		  ,[ZP04_00] = 40
		  ,[ZP05_00] = 50
		  ,[ZP06_00] = 60
		  ,[ZP01_01] = 11
		  ,[ZP02_01] = 21
		  ,[ZP03_01] = 31
		  ,[ZP04_01] = 41
		  ,[ZP05_01] = 51
		  ,[ZP06_01] = 61
		  ,[ZP01_02] = 12
		  ,[ZP02_02] = 22
		  ,[ZP03_02] = 32
		  ,[ZP04_02] = 42
		  ,[ZP05_02] = 52
		  ,[ZP06_02] = 62

	--RRS_VFLH
	UPDATE [dbo].[RRS_VFLH]
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()     
		  ,[RRS01_VFLH01] = 11
		  ,[RRS02_VFLH01] = 21
		  ,[RRS03_VFLH01] = 31
		  ,[RRS04_VFLH01] = 41
		  ,[RRS05_VFLH01] = 51
		  ,[RRS06_VFLH01] = 61

	--RRS_PVOI
	UPDATE [dbo].[RRS_PVOI]
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()     
		  ,[RRS01_PVOI01] = 11
		  ,[RRS02_PVOI01] = 21
		  ,[RRS03_PVOI01] = 31
		  ,[RRS04_PVOI01] = 41
		  ,[RRS05_PVOI01] = 51
		  ,[RRS06_PVOI01] = 61
		  ,[RRS07_PVOI01] = 71

	--RRS_PWLS
	UPDATE [dbo].[RRS_PWLS]
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()     
		  ,[RRS01_PWLS01] = 11
		  ,[RRS02_PWLS01] = 21
		  ,[RRS03_PWLS01] = 31
		  ,[RRS04_PWLS01] = 41
		  ,[RRS05_PWLS01] = 51
		  ,[RRS06_PWLS01] = 61
		  ,[RRS07_PWLS01] = 71
		  ,[RRS08_PWLS01] = 81
		  ,[RRS09_PWLS01] = 91
		  ,[RRS10_PWLS01] = 101
		  ,[RRS11_PWLS01] = 111
		  ,[RRS12_PWLS01] = 121
		  ,[RRS13_PWLS01] = 131
		  
	--WSDS_PVOI
	UPDATE [dbo].[WSDS_PVOI]
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()     
			,[WSDS01_PVOI01]=11
			,[WSDS02_PVOI01]=21
			,[WSDS03_PVOI01]=31
			,[WSDS04_PVOI01]=41
			,[WSDS05_PVOI01]=51
			,[WSDS06_PVOI01]=61
			,[WSDS07_PVOI01]=71
			,[WSDS08_PVOI01]=81
			,[WSDS09_PVOI01]=91
			,[WSDS10_PVOI01]=101
			,[WSDS11_PVOI01]=111
			,[WSDS12_PVOI01]=121
			,[WSDS13_PVOI01]=131
			,[WSDS14_PVOI01]=141
			,[WSDS15_PVOI01]=151
			,[WSDS16_PVOI01]=161
			,[WSDS17_PVOI01]=171
			,[WSDS18_PVOI01]=181
			,[WSDS19_PVOI01]=191
			,[WSDS20_PVOI01]=201
			,[WSDS21_PVOI01]=211
			,[WSDS22_PVOI01]=221
			,[WSDS23_PVOI01]=231
			,[WSDS24_PVOI01]=241
			,[WSDS25_PVOI01]=251
			,[WSDS26_PVOI01]=261


	--WSDS_PWLS
	UPDATE [dbo].[WSDS_PWLS]
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()   
			,[WSDS01_PWLS01]=11
			,[WSDS02_PWLS01]=21
			,[WSDS03_PWLS01]=31
			,[WSDS04_PWLS01]=41
			,[WSDS05_PWLS01]=51
			,[WSDS06_PWLS01]=61
			,[WSDS07_PWLS01]=71
			,[WSDS08_PWLS01]=81
			,[WSDS09_PWLS01]=91
			,[WSDS10_PWLS01]=101
			,[WSDS11_PWLS01]=111
			,[WSDS12_PWLS01]=121
			,[WSDS13_PWLS01]=131
			,[WSDS14_PWLS01]=141
			,[WSDS15_PWLS01]=151
			,[WSDS16_PWLS01]=161
			,[WSDS17_PWLS01]=171
			,[WSDS18_PWLS01]=181
			,[WSDS19_PWLS01]=191
			,[WSDS20_PWLS01]=201
			,[WSDS21_PWLS01]=211
			,[WSDS22_PWLS01]=221
			,[WSDS23_PWLS01]=231
			,[WSDS24_PWLS01]=241
			,[WSDS25_PWLS01]=251
			,[WSDS26_PWLS01]=261
			,[WSDS27_PWLS01]=271
			,[WSDS28_PWLS01]=281
			,[WSDS29_PWLS01]=291
			,[WSDS30_PWLS01]=301
			,[WSDS31_PWLS01]=311
			,[WSDS32_PWLS01]=321
			,[WSDS33_PWLS01]=331
			,[WSDS34_PWLS01]=341
			,[WSDS35_PWLS01]=351
			,[WSDS36_PWLS01]=361
			,[WSDS37_PWLS01]=371
			,[WSDS38_PWLS01]=381
			,[WSDS39_PWLS01]=391
			,[WSDS40_PWLS01]=401
			,[WSDS41_PWLS01]=411
			,[WSDS42_PWLS01]=421
			,[WSDS43_PWLS01]=431
			,[WSDS44_PWLS01]=441
			,[WSDS45_PWLS01]=451
			,[WSDS46_PWLS01]=461
			,[WSDS47_PWLS01]=471
			,[WSDS48_PWLS01]=481
			,[WSDS49_PWLS01]=491
			,[WSDS50_PWLS01]=501
			,[WSDS51_PWLS01]=511
			,[WSDS52_PWLS01]=521
			,[WSDS53_PWLS01]=531
			,[WSDS54_PWLS01]=541
			,[WSDS55_PWLS01]=551
			,[WSDS56_PWLS01]=561
			,[WSDS57_PWLS01]=571
			,[WSDS58_PWLS01]=581

END

GO
/****** Object:  Table [dbo].[AHU_04F]    Script Date: 2019/10/31 下午 11:44:19 ******/
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
/****** Object:  Table [dbo].[AHU_0B1]    Script Date: 2019/10/31 下午 11:44:19 ******/
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
/****** Object:  Table [dbo].[AHU_0RF]    Script Date: 2019/10/31 下午 11:44:19 ******/
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
/****** Object:  Table [dbo].[AHU_14F]    Script Date: 2019/10/31 下午 11:44:19 ******/
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
/****** Object:  Table [dbo].[AHU_S03]    Script Date: 2019/10/31 下午 11:44:19 ******/
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
/****** Object:  Table [dbo].[AHU_SB1]    Script Date: 2019/10/31 下午 11:44:19 ******/
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
/****** Object:  Table [dbo].[Chiller]    Script Date: 2019/10/31 下午 11:44:19 ******/
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
/****** Object:  Table [dbo].[COP]    Script Date: 2019/10/31 下午 11:44:19 ******/
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
/****** Object:  Table [dbo].[CP]    Script Date: 2019/10/31 下午 11:44:19 ******/
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
/****** Object:  Table [dbo].[CT]    Script Date: 2019/10/31 下午 11:44:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT](
	[AUTOID] [int] NOT NULL,
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
	[CT07_06] [real] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RRS_PVOI]    Script Date: 2019/10/31 下午 11:44:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RRS_PVOI](
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[RRS01_PVOI01] [real] NULL,
	[RRS02_PVOI01] [real] NULL,
	[RRS03_PVOI01] [real] NULL,
	[RRS04_PVOI01] [real] NULL,
	[RRS05_PVOI01] [real] NULL,
	[RRS06_PVOI01] [real] NULL,
	[RRS07_PVOI01] [real] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RRS_PWLS]    Script Date: 2019/10/31 下午 11:44:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RRS_PWLS](
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
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
	[RRS13_PWLS01] [real] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RRS_VFLH]    Script Date: 2019/10/31 下午 11:44:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RRS_VFLH](
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[RRS01_VFLH01] [real] NULL,
	[RRS02_VFLH01] [real] NULL,
	[RRS03_VFLH01] [real] NULL,
	[RRS04_VFLH01] [real] NULL,
	[RRS05_VFLH01] [real] NULL,
	[RRS06_VFLH01] [real] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WSDS_PVOI]    Script Date: 2019/10/31 下午 11:44:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WSDS_PVOI](
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[WSDS01_PVOI01] [real] NULL,
	[WSDS02_PVOI01] [real] NULL,
	[WSDS03_PVOI01] [real] NULL,
	[WSDS04_PVOI01] [real] NULL,
	[WSDS05_PVOI01] [real] NULL,
	[WSDS06_PVOI01] [real] NULL,
	[WSDS07_PVOI01] [real] NULL,
	[WSDS08_PVOI01] [real] NULL,
	[WSDS09_PVOI01] [real] NULL,
	[WSDS10_PVOI01] [real] NULL,
	[WSDS11_PVOI01] [real] NULL,
	[WSDS12_PVOI01] [real] NULL,
	[WSDS13_PVOI01] [real] NULL,
	[WSDS14_PVOI01] [real] NULL,
	[WSDS15_PVOI01] [real] NULL,
	[WSDS16_PVOI01] [real] NULL,
	[WSDS17_PVOI01] [real] NULL,
	[WSDS18_PVOI01] [real] NULL,
	[WSDS19_PVOI01] [real] NULL,
	[WSDS20_PVOI01] [real] NULL,
	[WSDS21_PVOI01] [real] NULL,
	[WSDS22_PVOI01] [real] NULL,
	[WSDS23_PVOI01] [real] NULL,
	[WSDS24_PVOI01] [real] NULL,
	[WSDS25_PVOI01] [real] NULL,
	[WSDS26_PVOI01] [real] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WSDS_PWLS]    Script Date: 2019/10/31 下午 11:44:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WSDS_PWLS](
	[AUTOID] [int] NOT NULL,
	[DATETIME] [datetime] NULL,
	[WSDS01_PWLS01] [real] NULL,
	[WSDS02_PWLS01] [real] NULL,
	[WSDS03_PWLS01] [real] NULL,
	[WSDS04_PWLS01] [real] NULL,
	[WSDS05_PWLS01] [real] NULL,
	[WSDS06_PWLS01] [real] NULL,
	[WSDS07_PWLS01] [real] NULL,
	[WSDS08_PWLS01] [real] NULL,
	[WSDS09_PWLS01] [real] NULL,
	[WSDS10_PWLS01] [real] NULL,
	[WSDS11_PWLS01] [real] NULL,
	[WSDS12_PWLS01] [real] NULL,
	[WSDS13_PWLS01] [real] NULL,
	[WSDS14_PWLS01] [real] NULL,
	[WSDS15_PWLS01] [real] NULL,
	[WSDS16_PWLS01] [real] NULL,
	[WSDS17_PWLS01] [real] NULL,
	[WSDS18_PWLS01] [real] NULL,
	[WSDS19_PWLS01] [real] NULL,
	[WSDS20_PWLS01] [real] NULL,
	[WSDS21_PWLS01] [real] NULL,
	[WSDS22_PWLS01] [real] NULL,
	[WSDS23_PWLS01] [real] NULL,
	[WSDS24_PWLS01] [real] NULL,
	[WSDS25_PWLS01] [real] NULL,
	[WSDS26_PWLS01] [real] NULL,
	[WSDS27_PWLS01] [real] NULL,
	[WSDS28_PWLS01] [real] NULL,
	[WSDS29_PWLS01] [real] NULL,
	[WSDS30_PWLS01] [real] NULL,
	[WSDS31_PWLS01] [real] NULL,
	[WSDS32_PWLS01] [real] NULL,
	[WSDS33_PWLS01] [real] NULL,
	[WSDS34_PWLS01] [real] NULL,
	[WSDS35_PWLS01] [real] NULL,
	[WSDS36_PWLS01] [real] NULL,
	[WSDS37_PWLS01] [real] NULL,
	[WSDS38_PWLS01] [real] NULL,
	[WSDS39_PWLS01] [real] NULL,
	[WSDS40_PWLS01] [real] NULL,
	[WSDS41_PWLS01] [real] NULL,
	[WSDS42_PWLS01] [real] NULL,
	[WSDS43_PWLS01] [real] NULL,
	[WSDS44_PWLS01] [real] NULL,
	[WSDS45_PWLS01] [real] NULL,
	[WSDS46_PWLS01] [real] NULL,
	[WSDS47_PWLS01] [real] NULL,
	[WSDS48_PWLS01] [real] NULL,
	[WSDS49_PWLS01] [real] NULL,
	[WSDS50_PWLS01] [real] NULL,
	[WSDS51_PWLS01] [real] NULL,
	[WSDS52_PWLS01] [real] NULL,
	[WSDS53_PWLS01] [real] NULL,
	[WSDS54_PWLS01] [real] NULL,
	[WSDS55_PWLS01] [real] NULL,
	[WSDS56_PWLS01] [real] NULL,
	[WSDS57_PWLS01] [real] NULL,
	[WSDS58_PWLS01] [real] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ZP]    Script Date: 2019/10/31 下午 11:44:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZP](
	[AUTOID] [int] NOT NULL,
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
	[ZP06_02] [real] NULL
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [TP_B3] SET  READ_WRITE 
GO
