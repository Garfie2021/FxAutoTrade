USE [DemoA_FX]
GO

DROP PROCEDURE [hltc].[SP_InsertデータCnt_Monthly]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [hltc].[SP_InsertデータCnt_Monthly]
	@back_Month int = -2
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @now		Datetime = GETDATE();


	while @back_Month < 1
	begin

		DECLARE @ThisMonth datetime
		DECLARE @StartDate datetime
		DECLARE @EndDate datetime
		EXECUTE [cmn].[SP_GetThisMonth] @now, @back_Month, @ThisMonth OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT

		DECLARE @通貨ペアNo tinyint = 0
		while @通貨ペアNo < 44
		begin

			--select @ThisMonth, @StartDate, @EndDate, @通貨ペアNo

			delete 
			--select *
			from [hltc].[T_データCnt_Monthly]
			where  通貨ペアNo = @通貨ペアNo and [日時] = @ThisMonth;


			Insert [hltc].[T_データCnt_Monthly] (
				 [日時]
				,[通貨ペアNo]
				,[件数_Weekly]
				,[件数_Monthly]
				,[StartDate]
				,[EndDate]
			)
			Values
			(
				@ThisMonth,
				@通貨ペアNo,
				(select count(*) from [dbo].[T_RateHistory_Weekly] where 通貨ペアNo = @通貨ペアNo and @StartDate <= 日時 and 日時 <= @EndDate),
				(select count(*) from [dbo].[T_RateHistory_Monthly] where 通貨ペアNo = @通貨ペアNo and @StartDate <= 日時 and 日時 <= @EndDate),
				@StartDate,
				@EndDate
			)

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @back_Month = @back_Month + 1;
	end;

END
GO
