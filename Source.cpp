#include <iostream>
#define N 1
#if N==1
#include "myVector.h"
#else
#include <vector>
#include "lamp.h"
#endif
using namespace std;
void off_all(vector<lamp>& lighters)
{
    for (int i = 0; i < lighters.size(); i++)
        if (lighters[i].is_on())
            lighters[i].on_off();
}
void set_lighters(vector<lamp>& lighters, int count, int power)
{
    for (int i = 0; i < count; i++)
        lighters.push_back(lamp(power));
}
void show(vector<lamp>& lighters)
{
    for (int i=0; i<lighters.size();i++)
        if (lighters[i].is_on())
            cout << "* ";
        else cout << "o ";
    cout << endl;
}
void set_half_power(vector<lamp>& lighters)
{
    int full_power = 0;
    for (auto iter = lighters.begin(); iter != lighters.end(); iter++)
        full_power += iter->get_power();
    full_power /= lighters.size();
    off_all(lighters);
    for (auto iter = lighters.begin(); iter != lighters.end(); iter++)
        if (iter->get_power() <= full_power)
            iter->on_off();
}
int main() 
{
    setlocale(LC_ALL, "Russian");
    vector<lamp> street_lighters;
    set_lighters(street_lighters, 1, 50);
    set_lighters(street_lighters, 1, 100);
    set_lighters(street_lighters, 1, 50);
    set_lighters(street_lighters, 1, 100);
    set_lighters(street_lighters, 1, 50);
    show(street_lighters);
    set_half_power(street_lighters);
    show(street_lighters);
    cout << endl;
    vector<lamp> house_lighters(street_lighters);
    house_lighters.pop_back();
    set_lighters(house_lighters, 1, 65);
    set_lighters(house_lighters, 1, 80);
    off_all(house_lighters);
    show(house_lighters);
    set_half_power(house_lighters);
    show(house_lighters);
    cout << endl;
    set_lighters(house_lighters, 1, 1000);
    off_all(house_lighters);
    show(house_lighters);
    set_half_power(house_lighters);
    show(house_lighters);
    cout << endl;
    house_lighters.pop_back();
    house_lighters.insert(house_lighters.begin() + 2, 2, lamp(50));
    off_all(house_lighters);
    show(house_lighters);
    set_half_power(house_lighters);
    show(house_lighters);
}