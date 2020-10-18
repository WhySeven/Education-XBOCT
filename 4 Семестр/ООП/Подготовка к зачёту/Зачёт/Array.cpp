#include "Complex.h"
#include "Array.h"
#include <iostream>

using namespace std;


Array::Array(int size)
{
	this->size = size;
	arr = (Complex*)malloc(this->size * sizeof(int) * 2);
}
void Array::Print(int i)
{
	std::cout << "i[" << i << "]" << " = " << arr[i];
}
void Array::Print()
{
	std::cout << "Your array:\n";
	for (int i = 0; i < size; i++)
	{
		Print(i);
	}
}
void Array::Assign(int number, Complex c)
{
	arr[number] = c;
}
void Array::Add(Complex c)
{
	size++;
	Complex* tmp = (Complex*)realloc(arr, size * sizeof(int) * 2);
	arr = tmp;
	arr[size - 1] = c;
}