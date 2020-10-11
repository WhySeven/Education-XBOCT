#include <iostream>
using namespace std;

class Array
{
private:
    int size;
    int *arr;
public:
    Array(int size)
    {
        this->size = size;
        arr = (int*)malloc(this->size * sizeof(int));
    }
    void Print(int i)
    {
        std::cout << i << " = " << arr[i] << ";\n";
    }
    void Print()
    {
        std::cout <<"Your array:\n";
        for (int i = 0; i < size; i++)
        {
            Print(i);
        }
    }
    void Assign(int number, int value)
    {
        arr[number] = value;
    }
    void Add(int value)
    {
        size++;
        int *tmp = (int*)realloc(arr, size * sizeof(int));
        arr = tmp;
        arr[size-1] = value;
    }
};
