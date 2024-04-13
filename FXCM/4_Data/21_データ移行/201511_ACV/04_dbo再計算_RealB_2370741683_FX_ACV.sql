USE [RealB_2370741683_FX_ACV];
go


DECLARE @back_15m int

DECLARE @“úMin	datetime;
SELECT  @back_15m = (DATEDIFF(MINUTE, MIN([“ú]), getdate()) / 15) * -1
FROM [dbo].[T_RateHistory_15m]


EXECUTE [indi].[SP_WMA_15m_ŒvZ_n‘O‚©‚ç¡‚Ü‚Å] @back_15m
GO
