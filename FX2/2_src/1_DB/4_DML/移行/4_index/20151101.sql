USE [FX2_Demo]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tRateHistory_Min15_5_661577395__K1_K2_K17] ON [rate].[tRateHistory_Min15]
(
	[通貨ペアNo] ASC,
	[StartDate] ASC,
	[売りWMAs2角度] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [_dta_index_tRateHistory_Min15_5_661577395__K1_K2_K8] ON [rate].[tRateHistory_Min15]
(
	[通貨ペアNo] ASC,
	[StartDate] ASC,
	[買いWMAs2角度] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tRateHistory_Min5_5_1173579219__K1_K2_K17] ON [rate].[tRateHistory_Min5]
(
	[通貨ペアNo] ASC,
	[StartDate] ASC,
	[売りWMAs2角度] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [_dta_index_tRateHistory_Min5_5_1173579219__K1_K8_K2] ON [rate].[tRateHistory_Min5]
(
	[通貨ペアNo] ASC,
	[買いWMAs2角度] ASC,
	[StartDate] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tRateHistory_Min1_5_1237579447__K1_K17_K2] ON [rate].[tRateHistory_Min1]
(
	[通貨ペアNo] ASC,
	[売りWMAs2角度] ASC,
	[StartDate] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [_dta_index_tRateHistory_Min1_5_1237579447__K1_K8_K2] ON [rate].[tRateHistory_Min1]
(
	[通貨ペアNo] ASC,
	[買いWMAs2角度] ASC,
	[StartDate] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tRateHistory_Min1_5_1237579447__K1_K2] ON [rate].[tRateHistory_Min1]
(
	[通貨ペアNo] ASC,
	[StartDate] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [_dta_index_tRateHistory_Min1_5_1237579447__K1] ON [rate].[tRateHistory_Min1]
(
	[通貨ペアNo] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tRateHistory_Min5_5_1173579219__K1_K2] ON [rate].[tRateHistory_Min5]
(
	[通貨ペアNo] ASC,
	[StartDate] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [_dta_index_tRateHistory_Min5_5_1173579219__K1] ON [rate].[tRateHistory_Min5]
(
	[通貨ペアNo] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO

CREATE STATISTICS [_dta_stat_999674609_10_1_2] ON [oder].[tOrderHistory]([Close済み], [通貨ペアNo], [OrderDate])
GO
