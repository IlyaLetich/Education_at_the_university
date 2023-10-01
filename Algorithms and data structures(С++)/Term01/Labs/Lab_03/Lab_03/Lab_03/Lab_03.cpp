#include <iostream>
#include <Windows.h>
#include <cstdlib>
#include <math.h>
using namespace std;
//���������� ������
void bubble_sort(int* const arr, const int n) {
	for (int i = 1; i < n; ++i)
	{
		for (int j = 0; j < n - i; j++)
		{
			if (arr[j] < arr[j + 1])
			{
				// ����� �������
				int temp = arr[j];
				arr[j] = arr[j + 1];
				arr[j + 1] = temp;
			}
		}
	}
}

//���������� ������� �����
void ShellSort(int n, int mass[])
{
	int i, j, step;
	int tmp;
	for (step = n / 2; step > 0; step /= 2)
		for (i = step; i < n; i++)
		{
			tmp = mass[i];
			for (j = i; j >= step; j -= step)
			{
				if (tmp < mass[j - step])
					mass[j] = mass[j - step];
				else
					break;
			}
			mass[j] = tmp;
		}
}

//���������� �������
void SelectionSort(int A[], int n) 
{	
	int count, key;
	for (int i = 0; i < n - 1; i++)
	{
		count = A[i]; key = i;
		for (int j = i + 1; j < n; j++)
			if (A[j] < A[key]) key = j;
		if (key != i)
		{
			A[i] = A[key];
			A[key] = count;
		}
	}
}

//������� ����������
void quickSort(int* array, int low, int high)
{
	int i = low;
	int j = high;
	int pivot = array[(i + j) / 2];
	int temp;

	while (i <= j)
	{
		while (array[i] < pivot)
			i++;
		while (array[j] > pivot)
			j--;
		if (i <= j)
		{
			temp = array[i];
			array[i] = array[j];
			array[j] = temp;
			i++;
			j--;
		}
	}
	if (j > low)
		quickSort(array, low, j);
	if (i < high)
		quickSort(array, i, high);
}

int main() {

	setlocale(LC_ALL, "Russian");

	int menufor = 1;

	system("cls");

	while (menufor != 0) {

		// ���������� ������
		char n;
		clock_t start_shaker, start_bubble, end_shaker, end_bubble, start_selection, end_selection, start_fast, end_fast;
		double time_bubble, time_shaker, time_selection, time_fast;
		//����
		cout << "__________________________________________________________\n";
		cout << "||                    ������� ����                      ||\n";
		cout << "||______________________________________________________||\n";
		cout << "||   ������, ������ ������� ���������� ���������:       ||\n";
		cout << "|| 1 - ���������� �������                               ||\n";
		cout << "|| 2 - ���������� ��������� :(                          ||\n";
		cout << "||______________________________________________________||\n\n";
		cout << "��� ������� ���������� ���������: ";
		cin >> n;
		system("cls");

		//�������� ���������� ���������
		switch (n) {

			//������� 1 ���� 
		case '1': {

			int arr_n;
			cout << "_________________________________________________\n";
			cout << "|| ������� ���������� ��������� � �������      ||\n";
			cout << "||_____________________________________________||\n\n>";
			cin >> arr_n;
			system("cls");

			//��������� � ���������� ���������� ������� ����������� ������������� �������
			static int* arrA = new int[arr_n];
			for (int i = 0; i < arr_n; i++) {
				arrA[i] = rand() % 100;
			}
			//����� �������
			for (int i = 0; i < arr_n; i++) {
				cout << "�������[" << i << "] = " << arrA[i] << "\n";
			}

			//�������� �������� B,C,D,E � ����������� �������� �� ������� A � ������ B,C,D,E
			static int* arrB = new int[arr_n];
			static int* arrC = new int[arr_n];
			static int* arrD = new int[arr_n];
			static int* arrE = new int[arr_n];
			for (int i = 0; i < arr_n; i++) {
				arrB[i] = arrA[i];
				arrC[i] = arrA[i];
				arrD[i] = arrA[i];
				arrE[i] = arrA[i];
			}
			//�����
			unsigned int start_time, end_time;
			  
			//������������� ����������
			start_time = clock();
			bubble_sort(arrB,arr_n);
			end_time = clock();
			unsigned int bubble_sort_time = end_time - start_time;
			//cout << "\n��������������� ������ ������:\n";
			//for (int i = 0; i < arr_n; i++) {
			//	cout << "�������[" << i << "] = " << arrB[i] << "\n";
			//}
			start_time = 0;
			end_time = 0;

			//���������� ��������(��� ������� �����)
			start_time = clock();
			ShellSort(arr_n, arrC);
			end_time = clock();
			unsigned int Shell_sort_time = end_time - start_time;
			//cout << "\n��������������� �������� ������:\n";
			//for (int i = 0; i < arr_n; i++) {
			//	cout << "�������[" << i << "] = " << arrC[i] << "\n";
			//}
			start_time = 0;
			end_time = 0;

			//���������� ������
			start_time = clock();
			SelectionSort(arrD,arr_n);
			end_time = clock();
			unsigned int Selection_sort_time = end_time - start_time;
			//cout << "\n��������������� �������� ������:\n";
			//for (int i = 0; i < arr_n; i++) {
			//	cout << "�������[" << i << "] = " << arrD[i] << "\n";
			//}
			start_time = 0;
			end_time = 0;
			
			//������� ����������
			start_time = clock();
			quickSort(arrE, 0, arr_n);
			end_time = clock();
			unsigned int quik_sort_time = end_time - start_time;
			cout << "\n��������������� ��������� ������:\n";
			for (int i = 1; i < arr_n+1; i++) {
				cout << "�������[" << i-1 << "] = " << arrE[i] << "\n";
			}

			//����� �������
			cout << "\n����� ���������� ���𸸸�:" << bubble_sort_time << "��.\n";
			cout << "\n����� ���������� ��������:" << Shell_sort_time << "��.\n";
			cout << "\n����� ���������� �������:" << Selection_sort_time << "��.\n";
			cout << "\n����� ���������� �������:" << quik_sort_time << "��.\n\n";\

			//����� 1-�� ������ ���������� ���������
			system("pause");
			system("cls");
			break;
		}

				//������� 2 ����� �� ���������
		case '2': {
			system("cls");
			cout << "\n\nXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX\n";
			cout << "XX                                                   XX\n";
			cout << "XX                ��������� ���������                XX\n";
			cout << "XX                                                   XX\n";
			cout << "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX\n\n";
			return 0;
			break;
		}

				//�������� ������� ���������� 
		default: {
			cout << "_______________________________________________________\n";
			cout << "�� ����� ������������ ������� ����������\t!!!!!!!\n";
			cout << "���������,� ���� ���������� � ����\t\t!!!!!!!\n";
			cout << "_______________________________________________________\n\n\n";
			break;
		}
		}
	}

	return 0;
}