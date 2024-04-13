USE DemoA_FX
GO

delete from [hstr].[t利益Monthly];

INSERT INTO [hstr].[t利益Monthly]
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
FROM [dbo].[T_利益_Monthly];



