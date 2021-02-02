#pragma once
#include "lamp.h"
template <class lamp>
class vector
{
	lamp* data;
	int size_ = 0;
public:
	class iterator
	{
	public:
		lamp* p;
		iterator(lamp* value)
		{
			this->p = value;
		};
		bool operator !=(const iterator a)
		{
			if (this->p != a.p)
				return true;
			return false;
		};
		bool operator ==(const iterator a)
		{
			return this->p == a.p;
		};
		iterator operator ++()
		{
			iterator i = *this; 
			p++; 
			return i;
		};
		iterator operator++(int junk) 
		{ 
			this->p++; 
			return *this; 
		}
		lamp& operator*()
		{
			return *this->p;
		};
		lamp* operator->()
		{
			return this->p;
		};
		iterator operator+(int a)
		{
			this->p += a;
			return *this;
		};
	};
	vector(){};
	vector(vector<lamp>& a)
	{
		this->size_ = a.size();
		this->data = new lamp[this->size_ + 1];
		for (int i = 0; i < this->size_; i++)
			this->data[i] = a[i];
	};
	vector(int count, lamp a)
	{
		this->size_ = count;
		this->data = new lamp[count + 1];
		for (int i = 0; i < count; i++)
			this->data[i] = a;
	};
	void push_back(lamp value)
	{
		if(this->size_==0)
		{
			this->size_++;
			this->data = new lamp[2];
			this->data[0] = value;
		}
		else
		{
			lamp* newData = new lamp[this->size_+2];
			for (int i = 0; i < this->size_+1; i++)
				newData[i] = data[i];
			delete this->data;
			this->data = newData;
			this->data[this->size_] = value;
			this->size_++;
		}
	};
	void pop_back()
	{
		if (this->size_ == 1)
		{
			delete this->data;
			this->size_ = 0;
		}
		else if (this->size_ > 1)
		{
			lamp* newData = new lamp[this->size_];
			for (int i = 0; i < this->size_ -1; i++)
				newData[i] = data[i];
			delete this->data;
			this->data = newData;
			this->size_--;
		}
	}
	void insert(iterator iter, int count, lamp a)
	{
		int i = 0;
		for (iterator it = this->begin(); it != this->end(); it++)
		{
			if (it == iter)
				break;
			i++;
		}
		if (i < this->size_)
		{
			lamp* newData = new lamp[this->size_ + count + 1];
			for (int j = 0; j <= i; j++)
				newData[j] = this->data[j];
			for (int j = i; j <= i + count; j++)
				newData[j] = a;
			this->size_ += count;
			for (int j = i + count; j < this->size_; j++)
				newData[j] = data[j - count];
			delete this->data;
			this->data = newData;
		}
	}
	iterator begin()
	{
		return iterator(this->data);
	};
	iterator end()
	{
		return iterator((this->data + this->size_));
	};
	int size()
	{
		return this->size_;
	};
	lamp& operator[](int index)
	{
		if (index < this->size_)
			return this->data[index];
	};
};