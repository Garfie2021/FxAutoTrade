USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acv].[SP_InsertRateHistory_Past]
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @StartDate datetime;

	declare @通貨ペアNo tinyint = 0;
	while @通貨ペアNo < 44
	begin

		select @StartDate = MAX([日時])
		from [acv].[T_RateHistory_Past]
		where [通貨ペアNo] = @通貨ペアNo

		select @StartDate

		if @StartDate is null or @StartDate < 1
		begin

			select 'A', @通貨ペアNo

			INSERT INTO [acv].[T_RateHistory_Past]
				([通貨ペアNo]
				,[日時]
				,[Rate_買い]
				,[Rate_売り]
				,[Swap_買い]
				,[Swap_売り])
			SELECT [通貨ペア]
				,[Date]
				,[Rate_買い]
				,[Rate_売り]
				,[Swap_買い]
				,[Swap_売り]
			FROM [dbo].[T_RateHistory]
			where [通貨ペア] = @通貨ペアNo;

		end
		else
		begin

			select 'B', @通貨ペアNo

			INSERT INTO [acv].[T_RateHistory_Past]
				([通貨ペアNo]
				,[日時]
				,[Rate_買い]
				,[Rate_売り]
				,[Swap_買い]
				,[Swap_売り])
			SELECT [通貨ペア]
				,[Date]
				,[Rate_買い]
				,[Rate_売り]
				,[Swap_買い]
				,[Swap_売り]
			FROM [dbo].[T_RateHistory]
			where [通貨ペア] = @通貨ペアNo and [Date] > @StartDate;
		end;

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;


END

GO
