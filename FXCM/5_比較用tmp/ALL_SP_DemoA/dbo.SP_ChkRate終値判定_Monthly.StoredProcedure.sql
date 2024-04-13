USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_ChkRate終値判定_Monthly]
	@通貨ペアNo		tinyint,
	@売買モード		varchar(5),
	@now			datetime,
	@判定			tinyint	output
AS
BEGIN

	DECLARE @今月_買い_安値 float;
	DECLARE @今月_買い_終値 float;
	DECLARE @今月_売り_高値 float;
	DECLARE @今月_売り_終値 float;
	DECLARE @1ヵ月前_買い_安値 float;
	DECLARE @1ヵ月前_買い_終値 float;
	DECLARE @1ヵ月前_売り_高値 float;
	DECLARE @1ヵ月前_売り_終値 float;

	DECLARE cursor_RateHistory_Monthly CURSOR FOR
	SELECT TOP 2 買い_安値, 買い_終値, 売り_高値, 売り_終値
	FROM [dbo].[T_RateHistory_Monthly]
	where 通貨ペアNo = @通貨ペアNo and [日時] <= @now
	order by [日時] desc

	open cursor_RateHistory_Monthly;
	
	FETCH NEXT FROM cursor_RateHistory_Monthly INTO @今月_買い_安値, @今月_買い_終値, @今月_売り_高値, @今月_売り_終値;
	FETCH NEXT FROM cursor_RateHistory_Monthly INTO @1ヵ月前_買い_安値, @1ヵ月前_買い_終値, @1ヵ月前_売り_高値, @1ヵ月前_売り_終値;

	CLOSE cursor_RateHistory_Monthly;
	DEALLOCATE cursor_RateHistory_Monthly;

	if @売買モード = '買い'
	begin
		if @1ヵ月前_買い_安値 > @今月_買い_終値
		begin
			Set @判定 = 0;	-- Orderを出すのは危険
		end
		else
		begin
			Set @判定 = 1;	-- Orderを出しても大丈夫
		end
	end
	else
	begin
		if @1ヵ月前_売り_高値 < @今月_売り_終値
		begin
			Set @判定 = 0;	-- Orderを出すのは危険
		end
		else
		begin
			Set @判定 = 1;	-- Orderを出しても大丈夫
		end
	end

	--select @判定

END


GO
