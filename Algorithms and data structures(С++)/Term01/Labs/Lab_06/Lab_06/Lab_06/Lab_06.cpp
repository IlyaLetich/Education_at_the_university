#include "Hash.h"
#include <iostream>
#include <Windows.h>
using namespace std;

void ziclo()
{
	setlocale(LC_ALL, "rus");
	int n = 0;
	string str = "////////////////////////////////////////////////////////////////////////////////";
	string str_2 = "                                                                                ";
	for (int l = 0; l < 80; l++)
	{
		cout << endl << "\tожидайте конца загрузки\n";
		cout << "\t+--------------------------------------------------------------------------------+\n\t|";
		cout << str.substr(0, l) << str_2.substr(0, 79 - l);
		cout << " |\n\t+--------------------------------------------------------------------------------+\n";
		system("cls");
	}
	cout << endl << "загрузка завершена";
}

struct AAA
{
	int key;
	char* mas;
	AAA(int k, char* z)
	{
		key = k;  mas = z;
	} AAA() {}
};
//-------------------------------
int key(void* d)
{
	AAA* f = (AAA*)d;
	return f->key;
}
//-------------------------------
void AAA_print(void* d)
{
	cout << " ключ " << ((AAA*)d)->key << " - " << ((AAA*)d)->mas << endl;
}
//-------------------------------
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	ziclo();
	system("cls");
	setlocale(LC_ALL, "rus");
	int siz = 10, choice, k;
	cout << "_________________________________________________\n";
	cout << "|| Введите размер хеш-таблицы                  ||\n";
	cout << "||_____________________________________________||\n";
	cout << "\n> "; 	
	cin >> siz;
	system("cls");
	Object H = create(siz, key);
	for (;;)
	{
		//Меню
		cout << "__________________________________________________________\n";
		cout << "||                    Главное меню                      ||\n";
		cout << "||______________________________________________________||\n";
		cout << "||   Привет, выбери вариант выполнения программы:       ||\n";
		cout << "|| 1 - вывод хеш-таблицы                                ||\n";
		cout << "|| 2 - добавление элемента                              ||\n";
		cout << "|| 3 - удаление элемента                                ||\n";
		cout << "|| 4 - поиск элемента                                   ||\n";
		cout << "|| 0 - Завершение программы :(                          ||\n";
		cout << "||______________________________________________________||\n\n";
		cout << "Ваш вариант выполнения программы: ";
		cin >> choice;
		system("cls");

		switch (choice)
		{
		case 0: {
			system("cls");
			cout << "\n\nXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX\n";
			cout << "XX                                                   XX\n";
			cout << "XX                Программа завершена                XX\n";
			cout << "XX                                                   XX\n";
			cout << "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX\n\n";
			return 0;
			break;
		};
		case 1: {H.scan(AAA_print);
			system("pause");
			system("cls");
		}  break;
		case 2: {  AAA* a = new AAA;
			char* str = new char[20];
			cout << "_________________________________________________\n";
			cout << "|| KEY enter...                                ||\n";
			cout << "||_____________________________________________||\n";
			cout << "\n> ";
			cin >> k;
			a->key = k;

			cout << "_________________________________________________\n";
			cout << "|| TEXT enter...                               ||\n";
			cout << "||_____________________________________________||\n";
			cout << "\n> ";
			cin >> str;
			a->mas = str;
			if (H.N == H.size) {
				cout << "_________________________________________________\n";
				cout << "|| Таблица заполнена                           ||\n";
				cout << "||_____________________________________________||\n";
				cout << "\n> ";
			}
			else
				H.insert(a);
			system("cls");
		} break;
		case 3: {  cout << "введите ключ для удаления" << endl;
			cin >> k;
			H.deleteByKey(k);
			system("cls");
		}  break;
		case 4: {  cout << "введите ключ для поиска" << endl;
			cin >> k;
			if (H.search(k) == NULL)
				cout << "Элемент не найден" << endl;
			else
				AAA_print(H.search(k));
			system("cls");
		}  break;
		}
	}
	return 0;
}
