#include <iostream>
#include <clocale>
#include <ctime>

#include "ErrorMsgText.h"
#include "Windows.h"

#define NAME L"\\\\*\\mailslot\\Box"
#define STOP "STOP"

using namespace std;

int main()
{
    setlocale(LC_ALL, "rus");

    HANDLE cM;
    DWORD rb;
    clock_t start, end;
    char wbuf[300];

    try {
        cout << "ClientMS\n\n";

        if ((cM = CreateFile(NAME, GENERIC_WRITE, FILE_SHARE_READ,
            NULL, OPEN_EXISTING, NULL, NULL)) == INVALID_HANDLE_VALUE) {
            throw SetPipeError("CreateFile: ", GetLastError());
        }

        int countMessage;
        cout << "Number of messages: ";
        cin >> countMessage;

        for (int i = 0; i < countMessage; i++)
        {
            string obufstr = "Hello from Client" + to_string(i);
            cout << obufstr << endl;
            strcpy_s(wbuf, obufstr.c_str());
            if (!WriteFile(cM,
                wbuf, // буфер
                sizeof(wbuf), // размер буфера
                &rb, // записано
                NULL))
                throw SetPipeError("ReadFileError", GetLastError());
        }

        if (!WriteFile(cM, STOP, sizeof(STOP), &rb, NULL)) {
            throw SetPipeError("WriteFile: ", GetLastError());
        }



        if (!CloseHandle(cM)) {
            throw SetPipeError("CloseHandle: ", GetLastError());
        }

        system("pause");
    }
    catch (string ErrorPipeText) { 
        cout << endl << ErrorPipeText;
    }
}