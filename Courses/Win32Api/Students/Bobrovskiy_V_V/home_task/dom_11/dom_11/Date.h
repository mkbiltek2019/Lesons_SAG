#pragma once 
#include "iostream"
#include "atltime.h"
class CDate
{
private:
	int day;
	int month;
	int year;
public:
	enum mon{jan=1,feb,mar,apr,may,jun,jul,aug,sep,oct,nov,dec=12};
	explicit CDate(int = 1, int = 1, int = 1);
	//-------
	void set_current_date();
	void SetDay(int d);
	void SetMonth(int m);
	void SetYear(int y);
	int GetDay() const;
	int GetMonth() const;
	int GetYear() const;
	//------
	CDate & operator = (const CDate & d);
    //------
	CDate operator + (CDate d);
	CDate operator + (int d);
	CDate operator ++(int i);//postfix
	CDate operator ++ ();//prefix
	CDate operator - (int d);
	CDate operator -- ();// prefix
	CDate operator -- (int i); //postfix
	CDate& add_day(int n);
	CDate& add_month(int n);
	CDate& add_year(int n);
	//-------------------------
	CDate operator += (CDate d);
	CDate operator += (int d);
	//---------------------
	operator int();
	operator double();	
	operator char*();
	//--------	
private:
	CDate check_set(int d,int m, int y);
	int maxm(int m);
};