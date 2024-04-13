USE OANDA_DemoB
GO

DROP PROCEDURE [oder].[spCnt当日注文数]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spCnt当日注文数]
    @口座No	Int,
	@from	DateTime,
	@Cnt	int			output
AS
BEGIN
	/*
	declare @from	DateTime = '2017/05/08 6:00:00'

	SELECT *
	FROM [oder].[tOrderHistory2]
	WHERE ([日時] >= @from)
	order by [日時] 
	*/

	SELECT @Cnt = COUNT(*)
	FROM [oder].[tOrderHistory2]
	WHERE 口座No = @口座No AND [日時] >= @from;
END
GO
/*
*/

