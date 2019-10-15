USE [TP_B3]
GO
/****** Object:  StoredProcedure [dbo].[TimerUpdateAHU2]    Script Date: 2019/10/15 下午 10:45:31 ******/
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
INSERT INTO [dbo].[RT1]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[PPWT1]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
INSERT INTO [dbo].[PRWT1]([AUTOID],[DATETIME]) VALUES (0,GETDATE())
	*/
ALTER PROCEDURE [dbo].[TimerUpdateAHU2]

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

END
