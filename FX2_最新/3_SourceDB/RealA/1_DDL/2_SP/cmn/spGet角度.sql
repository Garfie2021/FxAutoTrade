USE OANDA_DemoB
GO

DROP PROCEDURE [cmn].[spGet角度]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGet角度]
	@高さy	float,
	@角度	float	output
AS
BEGIN

	-- 	SELECT (ATAN((@買いWMA - @買いWMA_1つ前) / 1) * 180 / PI()) as 上昇角度;

	-- 底辺xは「1」固定。
	-- 底辺xに対して高さyの上昇角度(+-)を求める。
	Set @角度 = (ATAN(@高さy / 1) * 180 / PI());

END

GO

