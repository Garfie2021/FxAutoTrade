USE [RealB_2370741683_FX_ACV];
go


DECLARE @back_15m int

DECLARE @日時Min	datetime;
SELECT  @back_15m = (DATEDIFF(MINUTE, MIN([日時]), getdate()) / 15) * -1
FROM [dbo].[T_RateHistory_15m]


EXECUTE [indi].[SP_WMA_15m_計算_n前から今まで] @back_15m
GO
