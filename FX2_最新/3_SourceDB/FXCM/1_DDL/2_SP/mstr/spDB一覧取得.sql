USE [FXCM]
GO
/*
*/
DROP PROCEDURE [mstr].[spDB�ꗗ�擾]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [mstr].[spDB�ꗗ�擾]
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