USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acv].[SP_InsertRateHistory_5m_Past]
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @StartDate datetime;
	declare @通貨ペアNo tinyint = 0;

	while @通貨ペアNo < 44
	begin

		select @StartDate = MAX([日時])
		from [acv].[T_RateHistory_5m_Past]
		where [通貨ペアNo] = @通貨ペアNo

		if @StartDate is null or @StartDate < 1
		begin

			INSERT INTO [acv].[T_RateHistory_5m_Past]
				([通貨ペアNo]
				,[日時]
				,[買い_始値]
				,[買い_高値]
				,[買い_安値]
				,[買い_終値]
				,[売り_始値]
				,[売り_高値]
				,[売り_安値]
				,[売り_終値]
				,[StartDate]
				,[EndDate])
			SELECT
				 [通貨ペアNo]
				,[日時]
				,[買い_始値]
				,[買い_高値]
				,[買い_安値]
				,[買い_終値]
				,[売り_始値]
				,[売り_高値]
				,[売り_安値]
				,[売り_終値]
				,[StartDate]
				,[EndDate]
			FROM [dbo].[T_RateHistory_5m]
			where [通貨ペアNo] = @通貨ペアNo;

		end
		else
		begin

			INSERT INTO [acv].[T_RateHistory_5m_Past]
				([通貨ペアNo]
				,[日時]
				,[買い_始値]
				,[買い_高値]
				,[買い_安値]
				,[買い_終値]
				,[売り_始値]
				,[売り_高値]
				,[売り_安値]
				,[売り_終値]
				,[StartDate]
				,[EndDate])
			SELECT
				 [通貨ペアNo]
				,[日時]
				,[買い_始値]
				,[買い_高値]
				,[買い_安値]
				,[買い_終値]
				,[売り_始値]
				,[売り_高値]
				,[売り_安値]
				,[売り_終値]
				,[StartDate]
				,[EndDate]
			FROM [dbo].[T_RateHistory_5m]
			where [通貨ペアNo] = @通貨ペアNo 
			and [日時] > @StartDate;
		end;

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;


END

GO
