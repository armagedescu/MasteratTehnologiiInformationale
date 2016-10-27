#include <windows.h>
#include <GL/gl.h>
#include <GL/glu.h>
//#include <GL/glut.h>
#include <GL/glaux.h>
#include <stdio.h>
//#include "cone0.h"
//#include "cyllinder0.h"
#include "glfunctions.h"
#include "lab1.h"
void auxDrawCones()
{
	glColor3d(1,0,0);
	glPushMatrix();
	   glTranslated(5.3f, 0.0f, 0.0f);
	   glRotated(90, 0.0f, 1.0f, 0.0f);
	   auxSolidCone(0.1f, 0.2f);
	glPopMatrix();
	// Con Y
	glColor3d(0,1,0);
	glPushMatrix();
	   glTranslated(0.0f, 5.3f, 0.0f);
	   glRotated(-90, 1.0f, 0.0f, 0.0f);
	   auxSolidCone(0.1f, 0.2f);
	glPopMatrix();
	// Con Z
	glColor3d(0,0,1);
	glPushMatrix();
	   glTranslated(0.0f, 0.0f, 5.3f);
	   auxSolidCone(0.1f, 0.2f);
	glPopMatrix();
}

void auxDrawAll()
{
	drawCentralPoint();
	drawAxis();
	auxDrawCones();
}

void CALLBACK auxDisplay(void)
{
	glClear( GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT );
	// glClear( GL_COLOR_BUFFER_BIT );
	// glClear( GL_DEPTH_BUFFER_BIT );
	glPushMatrix();
	spacePrepare();
	auxDrawAll();


	lab1GlDisplay();
	//VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV
	// Aici vom adãuga fragmente de cod pentru diferite
	// exemple, pe parcursul studierii funcþiilor OpenGL
	//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^


	glPopMatrix();
	auxSwapBuffers();
}