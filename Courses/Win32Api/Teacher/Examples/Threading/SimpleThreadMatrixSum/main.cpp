#include <stdlib.h>
#include <time.h>
#include <windows.h>
#include <iostream>

using namespace std;

const int M = 5;
const int N = 3;

int Matrix[M][N]; 
int sum = 0;

void InitializeMatrix();
DWORD WINAPI MatrixSum(void* lpv);

int main()
{	
	cout << "Simple thread matrix summa" << endl;
	InitializeMatrix();
	HANDLE hThread = CreateThread(NULL, 0, MatrixSum, NULL, 0, NULL);
	if (!hThread)
	{
		cout << "Thread creation error" << endl;
	}
	while (true)
	{
		cout << sum << endl;
		Sleep(1000);
	}
	return 0;
}

void InitializeMatrix()
{
	srand((unsigned)time( NULL ));
	for (int i = 0; i < M; i++)
	{
		for (int j = 0; j < N; j++)
		{
			Matrix[i][j] = rand();
		}
	}
}

DWORD WINAPI MatrixSum(void* lpv)
{
	sum = 0;
	for (int i = 0; i < M; i++)
	{
		for (int j = 0; j < N; j++)
		{
			sum += Matrix[i][j];
		}
	}	
	return 0;
}