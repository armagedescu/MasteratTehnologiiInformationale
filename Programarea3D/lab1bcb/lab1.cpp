#include <windows.h>
#include <GL/gl.h>
#include <iostream>
#include "lab1.h"
#include "cone0.h"
#include "cyllinder0.h"
#include "HeartCyllinder.h"
#include "HeartCone.h"
#include "HeartConeNorm.h"
#include "HeartConeNormMethod2.h"
#include "HeartConeNormMethod1.h"
using namespace std;

double getDFi()
{
	static double dFi = 1;
	volatile double retVal = dFi;
	dFi += 0.02;
	//cout << retVal<< endl;
	return retVal;
}
void lab1Display()
{
    glPolygonMode(GL_FRONT_AND_BACK, GL_FILL);
	glEnable (GL_NORMALIZE);
    //glPolygonMode(GL_BACK, GL_LINE);
    static cone0 con1(10, 6);
    //static cyllinder0 cil1(10, 6);
    //static HeartCyllinder hci(40, 40);
    //static HeartConeNorm hco(8, 15);
    //hco.draw();
    //static HeartConeNorm hco(80, 80);
    //hco.draw();
	static HeartConeNormMethod2 hco2(8, 15);
    hco2.draw();
	static HeartConeNormMethod1 hco1(8, 15);
    //hco1.draw();
    //con1.draw();
    ////cil1.draw();
    ////hci.draw();
	//hco.draw1();
	//hco.draw2();

}
void lab1Display1()
{
    glPolygonMode(GL_FRONT, GL_FILL);
    glPolygonMode(GL_BACK, GL_LINE);
    static cone0 con1(10, 6);
    //static cyllinder0 cil1(10, 6);
    //static HeartCyllinder hci(40, 40);
    static HeartCone hco(8, 15);
    //con1.draw();
    ////cil1.draw();
    ////hci.draw();
    hco.draw();
	//hco.draw1();
	//hco.draw2();

}
//void lab1Display2()
//{
//	//static cone0 con1(10, 6);
//	//static cyllinder0 cil1(10, 6);
//	//static HeartCyllinder hci(40, 40);
//	static HeartCone hco(60, 60);
//	//con1.draw();
//	//cil1.draw();
//	//hci.draw();
//	hco.draw2();
//}
void directDisplay()
{
	glPushMatrix();
	glTranslated(0., 0., 0.);

	glPointSize(10.0f);
	glEnable(GL_POINT_SMOOTH);
	   glBegin(GL_POINTS);
	      glColor3d(0,0,0);
	      glVertex3f(0.f,0.f,3.f);
	   glEnd();
	glDisable(GL_POINT_SMOOTH);

	glLineWidth(1.5f);
	glEnable(GL_LINE_SMOOTH);
	glBegin(GL_LINES);
	   // Axa X
	   glColor3d  (  0., 0., 3.);
	   glVertex3d (-2.5, 0., 3.);
	   glColor3d  (  1., 0., 0.);
	   glVertex3d ( 2.5, 0., 3.);

	   // Axa Y
	   glColor3d  (0.,   0., 0.);
	   glVertex3d (0., -2.5, 3.);
	   glColor3d  (0.,   1., 0.);
	   glVertex3d (0.,  2.5, 3.);
	glEnd();

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
	directDisplay();
	glPopMatrix();
}
void lab1GlDisplay()
{
	directDisplay();
	mirrorDisplay();

}