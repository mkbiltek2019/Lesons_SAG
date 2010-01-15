#include "CDirection.h"
//---------------------
CDirection::CDirection():dir(1){
};
CDirection::~CDirection(){
};
//-------
const int CDirection::getDir(){
	return dir;
};
//-------
const int CDirection::moveUp(){
	dir = up;
	return up;
};
const int CDirection::moveDown(){
	dir = down;
	return down;
};
const int CDirection::moveLeft(){
	dir = left;
	return left;
};
const int CDirection::moveRight(){
	dir = right;
	return right;
};
	
//---------------------