USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_InsertRateHistory]
	 @通貨ペアNo tinyint
	,@日時 datetime
	,@Rate_買い float
	,@Rate_売り float
	,@Swap_買い float
	,@Swap_売り float
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [dbo].[T_RateHistory]
		([通貨ペア]
		,[Date]
		,[Rate_買い]
		,[Rate_売り]
		,[Swap_買い]
		,[Swap_売り]
		,[Rate相反Status_買い]
		,[Rate相反Status_売り])
	VALUES
		(@通貨ペアNo
		,@日時
		,@Rate_買い
		,@Rate_売り
		,@Swap_買い
		,@Swap_売り
		,null
		,null);

END

GO
