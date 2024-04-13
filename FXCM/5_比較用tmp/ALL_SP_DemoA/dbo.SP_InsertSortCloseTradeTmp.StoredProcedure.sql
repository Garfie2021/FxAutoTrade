USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_InsertSortCloseTradeTmp]
	@Time		datetime,
	@差益		float,
	@iAmount	int,
	@dRate		float,
	@sTradeID	varchar(50),
	@sQuoteID	varchar(100)
AS
BEGIN

	SET NOCOUNT ON;
	/*
	@差益		float,
	@iAmount	int,
	@dRate		float,
	@Time		datetime,
	@sTradeID	varchar(50),
	@sQuoteID	varchar(100)
	*/

	INSERT INTO [dbo].[T_SortCloseTradeTmp]
		([Time]
		,[差益]
		,[iAmount]
		,[dRate]
		,[sTradeID]
		,[sQuoteID])
	VALUES
		(@Time
		,@差益
		,@iAmount
		,@dRate
		,@sTradeID
		,@sQuoteID);


END

GO
