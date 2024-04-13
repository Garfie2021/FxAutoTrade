USE DemoA_FX
GO
/*
*/
DROP PROCEDURE [oder].[spGet売買判定2_Day1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spGet売買判定2_Day1]
	@通貨ペアNo		tinyint,
	@StartDate		datetime,
	@買いWMAs2		float		output,
	@買いWMAs14		float		output,
	@売りWMAs2		float		output,
	@売りWMAs14		float		output,
	@売買判定		varchar(1)	output		-- B(買い) or S(売り)
AS
BEGIN
	/*
	DECLARE @通貨ペアNo		tinyint = 21
	DECLARE @StartDate		datetime = getdate()
	DECLARE @シグマ閾値		float = 2.5
	DECLARE @WMA判定		varchar(5)
	DECLARE @BonusStage判定	varchar(5)
	DECLARE @WMA前_S2		float = 2.5
	DECLARE @WMA今_S2		float = 2.5
	*/

	SELECT TOP 1 @買いWMAs2 = [買いWMAs2], @買いWMAs14 = [買いWMAs14], @売りWMAs2 = [売りWMAs2], @売りWMAs14 = [売りWMAs14]
	FROM [hstr].[tDay1]
	where 通貨ペアNo = @通貨ペアNo and [StartDate] <= @StartDate
	order by [StartDate] desc;

	-- GC逆判定

	if @買いWMAs14 < @買いWMAs2
	begin
		SET @売買判定 = 'B';
	end
	else if @売りWMAs14 > @売りWMAs2
	begin
		SET @売買判定 = 'S';
	end
	else
	begin
		SET @売買判定 = '';
	end;

END
GO
/*
*/

