USE OANDA_RealA
GO
/*
*/
DROP PROCEDURE [pfmc].[spSelectExecLog]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pfmc].[spSelectExecLog]
	@����No int,
	@from	DateTime,
	@to		DateTime
AS
BEGIN

	SELECT 
		 a.[�ʉ݃y�ANo]
		,b.[�y�A��] as �ʉ݃y�A��
		,a.[�����]
		,COUNT(a.[�ʉ݃y�ANo]) as Count
	FROM [pfmc].[tExecLog] as a LEFT JOIN [cmn].[t�ʉ݃y�AMst] as b ON a.[�ʉ݃y�ANo] = b.[No]
	where [����No] = @����No AND @from <= a.[ExecDate] and a.[ExecDate] < @to
	group by a.[�ʉ݃y�ANo],b.[�y�A��], a.[�����]
	order by a.[�ʉ݃y�ANo] --, [ExecDate]

END
GO
/*
*/