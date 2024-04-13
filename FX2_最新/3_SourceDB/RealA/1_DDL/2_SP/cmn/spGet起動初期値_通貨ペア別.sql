USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [cmn].[spGet起動初期値_通貨ペア別]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGet起動初期値_通貨ペア別]
	@通貨ペアNo			tinyint,
	@通貨ペア名_Oanda	varchar(10),
	@買い売りRate差		float	output,
	@差分ストップ		float	output,
	@差分リミット通常	float	output,
	@差分リミットBS		float	output,
	@注文禁止Rate幅		float	output,
	@最終注文日時		datetime	output,
	@ポジションClose最終日時	datetime	output
AS
BEGIN

	SET NOCOUNT ON;

	/*
	DECLARE @通貨ペアNo			tinyint = 50;
	DECLARE @買い売りRate差		float;
	DECLARE @差分ストップ		float;
	DECLARE @差分リミット通常	float;
	DECLARE @差分リミットBS		float;
	DECLARE @注文禁止Rate幅		float;
	DECLARE @最終注文日時		datetime;
	*/

	DECLARE @Rate高値安値差_1Day	float;

	SELECT top 1 @買い売りRate差 = [売りRate] - [買いRate]
	FROM [hstr].[tSec]
	where @通貨ペアNo = [通貨ペアNo] AND [買いRate] > 0.00001 AND [売りRate] > 0.00001
	order by [StartDate] desc;

	SELECT @Rate高値安値差_1Day = AVG([買いRate_高値] - [買いRate_安値])
	FROM (
		SELECT top 5 [買いRate_高値], [買いRate_安値]
		FROM [hstr].[tDay1]
		WHERE [通貨ペアNo] = @通貨ペアNo
		ORDER BY [StartDate] DESC
	) as T;

	SET @差分ストップ = @買い売りRate差 + (@Rate高値安値差_1Day / 3);
	SET @差分リミット通常 = @買い売りRate差 + (@Rate高値安値差_1Day / 5);
	SET @差分リミットBS = @買い売りRate差 + (@Rate高値安値差_1Day / 2);
	SET @注文禁止Rate幅 = @買い売りRate差 + (@Rate高値安値差_1Day * 2);

	SELECT @最終注文日時 = MAX([日時])
	FROM [oder].[tOrderHistory2]
	WHERE [通貨ペアNo] = @通貨ペアNo;

	SELECT @ポジションClose最終日時 = MAX([time])
	FROM [oanda].[tTransaction]
	WHERE [instrument] = @通貨ペア名_Oanda AND [type] in ('TRADE_CLOSE', 'TAKE_PROFIT_FILLED');

	--select @買い売りRate差 as 買い売りRate差, @Rate高値安値差_1Day as Rate高値安値差_1Day, @差分リミット通常 as 差分リミット通常, @差分リミットBS as 差分リミットBS, @注文禁止Rate幅 as 注文禁止Rate幅;

END
GO
/*
*/
