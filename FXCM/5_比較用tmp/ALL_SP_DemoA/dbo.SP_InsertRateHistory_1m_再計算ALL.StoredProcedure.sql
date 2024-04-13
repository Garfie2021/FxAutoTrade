USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_InsertRateHistory_1m_再計算ALL]
AS
BEGIN

	declare @ALL通貨ペア tinyint = 0;	-- 1：全通貨ペアを再計算する　2：1通貨ペアのみ再計算する


	declare @通貨ペアNo tinyint = 0;
	declare @now datetime = getdate();
	declare @StartDate datetime;
	declare @EndDate datetime;	
	declare @diff bigint = 0;

	if @ALL通貨ペア = 0
	begin

		Set @通貨ペアNo = 1;

		-- T_RateHistoryに残っている全期間を対象にする
		select @StartDate = MIN([Date]), @EndDate = MAX([Date]) 
		from [dbo].T_RateHistory
		where 通貨ペア = @通貨ペアNo;

		Set @diff = DATEDIFF(MINUTE, @StartDate, @EndDate) * -1;

		select @StartDate as StartDate, @EndDate as EndDate, @diff as diff

		delete 
		--select *
		from [dbo].[T_RateHistory_1m]
		where 通貨ペアNo = @通貨ペアNo and @StartDate <= 日時 and 日時 < @EndDate;


		while @diff < 1
		begin

			EXEC [dbo].[SP_InsertRateHistory_1m] @back_minute = @diff, @通貨ペアNo = @通貨ペアNo, @now = @now;

			Set @diff = @diff + 1;
		end;

	end
	else
	begin

		Set @通貨ペアNo = 0;

		while @通貨ペアNo < 44
		begin

			select @StartDate = MIN([Date]), @EndDate = MAX([Date]) 
			from [dbo].T_RateHistory
			where 通貨ペア = @通貨ペアNo;

			Set @diff = DATEDIFF(MINUTE, @StartDate, @EndDate) * -1;

			delete 
			--select *
			from [dbo].[T_RateHistory_1m]
			where 通貨ペアNo = @通貨ペアNo and @StartDate <= 日時 and 日時 < @EndDate;

			while @diff < 1
			begin
				--select @通貨ペアNo as 通貨ペアNo, @StartDate as StartDate, @EndDate as EndDate, @diff as diff

				EXEC [dbo].[SP_InsertRateHistory_1m] @back_minute = @diff, @通貨ペアNo = @通貨ペアNo, @now = @now;

				Set @diff = @diff + 1;
			end;

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

	end;

END


GO
