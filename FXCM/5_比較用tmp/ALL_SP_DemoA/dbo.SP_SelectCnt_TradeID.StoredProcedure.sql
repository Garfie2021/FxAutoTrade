USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_SelectCnt_TradeID]
	@TradeID	varchar(100),
	@Cnt		int		output
AS
BEGIN

	/*
	DECLARE @TradeID	varchar(100)
	DECLARE @Cnt		int
	*/

	SELECT
		@Cnt = COUNT(*)
	FROM
		dbo.T_ClosedTrades
	WHERE
		(TradeID = @TradeID)

	--select @Limit as limit

END

GO
