#include <iostream>
using namespace std;

class Array
{
private:    
public:
    int size;
    Complex* arr;
    Array(int size);
    void Print(int i);
    void Print();
    void Assign(int number, Complex c);
    void Add(Complex c);
};
