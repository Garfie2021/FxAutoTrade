USE OANDA_DemoB
GO

DROP PROCEDURE [report].[spSelect�ʉ݃y�A�ʎ��n��������|�[�g]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [report].[spSelect�ʉ݃y�A�ʎ��n��������|�[�g]
AS
BEGIN

	SELECT 'oanda.tTrade', [time] 
	FROM [OANDA_DemoB].[oanda].[tTrade]
	union
	SELECT 'oder.tOrderHistory2', [����] 
	FROM [OANDA_DemoB].[oder].[tOrderHistory2]

END
GO

