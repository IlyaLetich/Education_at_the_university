---------------------Task_01---------------------
USE UNIVER;
set nocount on
if  exists (select * from  SYS.OBJECTS    
            where OBJECT_ID= object_id(N'dbo.Example') )	            
drop table Example;           
declare @c int, @flag char = 'c'; 
SET IMPLICIT_TRANSACTIONS  ON  
CREATE table Example(K int );  
	INSERT Example values (1),(2),(3);
	set @c = (select count(*) from Example);
	print 'количество строк в таблице Example: ' + cast( @c as varchar(2));
	if @flag = 'c'  commit;             
          else   rollback;              
  SET IMPLICIT_TRANSACTIONS  OFF 

if  exists (select * from  SYS.OBJECTS  
            where OBJECT_ID= object_id(N'DBO.Example') )
print 'таблица Example есть';  
else print 'таблицы Example нет'

---------------------Task_02---------------------
USE UNIVER;

delete from FACULTY where FACULTY = 'Тут'

begin try
	begin tran
		insert FACULTY values ('Тут','тут я не знаю что придумать')
		update FACULTY set FACULTY_NAME = 'Всё ок' where FACULTY = 'Тут'
	commit tran
end try
begin catch
	print 'ошибка '+case
	when error_number() = 2627 and patindex('%FACULTY_PK%',error_message()) > 0
	then 'дублирование' 
	else 'неизвестная ошибка: '+ cast(error_number() as varchar(5))+ error_message()
	end;
	if @@TRANCOUNT > 0 rollback tran;
end catch

select * from FACULTY
---------------------Task_03---------------------
use UNIVER

delete from FACULTY where FACULTY = 'Тут'

declare @point varchar(3)
begin try
	begin tran
		insert FACULTY values ('Тут','тут я не знаю что придумать')
		set @point = 'p1'; save tran @point
		insert PROGRESS values ('ASD',2113,'2023-21-12',10);
		set @point = 'p2'; save tran @point
		update FACULTY set FACULTY_NAME = 'Всё ок' where FACULTY = 'Тут'
		set @point = 'p3'; save tran @point
	commit tran
end try
begin catch
	print 'ошибка ' + error_message()
	if @@TRANCOUNT > 0
	begin
		print 'точка: ' + cast(@point as varchar)
		rollback tran @point
		commit tran
	end
end catch

select * from FACULTY
---------------------Task_04---------------------
USE UNIVER;
-----Сценарий A-----
set transaction isolation level READ UNCOMMITTED;
begin transaction
-----t1-----
	select @@SPID, 'insert AUDITORIUM_TYPE' 'результат', * from AUDITORIUM_TYPE
															   where AUDITORIUM_TYPE = 'СЗ';
	select @@SPID, 'update AUDITORIUM_TYPE' 'результат', * from AUDITORIUM_TYPE
															   where AUDITORIUM_TYPE = 'ЛК';
	WAITFOR DELAY '00:00:03';

	select @@SPID, 'insert AUDITORIUM_TYPE' 'результат', * from AUDITORIUM_TYPE
															   where AUDITORIUM_TYPE = 'СЗ';
	select @@SPID, 'update AUDITORIUM_TYPE' 'результат', * from AUDITORIUM_TYPE
															   where AUDITORIUM_TYPE = 'ЛК';
commit;
---------------------Task_05---------------------
USE UNIVER;
set transaction isolation level READ COMMITTED;
begin transaction
-----t1-----
	select @@SPID, 'insert AUDITORIUM_TYPE' 'результат', * from AUDITORIUM_TYPE
															   where AUDITORIUM_TYPE = 'СЗ';
	select @@SPID, 'update AUDITORIUM_TYPE' 'результат', * from AUDITORIUM_TYPE
															   where AUDITORIUM_TYPE = 'ЛК';
	WAITFOR DELAY '00:00:07';

	select @@SPID, 'insert AUDITORIUM_TYPE' 'результат', * from AUDITORIUM_TYPE
															   where AUDITORIUM_TYPE = 'СЗ';
	select @@SPID, 'update AUDITORIUM_TYPE' 'результат', * from AUDITORIUM_TYPE
															   where AUDITORIUM_TYPE = 'ЛК';
commit;
---------------------Task_06---------------------
USE UNIVER;
set transaction isolation level REPEATABLE READ;
begin transaction
-----t1-----
	select @@SPID, 'insert AUDITORIUM_TYPE' 'результат', * from AUDITORIUM_TYPE
															   where AUDITORIUM_TYPE = 'СЗ';
	select @@SPID, 'update AUDITORIUM_TYPE' 'результат', * from AUDITORIUM_TYPE
															   where AUDITORIUM_TYPE = 'ЛК';
	WAITFOR DELAY '00:00:07';

	select @@SPID, 'insert AUDITORIUM_TYPE' 'результат', * from AUDITORIUM_TYPE
															   where AUDITORIUM_TYPE = 'СЗ';
	select @@SPID, 'update AUDITORIUM_TYPE' 'результат', * from AUDITORIUM_TYPE
															   where AUDITORIUM_TYPE = 'ЛК';
commit;
---------------------Task_07---------------------
USE UNIVER;
set transaction isolation level SERIALIZABLE;
begin transaction
-----t1-----
	select @@SPID, 'insert AUDITORIUM_TYPE' 'результат', * from AUDITORIUM_TYPE
															   where AUDITORIUM_TYPE = 'СЗ';
	select @@SPID, 'update AUDITORIUM_TYPE' 'результат', * from AUDITORIUM_TYPE
															   where AUDITORIUM_TYPE = 'ЛК';
	WAITFOR DELAY '00:00:07';

	select @@SPID, 'insert AUDITORIUM_TYPE' 'результат', * from AUDITORIUM_TYPE
															   where AUDITORIUM_TYPE = 'СЗ';
	select @@SPID, 'update AUDITORIUM_TYPE' 'результат', * from AUDITORIUM_TYPE
															   where AUDITORIUM_TYPE = 'ЛК';
commit;
---------------------Task_08---------------------
USE UNIVER;
select * from PROGRESS

begin tran
	begin tran
	update PROGRESS set NOTE = 9 where IDSTUDENT = 1001;
	print @@TRANCOUNT
	commit;
	print @@TRANCOUNT
	if @@TRANCOUNT = 0 
	rollback;

select * from PROGRESS