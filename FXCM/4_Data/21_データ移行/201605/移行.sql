USE DemoA_FX
GO

delete from [hstr].[tBonusStage];
go

INSERT INTO [hstr].[tBonusStage]
	([通貨ペアNo]
	,[シグマ閾値]
	,[日時]
	,[買いRate]
	,[売りRate]
	,[WMA判定_15m]
	,[BS開始終了]
	,[補足])
SELECT
	 [通貨ペアNo]
	,[シグマ閾値]
	,[日時]
	,[買いRate]
	,[売りRate]
	,[WMA判定_15m]
	,[BS開始終了]
	,[補足]
FROM [dbo].[T_BonusStageHistory];
go

delete from [cmn].[tSettings]
go

INSERT INTO [cmn].[tSettings]
	([No]
	,[値]
	,[備考1]
	,[備考2])
SELECT
	 [No]
	,[値]
	,[備考1]
	,[備考2]
FROM [dbo].[T_Settings];
go


delete from [cmn].[t通貨ペアMst]
go

INSERT INTO [cmn].[t通貨ペアMst]
	([No]
	,[ペア名]
	,[SMLT_シグマ閾値]
	,[SMLT_直近1ヵ月の利益Sum]
	,[口座種別]
	,[Order間隔最小値_買い]
	,[Order間隔最小値_売り])
SELECT
	 [No]
	,[ペア名]
	,[SMLT_シグマ閾値]
	,[SMLT_直近1ヵ月の利益Sum]
	,[口座種別]
	,[Order間隔最小値_買い]
	,[Order間隔最小値_売り]
FROM [dbo].[T_通貨ペアMst];
go


delete from [pfmc].[t利益Monthly]
go

INSERT INTO [pfmc].[t利益Monthly]
           ([年月]
           ,[利益]
           ,[利益Plus]
           ,[利益Minus]
           ,[利益確定開始以降の利益]
           ,[出金可能Percent]
           ,[出金可能額]
           ,[出金済フラグ]
           ,[出金判定時_1時間前の取引証拠金]
           ,[出金判定時_現在の取引証拠金]
           ,[出金判定時_先月利益])
SELECT [年月]
      ,[利益]
      ,[利益Plus]
      ,[利益Minus]
      ,[利益確定開始以降の利益]
      ,[出金可能Percent]
      ,[出金可能額]
      ,[出金済フラグ]
      ,[出金判定時_1時間前の取引証拠金]
      ,[出金判定時_現在の取引証拠金]
      ,[出金判定時_先月利益]
FROM [hstr].[t利益Monthly]
go
