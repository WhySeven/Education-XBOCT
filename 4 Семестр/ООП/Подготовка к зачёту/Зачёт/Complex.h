#include <iostream>
using namespace std;
class Complex
{
private:
    int imaginary;
    int real;
public:
    Complex()
    {
        this-> imaginary = 0;
        this-> real = 0;
    }
    Complex(int imaginary)
    {
        this->imaginary = imaginary;
        real = 0;
    }
    Complex(int imaginary, int real)
    {
        this->imaginary = imaginary;
        this->real = real;
    }
    //Перегрузка операторов
    // +
    Complex operator+(Complex item) 
    {
        return Complex(imaginary + item.imaginary, real + item.real);
    }
    Complex operator+(int value)
    {
        return Complex(imaginary, real + value);
    }
    friend Complex operator+(int value, Complex item)
    {
        return Complex(item.imaginary, item.real + value);
    }

   
    // -
    Complex operator-(Complex item)
    {
        return Complex(imaginary - item.imaginary, real - item.real);
    }
    Complex operator-(int value)
    {
        return Complex(imaginary, real - value);
    }
    friend Complex operator-(int value, Complex item)
    {
        return Complex(item.imaginary, item.real - value);
    }


    // +=
    Complex& operator+=(Complex item) 
    {
        real += item.real;
        imaginary += item.imaginary;
        return *this;
    }
    Complex& operator+=(int value)
    {
        real += value;
        return *this;
    }
    friend int operator+=(int& value, Complex item)
    {
        value += item.real;
        std::cout << "The imaginary part has been lost due to assigning of a complex number to real.\n";
        return value;
    }
    // -=
    Complex& operator-=(Complex item) 
    {
        real -= item.real;
        imaginary -= item.imaginary;
        return *this;
    }
    Complex& operator-=(int value)
    {
        real -= value;
        return *this;
    }
    friend int operator-=(int& value, Complex item)
    {
        value -= item.real;
        std::cout << "The imaginary part has been lost due to assigning of a complex number to real.\n";
        return value;
    }

    // =
    Complex& operator=(Complex item) {
        real = item.real;
        imaginary = item.imaginary;
        return *this;
    }
    Complex& operator=(int value) 
    {
        real = value;
        imaginary = 0;
        return *this;
    }
    /*int& operator=(Complex& item)
    {
        std::cout << "The imaginary part has been lost due to assigning of a complex number to real.\n";
        return item.real;
    }*/
    int extract_real()
    {
        return real;
    }
    // <<
    friend ostream& operator<<(ostream& str, Complex item)
    {
        str << "imaginary = " << item.imaginary << ", real=" << item.real<<";\n";
        return str;
    }
};




