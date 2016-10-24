#include "lab1.h"
#include "cone0.h"
#include "cyllinder0.h"
#include "HeartCyllinder.h"
#include "HeartCone.h"
#include <windows.h>
#include <GL/gl.h>

#include <iostream>
using namespace std;
double getDFi()
{
	static double dFi = 1;//0.58;
	volatile double retVal = dFi;
	dFi += 0.02;
	//cout << retVal<< endl;
	return retVal;
}

void lab1Display()
{
	static cone0 con1(10, 30);
	static cyllinder0 cil1(10, 30);
	static HeartCyllinder hci(10, 30);
	static HeartCone hco(10, 30);
	//con1.draw();
	//cil1.draw();
	//hci.draw();
	hco.draw();
}
void dirrectDisplay()
{
	glPushMatrix();
	glTranslated(0., 0., 0.);
	//glTranslated(0., 0., 1.); translate along Z

	glPointSize(10.0f);
	glEnable(GL_POINT_SMOOTH);
	   glBegin(GL_POINTS);
	      glColor3d(0,0,0);
	      glVertex3f(0.f,0.f,3.f);
	   glEnd();
	glDisable(GL_POINT_SMOOTH);

	glScaled(2., 2., 3.);
	glColor3d(1., 0., 1.);
	lab1Display();
	glPopMatrix();
}
void mirrorDisplay()
{
	glPushMatrix();
	glRotated(180, 1, 0, 0);
	glRotated(180, 0, 0, 1);
	dirrectDisplay();
	glPopMatrix();
}
void lab1GlDisplay()
{
	dirrectDisplay();
	mirrorDisplay();

}