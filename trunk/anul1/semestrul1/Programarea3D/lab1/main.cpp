#include <windows.h>
#include <GL/gl.h>
#include <GL/glu.h>
#include <GL/glut.h>
#include <GL/glaux.h>
#include <stdio.h>

#include "externals.h"

int bezierMain(int argc, char** argv);
int glutMain(int argc, char** argv);
int auxMain(int argc, char** argv);

int main(int argc, char** argv)
{
	//return auxMain(argc, argv);
	return glutMain(argc, argv);
}
