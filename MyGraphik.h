#pragma once
#include <fstream>
#include <iostream>
#include <Windows.h>
using namespace std;
struct Zone
{
	int x1;
	int y1;
	int x2;
	int y2;
};
class Shape
{
	virtual void Draw(HPEN Pen) = 0;
protected:
	int x;
	int y;
	int color;
	bool visible;
	bool active = false;
	bool move = false;
	HPEN Pen();
	int style=0;
	Zone zone;
	bool touch=false;
public:
	Shape(int x, int y, int color);
	Shape();
	virtual ~Shape();
	virtual void Move(int dx, int dy);
	virtual void Disappear();
	virtual void Appear();
	void SetColor(int color);
	bool is_visible();
	bool is_active();
	bool is_move();
	virtual void ChangeStyle();
	void ChangeMove();
	virtual void ChangeActive();
	virtual Zone GetZone() = 0;
	bool is_touch();
	void SetTouch(bool touch);
	int Get_x();
	int Get_y();
	virtual Shape* Create() = 0;
	virtual int Order(int dx) = 0;
	virtual void Save(ostream &fout) = 0;
};

class Point : public Shape
{
	void Draw(HPEN Pen) override;
public:
	Point(int x, int y, int color);
	~Point() override;
	int Order(int dx) override;
	void Move(int dx, int dy);
	void Save(ostream &fout) override;
	Zone GetZone() override;
	Shape* Create() override;
};

class Line : public Shape
{
	void Draw(HPEN Pen) override;
protected:
	int x2;
	int y2;
public:
	Line(int x, int y, int x2, int y2, int color);
	~Line() override;
	void Move(int dx, int dy);
	void Save(ostream &fout);
	Zone GetZone() override;
	int Order(int dx) override;
	Shape* Create() override;
};

class Treangle : public Line
{
	void Draw(HPEN Pen) override;
protected:
	int x3;
	int y3;
public:
	Treangle(int x, int y, int x2, int y2, int x3, int y3, int color);
	~Treangle() override;
	void Move(int dx, int dy);
	void Save(ostream &fout) override;
	int Order(int dx) override;
	Zone GetZone() override;
	Shape* Create() override;
};

class Rectangl : public Line
{
	void Draw(HPEN Pen) override;
public:
	Rectangl(int x, int y, int x2, int y2, int color);
	~Rectangl() override;
	void Save(ostream &fout) override;
	int Order(int dx) override;
	Zone GetZone() override;
	Shape* Create() override;
};

class Circle : public Point
{
	void Draw(HPEN Pen) override;
protected:
	int r;
public:
	Circle(int x, int y, int r, int color);
	Circle();
	~Circle() override;
	void Save(ostream &fout) override;
	int Order(int dx) override;
	Zone GetZone() override;
	Shape* Create() override;
};
bool Intersection(Zone a, Zone b);