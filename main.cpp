#include "Agregat.h"
#include <conio.h>
void Help()
{
	system("cls");
	cout << "Create new object - 1" << endl;
	cout << "Delete selected - 2" << endl;
	cout << "Choose next - Tab" << endl;
	cout << "Choose prew - Ctrl + Tab" << endl;
	cout << "Move/Stop object - Q" << endl;
	cout << "Hide selected - A" << endl;
	cout << "Show selected - S" << endl;
	cout << "Change color - R" << endl;
	cout << "Agragate all - Space" << endl;
	cout << "Exit to Menu - Esc" << endl;
	system("pause");
	system("cls");
}
void ChangeColor(myShapelist& list)
{
	Shape* a;
	while (!list.is_end())
	{
		a = list.Extract();
		if (a->is_active())
		{
			a->ChangeStyle();
			break;
		}
		list.Next();
	}
	list.Start();
}
void ChangeMove(myShapelist& list)
{
	Shape* a;
	while (!list.is_end())
	{
		a = list.Extract();
		if (a->is_active())
		{
			a->ChangeMove();
			break;
		}
		list.Next();
	}
	list.Start();
}
void Hyde(myShapelist& list)
{
	Shape* a;
	while (!list.is_end())
	{
		a = list.Extract();
		if (a->is_active())
		{
			a->Disappear();
			break;
		}
		list.Next();
	}
	list.Start();
}
void Show(myShapelist& list)
{
	Shape* a;
	while (!list.is_end())
	{
		a = list.Extract();
		if (a->is_active())
		{
			a->Appear();
			break;
		}
		list.Next();
	}
	list.Start();
}
void Move(myShapelist& list)
{
	Shape* a;
	while (!list.is_end())
	{
		a = list.Extract();
		if (a->is_move())
		{
			a->Move(1, a->Order(1));
		}
		list.Next();
	}
	list.Start();
}
void ActiveNext(myShapelist& list)
{
	Shape* a;
	while (!list.is_end())
	{
		a = list.Extract();
		if (a->is_active())
		{
			a->ChangeActive();
			list.Next();
			a = list.Extract();
			a->ChangeActive();
			break;
		}
		list.Next();
	}
	list.Start();
}
void ActivePrew(myShapelist& list)
{
	Shape* a;
	while (!list.is_end())
	{
		a = list.Extract();
		if (a->is_active())
		{
			a->ChangeActive();
			list.Prew();
			a = list.Extract();
			a->ChangeActive();
			break;
		}
		list.Next();
	}
	list.Start();
}
void Delete(myShapelist& list)
{
	Shape* a;
	while (!list.is_end())
	{
		a = list.Extract();
		if (a->is_active())
		{
			list.DeleteCurent();
			break;
		}
		list.Next();
	}
	list.Start();
}
void AgregatAll(myShapelist& list)
{
	Agregat* a = new Agregat(250, 150, 0, list);
	list.Clear();
	list.Insert(a);
}
void CheckTouch(myShapelist& list)
{
	Shape* a; int n = 0;
	while (!list.is_end())
	{
		a = list.Extract();
		list.Next();
		while (!list.is_end())
		{
			bool b = Intersection(a->GetZone(), list.Extract()->GetZone());
			if (b)
			{
				a->SetTouch(true);
				list.Extract()->SetTouch(true);
			}
			list.Next();
		}
		list.Start();
		n++;
		for (int i = 0; i < n; i++)
			list.Next();
	}
	list.Start();
}
void Create(myShapelist& list)
{
	int type, x, y, x2, y2, x3, y3, r, red, green, blue;
	system("cls");
	cout << "1.Point" << endl;
	cout << "2.Line" << endl;
	cout << "3.Treangle" << endl;
	cout << "4.Rectangle" << endl;
	cout << "5.Circle" << endl;
	cout << "Enter your number : ";
	cin >> type;
	switch (type)
	{
	case 1:
	{
		cout << "x = "; cin >> x;
		cout << "y = "; cin >> y;
		cout << "Wrote number between 0 and 255 of quantity:" << endl;
		cout << "red color = "; cin >> red;
		cout << "green color = "; cin >> green;
		cout << "blue color = "; cin >> blue;
		Point* a = new Point(x, y, RGB(red, green, blue));
		list.Insert(a);
		break;
	}
	case 2:
	{
		cout << "x1 = "; cin >> x;
		cout << "y1 = "; cin >> y;
		cout << "x2 = "; cin >> x2;
		cout << "y2 = "; cin >> y2;
		cout << "Wrote number between 0 and 255 of quantity:" << endl;
		cout << "red color = "; cin >> red;
		cout << "green color = "; cin >> green;
		cout << "blue color = "; cin >> blue;
		Line* a = new Line(x, y, x2, y2, RGB(red, green, blue));
		list.Insert(a);
		break;
	}
	case 3:
	{
		cout << "x1 = "; cin >> x;
		cout << "y1 = "; cin >> y;
		cout << "x2 = "; cin >> x2;
		cout << "y2 = "; cin >> y2;
		cout << "x3 = "; cin >> x3;
		cout << "y3 = "; cin >> y3;
		cout << "Wrote number between 0 and 255 of quantity:" << endl;
		cout << "red color = "; cin >> red;
		cout << "green color = "; cin >> green;
		cout << "blue color = "; cin >> blue;
		Treangle* a = new Treangle(x, y, x2, y2, x3, y3, RGB(red, green, blue));
		list.Insert(a);
		break;
	}
	case 4:
	{
		cout << "x1 = "; cin >> x;
		cout << "y1 = "; cin >> y;
		cout << "x2 = "; cin >> x2;
		cout << "y2 = "; cin >> y2;
		cout << "Wrote number between 0 and 255 of quantity:" << endl;
		cout << "red color = "; cin >> red;
		cout << "green color = "; cin >> green;
		cout << "blue color = "; cin >> blue;
		Rectangl* a = new Rectangl(x, y, x2, y2, RGB(red, green, blue));
		list.Insert(a);
		break;
	}
	case 5:
	{
		cout << "x = "; cin >> x;
		cout << "y = "; cin >> y;
		cout << "radius = "; cin >> r;
		cout << "Wrote number between 0 and 255 of quantity:" << endl;
		cout << "red color = "; cin >> red;
		cout << "green color = "; cin >> green;
		cout << "blue color = "; cin >> blue;
		Circle* a = new Circle(x, y, r, RGB(red, green, blue));
		list.Insert(a);
		break;
	}
	default:
		cout << "You done misstake!!!" << endl;
		system("pause");
		break;
	}
}
void Clear()
{
	HWND hwnd = GetConsoleWindow();
	HDC hdc = GetDC(hwnd);
	RECT clientRect;
	GetClientRect(hwnd, &clientRect);
	FillRect(hdc, &clientRect, CreateSolidBrush(RGB(0, 0, 0)));
	ReleaseDC(NULL, hdc);
	system("cls");
}
void Paint(myShapelist& list)
{
	Shape* a;
	while (!list.is_end())
	{
		a = list.Extract();
		if (a->is_visible())
			a->Appear();
		else if (a->is_active())
			cout << "Selected object invisible";
		a->SetTouch(false);
		list.Next();
	}
	list.Start();
}
void Screen(myShapelist& list)
{
	int choose;
	do
	{
		while (!_kbhit())
		{
			if (list.is_end())
			{
				cout << "Haven`t objects!!!";
				break;
			}
			else
			{
				CheckTouch(list);
				Paint(list);
				Sleep(50);
				Clear();
				Move(list);
			}
		}
		choose = _getch();
		switch (choose)
		{
		case 59:
		{
			Help();
			break;
		}
		case 9:
		{
			ActiveNext(list);
			break;
		}
		case 148:
		{
			ActivePrew(list);
			break;
		}
		case 114:
		{
			ChangeColor(list);
			break;
		}
		case 97:
		{
			Hyde(list);
			break;
		}
		case 115:
		{
			Show(list);
			break;
		}
		case 113:
		{
			ChangeMove(list);
			break;
		}
		case 50:
		{
			Delete(list);
			break;
		}
		case 49:
		{
			Create(list);
			break;
		}
		case 32:
		{
			AgregatAll(list);
			break;
		}
		default:
			break;
		}
	} 
	while (choose != 27);
}
void Type(ifstream& fin, myShapelist& list)
{
	int type, x, y, x2, y2, x3, y3, r, color, n; myShapelist l2;
	fin >> type;
	switch (type)
	{
	case 1:
	{
		fin >> x >> y >> color;
		Point* a = new Point(x, y, color);
		list.Insert(a);
		break;
	}
	case 2:
	{
		fin >> x >> y >> x2 >> y2 >> color;
		Line* a = new Line(x, y, x2, y2, color);
		list.Insert(a);
		break;
	}
	case 3:
	{
		fin >> x >> y >> x2 >> y2 >> x3 >> y3 >> color;
		Treangle* a = new Treangle(x, y, x2, y2, x3, y3, color);
		list.Insert(a);
		break;
	}
	case 4:
	{
		fin >> x >> y >> x2 >> y2 >> color;
		Rectangl* a = new Rectangl(x, y, x2, y2, color);
		list.Insert(a);
		break;
	}
	case 5:
	{
		fin >> x >> y >> r >> color;
		Circle* a = new Circle(x, y, r, color);
		list.Insert(a);
		break;
	}
	case 6:
	{
		fin >> n >> x >> y >> color;
		for (int i = 0; i < n; i++)
			Type(fin, l2);
		Agregat* a = new Agregat(x, y, color, l2);
		list.Insert(a);
	}
	default:
			break;
	}
}
myShapelist& LoadConfig(string configfile, myShapelist& list)
{
	ifstream fin;
	system("cls");
	if (list.is_end())
	{
		fin.open(configfile);
		if (!fin.is_open())
		{
			cout << "Can`t open configfile!!!" << endl;
			system("pause");
			exit(1);
		}
		else
		{
			while (!fin.eof())
			{
				Type(fin, list);
			}
			list.Extract()->ChangeActive();
			cout << "Config download" << endl;
			system("Pause");
		}
	}
	return list;
}
void SaveConfig( myShapelist &list)
{
	Shape* a; 
	string configfile;
	ofstream fout;
	system("cls");
	if(list.is_end())
	{
		cout << "List is empty" << endl;
		system("Pause");
	}
	else
	{
		cout << "Wrote name configfile "; cin >> configfile;
		fout.open(configfile);
		while (!list.is_end())
		{
			a = list.Extract()->Create();
			a = list.Extract();
			a->Save(fout);
			list.Next();
		}
		list.Start();
		system("cls");
		cout << "Config saved" << endl;
		system("Pause");
	}
}
void Menu(string configfile, myShapelist& list)
{
	char choose;
	do
	{
		system("cls");
		cout << "1.Start" << endl;
		cout << "2.Save" << endl;
		cout << "0.Exit" << endl;
		cout << "Enter your number : ";
		cin >> choose;
		switch (choose)
		{
		case '1': 
		{
			list=LoadConfig(configfile,list);
			system("cls");
			Screen(list);
			break;
		}
		case '2':
		{
			SaveConfig(list);
			break;
		}
		case '0':
		{
			exit(0);
			break;
		}
		default:
		{
			cout << "You done misstake!!!" << endl;
			system("pause");
			break;
		}
		}
	} 
	while (choose != 0);
}
int main(int argc, char *argv[])
{
	string configfile; myShapelist* list = new myShapelist;
	HANDLE wHnd = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleTitle(L"OOP3");
	SMALL_RECT windowSize = { 0,0,800,600};
	SetConsoleWindowInfo(wHnd, TRUE, &windowSize);
	if (argc < 2)
	{
		cout << "Wrote name configfile "; cin >> configfile;
	}
	else
		configfile = argv[1];
	Menu(configfile,*list);
	return 0;
}