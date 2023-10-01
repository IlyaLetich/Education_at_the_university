#include <iostream>

using namespace std;

int* bubble_sort(int* arr, int n_arr) {

    int temp = 0; //Временная   переменная

    for (int i = 0; i < n_arr - 1; i++) {
        for (int j = i + 1; j < n_arr; j++) {
            if (arr[i] > arr[j]) {
                temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
    }

    return arr;
}

int vin(int* arr, int size)
{
    int vins = 0;
    int nom = 0;
    for (int i = size - 1; i >= 0; i--)
    {
        if (nom == 3)
        {
            break;
        }
        if (arr[i] == arr[i - 1])
        {
            vins++;
        }
        if (arr[i] > arr[i - 1])
        {
            nom++;
            vins++;
        }
    }
    return vins;
}

int* bubble_sort_obr(int* arr, int n_arr) {

    int temp = 0; //Временная   переменная

    for (int i = n_arr-1; i >= 0; i--) {
        for (int j = i - 1; j >= 0; j--) {
            if (arr[i] > arr[j]) {
                temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
    }

    return arr;
}

void ziclo()
{
    setlocale(LC_ALL,"rus");
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

int main() {


    ziclo();
    setlocale(LC_ALL, "rus");
    int forar = 1;
    while(forar!=0){
    char n;
    system("cls");
    //Меню
    cout << "__________________________________________________________\n";
    cout << "||                    Главное меню                      ||\n";
    cout << "||______________________________________________________||\n";
    cout << "||   Привет, выбери вариант выполнения программы:       ||\n";
    cout << "|| 1 - Задание 1                                        ||\n";
    cout << "|| 2 - Задание 2                                        ||\n";
    cout << "|| 3 - Завершение программы :(                          ||\n";
    cout << "||______________________________________________________||\n\n";
    cout << "Ваш вариант выполнения программы: ";
    cin >> n;
    system("cls");

    //Варианты выполнения программы
    switch (n) {

        //Вариант 1 Игра 
    case '1': {

        int arr_n;
        cout << "_________________________________________________\n";
        cout << "|| Введите количество элементов в массиве      ||\n";
        cout << "||_____________________________________________||\n\n>";
        cin >> arr_n;
        system("cls");
        if (arr_n >= 10000)break;
        //Генерация и заполнение случайными числами одномерного динамического массива
        static int* arrA = new int[arr_n];
        for (int i = 0; i < arr_n; i++) {
            arrA[i] = rand() % 100;
        }
        cout << "_________________________________________________\n";
        cout << "|| Корзина                                     ||\n";
        cout << "||_____________________________________________||\n";
        //Вывод массива
        for (int i = 0; i < arr_n; i++) {
            cout << "--- цена " << i+1 << " товара = " << arrA[i] << "\n";
        }
        cout << "||---------------------------------------------||\n";

        bubble_sort(arrA, arr_n);
        //Вывод массива
        cout << "_________________________________________________\n";
        cout << "|| Сортировка                                  ||\n";
        cout << "||_____________________________________________||\n";
        for (int i = 0; i < arr_n; i++) {
            cout << "--- цена " << i+1 << " товара = " << arrA[i] << "\n";
        }
        cout << "||---------------------------------------------||\n";
        int maxsum = 0;
        int jfor = arr_n/2;
        int jformin = arr_n / 2;
        if (arr_n % 2 != 1) {
            jfor = jfor - 1;
            jformin = jformin - 1;
        }
        static int* arrB = new int[arr_n];

        for (int i = 0; i < arr_n; i++) {
            if (i % 2 != 1) {
                arrB[i] = arrA[jfor];
                jfor++;
                maxsum = maxsum + arrA[jfor];
            }
        }
        for (int i = arr_n-1; i >= 0; i--) {
            if (i % 2 != 0) {
                arrB[i] = arrA[jformin];
                jformin--;
            }
        }
        

        cout << "_________________________________________________\n";
        cout << "|| Чек                                         ||\n";
        cout << "||_____________________________________________||\n";
        //Вывод массива
        for (int i = 0; i < arr_n; i++) {
            cout << "--- цена " << i+1 << " товара = " << arrB[i] << "\n";
        }
        cout << "||---------------------------------------------||\n";
        cout << "||\n";
        cout << "|| Максимальнаяя сумма чека = " << maxsum<<endl;
        cout << "||\n";
        cout << "||---------------------------------------------||\n";
        system("pause");
        break;
    }
    case '2': {
        system("cls");
        

        int arr_n;
        cout << "_________________________________________________\n";
        cout << "|| Введите количество элементов в массиве      ||\n";
        cout << "||_____________________________________________||\n\n>";
        cin >> arr_n;
        system("cls");
        if (arr_n >= 10000)break;
        //Генерация и заполнение случайными числами одномерного динамического массива
        static int* arrA = new int[arr_n];
        for (int i = 0; i < arr_n; i++) {
            arrA[i] = rand() % 100;
        }
        cout << "_________________________________________________\n";
        cout << "|| Участники                                   ||\n";
        cout << "||_____________________________________________||\n";
        //Вывод массива
        for (int i = 0; i < arr_n; i++) {
            cout << "--- участник " << i + 1 << " количество баллов = " << arrA[i] << "\n";
        }
        cout << "||---------------------------------------------||\n";

        bubble_sort_obr(arrA, arr_n);
        //Вывод массива
        cout << "_________________________________________________\n";
        cout << "|| Сортировка                                  ||\n";
        cout << "||_____________________________________________||\n";
        for (int i = 0; i < arr_n; i++) {
            cout << "--- участник " << i + 1 << " количество баллов = " << arrA[i] << "\n";
        }
        cout << "||---------------------------------------------||\n";
        int l = 0;
        int i = 0;
        int sravn = 0;
        int kolvo = 0;
        while(l!=3) {
            kolvo++;
            if (arrA[i] != arrA[i + 1]) {
                l++;
            }
            i++;
        }
        cout << "||---------------------------------------------||\n";
        cout << "||\n";
        cout << "|| Количество призёров = " << kolvo << endl;
        cout << "||\n";
        cout << "||---------------------------------------------||\n";
        system("pause");
        break;
    }

    case '3': {
        system("cls");
        cout << "\n\nXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX\n";
        cout << "XX                                                   XX\n";
        cout << "XX                Программа завершена                XX\n";
        cout << "XX                                                   XX\n";
        cout << "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX\n\n";
        return 0;
        break;
    }

            //Невернай вариант выполнения 
    default: {
        cout << "_______________________________________________________\n";
        cout << "Вы ввели некорректный вариант выполнения\t!!!!!!!\n";
        cout << "программы,и были возвращены в меню\t\t!!!!!!!\n";
        cout << "_______________________________________________________\n\n\n";
        break;
    }
    }
    }
    return 0;
}


