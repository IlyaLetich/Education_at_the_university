#include <iostream>
#include <ctime>
using namespace std;

int main() {

	setlocale(LC_ALL, "russian");

	int n;
	//���������� n-�� ����� ������������������ ��������� � ������� �����
	cout << "������� N ����� ������������������ ���������: ";
	cin >> n;
	cout << "\n";
	unsigned int start_time = clock();
	int a = 0,b = 1,c;
	if (n <= 2) {
		if (n == 1) {
			cout << n << " ������� ������������������ ��������� ����� " << a << "\n\n\n";
		}
		if (n == 2) {
			cout << n << " ������� ������������������ ��������� ����� " << b << "\n\n\n";
		}
	}
	else {
		for (int i = 3; i <= n+1; i++) {
			c = a + b;
			a = b;
			b = c;
		}
		cout << n << " ������� ������������������ ��������� ����� " << b << "\n\n";
	}
	unsigned int end_time = clock();
	unsigned int search_time = end_time - start_time;
	cout << "����� ���������� : " << search_time << " ��.\n\n\n" << endl;
	return 0;
}
