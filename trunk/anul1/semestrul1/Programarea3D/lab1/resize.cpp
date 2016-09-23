#include <windows.h>
#include <GL/gl.h>
#include <GL/glu.h>
#include <GL/glaux.h>
#include<stdio.h>

void CALLBACK resize(int width, int height)
{
	// Aici se indic� partea ferestrei �n care
	// se efectueaz� afi�area de c�tre OpenGL.
	GLuint wp = width<height ? width-20 : height-20;
	glViewport(10, 10, wp, wp);

	glMatrixMode( GL_PROJECTION );
	glLoadIdentity();

	// Stabilim tipul proiec�iei.
	// glOrtho - paralel�
	// glFrustum - perspectiv�
	// Parametrii la ambele func�ii sunt identici
	// Ei stabilesc volumul care va fi vizibil
	// peretele st�nga - 6.2 unit��i �n st�nga
	// dreapta - 6.2 unit��i �n dreapta
	// apoi pere�iile de jos �i de sus,
	// �i �n sf�r�it pere�iile din fa�� �i din spate
	glOrtho(-6.2,6.2, -6.2,6.2, 2., 12.);
	// glFrustum(-5,5, -5,5, 2,12);

	glMatrixMode( GL_MODELVIEW );
}