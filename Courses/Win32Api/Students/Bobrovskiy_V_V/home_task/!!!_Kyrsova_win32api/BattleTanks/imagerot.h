#ifndef AAROT_HPP
#define AAROT_HPP

#include <windows.h>
#include <iostream>
#include <vector>
#include <math.h>

#define aar_abs(a) (((a) < 0)?(-(a)):(a))

typedef bool(* aar_callback) (double);

struct aar_pnt
{
	double x,y;
	inline aar_pnt(){}
    inline aar_pnt(double x,double y):x(x),y(y){}
};

struct aar_dblrgbquad
{
	double red, green, blue, alpha;
};

struct aar_indll
{
    aar_indll * next;
    int ind;
};

class aarot {
public:
	aarot(){};
	~aarot(){};
	//------
     HBITMAP rotate(HBITMAP, double, int, bool);

	 double coss;
     double sins;
     aar_pnt * polyoverlap;
     int polyoverlapsize;
     aar_pnt * polysorted;
     int polysortedsize;
     aar_pnt * corners;
    //562

     inline int roundup(double a) {if (aar_abs(a - (int)(a + 5e-10)) < 1e-9) return (int)(a + 5e-10); else return (int)(a + 1);}
     inline int round(double a) {return (int)(a + 0.5);}
     inline BYTE byterange(double a) {int b = round(a); if (b <= 0) return 0; else if (b >= 255) return 255; else return (BYTE)b;}
     inline double aar_min(double & a, double & b) {if (a < b) return a; else return b;}
     inline double aar_max(double & a, double & b) {if (a > b) return a; else return b;}

     inline double aar_cos(double);
     inline double aar_sin(double);

     inline double area();
     inline void sortpoints();
     inline bool isinsquare(aar_pnt, aar_pnt &);
     inline double pixoverlap(aar_pnt *, aar_pnt);

     HBITMAP dorotate(HBITMAP, double, int, bool);
};
typedef aarot* Rot;

#endif
