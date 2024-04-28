USE DemoA_FX
GO

-- ���s��tOrderHistory�e�[�u����tOrderHistory_bk�փ��l�[��������

CREATE TABLE [oder].[tOrderHistory](
	[�ʉ݃y�ANo]		[tinyint]		NOT NULL,
	[����]				[datetime]		NOT NULL,
	[����Swap]			[float]			NOT NULL,
	[����Swap]			[float]			NOT NULL,
	[Swap����]			[bit]			NULL,		-- 0:����@1:����
	[����Rate]			[float]			NOT NULL,
	[����Rate]			[float]			NOT NULL,
	[��������]			[bit]			NOT NULL,		-- 0:����@1:����	���ŏI�I�ɔ��f���ꂽ��������
	[���~�b�g]			[float]			NOT NULL,
	[�����P��]			[int]			NOT NULL,
	[�ێ��|�W�V����]	[bit]			NULL,		-- NULL:�ێ��|�W�V���������@0:����@1:����
	[OpenOrderID]		[varchar](50)	NULL,
	[TradeID]			[varchar](50)	NULL,
	[CloseOrderID]		[varchar](50)	NULL,
	[Close����]			[datetime]		NULL,
	[Month1_Start]			[datetime]	NULL,
	[Month1_End]			[datetime]	NULL,
	[Month1_����WMAs2]		[float]		NULL,
	[Month1_����WMAs2�p�x]	[float]		NULL,
	[Month1_����WMAs14]		[float]		NULL,
	[Month1_����WMAs2]		[float]		NULL,
	[Month1_����WMAs2�p�x]	[float]		NULL,
	[Month1_����WMAs14]		[float]		NULL,
	[Month1_WMA����]		[tinyint]	NULL,		-- 0:����@1:����
	[Week1_Start]			[datetime]	NULL,
	[Week1_End]				[datetime]	NULL,
	[Week1_����WMAs2]		[float]		NULL,
	[Week1_����WMAs2�p�x]	[float]		NULL,
	[Week1_����WMAs14]		[float]		NULL,
	[Week1_����WMAs2]		[float]		NULL,
	[Week1_����WMAs2�p�x]	[float]		NULL,
	[Week1_����WMAs14]		[float]		NULL,
	[Week1_WMA����]			[tinyint]	NULL,		-- 0:����@1:����
	[Day1_Start]			[datetime]	NULL,
	[Day1_End]				[datetime]	NULL,
	[Day1_����WMAs2]		[float]		NULL,
	[Day1_����WMAs14]		[float]		NULL,
	[Day1_����WMAs2�p�x]	[float]		NULL,
	[Day1_����WMAs2]		[float]		NULL,
	[Day1_����WMAs14]		[float]		NULL,
	[Day1_����WMAs2�p�x]	[float]		NULL,
	[Day1_WMA����]			[tinyint]	NULL,		-- 0:����@1:����
	[Hour1_Start]			[datetime]	NULL,
	[Hour1_End]				[datetime]	NULL,
	[Hour1_����WMAs2]		[float]		NULL,
	[Hour1_����WMAs2�p�x]	[float]		NULL,
	[Hour1_����WMAs14]		[float]		NULL,
	[Hour1_����WMAs2]		[float]		NULL,
	[Hour1_����WMAs2�p�x]	[float]		NULL,
	[Hour1_����WMAs14]		[float]		NULL,
	[Hour1_WMA����]			[tinyint]	NULL,		-- 0:����@1:����
	[Min15_Start]					[datetime]	NULL,
	[Min15_End]						[datetime]	NULL,
	[Min15_����WMAs2]				[float]		NULL,
	[Min15_����WMAs2�p�x]			[float]		NULL,
	[Min15_����WMAs14]				[float]		NULL,
	[Min15_����WMAs14�p�x]			[float]		NULL,
	[Min15_����WMAs14�p�x�V�O�}]	[float]		NULL,
	[Min15_����WMAs2]				[float]		NULL,
	[Min15_����WMAs2�p�x]			[float]		NULL,
	[Min15_����WMAs14]				[float]		NULL,
	[Min15_����WMAs14�p�x]			[float]		NULL,
	[Min15_����WMAs14�p�x�V�O�}]	[float]		NULL,
	[Min15_WMA����]					[tinyint]	NULL,		-- 0:����@1:����
	[BB�J�n]						[bit]		NOT NULL,		-- 0:BB�J�n�ł͂Ȃ�WMA����@1:BB�J�n
	[Min5_Start]			[datetime]	NULL,
	[Min5_End]				[datetime]	NULL,
	[Min5_����WMAs2]		[float]		NULL,
	[Min5_����WMAs2�p�x]	[float]		NULL,
	[Min5_����WMAs14]		[float]		NULL,
	[Min5_����WMAs2]		[float]		NULL,
	[Min5_����WMAs2�p�x]	[float]		NULL,
	[Min5_����WMAs14]		[float]		NULL,
	[Min5_WMA����]			[tinyint]	NULL,		-- 0:����@1:����
	[Min1_Start]			[datetime]	NULL,
	[Min1_End]				[datetime]	NULL,
	[Min1_����WMAs2]		[float]		NULL,
	[Min1_����WMAs2�p�x]	[float]		NULL,
	[Min1_����WMAs14]		[float]		NULL,
	[Min1_����WMAs2]		[float]		NULL,
	[Min1_����WMAs2�p�x]	[float]		NULL,
	[Min1_����WMAs14]		[float]		NULL,
	[Min1_WMA����]			[tinyint]	NULL,		-- 0:����@1:����
CONSTRAINT [PK_tOrderHistory1] PRIMARY KEY CLUSTERED 
(
	[�ʉ݃y�ANo] ASC,
	[����] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT INTO [oder].[tOrderHistory]
           ([�ʉ݃y�ANo]
           ,[����]
           ,[��������]
           ,[����Swap]
           ,[����Swap]
           ,[����Rate]
           ,[����Rate]
           ,[���~�b�g]
           ,[�����P��]
           ,[BB�J�n]
           ,[OpenOrderID]
           ,[TradeID]
           ,[CloseOrderID]
           ,[Close����])
SELECT [�ʉ݃y�ANo]
      ,[����]
      ,[��������]
      ,[����Swap]
      ,[����Swap]
      ,[����Rate]
      ,[����Rate]
      ,[���~�b�g]
      ,[�����P��]
      ,[BB�J�n]
      ,[OpenOrderID]
      ,[TradeID]
      ,[CloseOrderID]
      ,[Close����]
FROM [oder].[tOrderHistory_bk]
GO

