#pragma once
#ifndef __LAB_1_HEART_CONE_H__
#define __LAB_1_HEART_CONE_H__
#include "constante.h"

class HeartCone
{
protected:
	int nh;
	int ns;
	double c[MAXH][MAXS][3];
	void calculate1();
	void calculate2();
	void calculate3();
public:
	HeartCone(int, int);
	void draw();
	void draw1();
	void draw2();
};

#endif