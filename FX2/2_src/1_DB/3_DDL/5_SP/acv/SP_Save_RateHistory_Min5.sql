USE [FX2_Demo]
GO

DROP PROCEDURE [acv].[SP_Save_RateHistory_Min5]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acv].[SP_Save_RateHistory_Min5]
AS
BEGIN

	SET NOCOUNT ON;


	-- acvへデータを退避

	DECLARE @StartDate_dboMin	datetime;
	DECLARE @StartDate_dboMax	datetime;
	DECLARE @StartDate_acvMax	datetime;
	DECLARE @StartDate_acvMin	datetime;
	declare @通貨ペアNo			tinyint = 0;

	while @通貨ペアNo < 44
	begin

		select @StartDate_acvMax = MAX([StartDate])
		from [acv].[tRateHistory_Min5]
		where [通貨ペアNo] = @通貨ペアNo;

		SELECT @StartDate_dboMin = MIN([StartDate]), @StartDate_dboMax = MAX([StartDate])
		FROM [rate].[tRateHistory_Min5]
		where [通貨ペアNo] = @通貨ペアNo;

		--SELECT @StartDate_acvMin, @StartDate_acvMax

		if @StartDate_acvMax is null or @StartDate_acvMax < 1
		begin

			WHILE @StartDate_dboMin < @StartDate_dboMax
			BEGIN

				INSERT INTO [acv].[tRateHistory_Min5]
					([通貨ペアNo]
					,[StartDate]
					,[買いRate_始値]
					,[買いRate_高値]
					,[買いRate_安値]
					,[買いRate_終値]
					,[買いWMAs2]
					,[買いWMAs2角度]
					,[買いWMAs2角度シグマ]
					,[買いWMAs2角度持続時間]
					,[買いWMAs2角度持続Rate]
					,[売りRate_始値]
					,[売りRate_高値]
					,[売りRate_安値]
					,[売りRate_終値]
					,[売りWMAs2]
					,[売りWMAs2角度]
					,[売りWMAs2角度シグマ]
					,[売りWMAs2角度持続時間]
					,[売りWMAs2角度持続Rate]
					,[更新日時])
				SELECT
					 [通貨ペアNo]
					,[StartDate]
					,[買いRate_始値]
					,[買いRate_高値]
					,[買いRate_安値]
					,[買いRate_終値]
					,[買いWMAs2]
					,[買いWMAs2角度]
					,[買いWMAs2角度シグマ]
					,[買いWMAs2角度持続時間]
					,[買いWMAs2角度持続Rate]
					,[売りRate_始値]
					,[売りRate_高値]
					,[売りRate_安値]
					,[売りRate_終値]
					,[売りWMAs2]
					,[売りWMAs2角度]
					,[売りWMAs2角度シグマ]
					,[売りWMAs2角度持続時間]
					,[売りWMAs2角度持続Rate]
					,[更新日時]
				FROM [rate].[tRateHistory_Min5]
				WHERE 通貨ペアNo = @通貨ペアNo AND DATEADD(HOUR, -1, @StartDate_dboMin) < [StartDate] AND [StartDate] <= @StartDate_dboMin

				SET @StartDate_dboMin = DATEADD(HOUR, 1, @StartDate_dboMin);

			end;

		end
		else
		begin

			WHILE @StartDate_acvMax < @StartDate_dboMax
			BEGIN

				INSERT INTO [acv].[tRateHistory_Min5]
					([通貨ペアNo]
					,[StartDate]
					,[買いRate_始値]
					,[買いRate_高値]
					,[買いRate_安値]
					,[買いRate_終値]
					,[買いWMAs2]
					,[買いWMAs2角度]
					,[買いWMAs2角度シグマ]
					,[買いWMAs2角度持続時間]
					,[買いWMAs2角度持続Rate]
					,[売りRate_始値]
					,[売りRate_高値]
					,[売りRate_安値]
					,[売りRate_終値]
					,[売りWMAs2]
					,[売りWMAs2角度]
					,[売りWMAs2角度シグマ]
					,[売りWMAs2角度持続時間]
					,[売りWMAs2角度持続Rate]
					,[更新日時])
				SELECT
					 [通貨ペアNo]
					,[StartDate]
					,[買いRate_始値]
					,[買いRate_高値]
					,[買いRate_安値]
					,[買いRate_終値]
					,[買いWMAs2]
					,[買いWMAs2角度]
					,[買いWMAs2角度シグマ]
					,[買いWMAs2角度持続時間]
					,[買いWMAs2角度持続Rate]
					,[売りRate_始値]
					,[売りRate_高値]
					,[売りRate_安値]
					,[売りRate_終値]
					,[売りWMAs2]
					,[売りWMAs2角度]
					,[売りWMAs2角度シグマ]
					,[売りWMAs2角度持続時間]
					,[売りWMAs2角度持続Rate]
					,[更新日時]
				FROM [rate].[tRateHistory_Min5]
				WHERE [通貨ペアNo] = @通貨ペアNo AND DATEADD(HOUR, -1, @StartDate_acvMax) < [StartDate] AND [StartDate] <= @StartDate_acvMax;

				SET @StartDate_acvMax = DATEADD(HOUR, 1, @StartDate_acvMax);
			end;

		end;

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;


	-- 退避済みのデータを削除

	SELECT @StartDate_acvMin = MIN([StartDate]), @StartDate_acvMax = MAX([StartDate])
	FROM [rate].[tRateHistory_Min5]

	SET @StartDate_acvMax = DATEADD(WEEK, -2, @StartDate_acvMax);	--2週間分のデータは残す

	WHILE @StartDate_acvMin < @StartDate_acvMax
	BEGIN

		SET @通貨ペアNo = 0;
		while @通貨ペアNo < 44
		begin

			DELETE FROM [rate].[tRateHistory_Min5]
			WHERE 通貨ペアNo = @通貨ペアNo AND DATEADD(HOUR, -1, @StartDate_acvMin) < [StartDate] AND [StartDate] <= @StartDate_acvMin

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		SET @StartDate_acvMin = DATEADD(HOUR, 1, @StartDate_acvMin);
	END;

END
GO

