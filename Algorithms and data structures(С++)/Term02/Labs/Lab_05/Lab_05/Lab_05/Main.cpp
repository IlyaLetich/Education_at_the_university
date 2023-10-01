#include <vector>
#include <iostream>
#include <windows.h>
using namespace std;


#define V 8


//prima
bool isValidEdge(int u, int v, vector<bool> inMST)
{
    if (u == v)
        return false;
    if (inMST[u] == false && inMST[v] == false)
        return false;
    else if (inMST[u] == true && inMST[v] == true)
        return false;
    return true;
}

void primMST(int cost[][V])
{
    vector<bool> inMST(V, false);

    inMST[0] = true;

    int edge_count = 0, mincost = 0;
    while (edge_count < V - 1) { 
        int min = INT_MAX, a = -1, b = -1;
        for (int i = 0; i < V; i++) {
            for (int j = 0; j < V; j++) {
                if (cost[i][j] < min) {
                    if (isValidEdge(i, j, inMST)) {
                        min = cost[i][j];
                        a = i;
                        b = j;
                    }
                }
            }
        }
        if (a != -1 && b != -1) {
            printf("Edge %d:(%d, %d) cost: %d \n",
                edge_count++, a, b, min);
            mincost = mincost + min;
            inMST[b] = inMST[a] = true;
        }
    }
    printf("\n Minimum cost= %d \n", mincost);
}


//kruskala
int parent[V];

int find(int i)
{
    while (parent[i] != i)
        i = parent[i];
    return i;
}

void union1(int i, int j)
{
    int a = find(i);
    int b = find(j);
    parent[a] = b;
}

void kruskalMST(int cost[][V])
{
    int mincost = 0;
    for (int i = 0; i < V; i++)
        parent[i] = i;

    int edge_count = 0;
    while (edge_count < V - 1) {
        int min = INT_MAX, a = -1, b = -1;
        for (int i = 0; i < V; i++) {
            for (int j = 0; j < V; j++) {
                if (find(i) != find(j) && cost[i][j] < min) {
                    min = cost[i][j];
                    a = i;
                    b = j;
                }
            }
        }

        union1(a, b);

        printf("Edge %d:(%d, %d) cost: %d \n",
            edge_count++, a, b, min);
        mincost += min;
    }

    printf("\n Minimum cost= %d \n", mincost);
}

int main()
{
    setlocale(LC_ALL,"rus");

    while (true) 
    {
        SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, (LPARAM)2);
        Sleep(500);
    }






    int cost[][V] = {
        {INT_MAX, 2, INT_MAX, 8, 2, INT_MAX, INT_MAX, INT_MAX},
        {2,INT_MAX, 3, 10, 5, INT_MAX, INT_MAX, INT_MAX},
        {INT_MAX, 3,INT_MAX, INT_MAX, 12, INT_MAX, INT_MAX, 7},
        {8, 10,INT_MAX, INT_MAX, 14, 3, 1, INT_MAX},
        {2, 5, 12, 14, INT_MAX, 11, 4, 8},
        {INT_MAX, INT_MAX, INT_MAX, 3, 11, INT_MAX, 6, INT_MAX},
        {INT_MAX, INT_MAX, INT_MAX, 1, 4, 6, INT_MAX, 9},
        {INT_MAX, INT_MAX, 7, INT_MAX, 8,INT_MAX, 9, INT_MAX},
    };
    std::cout << "\nАлгоритм Прима:\n";
    primMST(cost);

    std::cout << " - - - - - - - - - - - - -";

    std::cout << "\nАлгоритм Крускала:\n";
    kruskalMST(cost);

    return 0;
}