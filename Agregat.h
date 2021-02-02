#pragma once
#include "MyGraphik.h"
#include "myShapelist.h"
class Agregat :public Shape
{
protected:
	myShapelist list;
	int n=0;
public:
	Agregat(int x, int y, int color, myShapelist &list);
	~Agregat() override;
	void Move(int dx, int dy) override;
	void Appear() override;
	void Disappear();
	int Order(int dx);
	void ChangeStyle();
	void ChangeActive();
	void SetTouch(bool touch);
	Zone GetZone() override;
	void Save(ostream& fout) override;
	Shape* Create() override;
	void Draw(HPEN Pen) override;
};