USE OANDA_DemoB
GO

DROP PROCEDURE [oder].[spCnt����������]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spCnt����������]
    @����No	Int,
	@from	DateTime,
	@Cnt	int			output
AS
BEGIN
	/*
	declare @from	DateTime = '2017/05/08 6:00:00'

	SELECT *
	FROM [oder].[tOrderHistory2]
	WHERE ([����] >= @from)
	order by [����] 
	*/

	SELECT @Cnt = COUNT(*)
	FROM [oder].[tOrderHistory2]
	WHERE ����No = @����No AND [����] >= @from;
END
GO
/*
*/

