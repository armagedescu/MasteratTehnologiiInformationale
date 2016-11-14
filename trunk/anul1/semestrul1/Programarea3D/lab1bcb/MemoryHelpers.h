#pragma once
#ifndef __MEMORY_HELPERS_H__
#define __MEMORY_HELPERS_H__
#include <iostream>
class points3
{
	int size1;
	int size2;
	double* c;
	class points3pointer
	{
		points3* points;
		int sizer;
		double* p;
	public:
		points3pointer(points3* _points, int i): points(_points), p(_points->c), sizer(2)
		{
			p = _points->c + (_points->size2 ) * i * 3;
		}
		points3pointer& operator[](int i)
		{
			sizer--;
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
	};
public:
	points3(){c = 0;size1 = 0; size2 = 0;}

	void setSizes(int _size1, int _size2)
	{
		size1 = _size1;
		size2 = _size2;
		c = new double [size1 * size2 * 3];
	}
	points3pointer operator[](int i)
	{
		return points3pointer (this, i);
	}

	~points3(){delete[] c; c = 0;}
};
inline std::ostream& operator << (std::ostream& os, points3& pt)
{
	os<< (double&) pt;
	return os;
}

#endif