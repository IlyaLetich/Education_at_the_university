#include <WS2tcpip.h>
#include <WinSock2.h>
#include <iostream>
#include "ErrorMsgtext.h"
#include <conio.h>
#include <sstream>


#pragma comment(lib, "ws2_32.lib")
#pragma warning (disable : 4996)
#define BUF_SIZE 512

using namespace std;

int main()
{
	cout << "ClientU\n\n";

	LPWSADATA lpwsaData = new WSAData();
	SOCKET sS{};
	setlocale(0, "ru");
	try
	{
		if (WSAStartup(514, lpwsaData) != 0)
			throw SetErrorMsgText("WSAStartup:", WSAGetLastError());

		if ((sS = socket(AF_INET, SOCK_DGRAM, 0)) == INVALID_SOCKET)
			throw SetErrorMsgText("server socket:", WSAGetLastError());

		SOCKADDR_IN servInfo;
		servInfo.sin_addr.s_addr = inet_addr("127.0.0.1");
		servInfo.sin_port = htons(2000);
		servInfo.sin_family = AF_INET;
		int servInfoSize = sizeof(servInfo);
		int n;
		cout << "кол-во сообщений: ";
		cin >> n;
		char* servMessage = new char[BUF_SIZE];
		clock_t start = clock();
		for (size_t i = 1; i <= n; i++)
		{
			stringstream clntMessage;
			clntMessage << "Hello from Client " << i;
			if (sendto(sS, clntMessage.str().c_str(), BUF_SIZE, 0, (sockaddr*)&servInfo, servInfoSize) == SOCKET_ERROR)
				throw SetErrorMsgText("send:", WSAGetLastError());
			/*Sleep(10);*/
		}
		stringstream clntMessage;
		clntMessage << "";
		Sleep(1000); 
		if (sendto(sS, clntMessage.str().c_str(), BUF_SIZE, 0, (sockaddr*)&servInfo, servInfoSize) == SOCKET_ERROR)
			throw SetErrorMsgText("send:", WSAGetLastError());

		for (size_t i = 1; i <= n; i++)
		{
			if (recvfrom(sS, servMessage, BUF_SIZE, 0, (sockaddr*)&servInfo, &servInfoSize) == SOCKET_ERROR)
				throw SetErrorMsgText("recvfrom:", WSAGetLastError());
			if (strcmp(servMessage, "") == 0)
			{
				break;
			}

			cout << servMessage << endl;
		}


		clock_t end = clock();
		cout << "Время обмена: " << (static_cast<double>(end - start) / CLK_TCK) << " c\n";
		delete[] servMessage;
		closesocket(sS);
		WSACleanup();
	}
	catch (string error)
	{
		cout << error;
		closesocket(sS);
		WSACleanup();
	}
	system("pause");
	return 0;
}