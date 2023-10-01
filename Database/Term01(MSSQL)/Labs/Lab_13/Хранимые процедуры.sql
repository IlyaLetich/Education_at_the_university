
---------------------Task_01---------------------
USE UNIVER;
create procedure PSUBJECT
as begin
	declare @k int = (select count(*) from SUBJECT)
	select SUBJECT[���],SUBJECT_NAME[����������],PULPIT[�������] from SUBJECT
	return @k;
end
declare @i int = 0
exec @i = PSUBJECT
print 'Subject: '+ cast(@i as varchar(3))

drop procedure PSUBJECT
---------------------Task_02---------------------
USE UNIVER;
alter procedure [dbo].[PSUBJECT] @p varchar(20) = NULL,@c int output
as begin
	declare @k int = (select count(*) from SUBJECT)
	print '@p='+ @p +',@c='+cast(@c as varchar(3))
	select SUBJECT[���],SUBJECT_NAME[����������],PULPIT[�������] from SUBJECT where PULPIT = @p
	set @c = @@ROWCOUNT
	return @k
end
drop procedure PSUBJECT

declare @temp_2 int = 0, @out_2 int = 0;
exec @temp_2 = PSUBJECT '����', @out_2 output;
print '����� ���������: ' + convert(varchar, @temp_2);
print '�� ��� ������� ����: ' + convert(varchar, @out_2);
---------------------Task_03---------------------
use UNIVER
alter procedure PSUBJECT @p varchar(20)
as begin
	select * from dbo.SUBJECT where SUBJECT.PULPIT = @p;
end;

CREATE table #SUBJECT
(��� varchar(10) primary key,
���������� varchar(50),
������� varchar(10));
--drop table #SUBJECT;

insert #SUBJECT exec PSUBJECT @p = '����'; 
SELECT * from #SUBJECT;
---------------------Task_04---------------------
USE UNIVER;
create procedure PAUDITORIUM_INSERT @a char(20), @n varchar(50),  @c int=0, @t char(10)
as begin try
	insert into AUDITORIUM(AUDITORIUM, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY, AUDITORIUM_NAME)
		values (@a, @t, @c, @n)
	return 1;
end try
begin catch
	print '����� ������: ' + cast(error_number() as varchar(6));	
	print '���������: ' + error_message();
	print '�������: ' + cast(error_severity() as varchar(6));
	print '�����: ' + cast(error_state() as varchar(8));
	print '����� ������: ' + cast(error_line() as varchar(8));
	if error_procedure() is not null   
		print '��� ���������: ' + error_procedure();
	return -1;
end catch;
--drop procedure PAUDITORIUM_INSERT;

DECLARE @rc int; 
exec @rc=PAUDITORIUM_INSERT @a='777-7', @t='��', @c=60, @n='������ �������';
print '�����: '+cast(@rc as varchar(3));
--delete AUDITORIUM where AUDITORIUM='222-2';

select * from AUDITORIUM;
---------------------Task_05---------------------
USE UNIVER;
create procedure SUBJECT_REPORT @p char(10)
as declare @rc int = 0;
begin try
	if not exists (select SUBJECT from SUBJECT where PULPIT = @p)
	raiserror('������ � ����������', 11, 1);
	declare @subs_list char(300) = '', @sub char(10);
	declare SUBJECTS_L12 cursor for select SUBJECT from SUBJECT where PULPIT = @p;
	open SUBJECTS_L12;
	fetch SUBJECTS_L12 into @sub;
	while (@@FETCH_STATUS = 0)
	begin
		set @subs_list = rtrim(@sub) + ', ' + @subs_list;
		set @rc += 1;
		fetch SUBJECTS_L12 into @sub;
	end;
	print '������� ' + rtrim(@p) + ':';
	print rtrim(@subs_list);
	close SUBJECTS_L12;
	deallocate SUBJECTS_L12;
	return @rc;
end try
begin catch
	print '����� ������: ' + cast(error_number() as varchar(6));	
	print '���������: ' + error_message();
	print '�������: ' + cast(error_severity() as varchar(6));
	print '�����: ' + cast(error_state() as varchar(8));
	print '����� ������: ' + cast(error_line() as varchar(8));
	if error_procedure() is not null   
		print '��� ���������: ' + error_procedure();
	return @rc;
end catch;
go
--drop procedure SUBJECT_REPORT

declare @temp_5 int;
exec @temp_5 = SUBJECT_REPORT '����';
print '����������: ' + convert(varchar, @temp_5);
go
---------------------Task_06---------------------
USE UNIVER;
create procedure PAUDITORIUM_INSERTX 
@AUD char(20), @NAME varchar(50), @CAPACITY int = 0,
@AUD_TYPE char(10), @AUD_TYPENAME varchar(70)
as begin try
	set transaction isolation level SERIALIZABLE
	begin tran
		insert into AUDITORIUM_TYPE (AUDITORIUM_TYPE, AUDITORIUM_TYPENAME) values (@NAME, @AUD_TYPENAME)
		exec PAUDITORIUM_INSERT @AUD, @AUD_TYPE, @CAPACITY, @NAME
	commit tran
end try
begin catch
	print '�����:  ' + cast(ERROR_NUMBER() as varchar)
	print '�������: ' + cast(ERROR_SEVERITY() as varchar)
	print '���������:   ' + cast(ERROR_MESSAGE() as varchar)
	if @@TRANCOUNT > 0 
		rollback tran
	return -1
end catch
--drop procedure PAUDITORIUM_INSERTX;

exec PAUDITORIUM_INSERTX @AUD = '777-77', @NAME = '777', 
@CAPACITY = 50, @AUD_TYPE = '777', @AUD_TYPENAME = '777'
delete AUDITORIUM_TYPE where AUDITORIUM_TYPE='777'
delete AUDITORIUM where AUDITORIUM_TYPE='777';
select * from AUDITORIUM;


create procedure LabaSadali @p float
as begin
	declare @k int = (select count(*) from STUDENT inner join PROGRESS on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT where PROGRESS.NOTE > 6)
	print '���������� = ' + cast(@k as varchar);
	print '������� = ' + cast(square(cos(@p)) as varchar ); 
	return @k;
end

drop procedure LabaSadali

declare @temp_10 int
exec @temp_10 = LabaSadali 12