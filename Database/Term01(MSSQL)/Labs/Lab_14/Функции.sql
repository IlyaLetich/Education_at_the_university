---------------------Task_01---------------------
USE UNIVER;

create function COUNT_STUDENTS (@faculty nvarchar(20)) returns int
as begin
	declare @count int = 0
	set @count = (select count(STUDENT.IDSTUDENT) from FACULTY
	join GROUPS on GROUPS.FACULTY = FACULTY.FACULTY
	join STUDENT on STUDENT.IDGROUP = GROUPS.IDGROUP
	where FACULTY.FACULTY = @faculty)
	return @count
end

--drop function COUNT_STUDENTS

declare @temp int = dbo.COUNT_STUDENTS('ХТиТ');
print 'Число студентов на факультете ХТиТ составляет '+ cast(@temp as nvarchar(20))+' человек'

select FACULTY, dbo.COUNT_STUDENTS(FACULTY) from FACULTY;

alter function COUNT_STUDENTS (@faculty varchar(20) = NULL, @prof varchar(20) = NULL) returns int
as begin
	declare @count int = 0
	set @count = (select count(STUDENT.IDSTUDENT) from FACULTY
	join GROUPS on GROUPS.FACULTY = FACULTY.FACULTY
	join STUDENT on STUDENT.IDGROUP = GROUPS.IDGROUP
	where FACULTY.FACULTY = @faculty and GROUPS.PROFESSION = @prof)
	return @count
end

declare @temp2 int = dbo.COUNT_STUDENTS('ТОВ','1-48 01 02');
print 'Число студентов на факультете ТОВ,1-48 составляет ' + cast(@temp2 as nvarchar(20))+' человек';

select FACULTY.FACULTY, GROUPS.IDGROUP, GROUPS.PROFESSION, dbo.COUNT_STUDENTS(FACULTY.FACULTY,GROUPS.PROFESSION) 
from GROUPS inner join FACULTY on GROUPS.FACULTY = FACULTY.FACULTY;
---------------------Task_02---------------------
USE UNIVER;

create function FSUBJECTS (@p nvarchar(20)) returns nvarchar(300) 
as begin
	declare @list varchar(300) = 'Дисциплины: ', @sub varchar(20);
	declare SUBJECT_CURSOR cursor local for select SUBJECT.SUBJECT from SUBJECT where SUBJECT.PULPIT = @p
	open SUBJECT_CURSOR
	fetch next from SUBJECT_CURSOR into @sub
	while @@FETCH_STATUS = 0
	begin
		set @list=@list+rtrim(@sub)+', ';
		fetch SUBJECT_CURSOR into @sub
	end;
	return @list;
end;

--пример как на картинке
select SUBJECT.PULPIT,  dbo.FSUBJECTS(SUBJECT.PULPIT) from SUBJECT;
---------------------Task_03---------------------
use UNIVER

create function FFACPUL(@fac varchar(10), @pul varchar(10)) returns table
as return
select FACULTY.FACULTY, PULPIT.PULPIT 
from FACULTY left outer join PULPIT on FACULTY.FACULTY = PULPIT.FACULTY 
where FACULTY.FACULTY=isnull(@fac, FACULTY.FACULTY)
and PULPIT.PULPIT=isnull(@pul, PULPIT.PULPIT);
--drop function dbo.FFACPUL;

select * from dbo.FFACPUL(null,null);
select * from dbo.FFACPUL('ЛХФ',null);
select * from dbo.FFACPUL(null,'ЛМиЛЗ');
select * from dbo.FFACPUL('ТТЛП','ЛМиЛЗ');
---------------------Task_04---------------------
USE UNIVER;

create function FCTEACHER(@pul nvarchar(10)) returns int 
as begin
	declare @count int=(select count(*) from TEACHER where PULPIT=isnull(@pul, PULPIT));
	return @count;
end;

select PULPIT, dbo.FCTEACHER(PULPIT) from PULPIT;
select dbo.FCTEACHER(NULL) [Всего преподавателей];
---------------------Task_05---------------------
USE UNIVER;

create function COUNT_PULPIT(@faculty nvarchar(10)) returns int
as begin
	declare @rc int=0;
	set @rc=(select count(*) from PULPIT where PULPIT.FACULTY=@faculty)
	return @rc;
end;

create function COUNT_GROUPS(@faculty nvarchar(10)) returns int
as begin
	declare @rc int=0;
	set @rc=(select count(*) from GROUPS where GROUPS.FACULTY=@faculty)
	return @rc;
end;

create function COUNT_PROFESSION(@faculty varchar(20)) returns int
as begin
	declare @rc int = 0;
	set @rc = (select count(*) from PROFESSION where PROFESSION.FACULTY = @faculty)
	return @rc;
end;

drop function COUNT_STUDENTS
drop function FSUBJECTS
drop function dbo.FACULTY_REPORT;

create function FACULTY_REPORT(@c int) returns @fr table
([Факультет] varchar(50), [Кол-во кафедр] int, [Кол-во групп] int,
[Кол-во студентов] int, [Кол-во профф] int)
as begin
	declare cc cursor local static for select FACULTY from FACULTY where dbo.COUNT_STUDENTS(FACULTY.FACULTY) > @c;
	declare @f varchar(30);
	open cc;
	fetch cc into @f;
	while @@fetch_status = 0
	begin
		insert @fr values(@f,dbo.COUNT_PULPIT(@f), dbo.COUNT_GROUPS(@f),dbo.COUNT_STUDENTS(@f), dbo.COUNT_PROFESSION(@f));
		fetch cc into @f;
	end;
	close cc;
	deallocate cc;
	return;
end;

select * from dbo.FACULTY_REPORT(0);


create function ShoEtaTakoe (@number float) returns float
as begin
	declare @numberReturn float;
	set @numberReturn = square(sin(@number)) + square(cos(@number));
	return @numberReturn;
end

--drop function ShoEtaTakoe

declare @temp int = dbo.ShoEtaTakoe(12);
print 'Что ета такое - '+ cast(@temp as nvarchar(20))