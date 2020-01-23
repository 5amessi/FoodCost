USE [FoodCost]
GO
DECLARE @sql VARCHAR(MAX) = ''
        , @crlf VARCHAR(2) = CHAR(13) + CHAR(10) ;

SELECT @sql = @sql + 'DROP VIEW ' + QUOTENAME(SCHEMA_NAME(schema_id)) + '.' + QUOTENAME(v.name) +';' + @crlf
FROM   sys.views v

PRINT @sql;
EXEC(@sql);
IF NOT EXISTS(SELECT * FROM sysobjects WHERE name = 'BeginningEndingMonth' ) 
	CREATE TABLE[dbo].BeginningEndingMonth (Year varchar(50),Month varchar(50),FromDate datetime,ToDate datetime,Restaurant_ID int,Kitchen_ID int,Item_ID bigint,Qty bigint,Cost float);
