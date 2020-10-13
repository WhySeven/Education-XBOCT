#include <iostream>
using namespace std;

class Complex
{
public:
    // Поля
    int imaginary;
    int real;
    // Конструкторы
    Complex();
    Complex(int imaginary);
    Complex(int imaginary, int real);
    Complex(const Complex& c);

    //Перегрузка операторов
    // +
    const Complex operator+(const Complex& item) const;  
    const Complex operator+(const int& value) const;  
    friend const Complex operator+(const int& value, const Complex& item);

    // -
    const Complex operator-(const Complex& item) const;
    const Complex operator-(const int& value) const;
    friend const Complex operator-(const int& value, const Complex& item);

    // +=
    Complex& operator+=(const Complex& item);
    Complex& operator+=(const int& value);

    // -=
    Complex& operator-=(const Complex& item);
    Complex& operator-=(const int& value);

    // =
    Complex& operator=(const Complex& item);
    Complex& operator=(const int& value);

    // extract_real
    int extract_real();

    // <<
    friend ostream& operator<<(ostream& os, const Complex& item);
};




