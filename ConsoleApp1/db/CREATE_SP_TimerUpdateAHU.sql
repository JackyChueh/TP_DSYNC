USE [TP_B3]
GO
/****** Object:  StoredProcedure [dbo].[TimerUpdateAHU]    Script Date: 2019/9/17 �U�� 11:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[TimerUpdateAHU]

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
		  ,[AHU01_004F01] = ROUND(RAND() * 1, 0)
		  ,[AHU02_004F01] = ROUND(RAND() * 1, 0)
		  ,[AHU03_004F01] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_004F01] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_004F01] = ROUND(RAND() * 5, 0)+29
		  ,[AHU06_004F01] = ROUND(RAND() * 3, 0)+60
		  ,[AHU07_004F01] = ROUND(RAND() * 5, 0)+26
		  ,[AHU08_004F01] = ROUND(RAND() * 3, 0)+50
		  ,[AHU09_004F01] = 41
		  ,[AHU10_004F01] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_004F01] = ROUND(RAND() * 54, 0)+6
		  ,[AHU01_004F02] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_004F02] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_004F02] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_004F02] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_004F02] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_004F02] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_004F02] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_004F02] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_004F02] = 42                      
		  ,[AHU10_004F02] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_004F02] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_004F03] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_004F03] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_004F03] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_004F03] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_004F03] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_004F03] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_004F03] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_004F03] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_004F03] = 43                      
		  ,[AHU10_004F03] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_004F03] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_004F04] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_004F04] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_004F04] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_004F04] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_004F04] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_004F04] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_004F04] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_004F04] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_004F04] = 44                      
		  ,[AHU10_004F04] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_004F04] = ROUND(RAND() * 54, 0)+6 
	
	--AHU_0B1
	UPDATE [dbo].[AHU_0B1]
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()
		  ,[AHU01_0B1F01] = ROUND(RAND() * 1, 0)
		  ,[AHU02_0B1F01] = ROUND(RAND() * 1, 0)
		  ,[AHU03_0B1F01] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_0B1F01] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_0B1F01] = ROUND(RAND() * 5, 0)+29
		  ,[AHU06_0B1F01] = ROUND(RAND() * 3, 0)+60
		  ,[AHU07_0B1F01] = ROUND(RAND() * 5, 0)+26
		  ,[AHU08_0B1F01] = ROUND(RAND() * 3, 0)+50
		  ,[AHU09_0B1F01] = 1
		  ,[AHU10_0B1F01] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_0B1F01] = ROUND(RAND() * 54, 0)+6
		  ,[AHU01_0B1F02] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_0B1F02] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_0B1F02] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_0B1F02] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_0B1F02] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_0B1F02] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_0B1F02] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_0B1F02] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_0B1F02] = 2                      
		  ,[AHU10_0B1F02] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_0B1F02] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_0B1F03] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_0B1F03] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_0B1F03] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_0B1F03] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_0B1F03] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_0B1F03] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_0B1F03] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_0B1F03] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_0B1F03] = 3                      
		  ,[AHU10_0B1F03] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_0B1F03] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_0B1F04] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_0B1F04] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_0B1F04] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_0B1F04] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_0B1F04] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_0B1F04] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_0B1F04] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_0B1F04] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_0B1F04] = 4                      
		  ,[AHU10_0B1F04] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_0B1F04] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_0B1F05] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_0B1F05] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_0B1F05] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_0B1F05] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_0B1F05] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_0B1F05] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_0B1F05] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_0B1F05] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_0B1F05] = 5                      
		  ,[AHU10_0B1F05] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_0B1F05] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_0B1F06] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_0B1F06] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_0B1F06] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_0B1F06] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_0B1F06] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_0B1F06] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_0B1F06] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_0B1F06] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_0B1F06] = 6                      
		  ,[AHU10_0B1F06] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_0B1F06] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_0B1F07] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_0B1F07] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_0B1F07] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_0B1F07] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_0B1F07] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_0B1F07] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_0B1F07] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_0B1F07] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_0B1F07] = 7                      
		  ,[AHU10_0B1F07] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_0B1F07] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_0B1F08] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_0B1F08] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_0B1F08] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_0B1F08] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_0B1F08] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_0B1F08] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_0B1F08] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_0B1F08] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_0B1F08] = 8                      
		  ,[AHU10_0B1F08] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_0B1F08] = ROUND(RAND() * 54, 0)+6 

	--AHU_0RF
	UPDATE [dbo].[AHU_0RF]
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()
		  ,[AHU01_00RF01] = ROUND(RAND() * 1, 0)
		  ,[AHU02_00RF01] = ROUND(RAND() * 1, 0)
		  ,[AHU03_00RF01] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_00RF01] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_00RF01] = ROUND(RAND() * 5, 0)+29
		  ,[AHU06_00RF01] = ROUND(RAND() * 3, 0)+60
		  ,[AHU07_00RF01] = ROUND(RAND() * 5, 0)+26
		  ,[AHU08_00RF01] = ROUND(RAND() * 3, 0)+50
		  ,[AHU09_00RF01] = 991
		  ,[AHU10_00RF01] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_00RF01] = ROUND(RAND() * 54, 0)+6
		  ,[AHU01_00RF02] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_00RF02] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_00RF02] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_00RF02] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_00RF02] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_00RF02] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_00RF02] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_00RF02] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_00RF02] = 992                      
		  ,[AHU10_00RF02] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_00RF02] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_00RF03] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_00RF03] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_00RF03] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_00RF03] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_00RF03] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_00RF03] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_00RF03] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_00RF03] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_00RF03] = 993                      
		  ,[AHU10_00RF03] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_00RF03] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_00RF04] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_00RF04] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_00RF04] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_00RF04] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_00RF04] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_00RF04] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_00RF04] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_00RF04] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_00RF04] = 994                      
		  ,[AHU10_00RF04] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_00RF04] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_00RF05] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_00RF05] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_00RF05] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_00RF05] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_00RF05] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_00RF05] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_00RF05] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_00RF05] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_00RF05] = 995                      
		  ,[AHU10_00RF05] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_00RF05] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_00RF06] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_00RF06] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_00RF06] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_00RF06] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_00RF06] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_00RF06] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_00RF06] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_00RF06] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_00RF06] = 996                      
		  ,[AHU10_00RF06] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_00RF06] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_00RF07] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_00RF07] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_00RF07] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_00RF07] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_00RF07] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_00RF07] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_00RF07] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_00RF07] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_00RF07] = 997                      
		  ,[AHU10_00RF07] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_00RF07] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_00RF08] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_00RF08] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_00RF08] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_00RF08] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_00RF08] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_00RF08] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_00RF08] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_00RF08] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_00RF08] = 998                      
		  ,[AHU10_00RF08] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_00RF08] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_00RF09] = ROUND(RAND() * 1, 0)
		  ,[AHU02_00RF09] = ROUND(RAND() * 1, 0)
		  ,[AHU03_00RF09] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_00RF09] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_00RF09] = ROUND(RAND() * 5, 0)+29
		  ,[AHU06_00RF09] = ROUND(RAND() * 3, 0)+60
		  ,[AHU07_00RF09] = ROUND(RAND() * 5, 0)+26
		  ,[AHU08_00RF09] = ROUND(RAND() * 3, 0)+50
		  ,[AHU09_00RF09] = 999
		  ,[AHU10_00RF09] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_00RF09] = ROUND(RAND() * 54, 0)+6

	--AHU_014
	UPDATE [dbo].[AHU_14F]
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()
		  ,[AHU01_014F01] = ROUND(RAND() * 1, 0)
		  ,[AHU02_014F01] = ROUND(RAND() * 1, 0)
		  ,[AHU03_014F01] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_014F01] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_014F01] = ROUND(RAND() * 5, 0)+29
		  ,[AHU06_014F01] = ROUND(RAND() * 3, 0)+60
		  ,[AHU07_014F01] = ROUND(RAND() * 5, 0)+26
		  ,[AHU08_014F01] = ROUND(RAND() * 3, 0)+50
		  ,[AHU09_014F01] = 141
		  ,[AHU10_014F01] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_014F01] = ROUND(RAND() * 54, 0)+6
		  ,[AHU01_014F02] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_014F02] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_014F02] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_014F02] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_014F02] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_014F02] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_014F02] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_014F02] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_014F02] = 142                      
		  ,[AHU10_014F02] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_014F02] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_014F03] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_014F03] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_014F03] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_014F03] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_014F03] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_014F03] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_014F03] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_014F03] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_014F03] = 143                      
		  ,[AHU10_014F03] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_014F03] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_014F04] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_014F04] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_014F04] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_014F04] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_014F04] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_014F04] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_014F04] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_014F04] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_014F04] = 144                      
		  ,[AHU10_014F04] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_014F04] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_014F05] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_014F05] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_014F05] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_014F05] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_014F05] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_014F05] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_014F05] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_014F05] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_014F05] = 145                      
		  ,[AHU10_014F05] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_014F05] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_014F06] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_014F06] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_014F06] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_014F06] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_014F06] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_014F06] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_014F06] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_014F06] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_014F06] = 146                      
		  ,[AHU10_014F06] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_014F06] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_014F07] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_014F07] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_014F07] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_014F07] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_014F07] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_014F07] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_014F07] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_014F07] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_014F07] = 147                      
		  ,[AHU10_014F07] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_014F07] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_014F08] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_014F08] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_014F08] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_014F08] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_014F08] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_014F08] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_014F08] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_014F08] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_014F08] = 148                      
		  ,[AHU10_014F08] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_014F08] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_014F09] = ROUND(RAND() * 1, 0)
		  ,[AHU02_014F09] = ROUND(RAND() * 1, 0)
		  ,[AHU03_014F09] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_014F09] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_014F09] = ROUND(RAND() * 5, 0)+29
		  ,[AHU06_014F09] = ROUND(RAND() * 3, 0)+60
		  ,[AHU07_014F09] = ROUND(RAND() * 5, 0)+26
		  ,[AHU08_014F09] = ROUND(RAND() * 3, 0)+50
		  ,[AHU09_014F09] = 149
		  ,[AHU10_014F09] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_014F09] = ROUND(RAND() * 54, 0)+6
		  ,[AHU01_014F10] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_014F10] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_014F10] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_014F10] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_014F10] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_014F10] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_014F10] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_014F10] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_014F10] = 1410                      
		  ,[AHU10_014F10] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_014F10] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_014F11] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_014F11] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_014F11] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_014F11] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_014F11] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_014F11] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_014F11] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_014F11] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_014F11] = 1411                      
		  ,[AHU10_014F11] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_014F11] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_014F12] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_014F12] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_014F12] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_014F12] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_014F12] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_014F12] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_014F12] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_014F12] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_014F12] = 1412                      
		  ,[AHU10_014F12] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_014F12] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_014F13] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_014F13] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_014F13] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_014F13] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_014F13] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_014F13] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_014F13] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_014F13] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_014F13] = 1413                      
		  ,[AHU10_014F13] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_014F13] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_014F14] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_014F14] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_014F14] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_014F14] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_014F14] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_014F14] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_014F14] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_014F14] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_014F14] = 1414                      
		  ,[AHU10_014F14] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_014F14] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_014F15] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_014F15] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_014F15] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_014F15] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_014F15] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_014F15] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_014F15] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_014F15] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_014F15] = 1415                      
		  ,[AHU10_014F15] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_014F15] = ROUND(RAND() * 54, 0)+6 
		  ,[AHU01_014F16] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_014F16] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_014F16] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_014F16] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_014F16] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_014F16] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_014F16] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_014F16] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_014F16] = 1416                      
		  ,[AHU10_014F16] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_014F16] = ROUND(RAND() * 54, 0)+6 

	--AHU_S03
	UPDATE [dbo].[AHU_S03]
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()
		  ,[AHU01_S03F01] = ROUND(RAND() * 1, 0)
		  ,[AHU02_S03F01] = ROUND(RAND() * 1, 0)
		  ,[AHU03_S03F01] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_S03F01] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_S03F01] = ROUND(RAND() * 5, 0)+29
		  ,[AHU06_S03F01] = ROUND(RAND() * 3, 0)+60
		  ,[AHU07_S03F01] = ROUND(RAND() * 5, 0)+26
		  ,[AHU08_S03F01] = ROUND(RAND() * 3, 0)+50
		  ,[AHU09_S03F01] = 310
		  ,[AHU10_S03F01] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_S03F01] = ROUND(RAND() * 54, 0)+6

	--AHU_SB1
	UPDATE [dbo].[AHU_SB1]
	   SET [AUTOID] = CONVERT(int, right(left(replace(replace(replace(replace(CONVERT(varchar(50),GETDATE(),126),'-',''),':',''),'T',''),'.',''),14),10))
		  ,[DATETIME] = GETDATE()
		  ,[AHU01_SB1F01] = ROUND(RAND() * 1, 0)
		  ,[AHU02_SB1F01] = ROUND(RAND() * 1, 0)
		  ,[AHU03_SB1F01] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_SB1F01] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_SB1F01] = ROUND(RAND() * 5, 0)+29
		  ,[AHU06_SB1F01] = ROUND(RAND() * 3, 0)+60
		  ,[AHU07_SB1F01] = ROUND(RAND() * 5, 0)+26
		  ,[AHU08_SB1F01] = ROUND(RAND() * 3, 0)+50
		  ,[AHU09_SB1F01] = 311
		  ,[AHU10_SB1F01] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_SB1F01] = ROUND(RAND() * 54, 0)+6
		  ,[AHU01_SB1F02] = ROUND(RAND() * 1, 0)    
		  ,[AHU02_SB1F02] = ROUND(RAND() * 1, 0)    
		  ,[AHU03_SB1F02] = ROUND(RAND() * 10, 0)*10
		  ,[AHU04_SB1F02] = ROUND(RAND() * 10, 0)*10
		  ,[AHU05_SB1F02] = ROUND(RAND() * 5, 0)+29 
		  ,[AHU06_SB1F02] = ROUND(RAND() * 3, 0)+60 
		  ,[AHU07_SB1F02] = ROUND(RAND() * 5, 0)+26 
		  ,[AHU08_SB1F02] = ROUND(RAND() * 3, 0)+50 
		  ,[AHU09_SB1F02] = 312                     
		  ,[AHU10_SB1F02] = ROUND(RAND() * 10, 0)*10
		  ,[AHU11_SB1F02] = ROUND(RAND() * 54, 0)+6 

END
