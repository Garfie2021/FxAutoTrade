USE OANDA_DemoB
GO

DROP PROCEDURE [system].[spExecSql]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [system].[spExecSql]
	@sql		varchar(500)
AS
BEGIN

	sp_executesql(@sql);

END
GO

