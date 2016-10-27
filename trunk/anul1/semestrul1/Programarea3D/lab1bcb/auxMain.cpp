#include <windows.h>
#include <GL/gl.h>
#include <GL/glu.h>
//#include <GL/glut.h>
#include <GL/glaux.h>
#include <stdio.h>

#include "auxFunctions.h"
#include "glFunctions.h"


int auxMain(int argc, char** argv)
{
	// Stabilim coordonatele ferestrei pe ecran
	// coltul st�nga sus (0,0)
	// l��imea �i �n�l�imea - 500
	//1
	auxInitPosition( 0, 0, 500, 500);
	// Stabilim parametrii ale contextului OpenGL
	auxInitDisplayMode( AUX_RGB | AUX_DEPTH | AUX_DOUBLE );
	// Cream o fereastr� pe ecran
	auxInitWindow((LPCWSTR)("OpenGL"));

	// Aceast� fereastr� va primi mesajele
	// de la tastatura, mouse-ul, timer-ul �i orice alte mesaje.
	// �n timp ce nu vine nici un mesaj
	// va fi apelat� ciclic func�ia display.
	// Astfel se creeaz� anima�ia.
	// Dac� avem nevoie de o imagine static�
	// coment�m urm�toarea linie
	auxIdleFunc(auxDisplay);

	// In cazul c�nd se schimb� dimensiunile ferestrei
	// vor fi primit mesajul corespunz�tor.
	// �n Windows - acesta este WM_SIZE.
	// Indic�m func�ia resize ca func�ie care va fi
	// apelat� fiecare dat� c�nd se schimb� dimensiunile
	// ferestrei
	auxReshapeFunc(resize);
	// Mai departe stabilim un set de teste si parametri

	// Testul de transparent�, adic� va fi luat �n considera�ie
	// al patrulea parametru �n glColor
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

	auxMainLoop(auxDisplay);
	return 0;
}
