--DROP database Ilya_MyBase 

use master 
DROP database Ilya_MyBase

CREATE database Ilya_MyBase on primary
( name = N'Ilya_MyBase_mdf', filename = N'C:\Users\ilyac\OneDrive\������� ����\���� ������\Labs\Lab_03\Ilya_MyBase_mdf.mdf', 
   size = 10240Kb, maxsize=UNLIMITED, filegrowth=1024Kb),
( name = N'Ilya_MyBase_ndf', filename = N'C:\Users\ilyac\OneDrive\������� ����\���� ������\Labs\Lab_03\Ilya_MyBase_ndf.ndf', 
   size = 10240KB, maxsize=1Gb, filegrowth=25%),
filegroup FG1
( name = N'Ilya_MyBase_fg1_1', filename = N'C:\Users\ilyac\OneDrive\������� ����\���� ������\Labs\Lab_03\Ilya_MyBase_fgq1.ndf', 
   size = 10240Kb, maxsize=1Gb, filegrowth=25%),
( name = N'Ilya_MyBase_fg1_2', filename = N'C:\Users\ilyac\OneDrive\������� ����\���� ������\Labs\Lab_03\Ilya_MyBase_fgq2.ndf', 
   size = 10240Kb, maxsize=1Gb, filegrowth=25%)
log on
( name = N'Ilya_MyBase_log', filename=N'C:\Users\ilyac\OneDrive\������� ����\���� ������\Labs\Lab_03\Ilya_MyBase_log.ldf',       
   size=10240Kb,  maxsize=2048Gb, filegrowth=10%)

go

use Ilya_MyBase

CREATE TABLE ��������
(   
	ID_�������� int primary key not null,
    ��� nvarchar(20),
	������� nvarchar(20),
	�������� nvarchar(20),
	���� int,
) on FG1;

CREATE TABLE ��������
(   
	ID_�������� int primary key not null,
	������������_�������� nvarchar(30),
    ��������� int not null
);

CREATE TABLE ��������������
(
	ID_�������������� int primary key not null,
	�������� int not null foreign key  references ��������(ID_��������),
    ������� int not null foreign key  references ��������(ID_��������),
	����_�������� date,
	����_����������� date,
	������ int
);

ALTER Table �������� ADD ����� date; 
ALTER Table �������� DROP Column �����;

INSERT into ��������(ID_��������,������������_��������,���������)
	values (1, 'America', 10000),
		   (2, '��������', 100),
		   (3, '������', 1000);

INSERT into ��������(ID_��������,���,�������,��������,����)
	values (1, '˸��', '��������','����������',2),
		   (2, '����', '������','��������',3),
		   (3, '����', '������','��������',5);

INSERT into ��������������(ID_��������������, ��������, �������, ����_��������, ����_�����������, ������)
	values (1, 1, 2, '2023-08-12', '2023-08-17', 100),
		   (2, 1, 1, '2023-08-12', '2023-08-17', 200),
		   (3, 3, 3, '2023-08-12', '2023-08-17', 300),
		   (4, 2, 3, '2023-08-12', '2023-08-17', 400),
		   (5, 3, 3, '2023-08-12', '2023-08-17', 500);

SELECT * From ��������������; 
SELECT ID_��������������, ������  From ��������������;
SELECT count(*)[���������� �����] From ��������������; 
UPDATE �������������� set ������ = ������+1 Where ������� = 3;