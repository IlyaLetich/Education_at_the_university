--DROP database Ilya_MyBase 

use master 
DROP database Ilya_MyBase

CREATE database Ilya_MyBase on primary
( name = N'Ilya_MyBase_mdf', filename = N'C:\Users\ilyac\OneDrive\Рабочий стол\Базы данных\Labs\Lab_03\Ilya_MyBase_mdf.mdf', 
   size = 10240Kb, maxsize=UNLIMITED, filegrowth=1024Kb),
( name = N'Ilya_MyBase_ndf', filename = N'C:\Users\ilyac\OneDrive\Рабочий стол\Базы данных\Labs\Lab_03\Ilya_MyBase_ndf.ndf', 
   size = 10240KB, maxsize=1Gb, filegrowth=25%),
filegroup FG1
( name = N'Ilya_MyBase_fg1_1', filename = N'C:\Users\ilyac\OneDrive\Рабочий стол\Базы данных\Labs\Lab_03\Ilya_MyBase_fgq1.ndf', 
   size = 10240Kb, maxsize=1Gb, filegrowth=25%),
( name = N'Ilya_MyBase_fg1_2', filename = N'C:\Users\ilyac\OneDrive\Рабочий стол\Базы данных\Labs\Lab_03\Ilya_MyBase_fgq2.ndf', 
   size = 10240Kb, maxsize=1Gb, filegrowth=25%)
log on
( name = N'Ilya_MyBase_log', filename=N'C:\Users\ilyac\OneDrive\Рабочий стол\Базы данных\Labs\Lab_03\Ilya_MyBase_log.ldf',       
   size=10240Kb,  maxsize=2048Gb, filegrowth=10%)

go

use Ilya_MyBase

CREATE TABLE Водители
(   
	ID_водителя int primary key not null,
    Имя nvarchar(20),
	Фамилия nvarchar(20),
	Отчество nvarchar(20),
	Стаж int,
) on FG1;

CREATE TABLE Маршруты
(   
	ID_маршрута int primary key not null,
	Наименование_маршрута nvarchar(30),
    Дальность int not null
);

CREATE TABLE Грузоперевозки
(
	ID_грузоперевозки int primary key not null,
	Водитель int not null foreign key  references Водители(ID_Водителя),
    Маршрут int not null foreign key  references Маршруты(ID_Маршрута),
	Дата_отправки date,
	Дата_возвращения date,
	Оплата int
);

ALTER Table Маршруты ADD Грунт date; 
ALTER Table Маршруты DROP Column Грунт;

INSERT into Маршруты(ID_маршрута,Наименование_маршрута,Дальность)
	values (1, 'America', 10000),
		   (2, 'Беларусь', 100),
		   (3, 'Россия', 1000);

INSERT into Водители(ID_водителя,Имя,Фамилия,Отчество,Стаж)
	values (1, 'Лёха', 'Алексеич','Алексеевич',2),
		   (2, 'Иван', 'Иванов','Иванович',3),
		   (3, 'Петя', 'Петров','Петрович',5);

INSERT into Грузоперевозки(ID_грузоперевозки, Водитель, Маршрут, Дата_отправки, Дата_возвращения, Оплата)
	values (1, 1, 2, '2023-08-12', '2023-08-17', 100),
		   (2, 1, 1, '2023-08-12', '2023-08-17', 200),
		   (3, 3, 3, '2023-08-12', '2023-08-17', 300),
		   (4, 2, 3, '2023-08-12', '2023-08-17', 400),
		   (5, 3, 3, '2023-08-12', '2023-08-17', 500);

SELECT * From Грузоперевозки; 
SELECT ID_грузоперевозки, Оплата  From Грузоперевозки;
SELECT count(*)[Количество строк] From Грузоперевозки; 
UPDATE Грузоперевозки set Оплата = Оплата+1 Where Маршрут = 3;