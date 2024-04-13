USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [hltc].[SP_Select取引状況でデータ不足が発生した件数]
AS
BEGIN

	SELECT TOP 1000 *
	FROM [FX_DemoA].[hltc].[T_システム異常発生件数_Daily]
	ORDER By [年月日] desc

	SELECT TOP 1000 *
	FROM [FX_RealA].[hltc].[T_システム異常発生件数_Daily]
	ORDER By [年月日] desc

	SELECT TOP 1000 *
	FROM [FX_RealB].[hltc].[T_システム異常発生件数_Daily]
	ORDER By [年月日] desc

END


GO
