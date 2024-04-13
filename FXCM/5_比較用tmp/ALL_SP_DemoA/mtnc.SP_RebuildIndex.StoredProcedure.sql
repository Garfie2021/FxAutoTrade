USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [mtnc].[SP_RebuildIndex]
AS
BEGIN

	SET NOCOUNT ON;

	alter index [_dta_index_T_RateHistory_5_5575058__K1_3] ON [dbo].[T_RateHistory] rebuild partition=ALL with (DATA_COMPRESSION = PAGE)
	alter index _dta_index_T_RateHistory_5_5575058__K1_4 ON [dbo].[T_RateHistory] rebuild partition=ALL with (DATA_COMPRESSION = PAGE)
	alter index _dta_index_T_RateHistory_5_5575058__K1_5 ON [dbo].[T_RateHistory] rebuild partition=ALL with (DATA_COMPRESSION = PAGE)
	alter index _dta_index_T_RateHistory_5_5575058__K1_6 ON [dbo].[T_RateHistory] rebuild partition=ALL with (DATA_COMPRESSION = PAGE)

	alter index _dta_index_T_注文設定History2_5_629577281__K12_K2 ON [dbo].[T_注文設定History2] rebuild partition=ALL with (DATA_COMPRESSION = PAGE)



END


GO
