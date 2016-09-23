#include <windows.h>
#include <GL/gl.h>
#include <GL/glu.h>
#include <GL/glaux.h>
#include<stdio.h>

void CALLBACK resize(int width, int height)
{
	// Aici se indicã partea ferestrei în care
	// se efectueazã afiºarea de cãtre OpenGL.
	GLuint wp = width<height ? width-20 : height-20;
	glViewport(10, 10, wp, wp);

	glMatrixMode( GL_PROJECTION );
	glLoadIdentity();

	// Stabilim tipul proiecþiei.
	// glOrtho - paralelã
	// glFrustum - perspectivã
	// Parametrii la ambele funcþii sunt identici
	// Ei stabilesc volumul care va fi vizibil
	// peretele stânga - 6.2 unitãþi în stânga
	// dreapta - 6.2 unitãþi în dreapta
	// apoi pereþiile de jos ºi de sus,
	// ºi în sfârºit pereþiile din faþã ºi din spate
	glOrtho(-6.2,6.2, -6.2,6.2, 2., 12.);
	// glFrustum(-5,5, -5,5, 2,12);

	glMatrixMode( GL_MODELVIEW );
}