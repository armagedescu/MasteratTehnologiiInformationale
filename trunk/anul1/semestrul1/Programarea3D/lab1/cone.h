#pragma once
#ifndef __CONE_H__
#define __CONE_H__
#define _USE_MATH_DEFINES
#include <math.h>
const double RADGRAD = M_PI / 180;
const int MAXH = 150;
const int MAXS = 150;
//#define RADGRAD 0.0174532925199433
//#define MAXH 150
//#define MAXS 150
class cone0
{
protected:
	int nh;
	int ns;
	double c[MAXH][MAXS][3];
public:
	cone0(int, int);
	void drawcon();
};


#endif