USE RealB_2370741683_FX
GO
/*
*/
DROP PROCEDURE [cmn].[spUpdate通貨ペアMst_Order間隔最小値]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spUpdate通貨ペアMst_Order間隔最小値]
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @now datetime = GETDATE();
	DECLARE @システム設定_Rate幅を求めるn日間_n日前まで対象 tinyint;
	DECLARE @システム設定_前日の高値底値とOrder間隔最小値の割合 float;

    -- 「No」を変更する場合、ストアド内で使用されているソースも合わせて変更しないといけない
	select @システム設定_Rate幅を求めるn日間_n日前まで対象 = 値 
	from [cmn].[tSettings] 
	where [No] = 6;

	select @システム設定_前日の高値底値とOrder間隔最小値の割合 = 値 
	from [cmn].[tSettings] 
	where [No] = 7;

	/*
	select @システム設定_Rate幅を求めるn日間_n日前まで対象 as Rate幅を求めるn日間_n日前まで対象
	select @システム設定_前日の高値底値とOrder間隔最小値の割合 as システム設定_割合
	*/
	
	DECLARE @通貨ペアNo tinyint = 0;
	DECLARE @買い_Rate幅 float;
	DECLARE @売り_Rate幅 float;

	WHILE @通貨ペアNo < 44
	BEGIN
		EXECUTE [rate].[spGetRate幅] @通貨ペアNo, @now, @システム設定_Rate幅を求めるn日間_n日前まで対象, @システム設定_前日の高値底値とOrder間隔最小値の割合, 
			@買い_Rate幅 OUTPUT, @売り_Rate幅 OUTPUT;

		/*
		select @通貨ペアNo as 通貨ペアNo, @買い_Rate幅 as 買い_Rate幅, @売り_Rate幅 as 売り_Rate幅
		*/

		UPDATE [cmn].[t通貨ペアMst]
		SET [Order間隔最小値_買い] = @買い_Rate幅, [Order間隔最小値_売り] = @売り_Rate幅
		WHERE [No] = @通貨ペアNo

		SET @通貨ペアNo = @通貨ペアNo + 1;
	END;

END
GO
/*
*/
