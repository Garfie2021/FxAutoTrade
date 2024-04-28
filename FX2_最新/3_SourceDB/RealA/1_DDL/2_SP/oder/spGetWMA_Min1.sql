USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [oder].[spGetWMA_Min1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spGetWMA_Min1]
	@�ʉ݃y�ANo		tinyint,
	@StartDate		datetime,
	@����WMAs2		float		output,
	@����WMAs14		float		output,
	@����WMAs2		float		output,
	@����WMAs14		float		output,
	@����WMAs2�p�x	float		output,
	@����WMAs2�p�x	float		output
AS
BEGIN
	/*
	SELECT TOP 1 *
	FROM [hstr].[tMin1]
	where �ʉ݃y�ANo = 0 and [StartDate] = '2017/08/14 00:35:00'
	order by [StartDate] desc;
	*/

	SELECT TOP 1 
		@����WMAs2		= [����WMAs2], 
		@����WMAs14		= [����WMAs14], 
		@����WMAs2		= [����WMAs2], 
		@����WMAs14		= [����WMAs14],
		@����WMAs2�p�x	= [����WMAs2�p�x], 
		@����WMAs2�p�x	= [����WMAs2�p�x]
	FROM [hstr].[tMin1]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] = @StartDate
	order by [StartDate] desc;

END
GO
/*
*/

