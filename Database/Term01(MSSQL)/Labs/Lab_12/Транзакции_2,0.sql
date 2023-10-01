---------------------Task_04---------------------
USE UNIVER;
-----Сценарий B-----
set transaction isolation level READ COMMITTED 
begin transaction
	select @@SPID;
	insert AUDITORIUM_TYPE values ('СЗ', 'Спортивный зал');
	update AUDITORIUM_TYPE set AUDITORIUM_TYPENAME = 'Лекционный кабинет' where AUDITORIUM_TYPE = 'ЛК';
	WAITFOR DELAY '00:00:03';
-----t1-----
-----t2-----
rollback;
---------------------Task_05---------------------
USE UNIVER;
-----Сценарий B-----
set transaction isolation level READ COMMITTED 
begin transaction
	select @@SPID;
	insert AUDITORIUM_TYPE values ('СЗ', 'Спортивный зал');
	update AUDITORIUM_TYPE set AUDITORIUM_TYPENAME = 'Лекционный кабинет' where AUDITORIUM_TYPE = 'ЛК';
	WAITFOR DELAY '00:00:03';
-----t1-----
-----t2-----
commit; --rollback

delete AUDITORIUM_TYPE where AUDITORIUM_TYPE.AUDITORIUM_TYPENAME = 'Спортивный зал';
update AUDITORIUM_TYPE set AUDITORIUM_TYPENAME = 'Лекционная' where AUDITORIUM_TYPE = 'ЛК';
---------------------Task_06---------------------
USE UNIVER;
-----Сценарий B-----
set transaction isolation level READ COMMITTED 
begin transaction
	select @@SPID;
	insert AUDITORIUM_TYPE values ('СЗ', 'Спортивный зал');
	update AUDITORIUM_TYPE set AUDITORIUM_TYPENAME = 'Лекционный кабинет' where AUDITORIUM_TYPE = 'ЛК';
	WAITFOR DELAY '00:00:03';
-----t1-----
-----t2-----
commit; --rollback

delete AUDITORIUM_TYPE where AUDITORIUM_TYPE.AUDITORIUM_TYPENAME = 'Спортивный зал';
update AUDITORIUM_TYPE set AUDITORIUM_TYPENAME = 'Лекционная' where AUDITORIUM_TYPE = 'ЛК';
---------------------Task_07---------------------
USE UNIVER;
set transaction isolation level READ COMMITTED 
begin transaction
	select @@SPID;
	insert AUDITORIUM_TYPE values ('СЗ', 'Спортивный зал');
	update AUDITORIUM_TYPE set AUDITORIUM_TYPENAME = 'Лекционный кабинет' where AUDITORIUM_TYPE = 'ЛК';
	WAITFOR DELAY '00:00:03';
-----t1-----
-----t2-----
commit; --rollback

delete AUDITORIUM_TYPE where AUDITORIUM_TYPE.AUDITORIUM_TYPENAME = 'Спортивный зал';
update AUDITORIUM_TYPE set AUDITORIUM_TYPENAME = 'Лекционная' where AUDITORIUM_TYPE = 'ЛК';