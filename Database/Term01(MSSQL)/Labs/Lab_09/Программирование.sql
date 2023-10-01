--------------------------Task_01--------------------------
use UNIVER;

DECLARE @a1 char = 'a',
		@a2	varchar = 'b',
		@a3	datetime, 
		@a4 time, 
		@a5 int,
		@a6 smallint,
		@a7	tinyint,
		@a8	numeric(12, 5);

set @a3 = GETDATE();
set @a5 = 12;
set @a6 = 13;
set @a7 = 14;
set @a8 = 15;
select @a1 a, @a2 a2, @a3 a3
print 'a4 = ' + cast(@a4 as varchar(10))
print 'a5 = ' + cast(@a5 as varchar(10))
print 'a6 = ' + cast(@a6 as varchar(10))
print 'a7 = ' + cast(@a7 as varchar(10))
print 'a8 = ' + cast(@a8 as varchar(10))

--------------------------Task_02--------------------------
USE UNIVER;
declare @i1 int = (select sum(AUDITORIUM_CAPACITY) from AUDITORIUM);
if @i1 < 200
begin
	declare @i2 int = (select avg(AUDITORIUM_CAPACITY) as int from AUDITORIUM), @i3 real, @i4 real, @i5 real;
	set @i3 = (select count(*) from AUDITORIUM where AUDITORIUM_CAPACITY<@i2);
	set @i4 = (select count(*) from AUDITORIUM);
	set @i5 = (select cast((@i3/@i5)*100 as numeric(4,2)));
	select @i1 sum, @i2 avg, @i3 count, @i4'%';
end
else print 'CAPACITY: '+ cast(@i1 as varchar(10));
--------------------------Task_03--------------------------
USE UNIVER;
print 'Количество обработанных строк: '+cast(@@rowcount as varchar(12));
print 'Версия: '+cast(@@version as varchar(100));
print 'Номер процесса: '+cast(@@spid as varchar(12));
print 'Код последней ошибки: '+cast(@@error as varchar(10));
print 'Имя сервера: '+cast(@@servername as varchar(100));
print 'Уровень вложенности транзакции: '+cast(@@trancount as varchar(20));
print 'Проверка результата считывания строк результирующего набора: '+cast(@@fetch_status as varchar(20));
print 'Уровень вложенности текущей проце-дуры: '+cast(@@nestlevel as varchar(20));
--------------------------Task_04--------------------------
declare @t float=0.3, @x float=0.5, @z float;
if (@t>@x) set @z=power(sin(@t),2)
else if(@t<@x) set @z=1-exp(@x-2)
else set @z=4*(@t+@x)
print 'z= '+cast(@z as varchar(10));

declare @full_name nvarchar(100) = 'Макейчик Татьяна Леонидовна'
select 
    concat_ws(' ', 
        LEFT(@full_name, charindex(' ', @full_name) - 1), 
        LEFT(substring(@full_name, charindex(' ', @full_name) + 1, 1), 1) + '.', 
        LEFT(substring(@full_name, charindex(' ', @full_name, charindex(' ', @full_name) + 1) + 1, 1), 1) + '.') as Гатова

USE UNIVER
select DATENAME(dw,PDATE) from STUDENT inner join PROGRESS on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT where SUBJECT = 'СУБД' and IDGROUP = 5 GROUP BY PDATE

declare @numberMountch int = month(getdate());
select STUDENT.NAME,datediff(yy,STUDENT.BDAY,getdate()) from STUDENT where month(STUDENT.BDAY) = @numberMountch + 1;
--------------------------Task_05--------------------------
USE UNIVER
declare @num1 int = (select avg(PROGRESS.NOTE) from STUDENT inner join PROGRESS on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT where STUDENT.IDGROUP=6)
if @num1 < 4
begin 
	print 'Надо постараться';
end
else if @num1 >= 4 and @num1 < 7
begin
	print 'Чуть больше уделить времени и нормально';
end;
else if @num1 between 8 and 10
begin
	print 'Неплохо';
end
else 
	print 'Данных нет';
--------------------------Task_06--------------------------
select STUDENT.NAME [Имя], STUDENT.IDGROUP [Группа],
case	when PROGRESS.NOTE between 0 and 3 then 'плохо'
		when PROGRESS.NOTE between 4 and 6 then 'нормально'
		when PROGRESS.NOTE between 7 and 8 then 'неплохо'
else 'отлично'
end Оценка, COUNT(*)[Количество]
from STUDENT inner join GROUPS on STUDENT.IDGROUP = GROUPS.IDGROUP 
			 inner join PROFESSION on PROFESSION.PROFESSION = GROUPS.PROFESSION
			 inner join PROGRESS on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
where PROFESSION.FACULTY = 'ИТ'
group by student.NAME, student.IDGROUP,
case	when PROGRESS.NOTE between 0 and 3 then 'плохо'
		when PROGRESS.NOTE between 4 and 6 then 'нормально'
		when PROGRESS.NOTE between 7 and 8 then 'неплохо'
else 'отлично'
end
--------------------------Task_07--------------------------
create table #Table
(
	ID int identity(0,100),
	LOTO INT,
	Moneys money
);
set nocount on -- не выводить сообщение о вводе строки
declare @ii int = 0;
while @ii < 10
	begin
	insert #Table(LOTO,Moneys)
		values(1500*Rand(),15000*(Rand()))
		set @ii= @ii+1;
	end;
select * from #Table

drop table #Table
--------------------------Task_08--------------------------
declare @xx int = 1
while @xx < 10
begin
	print @xx
	set @xx=@xx+1
	if (@xx > 5) return
end
--------------------------Task_09--------------------------
declare @5 int = 5, @0 int = 0;
begin TRY
	print @5/@0;
end try
begin catch
	print 'Код последней ошибки ' + CAST(ERROR_NUMBER() as varchar(200));
	print 'Сообщение об ошибке ' + ERROR_MESSAGE()
	print 'Номер строки с ошибкой ' +CAST(ERROR_LINE() as varchar(200));
	print 'Уровень серьезности ошибки ' + CAST(ERROR_SEVERITY() as varchar(200));
	print 'Метка ошибки ' + CAST(ERROR_STATE() as varchar(200));
end catch