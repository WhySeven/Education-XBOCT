#include <iostream>
#include <sstream>
using namespace std;

class Point
{
private:
public:
	int x;
	int y;
	Point();
	Point(int x, int y);
	Point(const Point& p);
	Point& operator=(const Point& p);
	const Point operator+(const Point& p) const;
	Point Move(int x, int y);
	friend ostream& operator<<(ostream& os, const Point& p);
};
