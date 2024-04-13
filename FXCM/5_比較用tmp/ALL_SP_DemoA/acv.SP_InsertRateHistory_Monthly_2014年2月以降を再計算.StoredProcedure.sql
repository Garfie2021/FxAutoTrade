USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [acv].[SP_InsertRateHistory_Monthly_2014年2月以降を再計算]
AS
BEGIN

	DECLARE @通貨ペアNo tinyint = 12

	declare @StartDate datetime = '2014-02-01 6:00:00';
	declare @EndDate datetime;	

	select @EndDate = MAX([日時]) 
	from [acv].[T_RateHistory_Past]
	where 通貨ペアNo = @通貨ペアNo

	select @StartDate as StartDate, @EndDate as EndDate

	declare @diff int = 0;
	Set @diff = DATEDIFF(dayofyear, @StartDate, @EndDate) * -1;

	while @diff < 1
	begin

		select @diff

		EXEC [acv].[SP_InsertRateHistory_Monthly] @back_Month = @diff, @通貨ペアNo = @通貨ペアNo;

		Set @diff = @diff + 1;
	end;


END


GO
