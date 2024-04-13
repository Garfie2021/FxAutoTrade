USE [FX2_Demo]
GO

DROP PROCEDURE [cmn].[spGet注文数]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGet注文数]
	@角度シグマ	float,
	@注文数		int	output
AS
BEGIN

	-- 注文数をシグマで倍化して、有利な時に利益を出し易くする。
	-- いずれは、有効証拠金に合わせて10以上も可能にする。
	
	--declare @倍数	int = ROUND(@角度シグマ, 0);

	--if @倍数 < 1
	--begin
	--	Set @注文数 = 1;
	--end
	--else if @倍数 > 10
	--begin
	--	Set @注文数 = 10;
	--end
	--else
	--begin
	--	Set @注文数 = @倍数;
	--end
	Set @注文数 = 1;

END
GO

