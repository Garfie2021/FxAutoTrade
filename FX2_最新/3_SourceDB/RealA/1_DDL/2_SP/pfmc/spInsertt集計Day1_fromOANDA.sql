USE OANDA_DemoB
GO

DROP PROCEDURE [pfmc].[spInsertt�W�vDay1_fromOANDA]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pfmc].[spInsertt�W�vDay1_fromOANDA]
	@StartDate	datetime,
	@EndDate	datetime
AS
BEGIN

	declare	@����NoMax int = (select MAX([����No]) from [cmn].[t�����}�X�^]);

	declare	@����No int = 1;	-- �u����No=0�v�͏��O
	declare	@������	int = null;
	declare	@���~�b�g�ύX��	int = null;
	declare	@��萔	int = null;
	declare	@�����z float = null;
	declare	@����؋���	float = null;
	declare	@�L���؋���	float = null;
	declare	@�ێ��؋���	float = null;
	declare	@���X�J�b�g�]��� float = null;
	declare	@�|�W�V������ int = null;
	
	while @����No < @����NoMax
	begin

		SELECT
			@������ = COUNT(*)
		FROM [oanda].[tTransaction]
		WHERE [����No] = @����No AND @StartDate <= time AND time < @EndDate AND [type]='MARKET_ORDER_CREATE';

		SELECT
			@���~�b�g�ύX�� = COUNT(*)
		FROM [oanda].[tTransaction]
		WHERE [����No] = @����No AND @StartDate <= time AND time < @EndDate AND [type]='TRADE_UPDATE';

		SELECT
			@��萔 = COUNT(*),
			@�����z = SUM([pl])
		FROM [oanda].[tTransaction]
		WHERE [����No] = @����No AND @StartDate <= time AND time < @EndDate AND [type]='TRADE_CLOSE';

		SELECT TOP 1
			@����؋��� = [balance],
			@�ێ��؋��� = [marginUsed],
			@���X�J�b�g�]��� = [marginAvail],
			@�|�W�V������ = [openTrades]
		FROM [oanda].[tAccount]
		WHERE [����No] = @����No AND [����] <= @EndDate
		ORDER BY [����] DESC;

		INSERT INTO [pfmc].[t�W�vDay1] (
			 [����No]
			,[StartDate]
			,[������]
			,[���~�b�g�ύX��]
			,[��萔]
			,[�����z]
			,[����؋���]
			,[�L���؋���]
			,[�ێ��؋���]
			,[���X�J�b�g�]���]
			,[�|�W�V������]
	     ) VALUES (
			 @����No
			,@StartDate
			,@������
			,@���~�b�g�ύX��
			,@��萔
			,@�����z
			,@����؋���
			,@�L���؋���
			,@�ێ��؋���
			,@���X�J�b�g�]���
			,@�|�W�V������
		);

		Set @����No = @����No + 1;
	end;


END
GO

