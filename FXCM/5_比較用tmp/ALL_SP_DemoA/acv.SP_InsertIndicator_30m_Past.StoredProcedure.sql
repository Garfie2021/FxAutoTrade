USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acv].[SP_InsertIndicator_30m_Past]
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @StartDate datetime;
	declare @通貨ペアNo tinyint = 0;

	while @通貨ペアNo < 44
	begin

		select @StartDate = MAX([日時])
		from [acv].[T_Indicator_30m_Past]
		where [通貨ペアNo] = @通貨ペアNo

		if @StartDate is null or @StartDate < 1
		begin

			INSERT INTO [acv].[T_Indicator_30m_Past]
				([通貨ペアNo]
				,[日時]
				,[WMA_買い_WMA]
				,[WMA_売り_WMA]
				,[WMA_買い_WMA上昇角度]
				,[WMA_売り_WMA上昇角度]
				,[WMA_買い_WMA_S2]
				,[WMA_売り_WMA_S2]
				,[WMA_買い_WMA上昇角度_S2]
				,[WMA_売り_WMA上昇角度_S2])
			SELECT 
				 [通貨ペアNo]
				,[日時]
				,[WMA_買い_WMA]
				,[WMA_売り_WMA]
				,[WMA_買い_WMA上昇角度]
				,[WMA_売り_WMA上昇角度]
				,[WMA_買い_WMA_S2]
				,[WMA_売り_WMA_S2]
				,[WMA_買い_WMA上昇角度_S2]
				,[WMA_売り_WMA上昇角度_S2]
			FROM [indi].[T_Indicator_30m]
			where [通貨ペアNo] = @通貨ペアNo;

		end
		else
		begin

			INSERT INTO [acv].[T_Indicator_30m_Past]
				([通貨ペアNo]
				,[日時]
				,[WMA_買い_WMA]
				,[WMA_売り_WMA]
				,[WMA_買い_WMA上昇角度]
				,[WMA_売り_WMA上昇角度]
				,[WMA_買い_WMA_S2]
				,[WMA_売り_WMA_S2]
				,[WMA_買い_WMA上昇角度_S2]
				,[WMA_売り_WMA上昇角度_S2])
			SELECT 
				 [通貨ペアNo]
				,[日時]
				,[WMA_買い_WMA]
				,[WMA_売り_WMA]
				,[WMA_買い_WMA上昇角度]
				,[WMA_売り_WMA上昇角度]
				,[WMA_買い_WMA_S2]
				,[WMA_売り_WMA_S2]
				,[WMA_買い_WMA上昇角度_S2]
				,[WMA_売り_WMA上昇角度_S2]
			FROM [indi].[T_Indicator_30m]
			where [通貨ペアNo] = @通貨ペアNo 
			and [日時] > @StartDate;

		end;

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;


END

GO
