USE OANDA_DemoB
GO

DROP PROCEDURE [pfmc].[spInsertt�W�vMonth1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pfmc].[spInsertt�W�vMonth1]
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

		SELECT TOP 1
			@����؋��� = [����؋���],
			@�ێ��؋��� = [�ێ��؋���],
			@���X�J�b�g�]��� = [���X�J�b�g�]���],
			@�|�W�V������ = [�|�W�V������]
		FROM [pfmc].[t�W�vWeek1]
		WHERE [����No] = @����No AND [StartDate] <= @EndDate
		ORDER BY [StartDate] DESC;

		INSERT INTO [pfmc].[t�W�vMonth1] (
			 [����No]
			,[StartDate]
			,[������]
			,[��萔]
			,[�����z]
			,[����؋���]
			,[�L���؋���]
			,[�ێ��؋���]
			,[���X�J�b�g�]���]
			,[�|�W�V������]
	     )
		 SELECT
		 	 @����No
			,@StartDate
			,SUM([������])
			,SUM([��萔])
			,SUM([�����z])
			,@����؋���
			,@�L���؋���
			,@�ێ��؋���
			,@���X�J�b�g�]���
			,@�|�W�V������
		FROM [pfmc].[t�W�vWeek1]
		WHERE [����No] = @����No AND @StartDate <= [StartDate] AND [StartDate] < @EndDate;
		 
		Set @����No = @����No + 1;
	end;


END
GO

