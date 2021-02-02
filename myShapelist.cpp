#include "myShapelist.h"
myShapelist::myShapelist()
{
	this->head = 0;
}
myShapelist::~myShapelist()
{
	if (this->head != 0)
	{
		element* node = this->head;
		while (node->next != 0)
		{
			node = node->next;
		}
		while (node != head)
		{
			delete node->val;
			node = node->prew;
			delete node->next;
		}
		delete node;
		this->end = true;
	}
}
void myShapelist::Insert(Shape *val)
{
	element* node = this->head;
	element* prewnode = this->head;
	element* newelement = new element;
	newelement->val = val;
	newelement->next = 0;
	newelement->prew = 0;
	if (node == 0)
	{
		this->head = newelement;
		this->end = false;
		this->curent = head;
	}
	else if (node->next == 0)
	{
		this->head->next = newelement;
		newelement->prew = this->head;
	}
	else
	{
		while (node->next != 0)
		{
			prewnode = node;
			node = node->next;
		}
			node->next = newelement;
			newelement->prew = node;
	}
}
void myShapelist::Clear()
{
	if (this->head != 0)
	{
		element* node = this->head;
		while (node->next != 0)
		{
			node = node->next;
		}
		while (node != head)
		{
			node = node->prew;
			delete node->next;
		}
		delete node;
		this->head = 0;
		this->end = true;
	}
}
Shape* myShapelist::Extract()
{
	return this->curent->val;
};
void  myShapelist::Next()
{
	if(this->curent->next!=0)
	this->curent = curent->next;
	else
		this->end = true;
}
void  myShapelist::Prew()
{
	if (this->curent != this->head)
		this->curent = curent->prew;
}
bool  myShapelist::is_end()
{
	return this->end;
}
void  myShapelist::Start()
{
	this->curent = this->head;
	if(head!=0)
		this->end = false;
}
void  myShapelist::DeleteCurent()
{
	element* node = this->head;
	if (node->next == 0)
	{
		delete node;
		this->head = 0;
		this->end = true;
	}
	else
	{
		while (node->next != 0)
		{
			node = node->next;
			if (node == this->curent)
				break;
		}
		Prew();
		this->curent->val->ChangeActive();
		node->prew->next = node->next;
		if(node->next!=0)
			node->next->prew = node->prew;
		delete node;
	}
}