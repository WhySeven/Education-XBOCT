
#include <iostream>
#include "Complex.h"
#include "Array.h"
#include "Point.h"
#include "Rectangle.h"
#include "stdio.h"


using namespace std;


void ComplexCheck()
{
    Complex a(0, 10);
    Complex b(0, 5);
    Complex c;
    int i = 30;
    cout << "a = " << a << "b = " << b << "c = " << c << "i = " << i << "\n\n";
    c = a;
    cout << "Action: c = a;\n" << "c = " << c << "a = " << a << "\n\n";
    c = Complex(0, 0);
    cout << "Action: c = Complex(0,0);\nc = " << c << "\n\n";
    c = Complex(a);
    cout << "Action: c = Complex(a) (copy constructor using)\nc = " << c << "a = " << a << "\n\n";
    cout << "a = " << a << "b = " << b << "c = " << c << "i = " << i << "\n\n";
    c += b - a - i - Complex(c);
    cout << "Action: c += b - a - i - c;\n" << "c = " << c;
}


void ArrayCheck()
{
    int n;
    std::cout << "\nn = ";
    std::cin >> n;
    Array array(n);
    for (int i = 0; i < n;i++)
    {
        array.Assign(i, Complex(0, i));
    }
    for (int i = 10; i < 20;i++)
    {
        array.Add(Complex(i, 0));
    }
    array.Print();
}



int main()
{
    ComplexCheck();
    //ArrayCheck();
}
