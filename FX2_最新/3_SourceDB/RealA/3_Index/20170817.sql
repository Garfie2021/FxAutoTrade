USE OANDA_DemoB
GO

CREATE NONCLUSTERED INDEX [_dta_index_tMin15_7_915534345__K1_K2_K14_29] ON [hstr].[tMin15]
(
	[�ʉ݃y�ANo] ASC,
	[StartDate] ASC,
	[����WMAs14�p�x] ASC
)
INCLUDE ( 	[����WMAs14�p�x]) 
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
