------------------------- Task_01 ---------------------------------
use UNIVER;
SELECT PULPIT_NAME 
FROM PULPIT 
WHERE PULPIT.FACULTY IN (SELECT FACULTY FROM PROFESSION 
WHERE (PROFESSION_NAME like '%����������%' or PROFESSION_NAME like '%����������%'))
------------------------- Task_02 ---------------------------------
use UNIVER;
SELECT DISTINCT PULPIT_NAME FROM 
PULPIT INNER JOIN FACULTY ON PULPIT.FACULTY = FACULTY.FACULTY 
INNER JOIN PROFESSION ON FACULTY.FACULTY = PROFESSION.FACULTY AND (PROFESSION_NAME like '%����������%' or PROFESSION_NAME like '%����������%')
------------------------- Task_03 ---------------------------------
use UNIVER;
SELECT DISTINCT PULPIT_NAME FROM 
PULPIT INNER JOIN FACULTY ON PULPIT.FACULTY = FACULTY.FACULTY 
INNER JOIN PROFESSION ON FACULTY.FACULTY = PROFESSION.FACULTY
WHERE (PROFESSION_NAME like '%����������%' or PROFESSION_NAME like '%����������%')
------------------------- Task_04 ---------------------------------
use UNIVER;
SELECT AUDITORIUM,AUDITORIUM_TYPE, AUDITORIUM_CAPACITY FROM AUDITORIUM table_01
WHERE 
table_01.AUDITORIUM_CAPACITY = (SELECT TOP(1) AUDITORIUM_CAPACITY FROM AUDITORIUM table_02 
WHERE table_01.AUDITORIUM_TYPE = table_02.AUDITORIUM_TYPE ORDER BY AUDITORIUM_CAPACITY DESC)
------------------------- Task_05 ---------------------------------
use UNIVER;
SELECT * FROM FACULTY
WHERE NOT EXISTS (SELECT * FROM PULPIT WHERE PULPIT.FACULTY = FACULTY.FACULTY)
------------------------- Task_06 ---------------------------------
use UNIVER;
SELECT top(1)
(SELECT avg(NOTE) FROM PROGRESS WHERE SUBJECT = '����')[����],
(SELECT avg(NOTE) FROM PROGRESS WHERE SUBJECT = '��')[��],
(SELECT avg(NOTE) FROM PROGRESS WHERE SUBJECT = '����')[����]
FROM PROGRESS
------------------------- Task_07 ---------------------------------
use UNIVER;
SELECT AUDITORIUM.AUDITORIUM_CAPACITY, AUDITORIUM.AUDITORIUM_TYPE FROM AUDITORIUM
WHERE AUDITORIUM_CAPACITY <= all (select AUDITORIUM_CAPACITY from AUDITORIUM
WHERE (AUDITORIUM_TYPE like '��%'));
------------------------- Task_08 ---------------------------------
use UNIVER;
SELECT AUDITORIUM.AUDITORIUM_CAPACITY, AUDITORIUM.AUDITORIUM_TYPE
FROM AUDITORIUM
WHERE AUDITORIUM_CAPACITY > any (select AUDITORIUM_CAPACITY from AUDITORIUM
WHERE (AUDITORIUM_TYPE like '��%'));
------------------------- Task_09 ---------------------------------

---------- 1 example --------------
use Ilya_MyBase;
SELECT ��������������.������ 
FROM ��������������
WHERE ��������������.������� IN (SELECT ��������.ID_�������� FROM �������� WHERE ������������_�������� like '��������')

---------- 2 example --------------
use Ilya_MyBase;
SELECT ��������.������������_��������
FROM ��������
WHERE ��������� > ALL (select ��������� from ��������
WHERE (������������_�������� like '��������'));