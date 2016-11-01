#pragma once
#ifndef __MEMORY_HELPERS_H__
#define __MEMORY_HELPERS_H__
#include <iostream>
class points3
{
	int size1;
	int size2;
	int sizer;
	double* p;
	double* c;
public:
	points3(){c = 0;size1 = 0; size2 = 0;}
	points3(int _size1, int _size2)
	{
		setSizes(_size1, _size2);
	}
	void setSizes(int _size1, int _size2)
	{
		sizer = 3;
		size1 = _size1;
		size2 = _size2;
		c = new double [(size1 + 1) * (size2 + 1) * 3];
	}
	points3& operator[](int i)
	{
		sizer--;
		if (sizer == 2) p = c + (size2 ) * i * 3;
		if (sizer == 1) p += i * 3;
		if (sizer == 0) p += i;
		return *this;
	}
	operator double* ()
	{
		if (sizer != 1) throw "sizer must be 1";
		sizer = 3;
		return p;
	}
	double& operator () (double x)
	{
		(double&)*this = x;
		return *p;
	}
	operator double& ()
	{
		if (sizer != 0) throw "sizer must be 0";
		sizer = 3;
		return *p;
	}
	~points3(){delete[] c; c = 0;}
};
inline std::ostream& operator << (std::ostream& os, points3& pt)
{
	os<< (double&) pt;
	return os;
}

#endif