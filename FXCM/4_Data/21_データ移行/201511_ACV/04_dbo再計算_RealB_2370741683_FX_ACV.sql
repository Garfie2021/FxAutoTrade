USE [RealB_2370741683_FX_ACV];
go


DECLARE @back_15m int

DECLARE @����Min	datetime;
SELECT  @back_15m = (DATEDIFF(MINUTE, MIN([����]), getdate()) / 15) * -1
FROM [dbo].[T_RateHistory_15m]


EXECUTE [indi].[SP_WMA_15m_�v�Z_n�O���獡�܂�] @back_15m
GO
