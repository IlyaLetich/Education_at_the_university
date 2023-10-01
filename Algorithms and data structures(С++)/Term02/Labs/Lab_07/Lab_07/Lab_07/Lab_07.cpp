#include <iostream>
#include <vector>
#include <string>
#include <stdlib.h>

using namespace std;

void findLIS(vector<int> const& arr)
{

    int n = arr.size();

    // базовый вариант
    if (n == 0) {
        return;
    }

    // LIS[i] хранит самую длинную возрастающую подпоследовательность подмассива
    // `arr[0Еi]`, оканчивающийс€ на `arr[i]`
    vector<vector<int>> LIS(n, vector<int>{});
    
    // LIS[0] обозначает самую длинную возрастающую подпоследовательность, заканчивающуюс€ на `arr[0]
    LIS[0].push_back(arr[0]);

    // начинаем со второго элемента массива
    for (int i = 1; i < n; i++)
    {
        for (int j = 0; j < i; j++)
        {
            // найти самую длинную возрастающую подпоследовательность, заканчивающуюс€ на `arr[j]`
            // где `arr[j]` меньше, чем текущий элемент `arr[i]`
            if (arr[j] < arr[i] && LIS[j].size() > LIS[i].size()) 
            {
                LIS[i] = LIS[j];
            }
        }

        // включить `arr[i]` в `LIS[i]`
        LIS[i].push_back(arr[i]);
    }

    // `j` будет хранить индекс LIS
    int j = 0;
    for (int i = 0; i < n; i++)
    {
        if (LIS[j].size() <= LIS[i].size()) {
            j = i;
        }
    }

    cout << "Max: " << LIS[j].size() << endl << "Sequence: ";

    for (int i : LIS[j]) {
        cout << i << " ";
    }
}

int main()
{
    setlocale(LC_ALL, "rus");
    vector<int> arr; // = { 5, 10, 6, 12, 3, 24, 7, 8 }


    cout << "Enter the sequence elements: \n";

    string num;
    while (true)
    {
        cout << " > ";
        cin >> num;
        if (num == "END") {
            break;
        }
        arr.push_back(stoi(num));
    }

    cout << "\nThe original sequence: ";

    for (vector<int>::iterator it = arr.begin(); it != arr.end(); ++it)
    {
        cout << *it << " ";
    }
    cout << endl;

    findLIS(arr);

    cout << endl << endl;
    system("pause");
    return 0;
}