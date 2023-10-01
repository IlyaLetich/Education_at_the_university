---------------------Task_01---------------------
USE UNIVER;
exec sp_helpindex 'PULPIT'
exec sp_helpindex 'SUBJECT'	
exec sp_helpindex 'FACULTY'
exec sp_helpindex 'TEACHER'
exec sp_helpindex 'AUDITORIUM_TYPE'
exec sp_helpindex 'AUDITORIUM'
exec sp_helpindex 'STUDENT'
exec sp_helpindex 'PROGRESS'

drop table #temp_table
create table #temp_table(
field_01 int,
field_02 varchar(20))
set nocount on
declare @i int = 0
while @i < 1000
begin
	insert #temp_table(field_01,field_02)
		values(FLOOR(RAND()*10000), REPLICATE('lol ',3))
		set @i = @i + 1;
end

select count(*) [количество строчек] from #temp_table
select * from #temp_table

select * from #temp_table where field_01 between 1500 and 5000

checkpoint;  
DBCC DROPCLEANBUFFERS;  

DROP index #temp_table_cl on #temp_table
CREATE clustered index #temp_table_cl on #temp_table(field_01 asc)
---------------------Task_02---------------------
USE UNIVER;
drop table #temp_table_1
create table #temp_table_1(
field_01 int,
field_02 varchar(20),
counter_01 int identity(1,1))
set nocount on
declare @j int = 0
while @j < 10000
begin 
	insert #temp_table_1(field_01,field_02)
	values (FLOOR(RAND()*10000), REPLICATE('lol ',3));
	set @j = @j + 1
end

select count(*) [количество строчек] from #temp_table_1
select * from #temp_table_1

select * from #temp_table_1 where counter_01 >500 and field_01 between 1500 and 5000

CREATE index #temp_table_1_nonclu on #temp_table_1(field_01, counter_01)
DROP index #temp_table_1_nonclu on #temp_table_1

select counter_01 from #temp_table_1 where field_01 = 500
---------------------Task_03---------------------
USE UNIVER;
drop table #temp_table_2
create table #temp_table_2(
field_01 int,
field_02 varchar(20),
counter_01 int identity(1,1))
set nocount on
declare @k int = 0
while @k < 10000
begin 
	insert #temp_table_2(field_01,field_02)
	values (FLOOR(RAND()*10000), REPLICATE('lol ',3));
	set @k = @k + 1
end

select count(*) [количество строчек] from #temp_table_2
select * from #temp_table_2

CREATE index #temp_table_2_nonclu on #temp_table_2(counter_01) include(field_01)
DROP index #temp_table_2_nonclu on #temp_table_2

select counter_01 from #temp_table_2 where counter_01 > 5000
---------------------Task_04---------------------
USE UNIVER;
drop table #temp_table_3
create table #temp_table_3(
	field_01 int,
	field_02 varchar(20),
	counter_01 int identity(1,1))
set nocount on
declare @g int = 0
while @g < 10000
begin 
	insert #temp_table_3(field_01,field_02)
	values (FLOOR(RAND()*10000), REPLICATE('lol ',3));
	set @g = @g + 1
end

select field_01 from #temp_table_3 where (field_01 > 1500 and field_01 < 2000)

CREATE index #temp_table_3_nonclu on #temp_table_3(field_01) where (field_01 > 1500 and field_01 < 5000)
DROP index #temp_table_3_nonclu on #temp_table_3
---------------------Task_05---------------------
USE tempdb;
drop table #temp_table_4
create table #temp_table_4(
field_01 int,
field_02 varchar(20),
counter_01 int identity(1,1))
set nocount on
declare @p int = 0
while @p < 10000
begin 
	insert #temp_table_4(field_01,field_02)
	values (FLOOR(RAND()*10000), REPLICATE('lol ',3));
	set @p = @p + 1
end

select COUNT(*) from #temp_table_4

CREATE index #temp_table_4_nonclu on #temp_table_4(field_01)
DROP index #temp_table_4_nonclu on #temp_table_4

INSERT top(10000) #temp_table_4(field_01, field_02) select field_01, field_02 from #temp_table_4;

SELECT name [Индекс], avg_fragmentation_in_percent [Фрагментация (%)]
FROM sys.dm_db_index_physical_stats(DB_ID('tempdb'), 
OBJECT_ID(N'#temp_table_4'), NULL, NULL, NULL) ss  
JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id  WHERE name is not null;

ALTER index #temp_table_4_nonclu on #temp_table_4 reorganize;

ALTER index #temp_table_4_nonclu on #temp_table_4 rebuild with (online = off);
---------------------Task_06---------------------
USE tempdb;
drop table #temp_table_5
create table #temp_table_5(
field_01 int,
field_02 varchar(20),
counter_01 int identity(1,1))
set nocount on
declare @t int = 0
while @t < 10000
begin 
	insert #temp_table_5(field_01,field_02)
	values (FLOOR(RAND()*10000), REPLICATE('lol ',3));
	set @t = @t + 1
end

select COUNT(*) from #temp_table_5

CREATE index #temp_table_5_nonclu on #temp_table_5(field_01) with (fillfactor = 65);
DROP index #temp_table_5_nonclu on #temp_table_5

INSERT top(10000) #temp_table_4(field_01, field_02) select field_01, field_02 from #temp_table_5;

SELECT name [Индекс], avg_fragmentation_in_percent [Фрагментация (%)]
FROM sys.dm_db_index_physical_stats(DB_ID('tempdb'), 
OBJECT_ID(N'#temp_table_5'), NULL, NULL, NULL) ss  
JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id  WHERE name is not null;
---------------------Task_01 Home---------------------
USE Ilya_MyBase;
create index #ГП on dbo.Грузоперевозки(ID_грузоперевозки);
select * from Грузоперевозки where ID_грузоперевозки = 2;