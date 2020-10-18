#include <iostream>
using namespace std;

class Complex
{
public:
    // ����
    int imaginary;
    int real;
    // ������������
    Complex();
    Complex(int imaginary, int real);
    Complex(const Complex& c);

    //���������� ����������
    // +
    const Complex operator+(const Complex& c) const;  
    const Complex operator+(const int& value) const;  
    friend const Complex operator+(const int& value, const Complex& c);

    // -
    const Complex operator-(const Complex& c) const;
    const Complex operator-(const int& value) const;
    friend const Complex operator-(const int& value, const Complex& c);

    // +=
    Complex& operator+=(const Complex& c);
    Complex& operator+=(const int& value);

    // -=
    Complex& operator-=(const Complex& c);
    Complex& operator-=(const int& value);

    // =
    Complex& operator=(const Complex& c);
    Complex& operator=(const int& value);

    // extract_real
    int extract_real();

    // <<
    friend ostream& operator<<(ostream& os, const Complex& c);
};




