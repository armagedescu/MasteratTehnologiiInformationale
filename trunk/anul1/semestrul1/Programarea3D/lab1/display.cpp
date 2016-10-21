#include <windows.h>
#include <GL/gl.h>
#include <GL/glu.h>
#include <GL/glaux.h>
#include <stdio.h>
#include "cone.h"
static cone0 c1(10, 30);
void spacePrepare()
{
	glTranslated(0., 0., -6.0);
	glRotated(35., 1., 0., 0.);
	//glRotated(-35., 0., 1., 0.);
	glRotated(35., 0., 1., 0.);
}
void drawCentralPoint()
{
	glPointSize(10.0f);
	glEnable(GL_POINT_SMOOTH);
	   glBegin(GL_POINTS);
	      glColor3d(0,0,0);
	      glVertex3f(0.f,0.f,0.f);
	   glEnd();
	glDisable(GL_POINT_SMOOTH);
}
void drawAxis()
{
	glLineWidth(1.5f);
	glEnable(GL_LINE_SMOOTH);
	glBegin(GL_LINES);
	   // Axa X
	   glColor3d(0.,0.,0.);
	   glVertex3d(-5.5,0.,0.);
	   glColor3d(1.,0.,0.);
	   glVertex3d(5.5,0.,0.);
	   // Axa Y
	   glColor3d(0.,0.,0.);
	   glVertex3d(0.,-5.5,0.);
	   glColor3d(0.,1.,0.);
	   glVertex3d(0.,5.5,0.);
	   // Axa Z
	   glColor3d(0.,0.,0.);
	   glVertex3d(0.,0.,-5.5);
	   glColor3d(0.,0.,1.);
	   glVertex3d(0.,0.,5.5);
	glEnd();
}
void drawCones()
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

void drawAll()
{
	drawCentralPoint();
	drawAxis();
	drawCones();
}
void CALLBACK display(void)
{
	glClear( GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT );
	// glClear( GL_COLOR_BUFFER_BIT );
	// glClear( GL_DEPTH_BUFFER_BIT );
	glPushMatrix();
	spacePrepare();
	drawAll();
	glPushMatrix();
	glTranslated(0.,0., 1.);
	glScaled(2., 2., 3.);
	glColor3d(1., 0., 1.);
	c1.drawcon();
	glPopMatrix();

	//VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV
	// Aici vom adãuga fragmente de cod pentru diferite
	// exemple, pe parcursul studierii funcþiilor OpenGL
	//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
	glPopMatrix();
	auxSwapBuffers();
}