#pragma once
#include "MyGraphik.h"
using namespace std;
class myShapelist
{
	struct element
	{
		Shape *val;
		element* next;
		element* prew;
	};
	element* head;
	element* curent;
	bool end = true;
public:
	myShapelist();
	~myShapelist();
	void Insert(Shape* val);
	Shape* Extract();
	void Clear();
	void Next();
	void Prew();
	void DeleteCurent();
	bool is_end();
	void Start();
};