#pragma once
#ifndef __MEMORY_HELPERS_H__
#define __MEMORY_HELPERS_H__
#include <iostream>
template <class T> class multiarray
{
	int* sizes;
	int dimmension;
	T* array;
	void resetdimmensions()
	{
		delete[] sizes;
		delete[] array;
		dimmension = 0;
		sizes = 0;
		array = 0;
	}
	class multiarray_manipulator
	{
		multiarray<T>* elements;
		int sizer;
		double* p;
		int getblock(int i)
		{
			int sz = 1;
			if (sizer ==  elements->dimmension) return i;
			if (sizer > elements->dimmension) throw;
			for (int i = sizer; i < elements->dimmension; i++) sz *= elements->sizes[i];
			return sz;
		}
	public:
		multiarray_manipulator(multiarray<T>* _elements, int i): elements(_elements), p(_elements->array), sizer(1)
		{
			p = elements->array + (elements->sizes[sizer - 1] ) * i;
		}
		multiarray_manipulator& operator[](int i)
		{
			p += getblock (i);
			sizer ++;
			return *this;
		}
		operator T* ()
		{
			if (sizer >= elements->dimmension) throw;
			return p;
		}
		T& operator () (T x)
		{
			if (sizer > elements->dimmension) throw;
			(T&)*this = x;
			return *p;
		}
		operator T& ()
		{
			if (sizer != 0) throw "sizer must be 0";
			sizer = 3;
			return *p;
		}
	};
public:
	multiarray():sizes(0), array(0), dimmension(0){}
	multiarray(int _dimmension, ...){
		va_list argptr;
		va_start(argptr, _dimmension);
		//std::cout <<_dimmension <<std::endl;
		//std::cout <<*((&_dimmension) + 1) <<std::endl;
		setdimmensionss(_dimmension, (int*)argptr);
		va_end(argptr);
	}
	multiarray(int _dimmension, int* _sizes){
		
		setdimmensions(_dimmension, sizes);
	}
	multiarray_manipulator operator[] (int i)
	{
		return multiarray_manipulator (this, i);
	}
	void setdimmensionss(int _dimmension, int* _sizes)
	{
		resetdimmensions();
		dimmension =_dimmension;
		sizes = new int[dimmension];
		int numelements = 1;
		for (int i = 0; i < dimmension; i++)
		{
			sizes[i] = _sizes[-i];
			numelements *= sizes[i];
		}
		array = new T[numelements];
	}
	void copymem(T* _array)
	{
		int numelements = 1;
		for (int i = 0; i < dimmension; i++) numelements *= sizes[i];
		for (int i = 0; i < numelements; i++) array[i] = _array[i];
	}
	void attachmem(T* _array)
	{
		delete[] array;
		array = _array;
	}
	T* detachmem()
	{
		T* _array = array;
		array = 0;
		return _array;
	}
	void setdimmensions(int _dimmension, ...)
	{
		setdimmensions(_dimmension, &_dimmension + 1);
	}
	~multiarray()
	{
		delete[] sizes;
		delete[] array;
	}
};
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