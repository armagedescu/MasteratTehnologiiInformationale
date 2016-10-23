#include <windows.h>
#include <GL/gl.h>
#include <GL/glu.h>
#include <GL/glaux.h>
#include <math.h>
#include "cone0.h"

cone0::cone0(int heightsegm, int sectors)
{
	nh = nh > MAXH ? MAXH : (heightsegm < 1 ? 10 : heightsegm);
	ns = sectors > MAXS ? MAXS : (sectors < 3 ? 10 : sectors);

	double hstep = 1.0/nh;
	double astep = -360.0/ns;
	double hcur = 0.0, acur, rcur;
	for(int i = 0; i < nh; i++)
	{
		hcur += hstep;
		acur = 0.0;
		rcur = hcur;
		for(int j = 0; j < ns; j++)
		{
			c[i][j][0] = rcur * cos(RADGRAD * acur);
			c[i][j][1] = rcur * sin(RADGRAD * acur);
			c[i][j][2] = hcur;
			acur += astep;
		}
	}
}

void cone0::draw()
{
	glBegin(GL_TRIANGLE_FAN);
		glVertex3d(0., 0., 0.);
		for(int j = 0; j < ns; j++)
			glVertex3dv(c[0][j]);
		glVertex3dv(c[0][0]);
	glEnd();

	for(int i = 0; i < nh - 1; i++)
	{
		glBegin(GL_TRIANGLE_STRIP);
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
