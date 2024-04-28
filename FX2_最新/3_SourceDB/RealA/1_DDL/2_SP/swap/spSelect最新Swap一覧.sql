USE OANDA_RealA
GO

DROP PROCEDURE [swap].[spSelect�ŐVSwap�ꗗ]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [swap].[spSelect�ŐVSwap�ꗗ]
AS
BEGIN

	select
		b.�y�A�� as �ʉ݃y�A��,
		[����Swap],
		[����Swap]
	from
	(
		SELECT
			rank() over(partition by [�ʉ݃y�ANo] order by [StartDate] desc) as rk,
			[�ʉ݃y�ANo]
			,[StartDate],
			[����Swap],[����Swap]
		FROM OANDA_RealA.[swap].[tSwap�蓮�o�^_Day1]
	) as a LEFT JOIN OANDA_RealA.[cmn].[t�ʉ݃y�AMst] as b ON a.�ʉ݃y�ANo = b.[No]
	where rk=1 
	order by b.�y�A��

END
GO

