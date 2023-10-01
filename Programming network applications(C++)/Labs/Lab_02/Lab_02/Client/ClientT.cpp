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
        std::cout << "ClientT\n\n";

        if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
            throw SetErrorMsgText("Startup:", WSAGetLastError());
        if ((sS = socket(AF_INET, SOCK_STREAM, NULL)) == INVALID_SOCKET)
            throw SetErrorMsgText("socket:", WSAGetLastError());

        SOCKADDR_IN serv; // параметры сокета sS
        serv.sin_family = AF_INET; // используется IP-адресация
        serv.sin_port = htons(2000); // порт 2000
        serv.sin_addr.s_addr = inet_addr("127.0.0.1");

        if ((connect(sS, (sockaddr*)&serv, sizeof(serv))) == SOCKET_ERROR)
            throw SetErrorMsgText("connect:", WSAGetLastError());

        char ibuf[50] = "server: принято ";
        int  libuf = 0, lobuf = 0;

        int message_amount;
        std::cout << "Amount of messages to send: ";
        std::cin >> message_amount;

        const clock_t start = clock();
        for (int i = 1; i <= message_amount; i++) {
            std::string obuf = "Hello from Client " + std::to_string(i);

            if ((lobuf = send(sS, obuf.c_str(), strlen(obuf.c_str()) + 1, NULL)) == SOCKET_ERROR) {
                throw SetErrorMsgText("send: ", WSAGetLastError());
            }

            if ((libuf = recv(sS, ibuf, sizeof(ibuf), NULL)) == SOCKET_ERROR) {
                throw SetErrorMsgText("recv: ", WSAGetLastError());
            
            }

            std::cout << ibuf << '\n';
        }
        const clock_t end = clock();
        const std::string obuf = "";

        if ((lobuf = send(sS, obuf.c_str(), strlen(obuf.c_str()) + 1, NULL)) == SOCKET_ERROR) {
            throw SetErrorMsgText("send: ", WSAGetLastError());
        };

        std::cout << "Full time of recv/send exchange: " << (static_cast<double>(end - start) / CLK_TCK) << " c\n";

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