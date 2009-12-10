#ifndef _C_MY_DIRECTION_
#define _C_MY_DIRECTION_
//----------
class CDirection {
private:
	int dir;
	enum {up =1 , down = 2, left = 3, right = 4};
public:
	CDirection();
	~CDirection();
	//-------
	const int getDir();
	//-------
	const int moveUp();
	const int moveDown();
	const int moveLeft();
	const int moveRight();
	//-------
};
typedef CDirection* Dir;

//----------
#endif