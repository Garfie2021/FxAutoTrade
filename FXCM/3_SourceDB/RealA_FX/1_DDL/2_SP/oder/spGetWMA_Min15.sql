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
	@通貨ペアNo		tinyint,
	@StartDate		datetime,
	@買いWMAs2		float		output,
	@買いWMAs14		float		output,
	@売りWMAs2		float		output,
	@売りWMAs14		float		output,
	@買いWMAs2角度	float		output,
	@売りWMAs2角度	float		output
AS
BEGIN

	SELECT TOP 1 
		@買いWMAs2		= [買いWMAs2], 
		@買いWMAs14		= [買いWMAs14], 
		@売りWMAs2		= [売りWMAs2], 
		@売りWMAs14		= [売りWMAs14],
		@買いWMAs2角度	= [買いWMAs2角度], 
		@売りWMAs2角度	= [売りWMAs2角度]
	FROM [hstr].[tMin15]
	where 通貨ペアNo = @通貨ペアNo and [StartDate] = @StartDate
	order by [StartDate] desc;

END
GO
/*
*/

