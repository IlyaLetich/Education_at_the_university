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
		cout << endl << "\t�������� ����� ��������\n";
		cout << "\t+--------------------------------------------------------------------------------+\n\t|";
		cout << str.substr(0, l) << str_2.substr(0, 79 - l);
		cout << " |\n\t+--------------------------------------------------------------------------------+\n";
		system("cls");
	}
	cout << endl << "�������� ���������";
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
	cout << " ���� " << ((AAA*)d)->key << " - " << ((AAA*)d)->mas << endl;
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
	cout << "|| ������� ������ ���-�������                  ||\n";
	cout << "||_____________________________________________||\n";
	cout << "\n> "; 	
	cin >> siz;
	system("cls");
	Object H = create(siz, key);
	for (;;)
	{
		//����
		cout << "__________________________________________________________\n";
		cout << "||                    ������� ����                      ||\n";
		cout << "||______________________________________________________||\n";
		cout << "||   ������, ������ ������� ���������� ���������:       ||\n";
		cout << "|| 1 - ����� ���-�������                                ||\n";
		cout << "|| 2 - ���������� ��������                              ||\n";
		cout << "|| 3 - �������� ��������                                ||\n";
		cout << "|| 4 - ����� ��������                                   ||\n";
		cout << "|| 0 - ���������� ��������� :(                          ||\n";
		cout << "||______________________________________________________||\n\n";
		cout << "��� ������� ���������� ���������: ";
		cin >> choice;
		system("cls");

		switch (choice)
		{
		case 0: {
			system("cls");
			cout << "\n\nXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX\n";
			cout << "XX                                                   XX\n";
			cout << "XX                ��������� ���������                XX\n";
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
				cout << "|| ������� ���������                           ||\n";
				cout << "||_____________________________________________||\n";
				cout << "\n> ";
			}
			else
				H.insert(a);
			system("cls");
		} break;
		case 3: {  cout << "������� ���� ��� ��������" << endl;
			cin >> k;
			H.deleteByKey(k);
			system("cls");
		}  break;
		case 4: {  cout << "������� ���� ��� ������" << endl;
			cin >> k;
			if (H.search(k) == NULL)
				cout << "������� �� ������" << endl;
			else
				AAA_print(H.search(k));
			system("cls");
		}  break;
		}
	}
	return 0;
}
