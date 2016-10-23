#include <windows.h>
#include <GL/gl.h>
#include <GL/glu.h>
#include <GL/glut.h>
#include <GL/glaux.h>
#include <stdio.h>
#include "externals.h"
#include "glFunctions.h"
#include "glutFunctions.h"

void glutResize(int width, int height) {return resize(width, height);}

int glutMain(int argc, char** argv)
{
   glutInit(&argc, argv);

   //1
   glutInitWindowSize (500, 500);
   glutInitWindowPosition (0, 0);
   glutInitDisplayMode (GLUT_RGB | GLUT_DEPTH | GLUT_DOUBLE );
   glutCreateWindow ("OpenGL");
   glutIdleFunc(glutDisplay);
   
   //glutInit ();
   glutDisplayFunc(glutDisplay);
   glutReshapeFunc(glutResize);

    glEnable(GL_ALPHA_TEST);
	// testul de ad�ncime
	glEnable(GL_DEPTH_TEST);

	// func�ia glColor va stabili
	// propriet��ile materialelor.
	// De aceia nu este nevoie de apelul suplimentar
	// a func�iei glMaterialfv
	glEnable(GL_COLOR_MATERIAL);

	// Permitem iluminarea
	glEnable(GL_LIGHTING);
	// Aprindem sursa de lumin� cu num�rul 0
	glEnable(GL_LIGHT0);
	// Stabilim pozi�ia sursei de lumin�
	float pos[4] = {3,3,3,1};
	float dir[3] = {-1,-1,-1};
	glLightfv(GL_LIGHT0, GL_POSITION, pos);
	glLightfv(GL_LIGHT0, GL_SPOT_DIRECTION, dir);

	// Permitem amestecarea culorilor
	// (pentru suprafe�e transparente)
	glEnable(GL_BLEND);
	glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
	// Stabilim culoarea de umplere ini�ial� a ferestrei
	glClearColor(1.f, 1.f, 1.f, 1.f);
	// Indic�m c� func�ia display() va fi folosit� pentru
	// redesenarea ferestrei.
	// Aceast� func�ie va fi apelat� de fiecare dat� c�nd
	// apare necesitatea de a redesena fereastra.
	// De exemplu, c�nd fereastra se desf�oar�
	// pe �ntregul ecran (mesajul WM_PAINT in Windows)
   glutMainLoop();
   return 0;
}