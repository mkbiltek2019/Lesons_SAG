#include <iostream>
using namespace std;

class CycleQueue
{
private:
	int * arr;
	int maxSize;
	int curSize;

public:
	CycleQueue(int maxSize)
	{
		if (maxSize > 0)
		{
			this->maxSize = maxSize;
		}
		else
			maxSize = 0;

		arr = new int[maxSize];
		curSize = 0;
	}
	~CycleQueue()
	{
		delete [] arr;
	}
	bool IsEmpty()
	{
		return !curSize;
	}
	bool IsFull()
	{
		return curSize == maxSize;
	}
	void Push(int a)
	{
		if (!IsFull())
			arr[curSize++] = a;
	}
	int Pop()
	{
		int forReturn = -1;

		if (!IsEmpty())
		{
			forReturn = arr[0];
			for (int i = 0; i < curSize - 1; i++)
				arr[i] = arr[i + 1];
			arr[curSize - 1] = forReturn;
		}	

		return forReturn;		
	}
	void Clear()
	{
		curSize = 0;
	}
	void Print()
	{
		cout << endl;
		if (IsEmpty())
			cout << "Queue is empty!";
		else
			for (int i = 0; i < curSize; i++)
				cout << arr[i] << endl;
	}
	int GetMaxSize()
	{
		return maxSize;
	}
};