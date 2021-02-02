#include "Agregat.h"
Agregat::Agregat(int x, int y, int color, myShapelist& list):Shape(x,y,color)
{
	while (!list.is_end())
	{
		this->list.Insert(list.Extract());
		list.Next();
	}
	list.Start();
	while (!this->list.is_end())
	{
		Shape* a;
		a = this->list.Extract();
		if (!a->is_active())
			a->ChangeActive();
		this->n++;
		this->list.Next();
	}
	this->list.Start();
	this->visible = true;
	this->active = true;
}
Agregat::~Agregat()
{
}
void Agregat::Appear()
{
	this->visible = true;
	while (!this->list.is_end())
	{
		this->list.Extract()->Appear();
		this->list.Next();
	}
	this->list.Start();
}
void Agregat::Disappear()
{
	while (!this->list.is_end())
	{
		this->list.Extract()->Disappear();
		this->list.Next();
	}
	this->list.Start();
	this->visible = false;
}
void Agregat::ChangeActive()
{
	if (this->active == false)
		this->active = true;
	else
		this->active = false;
	while (!this->list.is_end())
	{
		this->list.Extract()->ChangeActive();
		this->list.Next();
	}
	this->list.Start();
}
void Agregat::ChangeStyle()
{
	while (!this->list.is_end())
	{
		this->list.Extract()->ChangeStyle();
		this->list.Next();
	}
	this->list.Start();
}
void Agregat::Move(int dx, int dy)
{
	while (!this->list.is_end())
	{
		this->list.Extract()->Move(dx, dy);
		this->list.Next();
	}
	this->list.Start();
	Shape::Move(dx, dy);
}
int Agregat::Order(int dx)
{
	if (this->x > 750)
	{
		while (!this->list.is_end())
		{
			this->list.Extract()->Move(-(this->x + 250), 0);
			this->list.Next();
		}
		this->list.Start();
		this->x = -250;
	}
	if (this->x  < -250)
	{
		while (!this->list.is_end())
		{
			this->list.Extract()->Move(1000, 0);
			this->list.Next();
		}
		this->list.Start();
		this->x = 750;
	}
	if (this->y  > 450)
	{
		while (!this->list.is_end())
		{
			this->list.Extract()->Move(0, -(this->y + 150));
			this->list.Next();
		}
		this->list.Start();
		this->y = -150;
	}
	if (this->y  < -150)
	{
		while (!this->list.is_end())
		{
			this->list.Extract()->Move(0, (600));
			this->list.Next();
		}
		this->list.Start();
		this->y = 450;
	}
	return (this->x-250)/20;
}
void Agregat::Save(ostream& fout)
{
	fout << "6 " << this->n << " " << this->x << " " << this->y << " " << this->color << endl;
	for (int i = 0; i < n; i++)
	{
		this->list.Extract()->Save(fout);
		this->list.Next();
	}
	this->list.Start();
}
Shape* Agregat::Create()
{
	return new Agregat(0, 0, 0, list);
}
void Agregat::Draw(HPEN Pen)
{}
Zone Agregat::GetZone()
{
	Zone a=list.Extract()->GetZone();
	while (!list.is_end())
	{
		if (list.Extract()->GetZone().x1 < a.x1)
			a.x1 = list.Extract()->GetZone().x1;
		if (list.Extract()->GetZone().y1 < a.y1)
			a.y1 = list.Extract()->GetZone().y1;
		if (list.Extract()->GetZone().x2 > a.x2)
			a.x2 = list.Extract()->GetZone().x2;
		if (list.Extract()->GetZone().y2 > a.y2)
			a.y2 = list.Extract()->GetZone().y2;
		list.Next();
	}
	list.Start();
	return a;
}
void Agregat::SetTouch(bool touch)
{
	while (!list.is_end())
	{
		list.Extract()->SetTouch(touch);
		list.Next();
	}
	list.Start();
}