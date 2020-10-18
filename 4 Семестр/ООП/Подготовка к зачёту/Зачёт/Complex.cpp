#include "Complex.h"
#include <iostream>

using namespace std;

Complex::Complex()
{
    this->real = 0;
    this->imaginary = 0;
}
Complex::Complex(int real,int imaginary)
{
    this->real = real;
    this->imaginary = imaginary;
}
Complex::Complex(const Complex& c)
{
    real = c.real;
    imaginary = c.imaginary;
}
//+
const Complex Complex::operator+(const Complex& c) const
{
    return Complex(real + c.real, imaginary + c.imaginary);
}
const Complex Complex::operator+(const int& value)const
{
    return Complex(real + value, imaginary);
}
const Complex operator+(const int& value, const Complex& c)
{
    return Complex(value + c.real, c.imaginary);
}

//-
const Complex Complex::operator-(const Complex& c) const
{
    return Complex(real - c.real, imaginary - c.imaginary);
}
const Complex Complex::operator-(const int& value) const
{
    return Complex(real - value, imaginary);
}
const Complex operator-(const int& value, const Complex& c)
{
    return Complex(value -c.real, -c.imaginary);
}

//+=
Complex& Complex::operator+=(const Complex& c)
{
    real += c.real;
    imaginary += c.imaginary;
    return *this;
}
Complex& Complex::operator+=(const int& value)
{
    real += value;
    imaginary += 0;
    return *this;
}

//-=
Complex& Complex::operator-=(const Complex& c)
{
    real -= c.real;
    imaginary -= c.imaginary;
    return *this;
}
Complex& Complex::operator-=(const int& value)
{
    real -= value;
    imaginary -= 0;
    return *this;
}

// =
Complex& Complex::operator=(const Complex& c)
{
    real = c.real;
    imaginary = c.imaginary;
    return *this;
}
Complex& Complex::operator=(const int& value)
{
    real = value;
    imaginary = 0;
    return *this;
}

// extract_real
int Complex::extract_real()
{
    return real;
}

//<<
ostream& operator<<(ostream& os, const Complex& c)
{
    return os << c.real << " + (" << c.imaginary << ")i;\n";;
}

