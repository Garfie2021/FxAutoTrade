USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [cmn].[SP_Get上昇角度]
	@底辺x_月		float,
	@高さy_上昇値	float,
	@上昇角度		float	output
AS
BEGIN

	Set @上昇角度 = (ATAN(@高さy_上昇値 / @底辺x_月) * 180 / PI());

END


GO
