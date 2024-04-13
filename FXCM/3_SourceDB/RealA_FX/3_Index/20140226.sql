use FX_RealA;

CREATE NONCLUSTERED INDEX [_dta_index_T_RateHistory_1m_5_775673811__K2] ON [dbo].[T_RateHistory_1m] 
(
	[日時] ASC
)WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go

CREATE NONCLUSTERED INDEX [_dta_index_T_RateHistory_5_5575058__K1_K2_5] ON [dbo].[T_RateHistory] 
(
	[通貨ペア] ASC,
	[Date] ASC
)
INCLUDE ( [Swap_買い]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
CREATE NONCLUSTERED INDEX [_dta_index_T_RateHistory_5_5575058__K1_K2_6] ON [dbo].[T_RateHistory] 
(
	[通貨ペア] ASC,
	[Date] ASC
)
INCLUDE ( [Swap_売り]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
CREATE NONCLUSTERED INDEX [_dta_index_T_RateHistory_5_5575058__K1_K2_3] ON [dbo].[T_RateHistory] 
(
	[通貨ペア] ASC,
	[Date] ASC
)
INCLUDE ( [Rate_買い]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
CREATE NONCLUSTERED INDEX [_dta_index_T_RateHistory_5_5575058__K1_K2_4] ON [dbo].[T_RateHistory] 
(
	[通貨ペア] ASC,
	[Date] ASC
)
INCLUDE ( [Rate_売り]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
CREATE NONCLUSTERED INDEX [_dta_index_T_RateHistory_5_5575058__K2_K1_3_4_5_6] ON [dbo].[T_RateHistory] 
(
	[Date] ASC,
	[通貨ペア] ASC
)
INCLUDE ( [Rate_買い],
[Rate_売り],
[Swap_買い],
[Swap_売り]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
CREATE NONCLUSTERED INDEX [_dta_index_T_RateHistory_1m_5_775673811__K2_1_3_4_5_6_7_8_9_10_11_12_13_14] ON [dbo].[T_RateHistory_1m] 
(
	[日時] ASC
)
INCLUDE ( [通貨ペアNo],
[買い_始値],
[買い_高値],
[買い_安値],
[買い_終値],
[売り_始値],
[売り_高値],
[売り_安値],
[売り_終値],
[MaxSwap],
[MinSwap],
[StartDate],
[EndDate]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
