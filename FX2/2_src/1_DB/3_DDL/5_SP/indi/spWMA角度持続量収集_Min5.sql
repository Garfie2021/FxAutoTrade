USE [FX2_Demo]
GO
/*
*/
DROP PROCEDURE [indi].[spWMA�p�x�����ʎ��W_Min5]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- [rate]�X�L�[�}����[indi]�X�L�[�}�փf�[�^���R�s�[
CREATE PROCEDURE [indi].[spWMA�p�x�����ʎ��W_Min5]
AS
BEGIN
	--DELETE FROM [indi].[tIndicatorHistory_Min5];

	declare @StartDate				datetime;
	declare @����WMAs2�p�x			float;
	declare @����WMAs2�p�x�V�O�}	float;
	declare @����WMAs2�p�x��������	int;
	declare @����WMAs2�p�x����Rate	float;
	declare @����WMAs2�p�x			float;
	declare @����WMAs2�p�x�V�O�}	float;
	declare @����WMAs2�p�x��������	int;
	declare @����WMAs2�p�x����Rate	float;
	declare @Cnt					int;
	declare @�ʉ݃y�ANo				tinyint = 0;

	while @�ʉ݃y�ANo < 44
	begin

		declare cursor_tRateHistory_Min5 cursor for
		SELECT [StartDate], 
			[����WMAs2�p�x], [����WMAs2�p�x�V�O�}], [����WMAs2�p�x��������], [����WMAs2�p�x����Rate],
			[����WMAs2�p�x], [����WMAs2�p�x�V�O�}], [����WMAs2�p�x��������], [����WMAs2�p�x����Rate]
		FROM [rate].[tRateHistory_Min5]
		WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo AND ([����WMAs2�p�x��������] is not null OR [����WMAs2�p�x��������] is not null);

		open cursor_tRateHistory_Min5;

		FETCH NEXT FROM cursor_tRateHistory_Min5 INTO @StartDate, 
			@����WMAs2�p�x, @����WMAs2�p�x�V�O�}, @����WMAs2�p�x��������, @����WMAs2�p�x����Rate,
			@����WMAs2�p�x, @����WMAs2�p�x�V�O�}, @����WMAs2�p�x��������, @����WMAs2�p�x����Rate;

		WHILE @@FETCH_STATUS = 0
		BEGIN
			SELECT @Cnt = Count(*)
			FROM [indi].[tIndicatorHistory_Min5]
			WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo AND [StartDate] = @StartDate;

			IF @Cnt > 0
			BEGIN
				UPDATE [indi].[tIndicatorHistory_Min5]
				SET [����WMAs2�p�x]	= @����WMAs2�p�x,
					[����WMAs2�p�x�V�O�}]	= @����WMAs2�p�x�V�O�},
					[����WMAs2�p�x��������] = @����WMAs2�p�x��������,
					[����WMAs2�p�x����Rate] = @����WMAs2�p�x����Rate,
					[����WMAs2�p�x]	= @����WMAs2�p�x,
					[����WMAs2�p�x�V�O�}]	= @����WMAs2�p�x�V�O�},
					[����WMAs2�p�x��������] = @����WMAs2�p�x��������,
					[����WMAs2�p�x����Rate] = @����WMAs2�p�x����Rate
				WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo AND [StartDate] = @StartDate;
			END
			ELSE
			BEGIN
				INSERT INTO [indi].[tIndicatorHistory_Min5]
					([�ʉ݃y�ANo], [StartDate], 
					 [����WMAs2�p�x], [����WMAs2�p�x�V�O�}], [����WMAs2�p�x��������], [����WMAs2�p�x����Rate],
					 [����WMAs2�p�x], [����WMAs2�p�x�V�O�}], [����WMAs2�p�x��������], [����WMAs2�p�x����Rate])
				VALUES
					(@�ʉ݃y�ANo, @StartDate, 
					 @����WMAs2�p�x, @����WMAs2�p�x�V�O�}, @����WMAs2�p�x��������, @����WMAs2�p�x����Rate, 
					 @����WMAs2�p�x, @����WMAs2�p�x�V�O�}, @����WMAs2�p�x��������, @����WMAs2�p�x����Rate);
			END;

			FETCH NEXT FROM cursor_tRateHistory_Min5 INTO @StartDate, 
				@����WMAs2�p�x, @����WMAs2�p�x�V�O�}, @����WMAs2�p�x��������, @����WMAs2�p�x����Rate,
				@����WMAs2�p�x, @����WMAs2�p�x�V�O�}, @����WMAs2�p�x��������, @����WMAs2�p�x����Rate;
		END;
	
		CLOSE cursor_tRateHistory_Min5;
		DEALLOCATE cursor_tRateHistory_Min5;

		Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
	end;

END
GO
/*
*/
