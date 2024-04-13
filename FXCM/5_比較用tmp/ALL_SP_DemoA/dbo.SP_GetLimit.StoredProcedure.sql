USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_GetLimit]
	@通貨ペアNo		tinyint,
	@現在日時		datetime,	-- シュミレーションを行う場合は、この日付を変更する
	@割合			float,		-- 1 ～ 0.01
	@Limit			float	output
AS
BEGIN

	/*
	DECLARE @通貨ペアNo		tinyint = 12
	DECLARE @現在日時		datetime = getdate()
	DECLARE @割合			float = 0.2
	DECLARE @Limit			float
	*/

	DECLARE @2つ前_日時 datetime;
	DECLARE @2つ前_買い_始値 float;
	DECLARE @2つ前_買い_高値 float;
	DECLARE @2つ前_買い_安値 float;
	DECLARE @2つ前_買い_終値 float;
	DECLARE @2つ前_売り_始値 float;
	DECLARE @2つ前_売り_高値 float;
	DECLARE @2つ前_売り_安値 float;
	DECLARE @2つ前_売り_終値 float;

	DECLARE @1つ前_日時 datetime;
	DECLARE @1つ前_買い_始値 float;
	DECLARE @1つ前_買い_高値 float;
	DECLARE @1つ前_買い_安値 float;
	DECLARE @1つ前_買い_終値 float;
	DECLARE @1つ前_売り_始値 float;
	DECLARE @1つ前_売り_高値 float;
	DECLARE @1つ前_売り_安値 float;
	DECLARE @1つ前_売り_終値 float;

	DECLARE @今_日時 datetime;
	DECLARE @今_買い_始値 float;
	DECLARE @今_買い_高値 float;
	DECLARE @今_買い_安値 float;
	DECLARE @今_買い_終値 float;
	DECLARE @今_売り_始値 float;
	DECLARE @今_売り_高値 float;
	DECLARE @今_売り_安値 float;
	DECLARE @今_売り_終値 float;

	DECLARE cursor_RateHistory_15m CURSOR FOR
	SELECT TOP 3 [日時], [買い_始値], [買い_高値], [買い_安値], [買い_終値], [売り_始値], [売り_高値], [売り_安値], [売り_終値]
	FROM [dbo].[T_RateHistory_15m]
	where 通貨ペアNo = @通貨ペアNo and [日時] < @現在日時
	order by [日時]

	open cursor_RateHistory_15m;

	FETCH NEXT FROM cursor_RateHistory_15m INTO @2つ前_日時, @2つ前_買い_始値, @2つ前_買い_高値, @2つ前_買い_安値, @2つ前_買い_終値, @2つ前_売り_始値, @2つ前_売り_高値, @2つ前_売り_安値, @2つ前_売り_終値;
	FETCH NEXT FROM cursor_RateHistory_15m INTO @1つ前_日時, @1つ前_買い_始値, @1つ前_買い_高値, @1つ前_買い_安値, @1つ前_買い_終値, @1つ前_売り_始値, @1つ前_売り_高値, @1つ前_売り_安値, @1つ前_売り_終値;
	FETCH NEXT FROM cursor_RateHistory_15m INTO @今_日時, @今_買い_始値, @今_買い_高値, @今_買い_安値, @今_買い_終値, @今_売り_始値, @今_売り_高値, @今_売り_安値, @今_売り_終値;

	DECLARE @Rate差 float;
	Set @Rate差 = @2つ前_買い_高値 - @2つ前_買い_安値;
	Set @Rate差 = @Rate差 + @1つ前_買い_高値 - @1つ前_買い_安値;
	Set @Rate差 = @Rate差 + @今_買い_高値 - @今_買い_安値;

	--Set @Limit = convert(varchar, (@Rate差 / 3) * @割合);
	Set @Limit = (@Rate差 / 3) * @割合;

	--select @Limit as limit

END


GO
