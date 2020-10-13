#include <iostream>
using namespace std;

class Array
{
private:
    int size;
    Complex *arr;
public:
    Array(int size)
    {
        this->size = size;
        arr = (Complex*)malloc(this->size * sizeof(int)*2);
    }
    void Print(int i)
    {
        std::cout << "i[" << i << "]" << " = " << arr[i];
    }
    void Print()
    {
        std::cout <<"Your array:\n";
        for (int i = 0; i < size; i++)
        {
            Print(i);
        }
    }
    void Assign(int number, Complex c)
    {
        arr[number] = c;
    }
    void Add(Complex c)
    {
        size++;
        Complex *tmp = (Complex*)realloc(arr, size * sizeof(int)*2);
        arr = tmp;
        arr[size-1] = c;
    }
};
