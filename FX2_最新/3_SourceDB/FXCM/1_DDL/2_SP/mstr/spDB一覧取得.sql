USE [FXCM]
GO
/*
*/
DROP PROCEDURE [mstr].[spDBˆê——Žæ“¾]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [mstr].[spDBˆê——Žæ“¾]
AS
BEGIN

	select name
	from sys.databases
	where name like '%FXCM%' or name like '%OANDA%'
	order by name;

END
GO
/*
*/