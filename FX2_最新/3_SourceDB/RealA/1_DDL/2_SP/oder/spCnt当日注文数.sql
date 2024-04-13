USE OANDA_DemoB
GO

DROP PROCEDURE [oder].[spCnt“–“ú’•¶”]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spCnt“–“ú’•¶”]
    @ŒûÀNo	Int,
	@from	DateTime,
	@Cnt	int			output
AS
BEGIN
	/*
	declare @from	DateTime = '2017/05/08 6:00:00'

	SELECT *
	FROM [oder].[tOrderHistory2]
	WHERE ([“úŽž] >= @from)
	order by [“úŽž] 
	*/

	SELECT @Cnt = COUNT(*)
	FROM [oder].[tOrderHistory2]
	WHERE ŒûÀNo = @ŒûÀNo AND [“úŽž] >= @from;
END
GO
/*
*/

