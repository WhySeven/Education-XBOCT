#include <iostream>
#include <sstream>
using namespace std;

class Point
{
private:
public:
	int x;
	int y;
	Point()
	{
		x = 0;
		y = 0;
	}
	Point(int x, int y)
	{
		this->x = x;
		this->y = y;
	}
	Point(const Point &p)
	{
		x = p.x;
		y = p.y;
	}
	Point& operator=(Point p)
	{
		x = p.x;
		y = p.y;
		return *this;
	}
	Point operator+(Point p)
	{
		return Point(x + p.x, y+p.y);
	}
	Point Move(int x, int y)
	{
		return Point(this->x + x,this->y + y);
	}
	friend ostream& operator<<(ostream& str, Point p)
	{
		str << "x = " << p.x << "; y = " << p.y << ";\n";
		return str;
	}
};
void Print(Point p)
{
	std::cout << "x = " << p.x << "; y = " << p.y<<";\n";
}
