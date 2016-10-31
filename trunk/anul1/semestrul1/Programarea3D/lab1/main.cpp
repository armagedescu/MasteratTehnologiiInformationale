#include <windows.h>
#include <GL/gl.h>
#include <GL/glu.h>
#include <GL/glut.h>
#include <GL/glaux.h>
//#include <stdio.h>

#include "externals.h"

int bezierGlutMain(int argc, char** argv);
int bezierAuxMain(int argc, char** argv);
int glutMain(int argc, char** argv);
int auxMain(int argc, char** argv);

int main(int argc, char** argv)
{
	//return bezierAuxMain( argc,  argv);
	//return bezierGlutMain( argc,  argv);
	//return auxMain(argc, argv);
	return glutMain(argc, argv);
}
