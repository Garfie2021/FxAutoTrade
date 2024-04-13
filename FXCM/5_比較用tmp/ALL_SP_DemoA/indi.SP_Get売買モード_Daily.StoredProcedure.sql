USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [indi].[SP_Get売買モード_Daily]
	@通貨ペアNo			int,
	@現在日時			datetime,	-- シュミレーションを行う場合は、この日付を変更する
	@売買モード			varchar(5)	output
AS
BEGIN

	-- DailyのRateとASIで、その日が買い方向か、売り方向かを予測。
	-- どちらも、上昇、下降に片側に傾いている場合は、その方向でしかOrderを出さない。
	-- RateとASIが相反している日は、Orderを出さない。

	-- とりあえずは、Rateの方向だけで判断。

	DECLARE @買い_始値 float;
	DECLARE @買い_終値 float;

	SELECT TOP 1 @買い_始値 = [買い_始値], @買い_終値 = [買い_終値]
	FROM [dbo].[T_RateHistory_Daily]
	where 通貨ペアNo = @通貨ペアNo and [日時] <= @現在日時
	order by 日時 desc

	if @買い_始値 < @買い_終値
	begin
		Set @売買モード = '買い';
	end
	else
	begin
		Set @売買モード = '売り';
	end


END


GO
