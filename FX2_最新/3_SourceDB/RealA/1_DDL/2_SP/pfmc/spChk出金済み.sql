USE OANDA_RealA
GO
/*
*/
DROP PROCEDURE [pfmc].[spChk出金済み]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pfmc].[spChk出金済み]
	@now				datetime,
	@現在の取引証拠金	int,
	@先月利益			int,
	@出金済フラグ		tinyint	output
AS
BEGIN
	/*
	DECLARE @now datetime = '2014/05/01 3:12:32';
	DECLARE @現在の取引証拠金	int = 9326056;
	DECLARE @先月利益			int = -18358;
	DECLARE @出金済フラグ	tinyint;
	*/

	Set @now = DATEADD(month, -1, @now);
	DECLARE @先月 date = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/01';

	select @出金済フラグ = [出金済フラグ]
	from pfmc.t利益Monthly
	WHERE [年月] = @先月

	if @出金済フラグ = 1
	begin
		--出金済み
		return;
	end;

	-- 現在は出金済み？
	-- 1時間前の証拠金と、現在の証拠金を比較して、当月引き落とし可能額が減っていたら、出金されたと見なし、出金済みフラグを1にする

	DECLARE @1時間前の取引証拠金	int;
	SELECT TOP 1
		@1時間前の取引証拠金 = [Balance]
	FROM
		fxcm.tAccounts
	WHERE
		日時 < DATEADD(HOUR, -1, @now)
	ORDER BY
		日時 DESC

	if @1時間前の取引証拠金 is NULL
	begin
		--未出金
		Set @出金済フラグ = 0;
		return;
	end;

	if @1時間前の取引証拠金 > (@現在の取引証拠金 - (@先月利益 - @先月利益 * 0.1))
	begin
		--出金済み
		UPDATE pfmc.t利益Monthly
		SET [出金済フラグ] = 1,
			[出金判定時_1時間前の取引証拠金] = @1時間前の取引証拠金,
			[出金判定時_現在の取引証拠金] = @現在の取引証拠金,
			[出金判定時_先月利益] = @先月利益
		WHERE [年月] = @先月
					
		--出金済み、余剰金から当月出金可能額を減らすのはやめる
		Set @出金済フラグ = 1;
		return;
	end
	else
	begin
		--未出金
		Set @出金済フラグ = 0;
		return;
	end

END
GO
/*
*/

