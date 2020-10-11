#include <cmath>
#include <sstream>  
using namespace std;

class Rectangle : Point
{
private:
	Point p1;
	Point p2;
public:
	Rectangle()
	{
		p1 = Point();
		p2 = Point();
	}
	Rectangle(Point p1, Point p2)
	{
		this->p1 = p1;
		this->p2 = p2;
	}
	Rectangle(const Rectangle& rect)
	{
		p1 = rect.p1;
		p2 = rect.p2;
	}
	Rectangle(Point p1, int x2, int y2)//Конструктор с рынка
	{
		this->p1 = p1;
		p2 = Point(x2, y2);
	}
	Rectangle operator=(Rectangle rect)
	{
		p1 = rect.p1;
		p2 = rect.p2;
		return *this;
	}
	friend ostream& operator<<(ostream& str, Rectangle rect)
	{
		str << "p1: " << rect.p1 << "p2: " << rect.p2;
		return str;
	}
	int Square()
	{
		return abs(p1.x - p2.x) * abs(p1.y - p2.y);
	}


	Rectangle Move(int x, int y)
	{
		p1.x += x;
		p2.x += x;
		p1.y += y;
		p2.y += y;
		return Rectangle(Point(p1.x + x, p1.y + y), Point(p2.x + x, p2.y + y));
	}

	
};
string Square(Rectangle rect)
{
	return to_string(rect.Square());
}