#ifndef _MY_MATRIX_
#define _MY_MATRIX_
#include <iostream>
#include <algorithm>
#include <vector>
using std::vector;
//---------Template class matrix--------
template <class T>
class matrix{
private:
	vector<vector<T> > mat;	
public:
	explicit matrix();
	explicit matrix(int n, int m);
	explicit matrix(std::vector<T> vect);
	explicit matrix(const matrix& mt);
	matrix<T>& push_back(std::vector<T> v); 
	matrix<T>& operator = (const matrix<T> a);
	matrix<T>& operator = (T value);
	std::vector<T>& operator[](int i);
};
//-----------------
template <class T>
matrix<T>::matrix(){
};
//-----------------
template <class T>
matrix<T>::matrix(std::vector<T> vect){
	this->mat.push_back(vect);
};
//-----------------
template <class T>
matrix<T>::matrix(const matrix<T> &mt){
	vector<vector<T> >::const_iterator iter;
	for(iter=mt.begin(); iter!=mt.end(); iter++){
		this->mat.push_back(*iter);
	};
};
//-----------------
template <class T>
std::vector<T>& matrix<T>::operator [](int i){
	vector<vector<T> >::iterator iter;
	int ct=0;
	for(iter=this->mat.begin(); iter!=this->mat.end(); iter++){
		if(i==ct) return *iter;
			ct++;		
	};	
	return *(this->mat.begin());
};
//-----------------
template <class T>
matrix<T>& matrix<T>::push_back(std::vector<T> v){
	this->mat.push_back(v);
	return *this;
};
//-----------------
template <class T>
matrix<T>::matrix(int n, int m){	
	std::vector<T> v(m,0);
	for(int i=0; i<n; i++){
	 this->mat.push_back(v);
	};
};
//-----------------
template <class T>
matrix<T>& matrix<T>::operator =(const matrix<T> a){
	vector<vector<T> >::const_iterator iter;
	for(iter=a.begin(); iter!=a.end(); iter++){
		this->mat.push_back(*iter);
	}
	return *this;
};
//-----------------
template <class T>
matrix<T>& matrix<T>::operator =(T value){
	vector<vector<T> >::iterator iter;
	vector<T>::iterator iti;
	vector<T> it;
	for(iter=this->mat.begin(); iter!=this->mat.end(); iter++){
		it=*iter;
		for(iti=it.begin(); iti!=it.end(); iti++){
		 	swap(*iti,value);//(*iti)=value;
		}				
	}
	return *this;
};
//-----------------
#endif