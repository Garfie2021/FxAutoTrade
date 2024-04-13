USE [FX_DemoA]
GO

DROP PROCEDURE [hltc].[SP_Increment取引状況でデータ不足が発生した件数]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [hltc].[SP_Increment取引状況でデータ不足が発生した件数]
AS
BEGIN

	declare @today date = getdate();

	declare @Cnt tinyint = 0;
	select @Cnt = count(*) from [hltc].[T_システム異常発生件数_Daily] where [年月日] = @today;

	if @Cnt < 1
	begin
		INSERT INTO [hltc].[T_システム異常発生件数_Daily] ([年月日]) VALUES (@today);
	end;

	UPDATE
		[hltc].[T_システム異常発生件数_Daily]
	SET
		[取引状況でデータ不足が発生した件数] = [取引状況でデータ不足が発生した件数] + 1
	WHERE
		[年月日] = @today

END

GO
