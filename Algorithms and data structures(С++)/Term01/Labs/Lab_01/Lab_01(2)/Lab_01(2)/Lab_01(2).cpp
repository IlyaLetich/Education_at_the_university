#include <iostream>

using namespace std;

int main() {

	setlocale(LC_ALL, "russian");

	int n,fibonachi(int);
	//Вычисление n-го числа последовательности Фибоначчи с помощью цикла
	cout << "Введите N числа последовательности Фибоначчи: ";
	cin >> n;
	unsigned int start_time = clock();
	int a = 0, b = 1;
	cout << "\n";
	cout << n << " элемент последовательности Фибоначчи равен " << fibonachi(n) << "\n\n\n";
	unsigned int end_time = clock();
	unsigned int search_time = end_time - start_time;
	cout << "Время выполнения рекурсии: " << search_time << " мс.\n\n\n" << endl;
	return 0;
}
int fibonachi(int n) {
	if (n <= 2) {
		if (n == 1) {
			return 1;
		}
		if (n == 0) {
			return 0;
		}
	}
	return fibonachi(n-1) + fibonachi(n-2);
}