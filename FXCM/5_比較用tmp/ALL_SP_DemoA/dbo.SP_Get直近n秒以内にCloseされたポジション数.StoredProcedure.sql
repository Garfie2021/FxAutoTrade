USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Get直近n秒以内にCloseされたポジション数]
	@通貨ペア名		varchar(20),
	@now			datetime,
	@直近n秒		int = 30,
	@Cnt			tinyint	output	-- 0：Closeポジション無し  1：Closeポジション有り
AS
BEGIN

	/*
	DECLARE @通貨ペア名 varchar(20) = 'GBP/JPY'
	DECLARE @now datetime = getdate()
	DECLARE @直近n秒 int = -30
	DECLARE @判定 tinyint
	*/

	--select @now as now, DATEADD(second, @直近n秒, @now)

	select @Cnt = count(*)
	--select *
	from dbo.T_ClosedTrades
	where [Instrument] = @通貨ペア名 
	and DATEADD(second, @直近n秒, @now) < CloseTime 
	and CloseTime <= @now
	--order by CloseTime desc

END

GO
