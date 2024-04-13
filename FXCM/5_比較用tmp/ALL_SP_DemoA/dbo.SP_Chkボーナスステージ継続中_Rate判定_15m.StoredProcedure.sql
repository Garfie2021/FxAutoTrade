USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_Chkボーナスステージ継続中_Rate判定_15m]
	@通貨ペアNo		tinyint,
	@now			datetime,
	@判定			tinyint	output	-- n倍 1.8倍か？
AS
BEGIN

	declare @処理位置_補足 varchar(50);

	select top 1 @処理位置_補足 = 処理位置_補足
	from smlt.T_Order判定History
	where 通貨ペアNo = @通貨ペアNo and 日時 <= @now
	order by 日時 desc


	if @処理位置_補足 = 'ボーナスステージ開始' or @処理位置_補足 = 'ボーナスステージ継続中'
	begin
		Set @判定 = 1;	--ボーナスステージ継続中
	end
	else
	begin
		Set @判定 = 0;	--ボーナスステージじゃない
	end

	--select @判定

END


GO
