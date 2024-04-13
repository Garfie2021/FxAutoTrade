USE [FX2_Demo]
GO
/*
*/
DROP PROCEDURE [indi].[spWMA角度持続量収集_Min5]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- [rate]スキーマから[indi]スキーマへデータをコピー
CREATE PROCEDURE [indi].[spWMA角度持続量収集_Min5]
AS
BEGIN
	--DELETE FROM [indi].[tIndicatorHistory_Min5];

	declare @StartDate				datetime;
	declare @買いWMAs2角度			float;
	declare @買いWMAs2角度シグマ	float;
	declare @買いWMAs2角度持続時間	int;
	declare @買いWMAs2角度持続Rate	float;
	declare @売りWMAs2角度			float;
	declare @売りWMAs2角度シグマ	float;
	declare @売りWMAs2角度持続時間	int;
	declare @売りWMAs2角度持続Rate	float;
	declare @Cnt					int;
	declare @通貨ペアNo				tinyint = 0;

	while @通貨ペアNo < 44
	begin

		declare cursor_tRateHistory_Min5 cursor for
		SELECT [StartDate], 
			[買いWMAs2角度], [買いWMAs2角度シグマ], [買いWMAs2角度持続時間], [買いWMAs2角度持続Rate],
			[売りWMAs2角度], [売りWMAs2角度シグマ], [売りWMAs2角度持続時間], [売りWMAs2角度持続Rate]
		FROM [rate].[tRateHistory_Min5]
		WHERE [通貨ペアNo] = @通貨ペアNo AND ([買いWMAs2角度持続時間] is not null OR [売りWMAs2角度持続時間] is not null);

		open cursor_tRateHistory_Min5;

		FETCH NEXT FROM cursor_tRateHistory_Min5 INTO @StartDate, 
			@買いWMAs2角度, @買いWMAs2角度シグマ, @買いWMAs2角度持続時間, @買いWMAs2角度持続Rate,
			@売りWMAs2角度, @売りWMAs2角度シグマ, @売りWMAs2角度持続時間, @売りWMAs2角度持続Rate;

		WHILE @@FETCH_STATUS = 0
		BEGIN
			SELECT @Cnt = Count(*)
			FROM [indi].[tIndicatorHistory_Min5]
			WHERE [通貨ペアNo] = @通貨ペアNo AND [StartDate] = @StartDate;

			IF @Cnt > 0
			BEGIN
				UPDATE [indi].[tIndicatorHistory_Min5]
				SET [買いWMAs2角度]	= @買いWMAs2角度,
					[買いWMAs2角度シグマ]	= @買いWMAs2角度シグマ,
					[買いWMAs2角度持続時間] = @買いWMAs2角度持続時間,
					[買いWMAs2角度持続Rate] = @買いWMAs2角度持続Rate,
					[売りWMAs2角度]	= @売りWMAs2角度,
					[売りWMAs2角度シグマ]	= @売りWMAs2角度シグマ,
					[売りWMAs2角度持続時間] = @売りWMAs2角度持続時間,
					[売りWMAs2角度持続Rate] = @売りWMAs2角度持続Rate
				WHERE [通貨ペアNo] = @通貨ペアNo AND [StartDate] = @StartDate;
			END
			ELSE
			BEGIN
				INSERT INTO [indi].[tIndicatorHistory_Min5]
					([通貨ペアNo], [StartDate], 
					 [買いWMAs2角度], [買いWMAs2角度シグマ], [買いWMAs2角度持続時間], [買いWMAs2角度持続Rate],
					 [売りWMAs2角度], [売りWMAs2角度シグマ], [売りWMAs2角度持続時間], [売りWMAs2角度持続Rate])
				VALUES
					(@通貨ペアNo, @StartDate, 
					 @買いWMAs2角度, @買いWMAs2角度シグマ, @買いWMAs2角度持続時間, @買いWMAs2角度持続Rate, 
					 @売りWMAs2角度, @売りWMAs2角度シグマ, @売りWMAs2角度持続時間, @売りWMAs2角度持続Rate);
			END;

			FETCH NEXT FROM cursor_tRateHistory_Min5 INTO @StartDate, 
				@買いWMAs2角度, @買いWMAs2角度シグマ, @買いWMAs2角度持続時間, @買いWMAs2角度持続Rate,
				@売りWMAs2角度, @売りWMAs2角度シグマ, @売りWMAs2角度持続時間, @売りWMAs2角度持続Rate;
		END;
	
		CLOSE cursor_tRateHistory_Min5;
		DEALLOCATE cursor_tRateHistory_Min5;

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;

END
GO
/*
*/
