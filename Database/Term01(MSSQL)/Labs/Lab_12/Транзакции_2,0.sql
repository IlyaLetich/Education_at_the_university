---------------------Task_04---------------------
USE UNIVER;
-----�������� B-----
set transaction isolation level READ COMMITTED 
begin transaction
	select @@SPID;
	insert AUDITORIUM_TYPE values ('��', '���������� ���');
	update AUDITORIUM_TYPE set AUDITORIUM_TYPENAME = '���������� �������' where AUDITORIUM_TYPE = '��';
	WAITFOR DELAY '00:00:03';
-----t1-----
-----t2-----
rollback;
---------------------Task_05---------------------
USE UNIVER;
-----�������� B-----
set transaction isolation level READ COMMITTED 
begin transaction
	select @@SPID;
	insert AUDITORIUM_TYPE values ('��', '���������� ���');
	update AUDITORIUM_TYPE set AUDITORIUM_TYPENAME = '���������� �������' where AUDITORIUM_TYPE = '��';
	WAITFOR DELAY '00:00:03';
-----t1-----
-----t2-----
commit; --rollback

delete AUDITORIUM_TYPE where AUDITORIUM_TYPE.AUDITORIUM_TYPENAME = '���������� ���';
update AUDITORIUM_TYPE set AUDITORIUM_TYPENAME = '����������' where AUDITORIUM_TYPE = '��';
---------------------Task_06---------------------
USE UNIVER;
-----�������� B-----
set transaction isolation level READ COMMITTED 
begin transaction
	select @@SPID;
	insert AUDITORIUM_TYPE values ('��', '���������� ���');
	update AUDITORIUM_TYPE set AUDITORIUM_TYPENAME = '���������� �������' where AUDITORIUM_TYPE = '��';
	WAITFOR DELAY '00:00:03';
-----t1-----
-----t2-----
commit; --rollback

delete AUDITORIUM_TYPE where AUDITORIUM_TYPE.AUDITORIUM_TYPENAME = '���������� ���';
update AUDITORIUM_TYPE set AUDITORIUM_TYPENAME = '����������' where AUDITORIUM_TYPE = '��';
---------------------Task_07---------------------
USE UNIVER;
set transaction isolation level READ COMMITTED 
begin transaction
	select @@SPID;
	insert AUDITORIUM_TYPE values ('��', '���������� ���');
	update AUDITORIUM_TYPE set AUDITORIUM_TYPENAME = '���������� �������' where AUDITORIUM_TYPE = '��';
	WAITFOR DELAY '00:00:03';
-----t1-----
-----t2-----
commit; --rollback

delete AUDITORIUM_TYPE where AUDITORIUM_TYPE.AUDITORIUM_TYPENAME = '���������� ���';
update AUDITORIUM_TYPE set AUDITORIUM_TYPENAME = '����������' where AUDITORIUM_TYPE = '��';