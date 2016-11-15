#pragma once
#ifndef __MEMORY_HELPERS_H__
#define __MEMORY_HELPERS_H__
#include <iostream>
#include <stdarg.h>
#include <memory.h>
using namespace std;
template <class T, const int dimmension> class MultiArray
{
	int numelements;
	int sizes[dimmension];
	int blocks[dimmension];
	T* array;
	void setdimmensions(int firstDimmension, va_list  argptr)
	{
		sizes[0] = firstDimmension;
		numelements = firstDimmension;
		for( int i = 1 ; i < dimmension - 1; i++ )
		{
			sizes[i] = va_arg( argptr, int );
			numelements *= sizes[i];
			std::cout<< sizes[i]<< std::endl;
		}
		int blocksize = 1;
		blocks[dimmension - 1] = 1;
		for (int i = dimmension - 1, j = dimmension - 2; i > 0; i--, j--)
		{
			blocksize *= sizes[i];
			blocks[j] = sizes[i];
		}
		array = new T[numelements];
	}
	class multiarray_manipulator
	{
		MultiArray<T, dimmension>* elements;
		int sizer;
		T* p;
	public:
		multiarray_manipulator(MultiArray<T, dimmension>* _elements, int i): elements(_elements), p(_elements->array + _elements->blocks[0] * i), sizer(1)
		{
		}
		multiarray_manipulator& operator[](int i)
		{
			p += elements->blocks[sizer] * i;
			sizer ++;
			return *this;
		}
		operator T* ()
		{
			//if (sizer >= elements->dimmension) throw "only arrays are allowed pointed dirrectly";
			return p;
		}
		T& operator () (T x)
		{
			//if (sizer > elements->dimmension + 1) throw;
			(T&)*this = x;
			return *p;
		}
		operator T& ()
		{
			//if (sizer > elements->dimmension + 1) throw "too many sizes";
			sizer ++;
			return *p;
		}
	};

public:
	MultiArray():array(0), numelements(0) {memset(sizes, 0, sizeof(sizes));memset(blocks, 0, sizeof(blocks));}
	MultiArray(int firstDimmension, ...) {
		va_list argptr;
		va_start(argptr, firstDimmension);
		setdimmensions(firstDimmension, argptr);
		va_end(argptr);
	}
	void setdimmensions(int firstDimmension, ...)
	{
		va_list argptr;
		va_start(argptr, firstDimmension);
		setdimmensions(firstDimmension, argptr);
		va_end(argptr);
	}
	multiarray_manipulator operator[] (int i)
	{
		return multiarray_manipulator (this, i);
	}
	~MultiArray()
	{
		delete[] array;
		array = 0;
	}
	void dump()
	{
		for (int i = 0; i < numelements; i++)
			std::cout<< "i:"<<i<<"="<< array[i]<< "; "<< std::endl;
	}
};
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
			int sz = i;
			if (sizer > elements->dimmension + 1) throw;
			for (int i = sizer; i < elements->dimmension; i++) sz *= elements->sizes[i];
			return sz;
		}
	public:
		multiarray_manipulator(multiarray<T>* _elements, int i): elements(_elements), p(_elements->array), sizer(1)
		{
			p = elements->array + getblock(i);
			sizer++;
		}
		multiarray_manipulator& operator[](int i)
		{
			p += getblock (i);
			sizer ++;
			return *this;
		}
		operator T* ()
		{
			if (sizer >= elements->dimmension) throw "only arrays are allowed pointed dirrectly";
			return p;
		}
		T& operator () (T x)
		{
			if (sizer > elements->dimmension + 1) throw;
			(T&)*this = x;
			return *p;
		}
		operator T& ()
		{
			if (sizer > elements->dimmension + 1) throw "too many sizes";
			sizer ++;
			return *p;
		}
	};
	void setdimmensions(int _dimmension, va_list  argptr)
	{
		dimmension = _dimmension;
		sizes = new int[_dimmension];
		int numelements = 1;
		for( int i = 0 ; i < dimmension; i++ )
		{
			sizes[i] = va_arg( argptr, int );
			numelements *= sizes[i];
			std::cout<< sizes[i]<< std::endl;
		}
		array = new T[numelements];
	}
public:
	multiarray():sizes(0), array(0), dimmension(0){}
	multiarray(int _dimmension, ...) {
		va_list argptr;
		va_start(argptr, _dimmension);
		setdimmensions(_dimmension, argptr);
		va_end(argptr);
	}
	multiarray_manipulator operator[] (int i)
	{
		return multiarray_manipulator (this, i);
	}
	void setdimmensions(int _dimmension, ...) {
		va_list argptr;
		va_start(argptr, _dimmension);
		setdimmensions(_dimmension, argptr);
		va_end(argptr);
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
	void dump()
	{
		int numelements = 1;
		for (int i = 0; i < dimmension; i++) numelements *= sizes[i];
		for (int i = 0; i < numelements; i++)
		{
			std::cout<< "i:"<<i<<"="<< array[i]<< "; "<< std::endl;
		}
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
		//		double& operator () (double x)
		//{
		//	(double&)*this = x;
		//	return *p;
		//}
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