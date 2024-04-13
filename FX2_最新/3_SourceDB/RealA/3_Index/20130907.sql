CREATE NONCLUSTERED INDEX [_dta_index_T_RateHistory_12_421576540__K1_5] ON [dbo].[T_RateHistory] 
(
	[通貨ペア] ASC
)
INCLUDE ( [Swap_買い]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
CREATE NONCLUSTERED INDEX [_dta_index_T_RateHistory_12_421576540__K1_6] ON [dbo].[T_RateHistory] 
(
	[通貨ペア] ASC
)
INCLUDE ( [Swap_売り]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
CREATE NONCLUSTERED INDEX [_dta_index_T_RateHistory_12_421576540__K1_3] ON [dbo].[T_RateHistory] 
(
	[通貨ペア] ASC
)
INCLUDE ( [Rate_買い]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
CREATE NONCLUSTERED INDEX [_dta_index_T_RateHistory_12_421576540__K1_4] ON [dbo].[T_RateHistory] 
(
	[通貨ペア] ASC
)
INCLUDE ( [Rate_売り]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go

CREATE STATISTICS [_dta_stat_117575457_6_1] ON [dbo].[T_ClosedTrades]([Lot], [TradeID])
go
CREATE STATISTICS [_dta_stat_117575457_6_16_5] ON [dbo].[T_ClosedTrades]([Lot], [CloseTime], [Instrument])
go
CREATE NONCLUSTERED INDEX [_dta_index_T_ClosedTrades_12_117575457__K16_12] ON [dbo].[T_ClosedTrades] 
(
	[CloseTime] ASC
)
INCLUDE ( [GrossPL]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
CREATE NONCLUSTERED INDEX [_dta_index_T_ClosedTrades_12_117575457__K16_K5] ON [dbo].[T_ClosedTrades] 
(
	[CloseTime] ASC,
	[Instrument] ASC
)WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go

CREATE STATISTICS [_dta_stat_245575913_20_1] ON [dbo].[T_Trades]([IsBuy], [TradeID])
go
CREATE STATISTICS [_dta_stat_245575913_5_19] ON [dbo].[T_Trades]([Instrument], [Time])
go
CREATE NONCLUSTERED INDEX [_dta_index_T_Trades_12_245575913__K5_9] ON [dbo].[T_Trades] 
(
	[Instrument] ASC
)
INCLUDE ( [Open]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
CREATE NONCLUSTERED INDEX [_dta_index_T_Trades_12_245575913__K19_K5] ON [dbo].[T_Trades] 
(
	[Time] ASC,
	[Instrument] ASC
)WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
CREATE NONCLUSTERED INDEX [_dta_index_T_Trades_12_245575913__K19D_K5_1_2_3_4_6_7_8_9_10_11_12_13_14_15_16_17_18_20_21_22_23_24_25_26_27_28] ON [dbo].[T_Trades] 
(
	[Time] DESC,
	[Instrument] ASC
)
INCLUDE ( [TradeID],
[AccountID],
[AccountName],
[OfferID],
[Lot],
[AmountK],
[BS],
[Open],
[Close],
[Stop],
[UntTrlMove],
[Limit],
[UntTrlMoveLimit],
[PL],
[GrossPL],
[Com],
[Int],
[IsBuy],
[Kind],
[QuoteID],
[OpenOrderID],
[OpenOrderReqID],
[QTXT],
[StopOrderID],
[LimitOrderID],
[TradeIDOrigin]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go

CREATE STATISTICS [_dta_stat_245575913_20_19_5] ON [dbo].[T_Trades]([IsBuy], [Time], [Instrument])
go
CREATE NONCLUSTERED INDEX [_dta_index_T_Trades_12_245575913__K5_9_19] ON [dbo].[T_Trades] 
(
	[Instrument] ASC
)
INCLUDE ( [Open],
[Time]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
