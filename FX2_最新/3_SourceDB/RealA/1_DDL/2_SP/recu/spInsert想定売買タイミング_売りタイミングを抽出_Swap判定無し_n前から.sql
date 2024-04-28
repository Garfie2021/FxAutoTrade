USE OANDA_RealA
GO

DROP PROCEDURE [recu].[spInsert�z�蔄���^�C�~���O_����^�C�~���O�𒊏o_Swap���薳��_n�O����]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [recu].[spInsert�z�蔄���^�C�~���O_����^�C�~���O�𒊏o_Swap���薳��_n�O����]
	@back_Month1 int = -1
AS
BEGIN

	DECLARE @now		Datetime = GETDATE();
	DECLARE @ThisWeek1	Datetime;
	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;

	while @back_Month1 < 1
	begin

		EXECUTE [cmn].[spGetThisMonth1] @now, @back_Month1, @ThisWeek1 OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT;

		--print @StartDate;

		EXECUTE [anls].[spInsert�z�蔄���^�C�~���O_����^�C�~���O�𒊏o_Swap���薳��] @StartDate;

		Set @back_Month1 = @back_Month1 + 1;
	end;

END

GO


