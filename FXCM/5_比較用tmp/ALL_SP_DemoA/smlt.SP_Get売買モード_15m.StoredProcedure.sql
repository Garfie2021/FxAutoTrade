USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [smlt].[SP_Get売買モード_15m]
	@売買判定ロジック	tinyint = 0,
	@通貨ペアNo			int,
	@現在日時			datetime,	-- シュミレーションを行う場合は、この日付を変更する
	@売買モード			varchar(5)	output
AS
BEGIN

	if @売買判定ロジック = 0
	begin
		-- DMI一般の判定ロジック
		DECLARE @買い_DI_plus float;
		DECLARE @買い_DI_minus float;
		DECLARE @売り_DI_plus float;
		DECLARE @売り_DI_minus float;

		SELECT TOP 1
		 @買い_DI_plus = [DMI_買い_DI_plus]
		,@買い_DI_minus = [DMI_買い_DI_minus]
		,@売り_DI_plus = [DMI_売り_DI_plus]
		,@売り_DI_minus = [DMI_売り_DI_minus]
		FROM [smlt].[T_Indicator_15m]
		where 通貨ペアNo = @通貨ペアNo and [日時] <= @現在日時
		order by 日時 desc

		if @買い_DI_plus > @買い_DI_minus
		begin
			Set @売買モード = '買い'
		end
		else if @売り_DI_plus < @売り_DI_minus
		begin
			Set @売買モード = '売り'
		end
		else
		begin
			Set @売買モード = '不明'
		end

	end

END


GO
