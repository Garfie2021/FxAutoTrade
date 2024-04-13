USE [FX2_Demo]
GO


--DECLARE @計算対象シグマ_1以上	float = 1;
--DECLARE @now					datetime = getdate();
--EXECUTE [reca].[sp再計算_WMA角度シグマ持続量_Month1_買い] @計算対象シグマ_1以上, @now;
--EXECUTE [reca].[sp再計算_WMA角度シグマ持続量_Month1_売り] @計算対象シグマ_1以上, @now;
--GO

--DECLARE @計算対象シグマ_1以上	float = 1;
--DECLARE @now					datetime = getdate();
--EXECUTE [reca].[sp再計算_WMA角度シグマ持続量_Week1_買い] @計算対象シグマ_1以上, @now;
--EXECUTE [reca].[sp再計算_WMA角度シグマ持続量_Week1_売り] @計算対象シグマ_1以上, @now;
--GO

--DECLARE @計算対象シグマ_1以上	float = 1;
--DECLARE @now					datetime = getdate();
--EXECUTE [reca].[sp再計算_WMA角度シグマ持続量_Day1_買い] @計算対象シグマ_1以上, @now;
--EXECUTE [reca].[sp再計算_WMA角度シグマ持続量_Day1_売り] @計算対象シグマ_1以上, @now;
--GO

--DECLARE @計算対象シグマ_1以上	float = 1;
--DECLARE @now					datetime = getdate();
--EXECUTE [reca].[sp再計算_WMA角度シグマ持続量_Hour1_買い] @計算対象シグマ_1以上, @now;
--EXECUTE [reca].[sp再計算_WMA角度シグマ持続量_Hour1_売り] @計算対象シグマ_1以上, @now;
--GO

--DECLARE @計算対象シグマ_1以上	float = 1;
--DECLARE @now					datetime = getdate();
--EXECUTE [reca].[sp再計算_WMA角度シグマ持続量_Min30_買い] @計算対象シグマ_1以上, @now;
--EXECUTE [reca].[sp再計算_WMA角度シグマ持続量_Min30_売り] @計算対象シグマ_1以上, @now;
--GO

DECLARE @計算対象シグマ_1以上	float = 0;
DECLARE @now					datetime = getdate();
EXECUTE [reca].[sp再計算_WMA角度シグマ持続量_Min15_買い] @計算対象シグマ_1以上, @now;
EXECUTE [reca].[sp再計算_WMA角度シグマ持続量_Min15_売り] @計算対象シグマ_1以上, @now;
GO

DECLARE @計算対象シグマ_1以上	float = 1;
DECLARE @now					datetime = getdate();
EXECUTE [reca].[sp再計算_WMA角度シグマ持続量_Min5_買い] @計算対象シグマ_1以上, @now;
EXECUTE [reca].[sp再計算_WMA角度シグマ持続量_Min5_売り] @計算対象シグマ_1以上, @now;
GO

DECLARE @計算対象シグマ_1以上	float = 1;
DECLARE @now					datetime = getdate();
EXECUTE [reca].[sp再計算_WMA角度シグマ持続量_Min1_買い] @計算対象シグマ_1以上, @now;
EXECUTE [reca].[sp再計算_WMA角度シグマ持続量_Min1_売り] @計算対象シグマ_1以上, @now;
GO

