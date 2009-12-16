#include "Date.h"
//----------------------
void CDate::set_current_date(){
// the data must be not later then current day
		//get current date -- use atltime.h
		time_t osBinaryTime;  
		time(&osBinaryTime);
		CTime curtime(osBinaryTime);
		//------------------
		this->year=curtime.GetYear();
		this->month=curtime.GetMonth();
		this->day=curtime.GetDay();			
};
//----------------------
int CDate::maxm(int m)
{
	int max=0;
	 switch (m){
		case (int)feb:
			max=28;//here can be added function for leap year
			break;
		case (int)apr: case (int)jun: case (int)sep: case (int)nov:
			max=30;
			break;
		case (int)jan: case (int)mar: case (int)may: case (int)jul: case (int)aug: case (int)oct: case (int)dec:
			max=31;
			break;						
	  };
	return max;
};
//----
CDate CDate::check_set(int d,int m, int y){
	//---------day of month and mothth of year check -----------------
	int max=maxm(m);
	//------------
	if((m>=jan)||(m<=dec)){
	if((d<1)||(max<d)){
		this->day=1;
		this->month=1;
		this->year=1;		
	}else{ 
		this->day=d;
		this->month=m;
		this->year=y;		
	};
	}else{
		this->day=1;
		this->month=1;
		this->year=1;
	}
	//----------
	return *this;
};
//---
void CDate::SetDay(int d)
{
	day = d;
}
void CDate::SetMonth(int m)
{
	month = m;
}
void CDate::SetYear(int y)
{
	year = y;
}
int CDate::GetDay() const
{
	return day;
}
int CDate::GetMonth() const
{
	return month;
}
int CDate::GetYear() const
{
	return this->year;
}
//---
CDate::CDate(int d, int m, int y) 
{
	check_set(d,m,y);
}
//---
CDate& CDate::operator =(const CDate &d)
{
	this->day = d.GetDay();
	this->month = d.GetMonth();
	this->year = d.GetYear();
	return *this;
}
//---
CDate CDate::operator +(int d)
{
	return check_set(this->day+d,this->month,this->year);
};
//---
CDate CDate::operator +(CDate d)
{
	CDate temp=*this;
	temp.add_day(d.day);
	temp.add_month(d.month);
	temp.add_year(d.year);
	return temp;
};
//---
CDate CDate::operator ++()
{   
	int max=maxm(this->month);
//-------------------------
	if (this->day > max)
	{
		this->day = 1;
		if(this->month>12){
			this->month=1;
			this->year++;
		}else{
		  this->month++;
		}
	}
	else
		this->day ++;
	return *this;
};
//----
CDate CDate::operator ++(int i)
{
	CDate temp = *this;
	int max=maxm(this->month);
	//------
	if (this->day > max)
	{
		this->day = 1;
		if(this->month>12){
			this->month=1;
			this->year++;
		}else{
		  this->month++;
		}
	}
	else{
		this->day ++;
	}
	//------
	return temp;
};
//----
CDate CDate::operator -(int d) 
{
	return check_set(this->day-d,this->month,this->year);
};
//----
CDate CDate::operator --(int i)
{
	CDate temp = *this;
	int max=maxm(this->month);
	//------
	if (this->day < 1)
	{
		this->day = 1;
		if(this->month<1){
			this->month=1;
			this->year--;
		}else{
		  this->month--;
		}
	}
	else{
		this->day --;
	}
	//------
	return temp;
};
//---
CDate& CDate::add_day(int n)
{
	if(n==0) return *this;
	while(n>0){
		int max=maxm(this->month);
		 //-----------
		if (this->day > max)
		{
			this->day = 1;
			if(this->month>12){
				this->month=1;
				this->year++;
			}else{
			  this->month++;
			}
		}
		else
			this->day ++;	
		n--;
	};//while
	//-------
	return *this;
};	
//---
CDate& CDate::add_month(int n)
{
	if(n==0) return *this;
	if(n>0){
		int delta_y=n/12;
		int mm=this->month+n%12;
		if(12<mm){
			delta_y++;
			mm-=12;
		};
	  this->year+=delta_y;
	  this->month=mm;
	  return *this;
	};
	return *this;
};
//---
CDate& CDate::add_year(int n)
{
	if(n==0) return *this;
	return check_set(this->day,this->month,this->year+n);
};
//---
CDate CDate::operator +=(CDate d)
{
	CDate temp=*this;
	temp.add_day(d.day);
	temp.add_month(d.month);
	temp.add_year(d.year);
	return temp;
};
//---
CDate CDate::operator +=(int d)
{
	CDate temp=*this;
	temp.add_day(d);
	return temp;
};

//---------
CDate::operator int()
{
	char* buff=new char[10];
	char* str=new char[50];
	int res=0;
	itoa(this->day,buff,10);
	strcpy(str,buff);
	delete[] buff;
	 buff=new char[10];
	itoa(this->month,buff,10);
	strcat(str,buff);
	delete[] buff;
	 buff=new char[10];
	itoa(this->year,buff,10);
	strcat(str,buff);
	delete[] buff;
	buff=new char[10];
	//--
	res=atoi(str);
	return res;
};
CDate::operator double()
{
	char* buff=new char[10];
	 char* str=new char[50];
	  double res=0;
	itoa(this->day,buff,10);
	 strcpy(str,buff);
	 delete[] buff;
	 buff=new char[10];
	itoa(this->month,buff,10);
	strcat(str,buff);
	 delete[] buff;
	 buff=new char[10];
	itoa(this->year,buff,10);
	strcat(str,buff);
	 delete[] buff;
	 res=atoi(str);
	delete[] str;
	return res;
};
CDate::operator char *()
{
	char* buff=new char[10];
	char* str=new char[30];
	double res=0;
	itoa(this->day,buff,10);
	strcpy(str,buff);
	delete[] buff;
	 buff=new char[10];
	itoa(this->month,buff,10);
	strcat(str,buff);
	delete[] buff;
	 buff=new char[10];
	itoa(this->year,buff,10);
	strcat(str,buff);
	delete[] buff;

	return str; 
};
//---

//=====================================================================================================================



