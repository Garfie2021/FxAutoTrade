USE [FX2_Demo]
GO

DROP PROCEDURE [cmn].[spGet三角数]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [cmn].[spGet三角数]
	@値			int,	-- 整数のみに対応している
	@三角数		int	output
AS
BEGIN

	Set @三角数 = 0;

	while @値 > 0
	begin

		Set @三角数 = @三角数 + @値;

		set @値 = @値 - 1;
	end;

END

GO

