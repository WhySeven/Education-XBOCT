#include "Complex.h"
#include <iostream>

using namespace std;

Complex::Complex()
{
    this->imaginary = 0;
    this->real = 0;
}
Complex::Complex(int imaginary)
{
    this->imaginary = imaginary;
    real = 0;
}
Complex::Complex(int imaginary,int real)
{
    this->imaginary = imaginary;
    this->real = real;
}
Complex::Complex(const Complex &c)
{
    imaginary = c.imaginary;
    real = c.real;
}
//+
const Complex Complex::operator+(const Complex& item) const
{
    return Complex(imaginary + item.imaginary, real + item.real);
}
const Complex Complex::operator+(const int& value)const
{
    return Complex(imaginary, real + value);
}
const Complex operator+(const int& value, const Complex& item)
{
    return Complex(item.imaginary, item.real + value);
}

//-
const Complex Complex::operator-(const Complex& item) const
{
    return Complex(imaginary - item.imaginary, real - item.real);
}
const Complex Complex::operator-(const int& value) const
{
    return Complex(imaginary, real - value);
}
const Complex operator-(const int& value, const Complex& item)
{
    return Complex(-item.imaginary, value - item.real);
}

//+=
Complex& Complex::operator+=(const Complex& item)
{
    imaginary += item.imaginary;
    real += item.imaginary;
    return *this;
}
Complex& Complex::operator+=(const int& value)
{
    imaginary += 0;
    real += value;
    return *this;
}

//-=
Complex& Complex::operator-=(const Complex& item)
{
    imaginary -= item.imaginary;
    real -= item.imaginary;
    return *this;
}
Complex& Complex::operator-=(const int& value)
{
    imaginary -= 0;
    real -= value;
    return *this;
}

// =
Complex& Complex::operator=(const Complex& item)
{
    imaginary = item.imaginary;
    real = item.real;
    return *this;
}
Complex& Complex::operator=(const int& value)
{
    imaginary = 0;
    real = value;
    return *this;
}

// extract_real
int Complex::extract_real()
{
    return real;
}

//<<
ostream& operator<<(ostream& os, const Complex& item)
{
    return os << item.real << " + (" << item.imaginary << ")i;\n";;
}