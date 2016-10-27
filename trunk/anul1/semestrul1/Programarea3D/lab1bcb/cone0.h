#pragma once
#ifndef __CONE_H__
#define __CONE_H__
#define _USE_MATH_DEFINES
#include <math.h>
#include "constante.h"

class cone0
{
protected:
	int nh;
	int ns;
	double c[MAXH][MAXS][3];
public:
	cone0(int, int);
	void draw();
};


#endif