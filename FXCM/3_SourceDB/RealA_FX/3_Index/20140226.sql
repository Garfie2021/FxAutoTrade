use FX_RealA;

CREATE NONCLUSTERED INDEX [_dta_index_T_RateHistory_1m_5_775673811__K2] ON [dbo].[T_RateHistory_1m] 
(
	[ϊ] ASC
)WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go

CREATE NONCLUSTERED INDEX [_dta_index_T_RateHistory_5_5575058__K1_K2_5] ON [dbo].[T_RateHistory] 
(
	[ΚέyA] ASC,
	[Date] ASC
)
INCLUDE ( [Swap_’]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
CREATE NONCLUSTERED INDEX [_dta_index_T_RateHistory_5_5575058__K1_K2_6] ON [dbo].[T_RateHistory] 
(
	[ΚέyA] ASC,
	[Date] ASC
)
INCLUDE ( [Swap_θ]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
CREATE NONCLUSTERED INDEX [_dta_index_T_RateHistory_5_5575058__K1_K2_3] ON [dbo].[T_RateHistory] 
(
	[ΚέyA] ASC,
	[Date] ASC
)
INCLUDE ( [Rate_’]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
CREATE NONCLUSTERED INDEX [_dta_index_T_RateHistory_5_5575058__K1_K2_4] ON [dbo].[T_RateHistory] 
(
	[ΚέyA] ASC,
	[Date] ASC
)
INCLUDE ( [Rate_θ]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
CREATE NONCLUSTERED INDEX [_dta_index_T_RateHistory_5_5575058__K2_K1_3_4_5_6] ON [dbo].[T_RateHistory] 
(
	[Date] ASC,
	[ΚέyA] ASC
)
INCLUDE ( [Rate_’],
[Rate_θ],
[Swap_’],
[Swap_θ]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
CREATE NONCLUSTERED INDEX [_dta_index_T_RateHistory_1m_5_775673811__K2_1_3_4_5_6_7_8_9_10_11_12_13_14] ON [dbo].[T_RateHistory_1m] 
(
	[ϊ] ASC
)
INCLUDE ( [ΚέyANo],
[’_nl],
[’_l],
[’_ΐl],
[’_Il],
[θ_nl],
[θ_l],
[θ_ΐl],
[θ_Il],
[MaxSwap],
[MinSwap],
[StartDate],
[EndDate]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
go
