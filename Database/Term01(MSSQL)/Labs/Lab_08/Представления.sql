--1
USE UNIVER;
DROP view [Преподаватель];
CREATE view [Преподаватель]
as SELECT TEACHER.TEACHER [Код],
TEACHER.TEACHER_NAME [Имя преподавателя],
TEACHER.GENDER [Пол],
TEACHER.PULPIT [Код кафедры]
FROM TEACHER

SELECT * FROM Преподаватель

--2
USE UNIVER;

DROP VIEW [Количество кафедр]
CREATE VIEW [Количество кафедр]
as SELECT FACULTY.FACULTY_NAME [Факультет], COUNT(*)[Количество кафедр]
FROM FACULTY INNER JOIN PULPIT ON PULPIT.FACULTY = FACULTY.FACULTY
GROUP BY FACULTY.FACULTY_NAME

SELECT * FROM [Количество кафедр]
--3
USE UNIVER;
DROP view [Аудитории];

CREATE view [Аудитории] ([Код аудитории], [Наименование аудитории], [Тип аудитории])
as SELECT AUDITORIUM,
AUDITORIUM_NAME,
AUDITORIUM_TYPE
FROM AUDITORIUM
WHERE AUDITORIUM_TYPE like 'ЛК%'
SELECT * FROM Аудитории

insert Аудитории ([Код аудитории], [Наименование аудитории],[Тип аудитории]) values ('200-3а', '200-3а', 'ЛК')
delete Аудитории where [Код аудитории] = '200-3а'

SELECT * FROM Аудитории

--4
USE UNIVER;
DROP view [Лекционные_аудитории];
create view [Лекционные_аудитории] ([Код аудитории], [Наименование аудитории], [Тип аудитории])
as SELECT AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE
FROM AUDITORIUM
WHERE AUDITORIUM_TYPE like 'ЛК%' 
WITH CHECK OPTION

SELECT * FROM [Лекционные_аудитории]

INSERT [Лекционные_аудитории] VALUES('200-3а', '200-3а', 'ЛК-К')
Delete [Лекционные_аудитории] where [Код аудитории] = '200-3а' 
INSERT [Лекционные_аудитории] VALUES('200-3а', '200-3а', 'Лаба')

--5
USE UNIVER;
DROP view [Дисциплины];
CREATE VIEW [Дисциплины]
AS SELECT TOP 100 SUBJECT [Код дисциплины],
SUBJECT_NAME [Наименование дисциплины],
PULPIT [Код кафедры]
FROM SUBJECT
ORDER BY SUBJECT_NAME

select * from Дисциплины

--6
USE UNIVER;

ALTER VIEW [Количество кафедр] WITH SCHEMABINDING
as SELECT dbo.FACULTY.FACULTY_NAME [Факультет], COUNT(*)[Количество кафедр]
FROM dbo.FACULTY INNER JOIN dbo.PULPIT ON dbo.PULPIT.FACULTY = dbo.FACULTY.FACULTY
GROUP BY dbo.FACULTY.FACULTY_NAME

SELECT * FROM [Количество кафедр]

--7(1)
USE Ilya_MyBase;

DROP VIEW [Количество поездок водителей]
Create view [Количество поездок водителей] as
SELECT
Водитель,
COUNT(*)[Количество поездок]
FROM Грузоперевозки
GROUP BY Водитель

select * from [Количество поездок водителей]
--7(2)
USE Ilya_MyBase;

DROP VIEW [Количество поездок по стажу]
Create view [Количество поездок по стажу] as
SELECT 
Стаж[Стаж],
COUNT(*)[Количество поездок]
FROM Грузоперевозки 
INNER JOIN Водители ON Грузоперевозки.Водитель = Водители.ID_водителя
INNER JOIN Маршруты ON Маршруты.ID_маршрута = Грузоперевозки.Маршрут
GROUP BY Стаж

select * from [Количество поездок по стажу]
