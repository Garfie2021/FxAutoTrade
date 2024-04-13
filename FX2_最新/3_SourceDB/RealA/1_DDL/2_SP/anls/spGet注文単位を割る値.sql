USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [anls].[spGet注文単位を割る値]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [anls].[spGet注文単位を割る値]
	@通貨ペアNo			tinyint,
	@売買				bit,
	@Rate				float,
	@注文単位を割る値	int	output
AS
BEGIN

	SET NOCOUNT ON;

	--declare @通貨ペアNo tinyint = 5;
	--declare @売買 bit = 1;
	--declare @Rate float = 0.74936; -- 売り：0.74957
	--declare @注文単位を割る値 int;

	--SELECT *
	--FROM [anls].[t注文単位を割る値]
	--WHERE [通貨ペアNo] = @通貨ペアNo AND [売買] = @売買 AND [Rate_High] >= @Rate AND @Rate >= [Rate_Low]
	--ORDER BY [注文単位を割る値] DESC;


	SELECT TOP 1 @注文単位を割る値 = [注文単位を割る値]
	FROM [anls].[t注文単位を割る値]
	WHERE [通貨ペアNo] = @通貨ペアNo AND [売買] = @売買 AND [Rate_High] >= @Rate AND @Rate >= [Rate_Low]
	ORDER BY [注文単位を割る値] DESC;
END
GO
/*
*/
