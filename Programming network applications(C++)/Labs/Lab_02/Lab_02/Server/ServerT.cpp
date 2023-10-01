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
        std::cout << "ServerT\n\n";

        if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
            throw SetErrorMsgText("Startup:", WSAGetLastError());
        if ((sS = socket(AF_INET, SOCK_STREAM, NULL)) == INVALID_SOCKET)
            throw SetErrorMsgText("socket:", WSAGetLastError());

        SOCKADDR_IN serv; // параметры сокета sS
        serv.sin_family = AF_INET; // используется IP-адресация
        serv.sin_port = htons(2000); // порт 2000
        serv.sin_addr.s_addr = INADDR_ANY; // любой собственный IP-адрес                 ------------------ поменять

        if (bind(sS, (LPSOCKADDR)&serv, sizeof(serv)) == SOCKET_ERROR)
            throw SetErrorMsgText("bind:", WSAGetLastError());

        if (listen(sS, SOMAXCONN) == SOCKET_ERROR)
            throw SetErrorMsgText("listen:", WSAGetLastError());

        SOCKET cS; // сокет для обмена данными с клиентом
        SOCKADDR_IN clnt; // параметры сокета клиента
        memset(&clnt, 0, sizeof(clnt)); // обнулить память
        int lclnt = sizeof(clnt); // размер SOCKADDR_IN
        while (true)
        {
            if ((cS = accept(sS, (sockaddr*)&clnt, &lclnt)) == INVALID_SOCKET)
                throw SetErrorMsgText("accept:", WSAGetLastError());

            std::cout << "\n---- NEW CLIENT ACCEPTED ----\n\n";

            std::cout << "IP: " << inet_ntoa(clnt.sin_addr) << " Port: " << ntohs(clnt.sin_port) << std::endl << std::endl;

            clock_t start, end;
            char
                obuf[50] = "server: принято ";
            bool flag = true;

            while (true) {
                int lobuf = 0;
                int libuf = 0;
                char ibuf[50];


                if ((libuf = recv(cS, ibuf, sizeof(ibuf), NULL)) == SOCKET_ERROR) {
                    if (WSAGetLastError() == WSAECONNRESET) {
                        end = clock();
                        flag = true;
                        std::cout << "\n---- CLIENT CONNECTION WAS RESET after " << (static_cast<double>(end - start) / CLK_TCK) << " seconds of recv/send excange ----\n";
                        break;
                    }
                    throw SetErrorMsgText("recv: ", WSAGetLastError());
                }
                if (flag) {
                    start = clock();
                    flag = !flag;
                }

                std::string obuf = ibuf;
                if ((lobuf = send(cS, obuf.c_str(), strlen(obuf.c_str()) + 1, NULL)) == SOCKET_ERROR) {
                    throw SetErrorMsgText("send: ", WSAGetLastError());
                }

                if (strcmp(ibuf, "") == 0) {
                    flag = true;
                    end = clock();
                    std::cout << "Full time of recv/send exchange: " << ((double)(end - start) / CLK_TCK) << " c\n\n";
                    break;
                }
                std::cout << ibuf << std::endl;
            }
            if (closesocket(cS) == SOCKET_ERROR)
                throw SetErrorMsgText("closesocket:", WSAGetLastError());
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