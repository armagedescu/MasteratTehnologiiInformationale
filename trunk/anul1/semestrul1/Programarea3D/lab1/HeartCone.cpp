#include "HeartCone.h"
#include <windows.h>
#include <GL/gl.h>
#include <GL/glu.h>
#include <GL/glaux.h>
#include <math.h>
#include <iostream>
using namespace std;
HeartCone::HeartCone(int heightsegm, int sectors)
{
	nh = nh > MAXH ? MAXH : (heightsegm < 1 ? 10 : heightsegm);
	ns = sectors > MAXS ? MAXS : (sectors < 3 ? 10 : sectors);

	const double rLim = 1.5;
	double rMax = ns / 2 * 0.1;
	double ratio = rMax / rLim;

	double hstep = 1.0/nh;
	double astep = -360.0/ns;
	double hcur = 0.0, acur, rcur;
	for(int i = 0; i < nh; i++)
	{
		hcur += hstep;
		acur = 0.0;
		int j;
		for(j = 0; j <= ns / 2; j++)
		{
			rcur = hcur * j * 0.1 / ratio;
			//if (i == nh - 1) cout << "rcur = "<< rcur<<"; acur = "<< acur<< endl;
			c[i][j][0] = rcur * cos(RADGRAD * acur) + hcur / 2;
			c[i][j][1] = rcur * sin(RADGRAD * acur);
			c[i][j][2] = hcur;
			acur += astep;
		}
		//if (i == nh - 1) cout << " ************************ "<<endl;
		for(int  j = ns / 2, z = ns / 2; j <= ns ; j++, z--)
		{
			acur -= astep;
			rcur = hcur * z * 0.1 / ratio;
			//if (i == nh - 1) cout << "rcur = "<< rcur<<"; acur = "<< acur<< endl;
			c[i][j][0] = rcur * cos(RADGRAD * acur) + hcur / 2;
			c[i][j][1] = rcur * -sin(RADGRAD * acur);
			c[i][j][2] = hcur;
		}
	}
}

void HeartCone::draw()
{
	glBegin(GL_TRIANGLE_FAN);
		glVertex3d(0., 0., 0.);
		for(int j = 0; j < ns; j++)
			glVertex3dv(c[0][j]);
		glVertex3dv(c[0][0]);
	glEnd();

	for(int i = 0; i < nh - 1; i++)
	{
		//glBegin(GL_TRIANGLE_STRIP);
		glBegin(GL_LINE_STRIP);
		for (int j = 0; j < ns; j++)
		{
			glVertex3dv(c[i + 1][j]);
			glVertex3dv(c[i][j]);
		}
		glVertex3dv(c[i+1][0]);
		glVertex3dv(c[i][0]);
		glEnd();
	}
}
