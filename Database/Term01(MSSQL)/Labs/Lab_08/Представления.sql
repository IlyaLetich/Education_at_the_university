--1
USE UNIVER;
DROP view [�������������];
CREATE view [�������������]
as SELECT TEACHER.TEACHER [���],
TEACHER.TEACHER_NAME [��� �������������],
TEACHER.GENDER [���],
TEACHER.PULPIT [��� �������]
FROM TEACHER

SELECT * FROM �������������

--2
USE UNIVER;

DROP VIEW [���������� ������]
CREATE VIEW [���������� ������]
as SELECT FACULTY.FACULTY_NAME [���������], COUNT(*)[���������� ������]
FROM FACULTY INNER JOIN PULPIT ON PULPIT.FACULTY = FACULTY.FACULTY
GROUP BY FACULTY.FACULTY_NAME

SELECT * FROM [���������� ������]
--3
USE UNIVER;
DROP view [���������];

CREATE view [���������] ([��� ���������], [������������ ���������], [��� ���������])
as SELECT AUDITORIUM,
AUDITORIUM_NAME,
AUDITORIUM_TYPE
FROM AUDITORIUM
WHERE AUDITORIUM_TYPE like '��%'
SELECT * FROM ���������

insert ��������� ([��� ���������], [������������ ���������],[��� ���������]) values ('200-3�', '200-3�', '��')
delete ��������� where [��� ���������] = '200-3�'

SELECT * FROM ���������

--4
USE UNIVER;
DROP view [����������_���������];
create view [����������_���������] ([��� ���������], [������������ ���������], [��� ���������])
as SELECT AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE
FROM AUDITORIUM
WHERE AUDITORIUM_TYPE like '��%' 
WITH CHECK OPTION

SELECT * FROM [����������_���������]

INSERT [����������_���������] VALUES('200-3�', '200-3�', '��-�')
Delete [����������_���������] where [��� ���������] = '200-3�' 
INSERT [����������_���������] VALUES('200-3�', '200-3�', '����')

--5
USE UNIVER;
DROP view [����������];
CREATE VIEW [����������]
AS SELECT TOP 100 SUBJECT [��� ����������],
SUBJECT_NAME [������������ ����������],
PULPIT [��� �������]
FROM SUBJECT
ORDER BY SUBJECT_NAME

select * from ����������

--6
USE UNIVER;

ALTER VIEW [���������� ������] WITH SCHEMABINDING
as SELECT dbo.FACULTY.FACULTY_NAME [���������], COUNT(*)[���������� ������]
FROM dbo.FACULTY INNER JOIN dbo.PULPIT ON dbo.PULPIT.FACULTY = dbo.FACULTY.FACULTY
GROUP BY dbo.FACULTY.FACULTY_NAME

SELECT * FROM [���������� ������]

--7(1)
USE Ilya_MyBase;

DROP VIEW [���������� ������� ���������]
Create view [���������� ������� ���������] as
SELECT
��������,
COUNT(*)[���������� �������]
FROM ��������������
GROUP BY ��������

select * from [���������� ������� ���������]
--7(2)
USE Ilya_MyBase;

DROP VIEW [���������� ������� �� �����]
Create view [���������� ������� �� �����] as
SELECT 
����[����],
COUNT(*)[���������� �������]
FROM �������������� 
INNER JOIN �������� ON ��������������.�������� = ��������.ID_��������
INNER JOIN �������� ON ��������.ID_�������� = ��������������.�������
GROUP BY ����

select * from [���������� ������� �� �����]
