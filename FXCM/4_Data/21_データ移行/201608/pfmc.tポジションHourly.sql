USE DemoA_FX
GO

-- ���s��tOrderHistory�e�[�u����tOrderHistory_bk�փ��l�[��������

CREATE TABLE [pfmc].[t�|�W�V����Hourly](
	[StartDate]				[datetime]	NOT NULL,
	[�ۗL�\�|�W�V������]	[float]		NULL,
	[���Z�҂��|�W�V������]	[float]		NULL,
	[����������]			[float]		NULL,
	[������萔]			[float]		NULL,
	[���������z]			[float]		NULL,
	[����؋���]			[float]		NULL,
	[�L���؋���]			[float]		NULL,
	[�ێ��؋���]			[float]		NULL,
	[���X�J�b�g�]���]		[float]		NULL,
	[�]����̊���]			[float]		NULL,
CONSTRAINT [PK_t�|�W�V����Hourly2] PRIMARY KEY CLUSTERED 
(
	[StartDate] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT INTO [pfmc].[t�|�W�V����Hourly]
           ([StartDate]
           ,[�ۗL�\�|�W�V������]
           ,[���Z�҂��|�W�V������]
           ,[����������]
           ,[������萔]
           ,[���������z]
           ,[����؋���]
           ,[�L���؋���]
           ,[�ێ��؋���]
           ,[���X�J�b�g�]���]
           ,[�]����̊���])
SELECT [StartDate]
      ,[�ۗL�\�|�W�V������]
      ,[���Z�҂��|�W�V������]
      ,[����������]
      ,[������萔]
      ,[���������z]
      ,[����؋���]
      ,[�L���؋���]
      ,[�ێ��؋���]
      ,[���X�J�b�g�]���]
      ,[�]����̊���]
  FROM [pfmc].[t�|�W�V����Hourly_bk]
GO

