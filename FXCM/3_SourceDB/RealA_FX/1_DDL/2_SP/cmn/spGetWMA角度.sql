USE [DemoA_FX]
GO

DROP PROCEDURE [cmn].[spGetWMA角度]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGetWMA角度]
	@買いWMAs2			float,
	@買いWMAs2_1つ前	float,
	@買いWMAs2角度		float	output,
	@売りWMAs2			float,
	@売りWMAs2_1つ前	float,
	@売りWMAs2角度		float	output
AS
BEGIN

	Declare @高さy_上昇値_買い_S2 float = @買いWMAs2 - @買いWMAs2_1つ前;
	EXECUTE [cmn].[spGet角度] @高さy_上昇値_買い_S2, @買いWMAs2角度 OUTPUT;

	Declare @高さy_上昇値_売りRate_S2 float = @売りWMAs2 - @売りWMAs2_1つ前;
	EXECUTE [cmn].[spGet角度] @高さy_上昇値_売りRate_S2, @売りWMAs2角度 OUTPUT;

END
GO

