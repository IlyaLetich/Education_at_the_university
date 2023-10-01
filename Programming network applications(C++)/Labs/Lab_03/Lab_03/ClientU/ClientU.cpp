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

    SOCKET сС; // дескриптор сокета
    WSADATA wsaData;
    try
    {
        std::cout << "ClientU\n\n";

        if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
            throw SetErrorMsgText("Startup:", WSAGetLastError());
        if ((сС = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
            throw SetErrorMsgText("socket:", WSAGetLastError());

        SOCKADDR_IN serv;
        int ls = sizeof(serv);
        serv.sin_family = AF_INET;
        serv.sin_port = htons(2000);
        serv.sin_addr.s_addr = inet_addr("127.0.0.1");

        clock_t start, end;
        char ibuf[50] = "server: принято ";
        int  libuf = 0, lobuf = 0;

        int countMessage;
        std::cout << "Number of messages: ";
        std::cin >> countMessage;

        start = clock();
        for (int i = 1; i <= countMessage; i++) {

            std::string obuf = "Hello from Client " + std::to_string(i);

            if ((libuf = sendto(сС, obuf.c_str(), obuf.length() + 1, NULL,
                (SOCKADDR*)&serv, sizeof(serv))) == SOCKET_ERROR) {
                throw  SetErrorMsgText("sendto: ", WSAGetLastError());
            }

            std::cout << obuf << std::endl;
        }
        end = clock();
        std::string obuf = "";

        if ((libuf = sendto(сС, obuf.c_str(), strlen(obuf.c_str()) + 1, NULL,
            (SOCKADDR*)&serv, sizeof(serv))) == SOCKET_ERROR) {
            throw  SetErrorMsgText("sendto: ", WSAGetLastError());
        }

        std::cout << "Time for sendto and recvfrom: " << ((double)(end - start) / CLK_TCK) << " c" << std::endl;

        //...........................................................
        if (closesocket(сС) == SOCKET_ERROR)
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