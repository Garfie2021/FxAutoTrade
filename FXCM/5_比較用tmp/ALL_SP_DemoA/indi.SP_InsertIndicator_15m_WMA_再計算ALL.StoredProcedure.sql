USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [indi].[SP_InsertIndicator_15m_WMA_再計算ALL]
	@ALL通貨ペア tinyint = 0	-- 1：全通貨ペアを再計算する　0：1通貨ペアのみ再計算する
AS
BEGIN

	/*
	declare @ALL通貨ペア tinyint = 0	-- 1：全通貨ペアを再計算する　0：1通貨ペアのみ再計算する
	*/

	declare @通貨ペアNo tinyint;
	declare @日時 datetime;
	declare @StartDate datetime = '2013-10-01 00:00:00';

	if @ALL通貨ペア = 0
	begin

		Set @通貨ペアNo = 0;

		declare cursor_T_RateHistory_15m2 cursor for
		SELECT [日時]
		FROM [dbo].[T_RateHistory_15m]
		WHERE [通貨ペアNo] = @通貨ペアNo and @StartDate <= [日時];

		open cursor_T_RateHistory_15m2;

		FETCH NEXT FROM cursor_T_RateHistory_15m2 INTO @日時;

		WHILE @@FETCH_STATUS = 0
		BEGIN
			select @通貨ペアNo as 通貨ペアNo, @日時 as 日時

			EXEC [indi].[SP_InsertIndicator_15m_WMA] @通貨ペアNo = @通貨ペアNo, @StartDate = @日時;

			FETCH NEXT FROM cursor_T_RateHistory_15m2 INTO @日時;
		END

		CLOSE cursor_T_RateHistory_15m2;
		DEALLOCATE cursor_T_RateHistory_15m2;

	end
	else
	begin

		Set @通貨ペアNo = 0;

		while @通貨ペアNo < 44
		begin

			declare cursor_T_RateHistory_15m2 cursor for
			SELECT [日時]
			FROM [dbo].[T_RateHistory_15m]
			WHERE [通貨ペアNo] = @通貨ペアNo and @StartDate <= [日時]

			open cursor_T_RateHistory_15m2;

			FETCH NEXT FROM cursor_T_RateHistory_15m2 INTO @日時;

			WHILE @@FETCH_STATUS = 0
			BEGIN
				select @通貨ペアNo as 通貨ペアNo, @日時 as 日時

				EXEC [indi].[SP_InsertIndicator_15m_WMA] @通貨ペアNo = @通貨ペアNo, @StartDate = @日時;

				FETCH NEXT FROM cursor_T_RateHistory_15m2 INTO @日時;
			END

			CLOSE cursor_T_RateHistory_15m2;
			DEALLOCATE cursor_T_RateHistory_15m2;

			Set @通貨ペアNo = @通貨ペアNo + 1;

		end;
	end;


END

GO
