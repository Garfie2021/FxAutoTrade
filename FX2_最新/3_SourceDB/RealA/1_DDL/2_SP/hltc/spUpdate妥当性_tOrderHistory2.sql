USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [hltc].[spUpdate妥当性_tOrderHistory2]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [hltc].[spUpdate妥当性_tOrderHistory2]
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE	@妥当性	[varchar](1000) = '';

	DECLARE	@通貨ペアNo	tinyint;
	DECLARE	@日時		datetime;
	DECLARE	@買いSwap	float;
	DECLARE	@売りSwap	float;
	DECLARE	@Swap判定	varchar(1);		-- 0:売り　1:買い
	DECLARE	@買いRate	float;
	DECLARE	@売りRate	float;
	DECLARE	@売買判定	varchar(1);		-- S:売り　B:買い
	DECLARE	@売買		bit;		-- 0:売り　1:買い	※最終的に判断された売買判定
	DECLARE	@保持ポジション					varchar(1);		-- NULL:保持ポジション無し　0:売り　1:買い
	DECLARE	@BS_Min15_買いWMAs14			float;
	DECLARE	@BS_Min15_買いWMAs14角度		float;

	DECLARE	@BS_Min15_買いWMAs14角度シグマ	float;
	DECLARE	@BS_Min15_売りWMAs14			float;
	DECLARE	@BS_Min15_売りWMAs14角度		float;
	DECLARE	@BS_Min15_売りWMAs14角度シグマ	float;
	DECLARE	@BS_WMA判定_15m		varchar(1);		-- S:売り　B:買い
	DECLARE	@BS判定_15m			varchar(1);		-- S:売り　B:買い
	DECLARE	@BS開始				bit;		-- 0:BB開始ではなくWMA判定　1:BB開始
	DECLARE	@BS判定_前			varchar(1);		-- B:BonusStage中　ブランク:BonusStageではない
	DECLARE	@BS判定_今			varchar(1);		-- B:BonusStage中　ブランク:BonusStageではない
	DECLARE	@差分リミット		float;
	DECLARE	@買いリミット		float;
	DECLARE	@売りリミット		float;
	DECLARE	@注文単位			int;
	DECLARE	@Month1_Start		datetime;
	DECLARE	@Month1_End			datetime;
	DECLARE	@Month1_買いWMAs2		float;
	DECLARE	@Month1_買いWMAs2角度	float;
	DECLARE	@Month1_買いWMAs14		float;
	DECLARE	@Month1_売りWMAs2		float;
	DECLARE	@Month1_売りWMAs2角度	float;
	DECLARE	@Month1_売りWMAs14		float;
	DECLARE	@Week1_Start			datetime;
	DECLARE	@Week1_End				datetime;
	DECLARE	@Week1_買いWMAs2		float;
	DECLARE	@Week1_買いWMAs2角度	float;
	DECLARE	@Week1_買いWMAs14		float;
	DECLARE	@Week1_売りWMAs2		float;
	DECLARE	@Week1_売りWMAs2角度	float;
	DECLARE	@Week1_売りWMAs14		float;
	DECLARE	@Day1_Start			datetime;
	DECLARE	@Day1_End			datetime;
	DECLARE	@Day1_買いWMAs2		float;
	DECLARE	@Day1_買いWMAs14	float;
	DECLARE	@Day1_買いWMAs2角度	float;
	DECLARE	@Day1_売りWMAs2		float;
	DECLARE	@Day1_売りWMAs14	float;
	DECLARE	@Day1_売りWMAs2角度	float;
	DECLARE	@Hour1_Start		datetime;
	DECLARE	@Hour1_End			datetime;
	DECLARE	@Hour1_買いWMAs2		float;
	DECLARE	@Hour1_買いWMAs2角度	float;
	DECLARE	@Hour1_買いWMAs14		float;
	DECLARE	@Hour1_売りWMAs2		float;
	DECLARE	@Hour1_売りWMAs2角度	float;
	DECLARE	@Hour1_売りWMAs14		float;
	DECLARE	@Min15_Start			datetime;
	DECLARE	@Min15_End				datetime;
	DECLARE	@Min15_買いWMAs2		float;
	DECLARE	@Min15_買いWMAs2角度	float;
	DECLARE	@Min15_買いWMAs14		float;
	DECLARE	@Min15_売りWMAs2		float;
	DECLARE	@Min15_売りWMAs2角度	float;
	DECLARE	@Min15_売りWMAs14		float;
	DECLARE	@Min5_Start			datetime;
	DECLARE	@Min5_End			datetime;
	DECLARE	@Min5_買いWMAs2		float;
	DECLARE	@Min5_買いWMAs2角度	float;
	DECLARE	@Min5_買いWMAs14	float;
	DECLARE	@Min5_売りWMAs2		float;
	DECLARE	@Min5_売りWMAs2角度	float;
	DECLARE	@Min5_売りWMAs14	float;
	DECLARE	@Min1_Start			datetime;
	DECLARE	@Min1_End			datetime;
	DECLARE	@Min1_買いWMAs2		float;
	DECLARE	@Min1_買いWMAs2角度	float;
	DECLARE	@Min1_買いWMAs14	float;
	DECLARE	@Min1_売りWMAs2		float;
	DECLARE	@Min1_売りWMAs2角度	float;
	DECLARE	@Min1_売りWMAs14	float;
	DECLARE	@Oanda_TradeData_id	BigInt;

	DECLARE cursor_OrderHistory2 CURSOR FOR
	SELECT  
		[通貨ペアNo],
		[日時],
		[買いSwap],
		[売りSwap],
		[Swap判定],		-- 0:売り　1:買い
		[買いRate],
		[売りRate],
		[売買判定],		-- S:売り　B:買い
		[売買],		-- 0:売り　1:買い	※最終的に判断された売買判定
		[保持ポジション],		-- NULL:保持ポジション無し　0:売り　1:買い
		[BS_Min15_買いWMAs14],
		[BS_Min15_買いWMAs14角度],
		[BS_Min15_買いWMAs14角度シグマ],
		[BS_Min15_売りWMAs14],
		[BS_Min15_売りWMAs14角度],
		[BS_Min15_売りWMAs14角度シグマ],
		[BS_WMA判定_15m],		-- S:売り　B:買い
		[BS判定_15m],		-- S:売り　B:買い
		[BS開始],		-- 0:BB開始ではなくWMA判定　1:BB開始
		[BS判定_前],		-- B:BonusStage中　ブランク:BonusStageではない
		[BS判定_今],		-- B:BonusStage中　ブランク:BonusStageではない
		[差分リミット],
		[買いリミット],
		[売りリミット],
		[注文単位],
		[Month1_Start],
		[Month1_End],
		[Month1_買いWMAs2],
		[Month1_買いWMAs2角度],
		[Month1_買いWMAs14],
		[Month1_売りWMAs2],
		[Month1_売りWMAs2角度],
		[Month1_売りWMAs14],
		[Week1_Start],
		[Week1_End],
		[Week1_買いWMAs2],
		[Week1_買いWMAs2角度],
		[Week1_買いWMAs14],
		[Week1_売りWMAs2],
		[Week1_売りWMAs2角度],
		[Week1_売りWMAs14],
		[Day1_Start],
		[Day1_End],
		[Day1_買いWMAs2],
		[Day1_買いWMAs14],
		[Day1_買いWMAs2角度],
		[Day1_売りWMAs2],
		[Day1_売りWMAs14],
		[Day1_売りWMAs2角度],
		[Hour1_Start],
		[Hour1_End],
		[Hour1_買いWMAs2],
		[Hour1_買いWMAs2角度],
		[Hour1_買いWMAs14],
		[Hour1_売りWMAs2],
		[Hour1_売りWMAs2角度],
		[Hour1_売りWMAs14],
		[Min15_Start],
		[Min15_End],
		[Min15_買いWMAs2],
		[Min15_買いWMAs2角度],
		[Min15_買いWMAs14],
		[Min15_売りWMAs2],
		[Min15_売りWMAs2角度],
		[Min15_売りWMAs14],
		[Min5_Start],
		[Min5_End],
		[Min5_買いWMAs2],
		[Min5_買いWMAs2角度],
		[Min5_買いWMAs14],
		[Min5_売りWMAs2],
		[Min5_売りWMAs2角度],
		[Min5_売りWMAs14],
		[Min1_Start],
		[Min1_End],
		[Min1_買いWMAs2],
		[Min1_買いWMAs2角度],
		[Min1_買いWMAs14],
		[Min1_売りWMAs2],
		[Min1_売りWMAs2角度],
		[Min1_売りWMAs14],
		[Oanda_TradeData_id]
	FROM [oder].[tOrderHistory2]
	where [妥当性] is null;

	open cursor_OrderHistory2;
	

	FETCH NEXT FROM cursor_OrderHistory2 INTO @通貨ペアNo, @日時, @買いSwap, @売りSwap, @Swap判定, @買いRate, @売りRate, @売買判定, @売買, @保持ポジション, @BS_Min15_買いWMAs14, @BS_Min15_買いWMAs14角度, @BS_Min15_買いWMAs14角度シグマ, @BS_Min15_売りWMAs14, @BS_Min15_売りWMAs14角度, @BS_Min15_売りWMAs14角度シグマ, @BS_WMA判定_15m, @BS判定_15m, @BS開始, @BS判定_前, @BS判定_今, @差分リミット, @買いリミット, @売りリミット, @注文単位, @Month1_Start, @Month1_End, @Month1_買いWMAs2, @Month1_買いWMAs2角度, @Month1_買いWMAs14, @Month1_売りWMAs2, @Month1_売りWMAs2角度, @Month1_売りWMAs14, @Week1_Start, @Week1_End, @Week1_買いWMAs2, @Week1_買いWMAs2角度, @Week1_買いWMAs14, @Week1_売りWMAs2, @Week1_売りWMAs2角度, @Week1_売りWMAs14, @Day1_Start, @Day1_End, @Day1_買いWMAs2, @Day1_買いWMAs14, @Day1_買いWMAs2角度, @Day1_売りWMAs2, @Day1_売りWMAs14, @Day1_売りWMAs2角度, @Hour1_Start, @Hour1_End, @Hour1_買いWMAs2, @Hour1_買いWMAs2角度, @Hour1_買いWMAs14, @Hour1_売りWMAs2, @Hour1_売りWMAs2角度, @Hour1_売りWMAs14, @Min15_Start, @Min15_End, @Min15_買いWMAs2, @Min15_買いWMAs2角度, @Min15_買いWMAs14, @Min15_売りWMAs2, @Min15_売りWMAs2角度, @Min15_売りWMAs14, @Min5_Start, @Min5_End, @Min5_買いWMAs2, @Min5_買いWMAs2角度, @Min5_買いWMAs14, @Min5_売りWMAs2, @Min5_売りWMAs2角度, @Min5_売りWMAs14, @Min1_Start, @Min1_End, @Min1_買いWMAs2, @Min1_買いWMAs2角度, @Min1_買いWMAs14, @Min1_売りWMAs2, @Min1_売りWMAs2角度, @Min1_売りWMAs14, @Oanda_TradeData_id;

	declare @Cnt int = 0;
	WHILE @@FETCH_STATUS = 0
	BEGIN

		SET @妥当性 = '';

		IF @Swap判定 <> 'B' AND @Swap判定 <> 'S'
		BEGIN
			SET @妥当性 = @妥当性 + 'バグ1\r\n';
		END;

		IF @売買判定 <> 'B' AND @売買判定 <> 'S'
		BEGIN
			SET @妥当性 = @妥当性 + 'バグ2\r\n';
		END;

		IF @保持ポジション <> ''
		BEGIN
			IF @Swap判定 <> @保持ポジション
			BEGIN
				SET @妥当性 = @妥当性 + 'バグ4\r\n';
			END;
		END;

		IF @Swap判定 = 'B' AND @買いSwap < @売りSwap
		BEGIN
			SET @妥当性 = @妥当性 + 'バグ5\r\n';
		END
		ELSE IF @Swap判定 = 'S' AND @買いSwap > @売りSwap
		BEGIN
			SET @妥当性 = @妥当性 + 'バグ6\r\n';
		END;

		--IF @売買判定 = 'B' AND @買いRate < @売りRate
		--BEGIN
		--	SET @妥当性 = @妥当性 + 'バグ7\r\n';
		--END
		--ELSE IF @売買判定 = 'S' AND @買いRate > @売りRate
		--BEGIN
		--	SET @妥当性 = @妥当性 + 'バグ8\r\n';
		--END;

		IF @BS開始 = 1	--1:BB開始
		BEGIN
			IF @BS判定_前 != 'B' AND @BS判定_今 != '' AND @BS判定_15m != ''
			BEGIN
				SET @妥当性 = @妥当性 + 'バグ9\r\n';
			END;

			IF @BS_WMA判定_15m <> 'B' AND @BS_WMA判定_15m <> 'S'
			BEGIN
				SET @妥当性 = @妥当性 + 'バグ10\r\n';
			END;

			IF @BS_WMA判定_15m = 'B'
			BEGIN
				IF @BS_Min15_売りWMAs14角度シグマ < 2.5 
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ11\r\n';
				END;
			END
			ELSE IF @BS_WMA判定_15m = 'S'
			BEGIN
				IF @BS_Min15_売りWMAs14角度シグマ < 2.5 
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ12\r\n';
				END;
			END;
		END
		ELSE
		BEGIN
			-- 0:BB開始ではなくWMA判定
			IF @BS判定_前 != '' AND @BS判定_今 != 'B'
			BEGIN
				SET @妥当性 = @妥当性 + 'バグ13\r\n';
			END

			IF @売買判定 = 'B'
			BEGIN
				IF @Month1_買いWMAs2 < @Month1_買いWMAs14
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ14\r\n';
				END;
				IF @Month1_買いWMAs2角度 < 0
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ15\r\n';
				END;

				IF @Week1_買いWMAs2 < @Week1_買いWMAs14
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ16\r\n';
				END;
				IF @Week1_買いWMAs2角度 < 0
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ17\r\n';
				END;

				IF @Day1_買いWMAs2 < @Day1_買いWMAs14
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ18\r\n';
				END;
				IF @Day1_買いWMAs2角度 < 0
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ19\r\n';
				END;

				IF @Hour1_買いWMAs2 < @Hour1_買いWMAs14
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ20\r\n';
				END;
				IF @Hour1_買いWMAs2角度 < 0
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ21\r\n';
				END;

				IF @Min15_買いWMAs2 < @Min15_買いWMAs14
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ22\r\n';
				END;
				IF @Min15_買いWMAs2角度 < 0
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ23\r\n';
				END;

				IF @Min5_買いWMAs2 < @Min5_買いWMAs14
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ24\r\n';
				END;
				IF @Min5_買いWMAs2角度 < 0
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ25\r\n';
				END;

				IF @Min1_買いWMAs2 < @Min1_買いWMAs14
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ26\r\n';
				END;
				IF @Min1_買いWMAs2角度 < 0
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ27\r\n';
				END;
			END
			ELSE IF @売買判定 = 'S'
			BEGIN
				IF @Month1_売りWMAs2 > @Month1_売りWMAs14
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ28\r\n';
				END;
				IF @Month1_売りWMAs2角度 > 0
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ29\r\n';
				END;

				IF @Week1_売りWMAs2 > @Week1_売りWMAs14
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ30\r\n';
				END;
				IF @Week1_売りWMAs2角度 > 0
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ31\r\n';
				END;

				IF @Day1_売りWMAs2 > @Day1_売りWMAs14
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ32\r\n';
				END;
				IF @Day1_売りWMAs2角度 > 0
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ33\r\n';
				END;

				IF @Hour1_売りWMAs2 > @Hour1_売りWMAs14
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ34\r\n';
				END;
				IF @Hour1_売りWMAs2角度 > 0
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ35\r\n';
				END;

				IF @Min15_売りWMAs2 > @Min15_売りWMAs14
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ36\r\n';
				END;
				IF @Min15_売りWMAs2角度 > 0
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ37\r\n';
				END;

				IF @Min5_売りWMAs2 > @Min5_売りWMAs14
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ38\r\n';
				END;
				IF @Min5_売りWMAs2角度 > 0
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ39\r\n';
				END;

				IF @Min1_売りWMAs2 > @Min1_売りWMAs14
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ40\r\n';
				END;
				IF @Min1_売りWMAs2角度 > 0
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ41\r\n';
				END;
			END;
		END;

		IF @Month1_Start <= @Week1_Start AND @Day1_End <= @Month1_End  -- @Week1_Endを使っていないのは@Month1_Endを超える仕様だから
		BEGIN
			IF @Week1_Start <= @Day1_Start AND @Day1_End <= @Week1_End
			BEGIN
				IF @Day1_Start <= @Hour1_Start AND @Hour1_End <= @Day1_End
				BEGIN
					IF @Hour1_Start <= @Min15_Start AND @Min15_End <= @Hour1_End
					BEGIN
						IF @Min15_Start <= @Min5_Start AND @Min5_End <= @Min15_End
						BEGIN
							IF @Min5_Start <= @Min1_Start AND @Min1_End <= @Min5_End
							BEGIN
								IF @Min1_Start <= @日時 AND @日時 <= @Min1_End
								BEGIN
									--SET @妥当性 = @妥当性 + 'バグ\r\n';
									print '';
								END
								ELSE
								BEGIN
									SET @妥当性 = @妥当性 + 'バグ42\r\n';
								END;
							END
							ELSE
							BEGIN
								SET @妥当性 = @妥当性 + 'バグ43\r\n';
							END;
						END
						ELSE
						BEGIN
							SET @妥当性 = @妥当性 + 'バグ44\r\n';
						END;
					END
					ELSE
					BEGIN
						SET @妥当性 = @妥当性 + 'バグ45\r\n';
					END;
				END
				ELSE
				BEGIN
					SET @妥当性 = @妥当性 + 'バグ46\r\n';
				END;
			END
			ELSE
			BEGIN
				SET @妥当性 = @妥当性 + 'バグ47\r\n';
			END;
		END
		ELSE
		BEGIN
			SET @妥当性 = @妥当性 + 'バグ48\r\n';
		END;

		--良いロジックが思いつかなかったので保留とした変数
		--DECLARE	@BS_Min15_買いWMAs14			float;
		--DECLARE	@BS_Min15_売りWMAs14			float;
		--DECLARE	@BS_Min15_買いWMAs14角度		float;
		--DECLARE	@BS_Min15_売りWMAs14角度		float;
		--@通貨ペアNo
		--DECLARE	@差分リミット		float;
		--DECLARE	@買いリミット		float;
		--DECLARE	@売りリミット		float;
		--DECLARE	@注文単位			int;
		--@Oanda_TradeData_id

		IF @妥当性 = ''
		BEGIN
			SET @妥当性 = '妥当';
		END;


		/* 確認
		select
			@妥当性	as 妥当性,
			@通貨ペアNo	as 通貨ペアNo,
			@日時	as 日時,
			@買いSwap	as 買いSwap,
			@売りSwap	as 売りSwap,
			@Swap判定	as Swap判定,
			@買いRate	as 買いRate,
			@売りRate	as 売りRate,
			@売買判定	as 売買判定,
			@売買	as 売買,
			@保持ポジション	as 保持ポジション,
			@BS_Min15_買いWMAs14	as BS_Min15_買いWMAs14,
			@BS_Min15_買いWMAs14角度	as BS_Min15_買いWMAs14角度,
			@BS_Min15_買いWMAs14角度シグマ	as BS_Min15_買いWMAs14角度シグマ,
			@BS_Min15_売りWMAs14	as BS_Min15_売りWMAs14,
			@BS_Min15_売りWMAs14角度	as BS_Min15_売りWMAs14角度,
			@BS_Min15_売りWMAs14角度シグマ	as BS_Min15_売りWMAs14角度シグマ,
			@BS_WMA判定_15m	as BS_WMA判定_15m,
			@BS判定_15m	as BS判定_15m,
			@BS開始	as BS開始,
			@BS判定_前	as BS判定_前,
			@BS判定_今	as BS判定_今,
			@差分リミット	as 差分リミット,
			@買いリミット	as 買いリミット,
			@売りリミット	as 売りリミット,
			@注文単位	as 注文単位,
			@Month1_Start	as Month1_Start,
			@Month1_End	as Month1_End,
			@Month1_買いWMAs2	as Month1_買いWMAs2,
			@Month1_買いWMAs2角度	as Month1_買いWMAs2角度,
			@Month1_買いWMAs14	as Month1_買いWMAs14,
			@Month1_売りWMAs2	as Month1_売りWMAs2,
			@Month1_売りWMAs2角度	as Month1_売りWMAs2角度,
			@Month1_売りWMAs14	as Month1_売りWMAs14,
			@Week1_Start	as Week1_Start,
			@Week1_End	as Week1_End,
			@Week1_買いWMAs2	as Week1_買いWMAs2,
			@Week1_買いWMAs2角度	as Week1_買いWMAs2角度,
			@Week1_買いWMAs14	as Week1_買いWMAs14,
			@Week1_売りWMAs2	as Week1_売りWMAs2,
			@Week1_売りWMAs2角度	as Week1_売りWMAs2角度,
			@Week1_売りWMAs14	as Week1_売りWMAs14,
			@Day1_Start	as Day1_Start,
			@Day1_End	as Day1_End,
			@Day1_買いWMAs2	as Day1_買いWMAs2,
			@Day1_買いWMAs14	as Day1_買いWMAs14,
			@Day1_買いWMAs2角度	as Day1_買いWMAs2角度,
			@Day1_売りWMAs2	as Day1_売りWMAs2,
			@Day1_売りWMAs14	as Day1_売りWMAs14,
			@Day1_売りWMAs2角度	as Day1_売りWMAs2角度,
			@Hour1_Start	as Hour1_Start,
			@Hour1_End	as Hour1_End,
			@Hour1_買いWMAs2	as Hour1_買いWMAs2,
			@Hour1_買いWMAs2角度	as Hour1_買いWMAs2角度,
			@Hour1_買いWMAs14	as Hour1_買いWMAs14,
			@Hour1_売りWMAs2	as Hour1_売りWMAs2,
			@Hour1_売りWMAs2角度	as Hour1_売りWMAs2角度,
			@Hour1_売りWMAs14	as Hour1_売りWMAs14,
			@Min15_Start	as Min15_Start,
			@Min15_End	as Min15_End,
			@Min15_買いWMAs2	as Min15_買いWMAs2,
			@Min15_買いWMAs2角度	as Min15_買いWMAs2角度,
			@Min15_買いWMAs14	as Min15_買いWMAs14,
			@Min15_売りWMAs2	as Min15_売りWMAs2,
			@Min15_売りWMAs2角度	as Min15_売りWMAs2角度,
			@Min15_売りWMAs14	as Min15_売りWMAs14,
			@Min5_Start	as Min5_Start,
			@Min5_End	as Min5_End,
			@Min5_買いWMAs2	as Min5_買いWMAs2,
			@Min5_買いWMAs2角度	as Min5_買いWMAs2角度,
			@Min5_買いWMAs14	as Min5_買いWMAs14,
			@Min5_売りWMAs2	as Min5_売りWMAs2,
			@Min5_売りWMAs2角度	as Min5_売りWMAs2角度,
			@Min5_売りWMAs14	as Min5_売りWMAs14,
			@Min1_Start	as Min1_Start,
			@Min1_End	as Min1_End,
			@Min1_買いWMAs2	as Min1_買いWMAs2,
			@Min1_買いWMAs2角度	as Min1_買いWMAs2角度,
			@Min1_買いWMAs14	as Min1_買いWMAs14,
			@Min1_売りWMAs2	as Min1_売りWMAs2,
			@Min1_売りWMAs2角度	as Min1_売りWMAs2角度,
			@Min1_売りWMAs14	as Min1_売りWMAs14,
			@Oanda_TradeData_id	as Oanda_TradeData_id;
		*/

		UPDATE [oder].[tOrderHistory2]
		SET
			[妥当性] = @妥当性,
			[更新日時] = GETDATE()
		WHERE 
			[通貨ペアNo] = @通貨ペアNo AND [日時] = @日時
		;

		FETCH NEXT FROM cursor_OrderHistory2 INTO @通貨ペアNo, @日時, @買いSwap, @売りSwap, @Swap判定, @買いRate, @売りRate, @売買判定, @売買, @保持ポジション, @BS_Min15_買いWMAs14, @BS_Min15_買いWMAs14角度, @BS_Min15_買いWMAs14角度シグマ, @BS_Min15_売りWMAs14, @BS_Min15_売りWMAs14角度, @BS_Min15_売りWMAs14角度シグマ, @BS_WMA判定_15m, @BS判定_15m, @BS開始, @BS判定_前, @BS判定_今, @差分リミット, @買いリミット, @売りリミット, @注文単位, @Month1_Start, @Month1_End, @Month1_買いWMAs2, @Month1_買いWMAs2角度, @Month1_買いWMAs14, @Month1_売りWMAs2, @Month1_売りWMAs2角度, @Month1_売りWMAs14, @Week1_Start, @Week1_End, @Week1_買いWMAs2, @Week1_買いWMAs2角度, @Week1_買いWMAs14, @Week1_売りWMAs2, @Week1_売りWMAs2角度, @Week1_売りWMAs14, @Day1_Start, @Day1_End, @Day1_買いWMAs2, @Day1_買いWMAs14, @Day1_買いWMAs2角度, @Day1_売りWMAs2, @Day1_売りWMAs14, @Day1_売りWMAs2角度, @Hour1_Start, @Hour1_End, @Hour1_買いWMAs2, @Hour1_買いWMAs2角度, @Hour1_買いWMAs14, @Hour1_売りWMAs2, @Hour1_売りWMAs2角度, @Hour1_売りWMAs14, @Min15_Start, @Min15_End, @Min15_買いWMAs2, @Min15_買いWMAs2角度, @Min15_買いWMAs14, @Min15_売りWMAs2, @Min15_売りWMAs2角度, @Min15_売りWMAs14, @Min5_Start, @Min5_End, @Min5_買いWMAs2, @Min5_買いWMAs2角度, @Min5_買いWMAs14, @Min5_売りWMAs2, @Min5_売りWMAs2角度, @Min5_売りWMAs14, @Min1_Start, @Min1_End, @Min1_買いWMAs2, @Min1_買いWMAs2角度, @Min1_買いWMAs14, @Min1_売りWMAs2, @Min1_売りWMAs2角度, @Min1_売りWMAs14, @Oanda_TradeData_id;
	END;

	CLOSE cursor_OrderHistory2;
	DEALLOCATE cursor_OrderHistory2;

END
GO
/*
*/
