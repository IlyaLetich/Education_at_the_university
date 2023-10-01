#include <iostream>
#include <sstream>
#include "ErrorMsgtext.h"
#pragma comment(lib, "ws2_32.lib")
#pragma warning (disable : 4996)
#define BUF_SIZE 512
using namespace std;

int main()
{
	setlocale(0, "ru");

	cout << "ServerU\n\n";

	LPWSADATA lpwsaData = new WSAData();
	SOCKET sS{};
	try
	{
		if (WSAStartup(514, lpwsaData) != 0)
			throw SetErrorMsgText("WSAStartup:", WSAGetLastError());

		if ((sS = socket(AF_INET, SOCK_DGRAM, 0)) == INVALID_SOCKET)
			throw SetErrorMsgText("server socket:", WSAGetLastError());


		SOCKADDR_IN servInfo;
		servInfo.sin_addr.s_addr = INADDR_ANY;
		servInfo.sin_port = htons(2000);
		servInfo.sin_family = AF_INET;

		if (bind(sS, (SOCKADDR*)&servInfo, sizeof(servInfo)) == SOCKET_ERROR)
			throw SetErrorMsgText("bind:", WSAGetLastError());


		SOCKADDR_IN clntInfo;
		memset(&clntInfo, 0, sizeof(clntInfo));
		int clntInfoSize = sizeof(clntInfo);
		while (true)
		{

			
			clock_t start = 0;
			
			char* clntMessage = new char[BUF_SIZE];
			char** clntMsgArr = new char*[2000];
			for (size_t i = 0; i < 2000; i++)
			{
				clntMsgArr[i] = new char[BUF_SIZE];
			}
			bool close = false;
			int countfrom = 0;
			while (true)
			{
				countfrom++;
				
				if (recvfrom(sS,clntMessage, BUF_SIZE,NULL,(sockaddr*)&clntInfo, &clntInfoSize) == SOCKET_ERROR)
					throw SetErrorMsgText("recvfrom:", WSAGetLastError());
				if (start == 0)
				{
					cout << "Клиент " << inet_ntoa(clntInfo.sin_addr) << ":" << htons(clntInfo.sin_port) << " передает сообщения\n";
					start = clock();
				}
				strcpy(clntMsgArr[countfrom - 1], clntMessage);
				if (strcmp(clntMessage, "") == 0)
				{
					close = true;
					break;
				}
				cout << clntMessage << endl;


			}
			cout << "сообщений принято: " << countfrom << endl;
			int countto = 0;
			while (true)
			{		
				countto++;
				stringstream clntMessageStream;
				clntMessageStream << clntMsgArr[countto - 1];
				if (countto == countfrom)
					break;
				if (sendto(sS, clntMessageStream.str().c_str(), BUF_SIZE, 0, (sockaddr*)&clntInfo, clntInfoSize) == SOCKET_ERROR)
					throw SetErrorMsgText("sendto:", WSAGetLastError());

			}
			cout << "сообщений отправлено: " << countto << endl;
			Sleep(10000);
			if (sendto(sS, (char*)"", BUF_SIZE, 0, (sockaddr*)&clntInfo, clntInfoSize) == SOCKET_ERROR)
				throw SetErrorMsgText("sendto:", WSAGetLastError());
			clock_t end = clock();
			cout << "Клиент " << inet_ntoa(clntInfo.sin_addr) << ":" << htons(clntInfo.sin_port) << " передал последний пакет\n";
			cout << "Время обмена: " << (static_cast<double>(end - start) / CLK_TCK) << " c\n";
			delete[] clntMessage;
			if (close)
			{
				cout << "Завершить работу сервера (y/n)?" << endl;
				char ans;
				cin >> ans;
				if (ans == 'y')
					break;
			}
		}
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