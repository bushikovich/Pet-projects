#pragma once
class lamp
{
protected:
	bool on;
	int power;
public:
	lamp();
	lamp(int);
	void on_off();
	bool is_on();
	bool is_crashed();
	int get_power();
	void change_lamp(int);
	bool crashed;
};

