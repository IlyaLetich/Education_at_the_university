#define _WINSOCK_DEPRECATED_NO_WARNINGS

#include <iostream>
#include <clocale>
#include <ctime>


#include "ErrorMsgText.h"
#include "Winsock2.h"                
#pragma comment(lib, "WS2_32.lib")   

int main()
{
    setlocale(LC_ALL, "rus");

    SOCKET sS; // дескриптор сокета
    WSADATA wsaData;
    try
    {
        std::cout << "ServerU\n\n";

        if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
            throw SetErrorMsgText("Startup:", WSAGetLastError());
        if ((sS = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
            throw SetErrorMsgText("socket:", WSAGetLastError());
        
        // связываем

        SOCKADDR_IN serv; // параметры сокета sS
        serv.sin_family = AF_INET; // используется IP-адресация
        serv.sin_port = htons(2000); // порт 2000
        serv.sin_addr.s_addr = INADDR_ANY; // любой собственный IP-адрес

        if (bind(sS, (LPSOCKADDR)&serv, sizeof(serv)) == SOCKET_ERROR)
            throw SetErrorMsgText("bind:", WSAGetLastError());

        // структура клиента
        SOCKADDR_IN clientInfo;
        memset(&clientInfo, 0, sizeof(clientInfo));

        char ibuf[50];
        int lc = sizeof(clientInfo), lb = 0, lobuf = 0;
        clock_t start, end;
        bool flag = true;

        while (true) {
            if ((lb = recvfrom(sS, ibuf, sizeof(ibuf), NULL, (sockaddr*)&clientInfo, &lc)) == SOCKET_ERROR) {
                throw  SetErrorMsgText("recvfrom: ", WSAGetLastError());
            }
            if (flag) {
                flag = false;
                start = clock();
            }
            if (strcmp(ibuf, "") == 0) {
                end = clock();
                flag = true;
                std::cout << "\nTime for sendto and recvfrom: " << ((double)(end - start) / CLK_TCK) << " c\n\n";

            }
            else {
                std::cout << ibuf << std::endl;
            }
        }
        //...........................................................
        if (closesocket(sS) == SOCKET_ERROR)
            throw SetErrorMsgText("closesocket:", WSAGetLastError());
        if (WSACleanup() == SOCKET_ERROR)
            throw SetErrorMsgText("Cleanup:", WSAGetLastError());
    }
    catch (std::string errorMsgText)
    {
        std::cout << std::endl << errorMsgText;
    }

    system("pause");
    return 0;
}