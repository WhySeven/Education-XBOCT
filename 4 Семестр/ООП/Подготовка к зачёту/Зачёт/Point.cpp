#include "Point.h"
#include <iostream>

using namespace std;

Point::Point()
{
	x = 0;
	y = 0;
}
Point::Point(int x, int y)
{
	this->x = x;
	this->y = y;
}
Point::Point(const Point& p)
{
	x = p.x;
	y = p.y;
}

Point& Point::operator=(const Point& p)
{
	x = p.x;
	y = p.y;
	return *this;
}
const Point Point::operator+(const Point& p) const
{
	return Point(x + p.x, y + p.y);
}
Point Point::Move(int x, int y)
{
	return Point(this->x + x, this->y + y);
}
ostream& operator<<(ostream& os, const Point& p)
{
	return os << "x = " << p.x << "y = " << p.y << ";";
}