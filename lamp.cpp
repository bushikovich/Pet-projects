#include "lamp.h"
lamp::lamp(int power)
{
	this->power = power;
	this->on = false;
	this->crashed = false;
}
lamp::lamp()
{
	this->power = 0;
	this->on = false;
	this->crashed = false;
}
void lamp::change_lamp(int power)
{
	this->power = power;
	this->on = false;
	this->crashed = false;
}
void lamp::on_off()
{
	if (!this->on)
		this->on = true;
	else
		this->on = false;
}
bool lamp::is_crashed()
{
	return this->crashed;
}
bool lamp::is_on()
{
	return this->on;
}
int lamp::get_power()
{
	return this->power;
}