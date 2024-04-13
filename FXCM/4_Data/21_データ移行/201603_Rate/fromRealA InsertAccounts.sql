USE DemoA_FX
GO

INSERT INTO [fxcm].[tAccounts]
           ([“úŽž]
           ,[AccountID]
           ,[AccountName]
           ,[Balance]
           ,[Equity]
           ,[DayPL]
           ,[NontrdEqty]
           ,[M2MEquity]
           ,[UsedMargin]
           ,[UsableMargin]
           ,[GrossPL]
           ,[Kind]
           ,[MarginCall]
           ,[IsUnderMarginCall]
           ,[Hedging]
           ,[AmountLimit]
           ,[BaseUnitSize])
SELECT [“úŽž]
      ,[AccountID]
      ,[AccountName]
      ,[Balance]
      ,[Equity]
      ,[DayPL]
      ,[NontrdEqty]
      ,[M2MEquity]
      ,[UsedMargin]
      ,[UsableMargin]
      ,[GrossPL]
      ,[Kind]
      ,[MarginCall]
      ,[IsUnderMarginCall]
      ,[Hedging]
      ,[AmountLimit]
      ,[BaseUnitSize]
FROM [dbo].[T_AccountsHistory] as b
where not exists 
(
	SELECT *
	FROM [fxcm].[tAccounts] as a
	where (a.[“úŽž] = b.[“úŽž])
)
go

