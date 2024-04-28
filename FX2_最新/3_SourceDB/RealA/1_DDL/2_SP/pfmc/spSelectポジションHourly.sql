USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [pfmc].[spSelect�|�W�V����Hourly]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pfmc].[spSelect�|�W�V����Hourly]
	@����No int,
	@from	DateTime,
	@to		DateTime
AS
BEGIN

	SELECT *
	from (
		SELECT TOP 1
			[StartDate],
			[�ۗL�\�|�W�V������],
			[���Z�҂��|�W�V������],
			[����������],
			[������萔],
			[���������z],
			[����؋���],
			[�L���؋���],
			[�ێ��؋���],
			[���X�J�b�g�]���],
			[�]����̊���]
		FROM [pfmc].[t�|�W�V����Hourly]
		where [����No] = @����No AND @from <= [StartDate] and [StartDate] < @to
		order by [StartDate]
	) as t1 
	UNION
	SELECT *
	from (
		SELECT TOP 1
			[StartDate],
			[�ۗL�\�|�W�V������],
			[���Z�҂��|�W�V������],
			[����������],
			[������萔],
			[���������z],
			[����؋���],
			[�L���؋���],
			[�ێ��؋���],
			[���X�J�b�g�]���],
			[�]����̊���]
		FROM [pfmc].[t�|�W�V����Hourly]
		where [����No] = @����No AND @from <= [StartDate] and [StartDate] < @to
		order by [StartDate] desc
	) as t2 ;

END
GO
/*
*/