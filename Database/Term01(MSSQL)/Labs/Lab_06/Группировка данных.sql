----------------------- tASK_01 ------------------------------
USE UNIVER;
SELECT
AUDITORIUM.AUDITORIUM_TYPE,
max(AUDITORIUM_CAPACITY) [Максимальная вместимость],
min(AUDITORIUM_CAPACITY) [Минимальная вместимость],
avg(AUDITORIUM_CAPACITY) [Средняя вместимость],
sum(AUDITORIUM_CAPACITY) [Суммарная вместимость],
count (*) [Количество аудиторий]
FROM AUDITORIUM INNER JOIN AUDITORIUM_TYPE 
ON AUDITORIUM.AUDITORIUM_TYPE = AUDITORIUM_TYPE.AUDITORIUM_TYPE 
GROUP BY AUDITORIUM.AUDITORIUM_TYPE
----------------------- tASK_02 ------------------------------
USE UNIVER;
SELECT
AUDITORIUM.AUDITORIUM_TYPE,
max(AUDITORIUM_CAPACITY) [Максимальная вместимость],
min(AUDITORIUM_CAPACITY) [Минимальная вместимость],
avg(AUDITORIUM_CAPACITY) [Средняя вместимость],
sum(AUDITORIUM_CAPACITY) [Суммарная вместимость],
count (*) [Количество аудиторий]
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
else '9-10' end [Оценки], 
COUNT (*) [Количество]
FROM PROGRESS GROUP BY CASE
when PROGRESS.NOTE between 1 and 2 then '1-2'
when PROGRESS.NOTE between 3 and 4 then '3-4'
when PROGRESS.NOTE between 5 and 6 then '5-6'
when PROGRESS.NOTE between 7 and 8 then '7-8'
else '9-10' end) as T
ORDER BY CASE [Оценки]
when '1-2' then 4
when '3-4' then 3
when '5-6' then 2
when '7-8' then 1
else 0 end
----------------------- tASK_04 ------------------------------
USE UNIVER;
select a.FACULTY,
       G.PROFESSION,
       (2013 - G.YEAR_FIRST + 1) [курс],
       round(avg(cast(NOTE as float(4))), 2) as [средняя оценка]
from FACULTY a
        full join GROUPS G on a.FACULTY = G.FACULTY
        full join STUDENT S on G.IDGROUP = S.IDGROUP
        full join PROGRESS P on S.IDSTUDENT = P.IDSTUDENT
group by a.FACULTY, G.PROFESSION, G.YEAR_FIRST

----------------------- tASK_05 ------------------------------
USE UNIVER;
select a.FACULTY,
       G.PROFESSION,
       (2013 - G.YEAR_FIRST + 1) [курс],
       round(avg(cast(NOTE as float(4))), 2) as [средняя оценка]
from FACULTY a
        full join GROUPS G on a.FACULTY = G.FACULTY
        full join STUDENT S on G.IDGROUP = S.IDGROUP
        full join PROGRESS P on S.IDSTUDENT = P.IDSTUDENT WHERE P.SUBJECT in ('СУБД','ОАиП')
group by a.FACULTY, G.PROFESSION, G.YEAR_FIRST
HAVING (G.PROFESSION is not null or G.YEAR_FIRST is not null)
----------------------- tASK_06 ------------------------------
USE UNIVER;
select a.FACULTY,
       G.PROFESSION,
       P.SUBJECT,
       round(avg(cast(NOTE as float(4))), 2) as [средняя оценка]
from FACULTY a
        full join GROUPS G on a.FACULTY = G.FACULTY
        full join STUDENT S on G.IDGROUP = S.IDGROUP
        full join PROGRESS P on S.IDSTUDENT = P.IDSTUDENT
		WHERE a.FACULTY = 'ИТ'
group by a.FACULTY, G.PROFESSION, P.SUBJECT
----------------------- tASK_07 ------------------------------
USE UNIVER;
SELECT SUBJECT,
       count(*)[Кол-во]
FROM PROGRESS
GROUP BY SUBJECT, NOTE
HAVING NOTE in (8, 9)
ORDER BY SUBJECT;
----------------------- tASK_07 ------------------------------
-------------- EXAMPLE 1 ------------------
USE Ilya_MyBase;
SELECT
Водитель,
COUNT(*)[Количество поездок]
FROM Грузоперевозки
GROUP BY Водитель
-------------- EXAMPLE 2 ------------------
USE Ilya_MyBase;
SELECT 
Стаж,
COUNT(*)[Количество поездок]
FROM Грузоперевозки 
INNER JOIN Водители ON Грузоперевозки.Водитель = Водители.ID_водителя
INNER JOIN Маршруты ON Маршруты.ID_маршрута = Грузоперевозки.Маршрут
GROUP BY Стаж 