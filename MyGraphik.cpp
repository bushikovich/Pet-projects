#include "MyGraphik.h"
Shape::Shape(int x, int y, int color)
{
	this->x = x;
	this->y = y;
	this->color = color;
}
Shape::Shape()
{
	this->x = 0;
	this->y = 0;
	this->color = RGB(0, 0, 0);
}
Shape::~Shape()
{
}
void Shape::Move(int dx, int dy)
{
	this->x += dx;
	this->y += dy;
}
void Shape::SetColor(int color)
{
	this->color = color;
	if (visible == true)
		Appear();
}
void Shape::Appear()
{
	Draw(Pen());
	visible = true;
}
void Shape::Disappear()
{
	int c = this->color;
	SetColor(RGB(0, 0, 0));
	this->color = c;
	visible = false;
}
bool Shape::is_visible()
{
	return this->visible;
}
bool Shape::is_active()
{
	return this->active;
}
bool Shape::is_move()
{
	return this->move;
}
void Shape::ChangeMove()
{
	if (this->move == false)
	{
		this->move = true;
	}
	else
	{
		this->move = false;
	}
}
void Shape::ChangeActive()
{
	if (this->active == false)
		this->active = true;
	else
		this->active = false;
}
void Shape::ChangeStyle()
{
	switch (this->style)
	{
	case 1: 
	{
		this->SetColor(RGB(250, 0, 0));
		break;
	}
	case 2:
	{
		this->SetColor(RGB(0, 250, 0));
		break; 
	}
	case 3:
	{
		this->SetColor(RGB(0, 0, 250));
		break;
	}
	case 4:
	{
		this->SetColor(RGB(250, 250, 250));
		break;
	}
	case 5:
	{
		this->SetColor(RGB(200, 0, 200));
		break;
	}
	default:
		break;
	}
	if (this->style == 5)
		this->style = 1;
	else this->style++;
}
void Shape::Save(ostream &fout)
{
}
void Shape::SetTouch(bool touch)
{
	this->touch = touch;
}
bool Shape::is_touch()
{
	return this->touch;
}
HPEN Shape::Pen()
{
	int a = 1, c = this->color;
	if (touch)
	{
		a = 2;
		c = RGB(200, 100, 0);
	}
	if (active)
		a = 4;
	HPEN Pen = CreatePen(PS_SOLID, a, c);
	return Pen;
}
int Shape::Get_x()
{
	return this->x;
}
int Shape::Get_y()
{
	return this->y;
}
void Point::Draw(HPEN Pen)
{
	HDC hdc = GetDC(GetConsoleWindow());
	SelectObject(hdc, Pen);
	Arc(hdc, this->x-1, this->y-1, this->x+1, this->y+1, 0, 0, 0, 0);
	DeleteObject(Pen);
	ReleaseDC(NULL, hdc);
}
Point::Point(int x, int y, int color) :Shape(x, y, color)
{
}
Point::~Point()
{
}
Zone Point::GetZone()
{
	zone.x1 = zone.x2 = this->x;
	zone.y1 = zone.y2 = this->y;
	return zone;
}
void Point::Save(ostream &fout)
{
	fout << "1 " << this->x << " " << this->y << " " << this->color << endl;
}
void Point::Move(int dx, int dy)
{
	this->x += dx;
	this->y += dy;
}
int Point::Order(int dx)
{
	if (this->x > 500)
	{
		this->x = 0;
	}
	if (this->x < 0)
	{
		this->x = 500;
	}
	if (this->y > 300)
	{
		this->y = 0;
	}
	if (this->y < 0)
	{
		this->y = 300;
	}
	return 30*sin(this->x);
}
Shape* Point::Create()
{
	return new Point(0,0,0);
}
void Line::Draw(HPEN Pen)
{
	HDC hdc = GetDC(GetConsoleWindow());
	SelectObject(hdc, Pen);
	MoveToEx(hdc, this->x, this->y, NULL);
	LineTo(hdc, this->x2, this->y2);
	DeleteObject(Pen);
	ReleaseDC(NULL, hdc);
}
Line::Line(int x,int y,int x2,int y2,int color):Shape(x,y,color)
{
	this->x2 = x2;
	this->y2 = y2;
}
Line::~Line()
{
}
void Line::Move(int dx, int dy)
{
	this->x += dx;
	this->y += dy;
	this->x2 += dx;
	this->y2 += dy;
}
Zone Line::GetZone()
{
	zone.x1 = min(x, x2);
	zone.y1 = min(y, y2);
	zone.x2 = max(x, x2);
	zone.y2 = max(y, y2);
	return zone;
}
void Line::Save(ostream &fout)
{
	fout << "2 " << this->x << " " << this->y << " " << this->x2 << " " << this->y2 << " " << this->color << endl;
}
int Line::Order(int dx)
{
	int hight = this->y2 - this->y, weidght = this->x2 - this->x;
	if (this->x > 500)
	{
		this->x = -weidght;
		this->x2 = 0;
	}
	if (this->x2 < 0)
	{
		this->x = 500;
		this->x2 = 500 + weidght;
	}
	if (this->y > 300)
	{
		this->y = -hight;
		this->y2 = 0;
	}
	if (this->y2 < 0)
	{
		this->y = 300;
		this->y2 = 300 + hight;
	}
	return dx * dx * 5;
}
Shape* Line::Create()
{
	return new Line(0, 0, 0, 0, 0);
}
void Treangle::Draw(HPEN Pen)
{
	HDC hdc = GetDC(GetConsoleWindow());
	SelectObject(hdc, Pen);
	MoveToEx(hdc, this->x, this->y, NULL);
	LineTo(hdc, this->x2, this->y2);
	LineTo(hdc, this->x3, this->y3);
	LineTo(hdc, this->x, this->y);
	DeleteObject(Pen);
	ReleaseDC(NULL, hdc);
}
Treangle::Treangle(int x, int y, int x2, int y2, int x3, int y3, int color):Line(x, y, x2, y2, color)
{
	this->x3 = x3;
	this->y3 = y3;
}
Treangle::~Treangle()
{
}
void Treangle::Move(int dx, int dy)
{
	this->x3 += dx;
	this->y3 += dy; 
	Line::Move(dx, dy);
}
Zone Treangle::GetZone()
{
	zone.x1 = min(x, x2, x3);
	zone.y1 = min(y, y2, y3);
	zone.x2 = max(x, x2, x3);
	zone.y2 = max(y, y2, y3);
	return zone;
}
void Treangle::Save(ostream &fout)
{
	fout << "3 " << this->x << " " << this->y << " " << this->x2 << " " << this->y2 << " " << this->x3 << " " << this->y3 << " " << this->color << endl;
}
int Treangle::Order(int dx)
{
	int l1 = this->x2 - this->x; int l2 = this->x2 - this->x3; int l3 = this->x - this->x3;
	int r1 = this->y2 - this->y; int r2 = this->x2 - this->y3; int r3 = this->y - this->y3;
	if (min(x,x2,x3) > 500)
	{
		if((x>x2)&&(x>x3))
		{
			this->x = 0;
			this->x2 = l1;
			this->x3 = l3;
		}
		else if((x2>x)&&(x2>x3))
		{
			this->x2 = 0;
			this->x = -l1;
			this->x3 = -l2;
		}
		else
		{
			this->x3 = 0;
			this->x = l3;
			this->x2 = l2;
		}
	}
	if (max(x,x2,x3) < 0)
	{
		if ((x < x2) && (x < x3))
		{
			this->x = 500;
			this->x2 = 500+l1;
			this->x3 = 500-l3;
		}
		else if ((x2 < x) && (x2 < x3))
		{
			this->x2 = 500;
			this->x = 500-l1;
			this->x3 = 500-l2;
		}
		else
		{
			this->x3 = 500;
			this->x = 500+l3;
			this->x2 = 500+l2;
		}
	}
	if (min(y,y2,y3) > 300)
	{
		if ((y > y2) && (y > y3))
		{
			this->y = 0;
			this->y2 = r1;
			this->y3 = r3;
		}
		else if ((y2 > y) && (y2 > y3))
		{ 
			this->y2 = 0;
			this->y = -r1;
			this->y3 = -r2;
		}
		else
		{
			this->y3 = 0;
			this->y = r3;
			this->y2 = r2;
		}
	}
	if (max(y,y2,y3) < 0)
	{
		if ((y < y2) && (y < y3))
		{
			this->y = 300;
			this->y2 = 300+r1;
			this->y3 = 300-r3;
		}
		else if ((y2 < y) && (y2 < y3))
		{
			this->y2 = 300;
			this->y = 300-r1;
			this->y3 = 300-r2;
		}
		else
		{
			this->y3 = 300;
			this->y = 300+r3;
			this->y2 = 300+r2;
		}
	}
	return -5*dx;
}
Shape* Treangle::Create()
{
	return new Treangle(0, 0, 0, 0, 0, 0, 0);
}
void Rectangl::Draw(HPEN Pen)
{
	HDC hdc = GetDC(GetConsoleWindow());
	SelectObject(hdc, Pen);
	MoveToEx(hdc, this->x, this->y, NULL);
	LineTo(hdc, this->x2, this->y);
	LineTo(hdc, this->x2, this->y2);
	LineTo(hdc, this->x, this->y2);
	LineTo(hdc, this->x, this->y);
	DeleteObject(Pen);
	ReleaseDC(NULL, hdc);
}
Rectangl::Rectangl(int x, int y, int x2, int y2, int color):Line(x,y,x2,y2,color)
{

}
Rectangl::~Rectangl()
{
}
void Rectangl::Save(ostream &fout)
{
	fout << "4 " << this->x << " " << this->y << " " << this->x2 << " " << this->y2 << " " << this->color << endl;
}
int Rectangl::Order(int dx)
{
	int hight = this->y2 - this->y, weidght = this->x2 - this->x;
	if (this->x > 500)
	{
		this->x = 0;
		this->x2 = weidght;
	}
	if (this->x2 < 0)
	{
		this->x = 500 - weidght;
		this->x2 = 500;
	}
	if (this->y > 300)
	{
		this->y = -hight;
		this->y2 = 0;
	}
	if (this->y2 < 0)
	{
		this->y = 300;
		this->y2 = 300 + hight;
	}
	return -4*dx;
}
Shape* Rectangl::Create()
{
	return new Rectangl(0, 0, 0, 0, 0);
}
Zone Rectangl::GetZone()
{
	zone.x1 = min(x, x2);
	zone.y1 = min(y, y2);
	zone.x2 = max(x, x2);
	zone.y2 = max(y, y2);
	return zone;
}
void Circle::Draw(HPEN Pen)
{
	int x1 = this->x - r;
	int y1 = this->y - r;
	int x2 = this->x + r;
	int y2 = this->y + r;
	HDC hdc = GetDC(GetConsoleWindow());
	SelectObject(hdc, Pen);
	Arc(hdc, x1, y1, x2, y2, 0, 0, 0, 0);
	DeleteObject(Pen);
	ReleaseDC(NULL, hdc);
}
Circle::Circle(int x, int y, int r, int color) :Point(x, y, color)
{
	this->r = r;
}
Circle::~Circle()
{
}
void Circle::Save(ostream &fout)
{
	fout << "5 " << this->x << " " << this->y << " " << this->r << " " << this->color << endl;
}
int Circle::Order(int dx)
{
	if (x - r > 500)
	{
		this->x = -r;
	}
	if (x + r < 0)
	{
		this->x = 500 + r;
	}
	if (y - r > 300)
	{
		this->y = -r;
	}
	if (y + r < 0)
	{
		this->y = 300 + r;
	}
	return 5;
}
Shape* Circle::Create()
{
	return new Circle(0, 0, 0 ,0);
}
Zone Circle::GetZone()
{
	zone.x1 = x-r;
	zone.y1 = y-r;
	zone.x2 = x+r;
	zone.y2 = y+r;
	return zone;
}
bool Intersection(Zone a, Zone b)
{
	if (a.x1 >= b.x1)
	{
		if (a.x1 <= b.x2)
		{
			if (a.y1 >= b.y1)
			{
				if (a.y1 <= b.y2)
					return true;
			}
			else if (a.y2 >= b.y1)
			{
				return true;
			}
		}
	}
	else if (b.x1 >= a.x1)
	{
		if (b.x1 <= a.x2)
		{
			if (b.y1 >= a.y1)
			{
				if (b.y1 <= a.y2)
					return true;
			}
			else if (b.y2 >= a.y1)
			{
				return true;
			}
		}
	}
	return false;
}