---------------------Task_01---------------------
USE UNIVER;
create table TR_AUDIT
(
	ID int identity,
	STMT varchar(20) --DML-��������
		check (STMT in ('INS','DEL','UPD')),
	TRNAME varchar(50), --��� ��������
	CC varchar(300) -- ����������
)

--drop table TR_AUDIT
go

create trigger TR_TEACHER_INS on TEACHER after insert
as
	declare @a1 char(10),@a2 varchar(100),@a3 char(1),@a4 char(20),@in varchar(300)
	print '�������'
	set @a1 = (select TEACHER from inserted)
	set @a2 = (select TEACHER_NAME from inserted)
	set @a3 = (select GENDER from inserted)
	set @a4 = (select PULPIT from inserted)
	set @in = @a1+' '+@a2+ ' '+@a3+ ' '+@a4
	insert into TR_AUDIT(STMT,TRNAME,CC) values('INS','TR_TEACHER_INS',@in)
	return

insert into TEACHER values('il','ilya','�','����')
select * from TR_AUDIT
delete TEACHER where TEACHER = 'il'
delete TR_AUDIT where STMT = 'INS'
drop trigger TR_TEACHER_INS
---------------------Task_02---------------------
USE UNIVER;

go 
create trigger TR_TEACHER_DEL on TEACHER after delete
as
	declare @a1 char(10),@a2 varchar(100),@a3 char(1),@a4 char(20),@in varchar(300)
	print '��������'
	set @a1 = (select TEACHER from deleted)
	set @a2 = (select TEACHER_NAME from deleted)
	set @a3 = (select GENDER from deleted)
	set @a4 = (select PULPIT from deleted)
	set @in = @a1+' '+@a2+ ' '+@a3+ ' '+@a4
	insert into TR_AUDIT(STMT,TRNAME,CC) values('DEL','TR_TEACHER_DEL',@in)
	return

delete TEACHER where TEACHER = 'il'
select * from TR_AUDIT
drop trigger TR_TEACHER_DEL
---------------------Task_03---------------------
use UNIVER

go
create trigger TR_TEACHER_UPD on TEACHER after update
as
	declare @a1 char(10),@a2 varchar(100),@a3 char(1),@a4 char(20),@in varchar(300)
	print '����������'
	set @a1 = (select TEACHER from inserted)
	set @a2 = (select TEACHER_NAME from inserted)
	set @a3 = (select GENDER from inserted)
	set @a4 = (select PULPIT from inserted)
	set @in = @a1+' '+@a2+ ' '+@a3+ ' '+@a4

	set @a1 = (select TEACHER from deleted)
	set @a2 = (select TEACHER_NAME from deleted)
	set @a3 = (select GENDER from deleted)
	set @a4 = (select PULPIT from deleted)
	set @in =@in+' '+ @a1+' '+@a2+ ' '+@a3+ ' '+@a4
	insert into TR_AUDIT(STMT,TRNAME,CC) values('UPD','TR_TEACHER_DEL',@in)
	return

insert into TEACHER values('il','ilya','�','����')
update TEACHER set TEACHER_NAME ='Eee' where TEACHER = 'il'
select * from TR_AUDIT
drop trigger TR_TEACHER_UPD
delete TEACHER where TEACHER_NAME = 'Eee'
---------------------Task_04---------------------
USE UNIVER;
go
create trigger TR_TEACHER on TEACHER after INSERT,DELETE,UPDATE
as
	declare @a1 char(10),@a2 varchar(100),@a3 char(1),@a4 char(20),@in varchar(300)
	if ((select count (*) from inserted) > 0 and (select count(*) from deleted) = 0)
	begin
		print '��������� �������:INS'
		set @a1 = (select TEACHER from inserted)
		set @a2 = (select TEACHER_NAME from inserted)
		set @a3 = (select GENDER from inserted)
		set @a4 = (select PULPIT from inserted)
		set @in = @a1+' '+@a2+ ' '+@a3+ ' '+@a4
		insert into TR_AUDIT(STMT,TRNAME,CC) values ('INS','TR_TEACHER',@in)
	end
	else if ((select count(*) from inserted) = 0 and (select count(*) from deleted) > 0)
	begin
		print '��������� �������:DEL'
		set @a1 = (select TEACHER from deleted)
		set @a2 = (select TEACHER_NAME from deleted)
		set @a3 = (select GENDER from deleted)
		set @a4 = (select PULPIT from deleted)
		set @in =@a1+' '+@a2+ ' '+@a3+ ' '+@a4
		insert into TR_AUDIT(STMT,TRNAME,CC) values ('DEL','TR_TEACHER',@in)
	end

	else if ((select count(*) from inserted)>0 and (select count(*) from deleted)>0)
	begin
		print '��������� �������:UPD'
		set @a1 = (select TEACHER from inserted)
		set @a2 = (select TEACHER_NAME from inserted)
		set @a3 = (select GENDER from inserted)
		set @a4 = (select PULPIT from inserted)
		set @in = @a1+' '+@a2+ ' '+@a3+ ' '+@a4

		set @a1 = (select TEACHER from deleted)
		set @a2 = (select TEACHER_NAME from deleted)
		set @a3 = (select GENDER from deleted)
		set @a4 = (select PULPIT from deleted)
		set @in =@in+' '+ @a1+' '+@a2+ ' '+@a3+ ' '+@a4
		insert into TR_AUDIT(STMT,TRNAME,CC) values('UPD','TR_TEACHER',@in)
	end
return
drop trigger TR_TEACHER

delete TEACHER where TEACHER = 'il'
insert into TEACHER values('il','ilya','�','����')
update TEACHER set TEACHER_NAME ='Eee' where TEACHER = 'il'
delete TEACHER where TEACHER_NAME = 'Eee'
select * from TR_AUDIT
---------------------Task_05---------------------
USE UNIVER;
update TEACHER set GENDER = 'N' where TEACHER = 'il'
select * from TR_AUDIT
---------------------Task_06---------------------
USE UNIVER;
go
create trigger TR_TEACHER_DEL1 on TEACHER after delete
as print 'DELETE Trigger 1'
return;
go
create trigger TR_TEACHER_DEL2 on TEACHER after delete
as print 'DELETE Trigger 2'
return;  
go
create trigger TR_TEACHER_DEL3 on TEACHER after delete
as print 'DELETE Trigger 3'
return;  
drop trigger TR_TEACHER_DEL1
drop trigger TR_TEACHER_DEL2
drop trigger TR_TEACHER_DEL3

select t.name, e.type_desc 
from sys.triggers t join  sys.trigger_events e  
on t.object_id = e.object_id  
where OBJECT_NAME(t.parent_id) = 'TEACHER' and e.type_desc = 'DELETE'

exec SP_SETTRIGGERORDER @triggername = 'TR_TEACHER_DEL3', @order = 'First', @stmttype = 'DELETE'
exec SP_SETTRIGGERORDER @triggername = 'TR_TEACHER_DEL2', @order = 'Last',  @stmttype = 'DELETE'

insert into TEACHER values('il','ilya','�','����')
delete from TEACHER where TEACHER = 'il'
select * from TR_AUDIT
---------------------Task_07---------------------
USE UNIVER;




go
create trigger TranTest on PULPIT after insert,delete,update
as 
	declare @c int = (select count (*) from PULPIT); 	 
	if (@c > 19) 
	begin
		raiserror('����� ���������� ������ �� ����� ��������� 19', 10, 1);
	end;
	rollback;
	return;    
drop trigger TranTest
insert into PULPIT(PULPIT,PULPIT_NAME,FACULTY) values('error)','error','��')
select count(*) from PULPIT;
---------------------Task_08---------------------
USE UNIVER;
go
create trigger F_INSTEAD_OF on FACULTY instead of delete
as
	raiserror('�������� ���������',10,1)
	return

delete FACULTY where FACULTY = '����'

drop trigger F_INSTEAD_OF

drop trigger TR_TEACHER_INS
drop trigger TR_TEACHER_DEL
drop trigger TR_TEACHER_UPD
drop trigger TR_TEACHER
drop trigger TR_TEACHER_DEL1
drop trigger TR_TEACHER_DEL2
drop trigger TR_TEACHER_DEL3
drop trigger TranTest
---------------------Task_09---------------------
USE UNIVER;
go
create trigger TR_TEACHER_DDL on database for DDL_DATABASE_LEVEL_EVENTS  
as   
	declare @EVENT_TYPE varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/EventType)[1]', 'varchar(50)')
	declare @OBJ_NAME varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectName)[1]', 'varchar(50)')
	declare @OBJ_TYPE varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectType)[1]', 'varchar(50)')
	if @OBJ_NAME = 'TEACHER' 
	begin
		print '��� �������: ' + cast(@EVENT_TYPE as varchar)
		print '��� �������: ' + cast(@OBJ_NAME as varchar)
		print '��� �������: ' + cast(@OBJ_TYPE as varchar)
		raiserror('�������� � �������� ���������.', 16, 1)
		rollback  
	end

alter table TEACHER drop column TEACHER_NAME



create trigger TR_TEACHER_DDL on database for DDL_DATABASE_LEVEL_EVENTS  
as   
	declare @EVENT_TYPE varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/EventType)[1]', 'varchar(50)')
	declare @OBJ_NAME varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectName)[1]', 'varchar(50)')
	declare @OBJ_TYPE varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectType)[1]', 'varchar(50)')
	if @OBJ_NAME = 'TEACHER' 
	begin
		print '��� �������: ' + cast(@EVENT_TYPE as varchar)
		print '��� �������: ' + cast(@OBJ_NAME as varchar)
		print '��� �������: ' + cast(@OBJ_TYPE as varchar)
		raiserror('�������� � �������� ���������.', 16, 1)
		rollback  
	end





create trigger HelloWorld on Otsenki instead of insert
as
	raiserror('�������� ���������',10,1)
	return
--������ ���� 5 ������ 2
--������ ���� 5 ����������� �� 1


insert into Otsenki(NameUser,Otsenka) values('��������� ���������� ����',8)
insert into Otsenki(NameUser,Otsenka) values('��',4)

create table Otsenki
(
	NameUser varchar(50),
	Otsenka float
)

select * from Otsenki;

--drop table Otsenki



ALTER TRIGGER OZENKA ON PROGRESS
INSTEAD OF INSERT
AS
BEGIN
  INSERT INTO PROGRESS (SUBJECT, IDSTUDENT, PDATE, NOTE)
  SELECT SUBJECT, IDSTUDENT, PDATE, 2
  FROM inserted
  WHERE NOTE = 10;
 INSERT INTO PROGRESS (SUBJECT, IDSTUDENT, PDATE, NOTE)
  SELECT SUBJECT, IDSTUDENT, PDATE, NOTE
  FROM inserted
  WHERE NOTE != 10;
END;



INSERT into PROGRESS(SUBJECT, IDSTUDENT, PDATE, NOTE) VALUES ('��', 1000, GETDATE(), 9);
select * from PROGRESS