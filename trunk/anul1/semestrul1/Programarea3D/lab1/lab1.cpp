#include "lab1.h"
#include "cone.h"
#include "cyllinder0.h"
#include <windows.h>
#include <GL/gl.h>
double getDFi()
{
	static double dFi = 0.0;
	volatile double retVal = dFi;
	dFi += 0.02;
	return retVal;
}
void lab1Display()
{
	static cone0 c1(10, 30);
	static cyllinder0 c2(10, 30);
	c1.draw();
	//c2.draw();
}
void lab1GlDisplay()
{
	glPushMatrix();
	glTranslated(0.,0., 1.);
	glScaled(2., 2., 3.);
	glColor3d(1., 0., 1.);
	lab1Display();
	glPopMatrix();
}