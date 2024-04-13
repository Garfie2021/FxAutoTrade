USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_InsertRateHistory_Daily_再計算All]
AS
BEGIN

	declare @通貨ペアNo int = 34;

	declare @StartDate datetime;
	declare @EndDate datetime;	
	select @StartDate = MIN([Date]), @EndDate = MAX([Date]) 
	from [dbo].T_RateHistory
	where 通貨ペア = @通貨ペアNo
	;

	declare @diff int = 0;
	Set @diff = DATEDIFF(dayofyear, @StartDate, @EndDate) * -1;

	while @diff < 1
	begin

		EXEC [dbo].[SP_InsertRateHistory_Daily] @back_day = @diff, @通貨ペアNo = @通貨ペアNo;

		Set @diff = @diff + 1;
	end;

	/*
	declare @通貨ペアNo int = 0;

	while @通貨ペアNo < 44
	begin

		declare @StartDate datetime;
		declare @EndDate datetime;	
		select @StartDate = MIN([Date]), @EndDate = MAX([Date]) 
		from [dbo].T_RateHistory
		where 通貨ペア = @通貨ペアNo
		;

		declare @diff int = 0;
		Set @diff = DATEDIFF(dayofyear, @StartDate, @EndDate) * -1;

		select @StartDate, @EndDate, @diff

		while @diff < 1
		begin

			select @diff, @通貨ペアNo

			EXEC [dbo].[SP_InsertRateHistory_Daily] @back_day = @diff, @通貨ペアNo = @通貨ペアNo;

			Set @diff = @diff + 1;
		end;

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;
	*/
END


GO
