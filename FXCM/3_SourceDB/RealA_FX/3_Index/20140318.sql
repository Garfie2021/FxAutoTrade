CREATE STATISTICS [_dta_stat_2105058535_16_5_15] ON [dbo].[T_ClosedTrades]([CloseTime], [Instrument], [OpenTime])
go
CREATE STATISTICS [_dta_stat_2105058535_15_1_16] ON [dbo].[T_ClosedTrades]([OpenTime], [TradeID], [CloseTime])
go
CREATE NONCLUSTERED INDEX [_dta_index_T_ClosedTrades_7_2105058535__K15_12] ON [dbo].[T_ClosedTrades]
(
	[OpenTime] ASC
)
INCLUDE ( 	[GrossPL]) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
CREATE NONCLUSTERED INDEX [_dta_index_T_ClosedTrades_7_2105058535__K16_K15] ON [dbo].[T_ClosedTrades]
(
	[CloseTime] ASC,
	[OpenTime] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
CREATE STATISTICS [_dta_stat_2105058535_1_16] ON [dbo].[T_ClosedTrades]([TradeID], [CloseTime])
go
SET ANSI_PADDING ON
go
CREATE NONCLUSTERED INDEX [_dta_index_T_ClosedTrades_7_2105058535__K16_K5_K1_12] ON [dbo].[T_ClosedTrades]
(
	[CloseTime] ASC,
	[Instrument] ASC,
	[TradeID] ASC
)
INCLUDE ( 	[GrossPL]) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
SET ANSI_PADDING ON
go
CREATE NONCLUSTERED INDEX [_dta_index_T_ClosedTrades_7_2105058535__K16_K5_K1_K15] ON [dbo].[T_ClosedTrades]
(
	[CloseTime] ASC,
	[Instrument] ASC,
	[TradeID] ASC,
	[OpenTime] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
CREATE STATISTICS [_dta_stat_2105058535_6_16_15_5] ON [dbo].[T_ClosedTrades]([Lot], [CloseTime], [OpenTime], [Instrument])
go
CREATE NONCLUSTERED INDEX [_dta_index_T_ClosedTrades_7_2105058535__K15_K16] ON [dbo].[T_ClosedTrades]
(
	[OpenTime] ASC,
	[CloseTime] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
SET ANSI_PADDING ON
go
CREATE NONCLUSTERED INDEX [_dta_index_T_ClosedTrades_7_2105058535__K15_K5_K16_12] ON [dbo].[T_ClosedTrades]
(
	[OpenTime] ASC,
	[Instrument] ASC,
	[CloseTime] ASC
)
INCLUDE ( 	[GrossPL]) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
SET ANSI_PADDING ON
go
CREATE NONCLUSTERED INDEX [_dta_index_T_ClosedTrades_7_2105058535__K16_K5_12] ON [dbo].[T_ClosedTrades]
(
	[CloseTime] ASC,
	[Instrument] ASC
)
INCLUDE ( 	[GrossPL]) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
CREATE NONCLUSTERED INDEX [_dta_index_T_ClosedTrades_7_2105058535__K16_12_15] ON [dbo].[T_ClosedTrades]
(
	[CloseTime] ASC
)
INCLUDE ( 	[GrossPL],
	[OpenTime]) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
CREATE STATISTICS [_dta_stat_676197459_4_1] ON [dbo].[T_OrderHistory]([Close済み], [通貨ペアNo])
go
CREATE NONCLUSTERED INDEX [_dta_index_T_OrderHistory_7_676197459__K1] ON [dbo].[T_OrderHistory]
(
	[通貨ペアNo] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
CREATE NONCLUSTERED INDEX [_dta_index_T_RateHistory_Weekly_7_66099276__K1_5] ON [dbo].[T_RateHistory_Weekly]
(
	[通貨ペアNo] ASC
)
INCLUDE ( 	[MinRate]) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
CREATE NONCLUSTERED INDEX [_dta_index_T_RateHistory_Weekly_7_66099276__K1_4_5] ON [dbo].[T_RateHistory_Weekly]
(
	[通貨ペアNo] ASC
)
INCLUDE ( 	[MaxRate],
	[MinRate]) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
SET ANSI_PADDING ON
go
CREATE NONCLUSTERED INDEX [_dta_index_T_ClosedTrades_7_2105058535__K1_K16] ON [dbo].[T_ClosedTrades]
(
	[TradeID] ASC,
	[CloseTime] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
CREATE STATISTICS [_dta_stat_85575343_19_1] ON [dbo].[T_Trades]([Time], [TradeID])
go
CREATE NONCLUSTERED INDEX [_dta_index_T_Trades_7_85575343__K19_7] ON [dbo].[T_Trades]
(
	[Time] ASC
)
INCLUDE ( 	[AmountK]) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
SET ANSI_PADDING ON
go
CREATE NONCLUSTERED INDEX [_dta_index_T_Trades_7_85575343__K1_K19_7] ON [dbo].[T_Trades]
(
	[TradeID] ASC,
	[Time] ASC
)
INCLUDE ( 	[AmountK]) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
SET ANSI_PADDING ON
go
CREATE NONCLUSTERED INDEX [_dta_index_T_Trades_7_85575343__K5_K19_1_2_3_4_6_7_8_9_10_11_12_13_14_15_16_17_18_20_21_22_23_24_25_26_27_28] ON [dbo].[T_Trades]
(
	[Instrument] ASC,
	[Time] ASC
)
INCLUDE ( 	[TradeID],
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
	[TradeIDOrigin]) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
SET ANSI_PADDING ON
go
CREATE NONCLUSTERED INDEX [_dta_index_T_Trades_7_85575343__K19_K1_5_7_9] ON [dbo].[T_Trades]
(
	[Time] ASC,
	[TradeID] ASC
)
INCLUDE ( 	[Instrument],
	[AmountK],
	[Open]) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
