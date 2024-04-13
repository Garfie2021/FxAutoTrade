USE DemoA_FX
GO

DROP PROCEDURE [oder].[spChk直近n分以内にボーナスステージ終了有り]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spChk直近n分以内にボーナスステージ終了有り]
	@通貨ペアNo		tinyint,
	@n分前			datetime,
	@判定			tinyint		output
AS
BEGIN

	DECLARE @iCnt int;

	SELECT @iCnt = Count(*)
	FROM [hstr].[tBonusStage]
	where [通貨ペアNo] = @通貨ペアNo AND 
		@n分前 < [日時] AND 
		[BS判定_前] = 'B' AND 
		[BS判定_今] = ''

	if 0 < @iCnt
	begin
		Set @判定 = 1;
	end
	else
	begin
		Set @判定 = 0;
	end;

	--select @判定

END

GO


