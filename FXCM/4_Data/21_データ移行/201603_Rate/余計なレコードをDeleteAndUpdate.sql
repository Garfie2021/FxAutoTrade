use RealA_FX


select * 
FROM [hstr].tmonth1
where �ʉ݃y�ANo = 34
order by [StartDate] desc

DECLARE @�ʉ݃y�ANo tinyint = 34;
--while @�ʉ݃y�ANo < 44
--begin

	declare cursor_hour cursor for
	SELECT  [StartDate]
	FROM [hstr].thour1
	where �ʉ݃y�ANo = @�ʉ݃y�ANo

	open cursor_hour;

	declare @StartDate datetime;
	FETCH NEXT FROM cursor_hour INTO @StartDate;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		--select @cnt = count(*) 
		select *
		from [hstr].thour1 
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and year([StartDate])=year(@StartDate) and month([StartDate])=month(@StartDate) and day([StartDate])=day(@StartDate);
			 and day([StartDate])=day(@StartDate)

		FETCH NEXT FROM cursor_hour INTO @StartDate;
	END

	CLOSE cursor_hour;
	DEALLOCATE cursor_hour;

	Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
--end;


/*
delete FROM [hstr].tday1
where datepart(hour, [StartDate])=6

update [hstr].tday1
set [StartDate]=DATEADD(hour, 6, [StartDate])

select * 
FROM [hstr].tday1
where datepart(hour, [StartDate])<>6

DECLARE @�ʉ݃y�ANo tinyint = 34;
--while @�ʉ݃y�ANo < 44
--begin

	declare cursor_day cursor for
	SELECT  [StartDate]
	FROM [hstr].tday1
	where �ʉ݃y�ANo = @�ʉ݃y�ANo

	open cursor_day;

	declare @StartDate datetime;
	FETCH NEXT FROM cursor_day INTO @StartDate;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		--select @cnt = count(*) 
		select *
		from [hstr].tday1 
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and year([StartDate])=year(@StartDate) and month([StartDate])=month(@StartDate) and day([StartDate])=day(@StartDate);

		FETCH NEXT FROM cursor_day INTO @StartDate;
	END

	CLOSE cursor_day;
	DEALLOCATE cursor_day;

	Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
--end;


delete FROM [hstr].tweek1
where datepart(hour, [StartDate])=6

update [hstr].tweek1
set [StartDate]=DATEADD(hour, 6, [StartDate])

select * 
FROM [hstr].tweek1
where datepart(hour, [StartDate])<>6

DECLARE @�ʉ݃y�ANo tinyint = 34;
--while @�ʉ݃y�ANo < 44
--begin

	declare cursor_week cursor for
	SELECT  [StartDate]
	FROM [hstr].tweek1
	where �ʉ݃y�ANo = @�ʉ݃y�ANo

	open cursor_week;

	declare @StartDate datetime;
	FETCH NEXT FROM cursor_week INTO @StartDate;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		--select @cnt = count(*) 
		select *
		from [hstr].tweek1 
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and year([StartDate])=year(@StartDate) and month([StartDate])=month(@StartDate) and day([StartDate])=day(@StartDate);

		FETCH NEXT FROM cursor_week INTO @StartDate;
	END

	CLOSE cursor_week;
	DEALLOCATE cursor_week;

	Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
--end;
*/

/*
delete FROM [hstr].tMonth1
where datepart(hour, [StartDate])=6

update [hstr].tMonth1
set [StartDate]=DATEADD(hour, 6, [StartDate])

select * 
FROM [hstr].tMonth1
where datepart(hour, [StartDate])=6

DECLARE @�ʉ݃y�ANo tinyint = 34;
--while @�ʉ݃y�ANo < 44
--begin

	declare cursor_Month cursor for
	SELECT  [StartDate]
	FROM [hstr].tMonth1
	where �ʉ݃y�ANo = @�ʉ݃y�ANo

	open cursor_Month;

	declare @StartDate datetime;
	FETCH NEXT FROM cursor_Month INTO @StartDate;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		--select @cnt = count(*) 
		select *
		from [hstr].tMonth1 
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and year([StartDate])=year(@StartDate) and month([StartDate])=month(@StartDate) and day([StartDate])=day(@StartDate);

		FETCH NEXT FROM cursor_Month INTO @StartDate;
	END

	CLOSE cursor_Month;
	DEALLOCATE cursor_Month;

	Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
--end;
*/
