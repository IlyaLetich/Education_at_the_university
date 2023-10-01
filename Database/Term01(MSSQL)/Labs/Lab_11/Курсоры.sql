---------------------Task_01---------------------
USE UNIVER;
begin
declare cur cursor for 
select SUBJECT from SUBJECT where SUBJECT.PULPIT = '����'
declare @discipline nvarchar(50),@str char(300) = ' '
open cur
fetch cur into @discipline
print '����������:'
while @@FETCH_STATUS = 0
begin
	set @str = rtrim(@discipline)+ ', '+@str
	fetch cur into @discipline
end
print @str
close cur
deallocate cur
end
---------------------Task_02---------------------
USE UNIVER;
declare curLocal cursor local for select PROGRESS.IDSTUDENT,PROGRESS.NOTE from PROGRESS
declare @str2 varchar(10), @note real
open curLocal
fetch curLocal into @str2,@note
print '1. ' +@str2 + ': '+ cast(@note as varchar)
go
declare @str2 varchar(10), @note real
open curLocal
fetch curLocal into @str2,@note
print '2. '+ @str2 + ': ' + cast(@note as varchar)
go

declare curGlobal cursor for select PROGRESS.IDSTUDENT,PROGRESS.NOTE from PROGRESS
declare @str2 varchar(10), @note real
open curGlobal
fetch curGlobal into @str2,@note
print '1. ' +@str2 + ': '+ cast(@note as varchar)
go
declare @str2 varchar(10), @note real
fetch curGlobal into @str2,@note
print '2. '+ @str2 + ': ' + cast(@note as varchar)
go
close curGlobal
deallocate curGlobal
---------------------Task_03---------------------
USE UNIVER;
declare cur cursor local static for 
select AUDITORIUM,AUDITORIUM_TYPE,AUDITORIUM_CAPACITY from AUDITORIUM
declare @name varchar(10),
		@type varchar(5),
		@cap int
open cur
print '���������� �����: ' + cast(@@cursor_rows as char)
update AUDITORIUM set AUDITORIUM_TYPE = '��-�' where AUDITORIUM = '236-1'
fetch cur into @name,@type,@cap
while @@FETCH_STATUS = 0
begin
	print @name + ' '+ @type + ' ' + cast(@cap as char)
	fetch cur into @name,@type,@cap
end
select AUDITORIUM,AUDITORIUM_TYPE,AUDITORIUM_CAPACITY from AUDITORIUM where AUDITORIUM = '236-1'
close cur
deallocate cur

go
declare cur cursor local dynamic for 
select AUDITORIUM,AUDITORIUM_TYPE,AUDITORIUM_CAPACITY from AUDITORIUM
declare @name varchar(10),@type varchar(5),@cap int
open cur
print '���������� �����: ' + cast(@@cursor_rows as char)
update AUDITORIUM set AUDITORIUM_TYPE = '��' where AUDITORIUM = '236-1'
fetch cur into @name,@type,@cap
while @@FETCH_STATUS = 0
begin
	print @name + ' '+ @type + ' ' + cast(@cap as char)
	fetch cur into @name,@type,@cap
end
select AUDITORIUM,AUDITORIUM_TYPE,AUDITORIUM_CAPACITY from AUDITORIUM where AUDITORIUM = '236-1'
close cur
deallocate cur
---------------------Task_04---------------------
USE UNIVER;
declare @t int, @rn char(50)
declare curScroll cursor local dynamic scroll for 
	select ROW_NUMBER() over (order by NAME), NAME from STUDENT where IDGROUP = 4
open curScroll
fetch FIRST from curScroll into  @t, @rn                
print '������: ' + cast(@t as varchar(3))+ ' ' + rtrim(@rn)
fetch NEXT from curScroll into  @t, @rn              
print '��������: ' + cast(@t as varchar(3))+ ' ' + rtrim(@rn)      
fetch LAST from  curScroll into @t, @rn       
print '���������: ' +  cast(@t as varchar(3))+ ' '+rtrim(@rn)   
fetch PRIOR from curScroll into  @t, @rn        
print '��� �����: ' + cast(@t as varchar(3))+ ' ' + rtrim(@rn) 
fetch ABSOLUTE 2 from curScroll into  @t, @rn                
print '������: ' + cast(@t as varchar(3))+ ' ' + rtrim(@rn) 
fetch RELATIVE 1 from curScroll into  @t, @rn          
print '��� + 1: ' + cast(@t as varchar(3))+ ' ' + rtrim(@rn) 
close curScroll
deallocate curScroll
---------------------Task_05---------------------
USE UNIVER;
declare cur cursor local dynamic for 
select IDSTUDENT, NOTE from PROGRESS FOR UPDATE
declare @id varchar(10), @nt int
open cur
fetch cur into @id, @nt
print @id + ' ������� ' + cast(@nt as varchar) + ' '
delete PROGRESS where CURRENT OF cur	
fetch cur into @id, @nt
update PROGRESS set NOTE = NOTE + 1 where CURRENT OF cur
print @id + ' �������� �� + 1 ' + cast(@nt + 1 as varchar) + ' '
close cur
deallocate cur

insert into PROGRESS values('����',1001,'2012-01-10', 9);
select * from PROGRESS
---------------------Task_06---------------------
USE UNIVER;
go
declare @name nvarchar(20),@n int
declare cur cursor local for select IDSTUDENT,NOTE from PROGRESS where NOTE < 4
open cur
fetch cur into @name,@n
while @@FETCH_STATUS = 0
begin
	delete PROGRESS where CURRENT OF cur
	fetch cur into @name,@n
end
close cur
deallocate cur

select IDSTUDENT,NOTE from PROGRESS
insert into PROGRESS (SUBJECT,IDSTUDENT,PDATE, NOTE)
values  ('����', 1000,  '01.10.2013',3),
        ('��', 1001,  '01.12.2013',2),
		('��',   1002,  '06.5.2013',2),
        ('��',   1003,  '01.1.2013',2),
        ('��',   1004,  '01.1.2013',2)
-- ������������ ������
declare @name4 char(20), @n3 int
declare cur2 cursor local for select IDSTUDENT, NOTE from PROGRESS where IDSTUDENT = 1005
open cur2
fetch  cur2 into @name4, @n3
update PROGRESS set NOTE=NOTE+1 where current of cur2
close cur2
deallocate cur2