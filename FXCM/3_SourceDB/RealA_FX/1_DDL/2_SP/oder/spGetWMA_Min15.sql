USE [RealB_2370741683_FX]
GO
/*
*/
DROP PROCEDURE [oder].[spGetWMA_Min15]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spGetWMA_Min15]
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

	SELECT TOP 1 
		@����WMAs2		= [����WMAs2], 
		@����WMAs14		= [����WMAs14], 
		@����WMAs2		= [����WMAs2], 
		@����WMAs14		= [����WMAs14],
		@����WMAs2�p�x	= [����WMAs2�p�x], 
		@����WMAs2�p�x	= [����WMAs2�p�x]
	FROM [hstr].[tMin15]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] = @StartDate
	order by [StartDate] desc;

END
GO
/*
*/

