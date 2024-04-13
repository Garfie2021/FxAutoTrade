USE [FXCM]
GO
/*
*/
DROP PROCEDURE [mstr].[spDB一覧取得]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [mstr].[spDB一覧取得]
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