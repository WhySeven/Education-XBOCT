
#include <iostream>
#include "Complex.h"
#include "Array.h"
#include "Point.h"
#include "Rectangle.h"
#include "stdio.h"

using namespace std;

int main()
{
    Complex a (1,10);
    Complex b (5);
    Complex c (0,0);
    int d = 10;
    c = d + a;
    std::cout << c << "d = " << d <<";\n";
    c = d + a - d;
    std::cout << c << "d = " << d <<";\n";
    c += b+a;
    d += c;
    std::cout << c << "d = " << d << ";\n";
    d = c.extract_real();
    std::cout << a << b << c << "\nd = " << d;
    int g = 10;
    printf("\n%p", &g);
    int n;
    std::cout << "\nn = ";
    std::cin >> n;
    Array array(n);
    for (int i = 0; i < n;i++)
    {
        array.Assign(i,i);
    }
    for (int i = 10; i <= 20;i++)
    {
        array.Add(i);
    }
    array.Print();
    Point p1 (1, 1);
    Point p2 (10, 10);
    Point p3(p1 + p2);
    p1 = p2;
    Print((p1 + p2).Move(-5,-10));
    p1 = Point(0, 0);
    Rectangle rect1(p1, p2);
    Rectangle rect2 = rect1;
    std::cout << rect2 << Square(rect2);
}