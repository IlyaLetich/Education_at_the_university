#include <iostream>
#include <ctime>
using namespace std;

int main() {

	setlocale(LC_ALL, "russian");

	int n;
	//Вычисление n-го числа последовательности Фибоначчи с помощью цикла
	cout << "Введите N числа последовательности Фибоначчи: ";
	cin >> n;
	cout << "\n";
	unsigned int start_time = clock();
	int a = 0,b = 1,c;
	if (n <= 2) {
		if (n == 1) {
			cout << n << " элемент последовательности Фибоначчи равен " << a << "\n\n\n";
		}
		if (n == 2) {
			cout << n << " элемент последовательности Фибоначчи равен " << b << "\n\n\n";
		}
	}
	else {
		for (int i = 3; i <= n+1; i++) {
			c = a + b;
			a = b;
			b = c;
		}
		cout << n << " элемент последовательности Фибоначчи равен " << b << "\n\n";
	}
	unsigned int end_time = clock();
	unsigned int search_time = end_time - start_time;
	cout << "Время выполнения : " << search_time << " мс.\n\n\n" << endl;
	return 0;
}
