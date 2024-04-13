USE [FX2_Demo]
GO

DROP PROCEDURE [oder].[spOrderSetting初期化]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spOrderSetting初期化]
AS
BEGIN

	DECLARE @Cnt tinyint;
	
	SELECT @Cnt = COUNT(*)
	FROM [oder].[tOrderSettings]

	if @Cnt > 0
	begin
		-- 既に初期化済み
		return;
	end;

	declare @通貨ペアNo tinyint = 0;
	while @通貨ペアNo < 44
	begin

		INSERT INTO [oder].[tOrderSettings]
           ([通貨ペアNo]
           ,[計算対象]
           ,[注文対象])
	     VALUES
           (@通貨ペアNo
           ,1
           ,1)

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;

END
GO
/*
*/

