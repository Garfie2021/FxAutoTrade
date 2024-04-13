USE DemoA_FX
GO

DROP PROCEDURE [fxcm].[spInsertAccounts]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [fxcm].[spInsertAccounts]
	@日時				datetime,
	@AccountID			varchar(50),
	@AccountName		varchar(50),
	@Balance			float,
	@Equity				float,
	@DayPL				float,
	@NontrdEqty			float,
	@M2MEquity			float,
	@UsedMargin			float,
	@UsableMargin		float,
	@GrossPL			float,
	@Kind				varchar(50),
	@MarginCall			varchar(50),
	@IsUnderMarginCall	varchar(50),
	@Hedging			varchar(50),
	@AmountLimit		int,
	@BaseUnitSize		int
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [fxcm].[tAccounts]
		([日時]
		,[AccountID]
		,[AccountName]
		,[Balance]
		,[Equity]
		,[DayPL]
		,[NontrdEqty]
		,[M2MEquity]
		,[UsedMargin]
		,[UsableMargin]
		,[GrossPL]
		,[Kind]
		,[MarginCall]
		,[IsUnderMarginCall]
		,[Hedging]
		,[AmountLimit]
		,[BaseUnitSize])
	VALUES
		(@日時
		,@AccountID
		,@AccountName
		,@Balance
		,@Equity
		,@DayPL
		,@NontrdEqty
		,@M2MEquity
		,@UsedMargin
		,@UsableMargin
		,@GrossPL
		,@Kind
		,@MarginCall
		,@IsUnderMarginCall
		,@Hedging
		,@AmountLimit
		,@BaseUnitSize);


END
GO
