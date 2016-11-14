#include <windows.h>
//#include <stdio.h>
#include "MemoryHelpers.h"
#include "externals.h"
#include <iostream>
int bezierGlutMain(int argc, char** argv);
int bezierAuxMain(int argc, char** argv);
int glutMain(int argc, char** argv);
int auxMain(int argc, char** argv);

using namespace std;
int main(int argc, char** argv)
{
	//return bezierAuxMain( argc,  argv);
	//return bezierGlutMain( argc,  argv);
	//return auxMain(argc, argv);
	multiarray<double> x(3, 4, 7, 3);
	for (int i = 0; i < 4; i++)
	   for (int j = 0 ; j < 7; j++)
		  for (int k = 0; k < 3; k++)
		  {
		      cout <<i << "; "<< j << ";"<< k<< endl;
		      x[i][j][k] ((double) i * j * k);
		   }
	return 0;
	return glutMain(argc, argv);
}
