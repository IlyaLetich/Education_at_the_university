#include <iostream>
#include <clocale>
#include <ctime>

#include "ErrorMsgText.h"
#include "Windows.h"
#include <string>

#define STOP "STOP"
#define NAME L"\\\\.\\pipe\\Tube"

using namespace std;

int main()
{
    setlocale(LC_ALL, "rus");

    HANDLE cH;
    DWORD mode = PIPE_READMODE_MESSAGE; 
    DWORD lp;
    char ibuf[50] = "Hello from Client",
        obuf[50];

    try {
        cout << "ClientNPt\n\n";

        if ((cH = CreateFile(NAME,
            GENERIC_READ | GENERIC_WRITE, //чтение запись
            FILE_SHARE_READ | FILE_SHARE_WRITE, // совместное чтение и запись
            NULL, // атрибуты безопастности
            OPEN_EXISTING, //параметр открытия канала
            NULL, NULL)) == INVALID_HANDLE_VALUE) {
            throw SetPipeError("CreateFile: ", GetLastError());
        }
        if (!SetNamedPipeHandleState(cH, &mode, NULL, NULL)) { // изменение динамических характеристик канала
            cout << GetLastError();
            throw SetPipeError("SetNamedPipeHandleState: ", GetLastError());
        }
      
        int countMessage = 10;
        cout << "Number of messages: 10";

        for (int i = 1; i <= countMessage; i++) {

            string obufstr = "Hello from ClientNPt " + to_string(i);
            strcpy_s(obuf, obufstr.c_str());

            if (!TransactNamedPipe(cH, //дискриптор канала (объединение считывания и отправки)
                obuf, sizeof(obuf), //для записи
                ibuf, sizeof(ibuf), // для чтения
                &lp,  //кол-во байт
                NULL)) { // если толкьо режим PIPE_READMODE_MESSAGE (чтение на сообщение)
                throw SetPipeError("TransactNamedPipe: ", GetLastError());
            }

            cout << ibuf << endl;
        }

        if (!WriteFile(cH, STOP, sizeof(STOP), &lp, NULL)) {
            throw SetPipeError("WriteFile: ", GetLastError());
        }
        if (!CloseHandle(cH)) {
            throw SetPipeError("CloseHandle: ", GetLastError());
        }

        system("pause");
    }
    catch (string ErrorPipeText) {
        cout << endl << ErrorPipeText;
    }
}