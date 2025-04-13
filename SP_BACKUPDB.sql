USE [DataGuardXcore]
GO

/****** Object:  StoredProcedure [dbo].[SP_BACKUPDB]    Script Date: 15/9/2024 1:36:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_BACKUPDB]
AS
DECLARE @strBackup nvarchar(200)
DECLARE @strBackupIshopX nvarchar(200)
--DECLARE @strToday nvarchar(8)
--DECLARE @strTime nvarchar(8)
--SELECT @strToday = CONVERT(CHAR(8), GETDATE(), 112)
--SELECT @strTime = LEFT(CONVERT(CHAR(8), GETDATE(), 108), 2) + SUBSTRING(CONVERT(CHAR(8), GETDATE(), 108), 4, 2) + RIGHT(CONVERT(CHAR(8), GETDATE(), 108), 2)

DECLARE @str varchar(200)
set @str = replace(replace(replace(CONVERT(varchar, getdate(), 120 ),'-',''),' ',''),':','')
  
SET @strBackup = 'C:\DataBaseBAK\DataGuardXcore_' + @str + '.bak'

SET @strBackupIshopX = 'C:\DataBaseBAK\IshopX559_' + @str + '.bak'

BACKUP DATABASE DataGuardXcore
TO DISK= @strBackup
WITH FORMAT

BACKUP DATABASE IshopX559
TO DISK= @strBackupIshopX
WITH FORMAT

GO

