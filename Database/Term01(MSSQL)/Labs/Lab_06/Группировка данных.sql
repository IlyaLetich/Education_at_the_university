----------------------- tASK_01 ------------------------------
USE UNIVER;
SELECT
AUDITORIUM.AUDITORIUM_TYPE,
max(AUDITORIUM_CAPACITY) [������������ �����������],
min(AUDITORIUM_CAPACITY) [����������� �����������],
avg(AUDITORIUM_CAPACITY) [������� �����������],
sum(AUDITORIUM_CAPACITY) [��������� �����������],
count (*) [���������� ���������]
FROM AUDITORIUM INNER JOIN AUDITORIUM_TYPE 
ON AUDITORIUM.AUDITORIUM_TYPE = AUDITORIUM_TYPE.AUDITORIUM_TYPE 
GROUP BY AUDITORIUM.AUDITORIUM_TYPE
----------------------- tASK_02 ------------------------------
USE UNIVER;
SELECT
AUDITORIUM.AUDITORIUM_TYPE,
max(AUDITORIUM_CAPACITY) [������������ �����������],
min(AUDITORIUM_CAPACITY) [����������� �����������],
avg(AUDITORIUM_CAPACITY) [������� �����������],
sum(AUDITORIUM_CAPACITY) [��������� �����������],
count (*) [���������� ���������]
FROM AUDITORIUM INNER JOIN AUDITORIUM_TYPE 
ON AUDITORIUM.AUDITORIUM_TYPE = AUDITORIUM_TYPE.AUDITORIUM_TYPE 
GROUP BY AUDITORIUM.AUDITORIUM_TYPE
----------------------- tASK_03 ------------------------------
USE UNIVER;
SELECT * FROM
(SELECT CASE 
when PROGRESS.NOTE between 1 and 2 then '1-2'
when PROGRESS.NOTE between 3 and 4 then '3-4'
when PROGRESS.NOTE between 5 and 6 then '5-6'
when PROGRESS.NOTE between 7 and 8 then '7-8'
else '9-10' end [������], 
COUNT (*) [����������]
FROM PROGRESS GROUP BY CASE
when PROGRESS.NOTE between 1 and 2 then '1-2'
when PROGRESS.NOTE between 3 and 4 then '3-4'
when PROGRESS.NOTE between 5 and 6 then '5-6'
when PROGRESS.NOTE between 7 and 8 then '7-8'
else '9-10' end) as T
ORDER BY CASE [������]
when '1-2' then 4
when '3-4' then 3
when '5-6' then 2
when '7-8' then 1
else 0 end
----------------------- tASK_04 ------------------------------
USE UNIVER;
select a.FACULTY,
       G.PROFESSION,
       (2013 - G.YEAR_FIRST + 1) [����],
       round(avg(cast(NOTE as float(4))), 2) as [������� ������]
from FACULTY a
        full join GROUPS G on a.FACULTY = G.FACULTY
        full join STUDENT S on G.IDGROUP = S.IDGROUP
        full join PROGRESS P on S.IDSTUDENT = P.IDSTUDENT
group by a.FACULTY, G.PROFESSION, G.YEAR_FIRST

----------------------- tASK_05 ------------------------------
USE UNIVER;
select a.FACULTY,
       G.PROFESSION,
       (2013 - G.YEAR_FIRST + 1) [����],
       round(avg(cast(NOTE as float(4))), 2) as [������� ������]
from FACULTY a
        full join GROUPS G on a.FACULTY = G.FACULTY
        full join STUDENT S on G.IDGROUP = S.IDGROUP
        full join PROGRESS P on S.IDSTUDENT = P.IDSTUDENT WHERE P.SUBJECT in ('����','����')
group by a.FACULTY, G.PROFESSION, G.YEAR_FIRST
HAVING (G.PROFESSION is not null or G.YEAR_FIRST is not null)
----------------------- tASK_06 ------------------------------
USE UNIVER;
select a.FACULTY,
       G.PROFESSION,
       P.SUBJECT,
       round(avg(cast(NOTE as float(4))), 2) as [������� ������]
from FACULTY a
        full join GROUPS G on a.FACULTY = G.FACULTY
        full join STUDENT S on G.IDGROUP = S.IDGROUP
        full join PROGRESS P on S.IDSTUDENT = P.IDSTUDENT
		WHERE a.FACULTY = '��'
group by a.FACULTY, G.PROFESSION, P.SUBJECT
----------------------- tASK_07 ------------------------------
USE UNIVER;
SELECT SUBJECT,
       count(*)[���-��]
FROM PROGRESS
GROUP BY SUBJECT, NOTE
HAVING NOTE in (8, 9)
ORDER BY SUBJECT;
----------------------- tASK_07 ------------------------------
-------------- EXAMPLE 1 ------------------
USE Ilya_MyBase;
SELECT
��������,
COUNT(*)[���������� �������]
FROM ��������������
GROUP BY ��������
-------------- EXAMPLE 2 ------------------
USE Ilya_MyBase;
SELECT 
����,
COUNT(*)[���������� �������]
FROM �������������� 
INNER JOIN �������� ON ��������������.�������� = ��������.ID_��������
INNER JOIN �������� ON ��������.ID_�������� = ��������������.�������
GROUP BY ���� 