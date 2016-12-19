#include <windows.h>

#include <GL/gl.h>
#pragma comment(lib,"OpenGL32.lib")

#include <GL/glu.h>
#pragma comment(lib,"Glu32.lib")

#include "glaux.h"
#pragma comment(lib,"Glaux.lib")


#include <math.h>
#define RADGRAD 0.0174532925199433
#define MAXH 150
#define MAXS 150

static AUX_RGBImageRec *pimage;

AUX_RGBImageRec *pimage1;
AUX_RGBImageRec *pimage2;
GLuint tex_name1;
GLuint tex_name2;

class cone0
{
protected:
	int nh;
	int ns;
	double c[MAXH][MAXS][3];
public:
	cone0(int, int);
	void draw();
};

cone0::cone0(int heightlayer, int segments)
{
	nh = heightlayer;
	ns = segments;

	if (nh > MAXH)
		nh = MAXH;
	else
		if (nh < 1)
			nh = 10;
	if (ns > MAXS)
		ns = MAXS;
	else
		if (ns < 3)
			ns = 10;

	int i, j;

	double hstep = 1.0 / nh;
	double astep = -360.0 / ns;
//	double astep = -180.0 / ns;

	double hcur, acur, rcur;

	hcur = 0.0;

	for (i = 0; i<nh; i++)
	{
		hcur += hstep;
		
		acur = 0.0;
		rcur = hcur;
		for (j = 0; j<ns; j++)
		{
			c[i][j][0] = rcur*cos(RADGRAD*acur);
			c[i][j][1] = rcur*sin(RADGRAD*acur);
			c[i][j][2] = hcur;
			acur += astep;
		}
	}
}


void cone0::draw()
{
	int i, j;

	glBegin(GL_TRIANGLES);
		for (j = 0; j < ns; j++)
		{
			glVertex3d(0., 0., 0.);
			glVertex3dv(c[0][j]);
			glVertex3dv(c[0][(j+1)%ns]);
		}

		for (i = 0; i<nh - 1; i++)
		{
			for (j = 0; j < ns; j++)
			{
				glVertex3dv(c[i][j]);
				glVertex3dv(c[i + 1][j]);
				glVertex3dv(c[i + 1][(j + 1) % ns]);

				glVertex3dv(c[i][j]);
				glVertex3dv(c[i + 1][(j + 1) % ns]);
				glVertex3dv(c[i][(j + 1) % ns]);
			}
		}
	glEnd();
}


class cone0_norm : public cone0
{
public:
	cone0_norm(int, int);
	void virtual draw();
};

cone0_norm::cone0_norm(int heightsegm, int sectors) :
			cone0(heightsegm, sectors)
{

}

void cone0_norm::draw()
{
	static GLdouble v[3] = { 0.0, 0.0, 0.0 };
	int i, j;
	glBegin(GL_TRIANGLES);
	for (j = 0; j < ns; j++)
	{
		glNormal3d((c[0][j][0] + c[0][(j + 1) % ns][0])*0.5,
			(c[0][j][1] + c[0][(j + 1) % ns][1])*0.5,
			-(c[0][j][2] + c[0][(j + 1) % ns][2])*0.5);
		glVertex3dv(v);
		glNormal3d(c[0][j][0], c[0][j][1], -c[0][j][2]);
		glVertex3dv(c[0][j]);
		glNormal3d(c[0][(j + 1) % ns][0], c[0][(j + 1) % ns][1], -c[0][(j + 1) % ns][2]);
		glVertex3dv(c[0][(j + 1) % ns]);
	}
	for (i = 0; i<nh - 1; i++)
	{
		for (j = 0; j<ns; j++)
		{
			glNormal3d(c[i][j][0], c[i][j][1], -c[i][j][2]);
			glVertex3dv(c[i][j]);
			glNormal3d(c[i + 1][j][0], c[i + 1][j][1], -c[i + 1][j][2]);
			glVertex3dv(c[i + 1][j]);
			glNormal3d(c[i + 1][(j + 1) % ns][0], c[i + 1][(j + 1) % ns][1],
				-c[i + 1][(j + 1) % ns][2]);
			glVertex3dv(c[i + 1][(j + 1) % ns]);


			glNormal3d(c[i][j][0], c[i][j][1], -c[i][j][2]);
			glVertex3dv(c[i][j]);
			glNormal3d(c[i + 1][(j + 1) % ns][0], c[i + 1][(j + 1) % ns][1],
				-c[i + 1][(j + 1) % ns][2]);
			glVertex3dv(c[i + 1][(j + 1) % ns]);
			glNormal3d(c[i][(j + 1) % ns][0], c[i][(j + 1) % ns][1],
				-c[i][(j + 1) % ns][2]);
			glVertex3dv(c[i][(j + 1) % ns]);
		}
	}
	glEnd();
}



GLdouble *norm(const GLdouble p1[3], const GLdouble p2[3], const GLdouble p3[3])
{
	static GLdouble p[3];
	double d;
	p[0] = (p1[1] * (p2[2] - p3[2]) + p2[1] * (p3[2] - p1[2]) + p3[1] * (p1[2] - p2[2]));
	p[1] = (p1[2] * (p2[0] - p3[0]) + p2[2] * (p3[0] - p1[0]) + p3[2] * (p1[0] - p2[0]));
	p[2] = (p1[0] * (p2[1] - p3[1]) + p2[0] * (p3[1] - p1[1]) + p3[0] * (p1[1] - p2[1]));

	//d = sqrt(p[0] * p[0] + p[1] * p[1] + p[2] * p[2]);
	//p[0] /= d;
	//p[1] /= d;
	//p[2] /= d;

	return p;
}

class cyl0
{
protected:
	int nh;
	int ns;
	double c[MAXH][MAXS][3];
public:
	cyl0(int, int);
	void draw();
};

cyl0::cyl0(int heightlayer, int segments)
{
	nh = heightlayer;
	ns = segments;

	if (nh > MAXH)
		nh = MAXH;
	else
		if (nh < 1)
			nh = 10;
	if (ns > MAXS)
		ns = MAXS;
	else
		if (ns < 3)
			ns = 10;

	int i, j;

	double hstep = 1.0 / (nh - 1);
	double astep = -360.0 / ns;
	//	double astep = -180.0 / ns;

	double hcur, acur, rcur;

	hcur = 0.0;
	rcur = 1.0;

	for (i = 0; i<nh; i++)
	{
		acur = 0.0;
		for (j = 0; j<ns; j++)
		{
			c[i][j][0] = rcur*cos(RADGRAD*acur);
			c[i][j][1] = rcur*sin(RADGRAD*acur);
			c[i][j][2] = hcur;
			acur += astep;
		}
		hcur += hstep;
	}
}

void cyl0::draw()
{
	int i, j;

	glBegin(GL_TRIANGLES);
	for (i = 0; i<nh - 1; i++)
	{
		for (j = 0; j < ns; j++)
		{
			glVertex3dv(c[i][j]);
			glVertex3dv(c[i + 1][j]);
			glVertex3dv(c[i + 1][(j + 1) % ns]);

			glVertex3dv(c[i][j]);
			glVertex3dv(c[i + 1][(j + 1) % ns]);
			glVertex3dv(c[i][(j + 1) % ns]);
		}
	}
	glEnd();
}

class cyl0_norm : public cyl0
{
public:
	cyl0_norm(int, int);
	void draw();
};

cyl0_norm::cyl0_norm(int heightlayer, int segments):
   cyl0(heightlayer, segments)
{
}

void cyl0_norm::draw()
{
	int i, j;

	glBegin(GL_TRIANGLES);
		for (i = 0; i<nh - 1; i++)
		{
			for (j = 0; j < ns; j++)
			{
				glNormal3d(c[i][j][0], c[i][j][1], 0.0);
				glVertex3dv(c[i][j]);
				glNormal3d(c[i + 1][j][0], c[i + 1][j][1], 0.0);
				glVertex3dv(c[i + 1][j]);
				glNormal3d(c[i + 1][(j + 1) % ns][0], c[i + 1][(j + 1) % ns][1], 0.0);
				glVertex3dv(c[i + 1][(j + 1) % ns]);

				glNormal3d(c[i][j][0], c[i][j][1], 0.0);
				glVertex3dv(c[i][j]);
				glNormal3d(c[i + 1][(j + 1) % ns][0], c[i + 1][(j + 1) % ns][1], 0.0);
				glVertex3dv(c[i + 1][(j + 1) % ns]);
				glNormal3d(c[i][(j + 1) % ns][0], c[i][(j + 1) % ns][1], 0.0);
				glVertex3dv(c[i][(j + 1) % ns]);
			}
		}
	glEnd();
}


class cyl0_norm_texture : public cyl0_norm
{
	double t[MAXH][MAXS + 1][2];
public:
	cyl0_norm_texture(int, int);
	void draw();
};

cyl0_norm_texture::cyl0_norm_texture(int heightlayer, int segments) :
cyl0_norm(heightlayer, segments)
{
	int i, j;
	double hstep = 1.0 / (nh - 1);
	double vstep = 1.0 / ns;
	double hcur, vcur;
	hcur = 0.0;
	for (i = 0; i<nh; i++)
	{
		vcur = 0.0;
		for (j = 0; j<(ns + 1); j++)
		{
			t[i][j][0] = hcur;
			t[i][j][1] = vcur;
			vcur += vstep;
		}
		hcur += hstep;
	}
}

void cyl0_norm_texture::draw()
{
	int i, j;

	glBegin(GL_TRIANGLES);
	for (i = 0; i<nh - 1; i++)
	{
		for (j = 0; j < ns; j++)
		{
			glNormal3d(c[i][j][0], c[i][j][1], 0.0);
			glTexCoord2dv(t[i][j]); glVertex3dv(c[i][j]);
			glNormal3d(c[i + 1][j][0], c[i + 1][j][1], 0.0);
			glTexCoord2dv(t[i + 1][j]); glVertex3dv(c[i + 1][j]);
			glNormal3d(c[i + 1][(j + 1) % ns][0], c[i + 1][(j + 1) % ns][1], 0.0);
			glTexCoord2dv(t[i + 1][j + 1]); glVertex3dv(c[i + 1][(j + 1) % ns]);

			glNormal3d(c[i][j][0], c[i][j][1], 0.0);
			glTexCoord2dv(t[i][j]); glVertex3dv(c[i][j]);
			glNormal3d(c[i + 1][(j + 1) % ns][0], c[i + 1][(j + 1) % ns][1], 0.0);
			glTexCoord2dv(t[i + 1][j + 1]); glVertex3dv(c[i + 1][(j + 1) % ns]);
			glNormal3d(c[i][(j + 1) % ns][0], c[i][(j + 1) % ns][1], 0.0);
			glTexCoord2dv(t[i][j + 1]); glVertex3dv(c[i][(j + 1) % ns]);
		}
	}
	glEnd();
}




class arc0
{
protected:
	int nh;
	int ns;
	double c[MAXH][MAXS][3];
public:
	arc0(int, int, double, double);
	void draw();
};

arc0::arc0(int heightlayer, int segments, double f = 360.0, double a = 1.0)
{
	nh = heightlayer;
	ns = segments;

	if (nh > MAXH)
		nh = MAXH;
	else
		if (nh < 1)
			nh = 10;
	if (ns > MAXS)
		ns = MAXS;
	else
		if (ns < 3)
			ns = 10;

	int i, j;

	double hstep = 1.0 / (nh - 1);

	double hcur, acur;
	double radf = RADGRAD * f;
	double astep = radf / (ns - 1);

	hcur = 0.0;


	for (i = 0; i<nh; i++)
	{
		acur = 0.0;
		for (j = 0; j<ns; j++)
		{
			c[i][j][0] = a*acur*cos(-acur);
			c[i][j][1] = a*acur*sin(-acur);
			c[i][j][2] = hcur;
			acur += astep;
		}
		hcur += hstep;
	}
}

void arc0::draw()
{
	int i, j;

	glBegin(GL_TRIANGLES);
	for (i = 0; i<nh - 1; i++)
	{
		for (j = 0; j < ns - 1; j++)
		{
			glVertex3dv(c[i][j]);
			glVertex3dv(c[i + 1][j]);
			glVertex3dv(c[i + 1][j + 1]);

			glVertex3dv(c[i][j]);
			glVertex3dv(c[i + 1][j + 1]);
			glVertex3dv(c[i][j + 1]);
		}
	}
	glEnd();
}


class cone0_norm_texture : public cone0_norm
{
protected:
	double t[MAXH][MAXS + 1][2];
public:
	cone0_norm_texture(int, int);
	void virtual draw();
};

cone0_norm_texture::cone0_norm_texture(int heightsegm,
	int sectors) :
	cone0_norm(heightsegm, sectors)
{
	int i, j;
	double hstep = 1.0 / nh;
	double vstep = 1.0 / ns;
	double hcur, vcur;
	hcur = 0.0;
	for (i = 0; i<nh; i++)
	{
		hcur += hstep;
		vcur = 0.0;
		for (j = 0; j<(ns + 1); j++)
		{
			t[i][j][0] = hcur;
			t[i][j][1] = vcur;
			vcur += vstep;
		}
	}
}

void cone0_norm_texture::draw()
{
	static GLdouble v[3] = { 0.0, 0.0, 0.0 };
	int i, j;
	glBegin(GL_TRIANGLES);
	for (j = 1; j <= ns; j++)
	{
		glNormal3dv(norm(v, c[0][j - 1], c[0][j%ns]));
		glTexCoord2d(0., 0.5); glVertex3dv(v);
		glTexCoord2dv(t[0][j - 1]); glVertex3dv(c[0][j - 1]);
		glTexCoord2dv(t[0][j]); glVertex3dv(c[0][j%ns]);
	}
	for (i = 0; i<nh - 1; i++)
		for (j = 0; j<ns; j++)
		{
			glNormal3dv(norm(c[i][j], c[i + 1][j],
				c[i + 1][(j + 1) % ns]));
			glTexCoord2dv(t[i][j]); glVertex3dv(c[i][j]);
			glTexCoord2dv(t[i + 1][j]); glVertex3dv(c[i + 1][j]);
			glTexCoord2dv(t[i + 1][j + 1]);
			glVertex3dv(c[i + 1][(j + 1) % ns]);
			glNormal3dv(norm(c[i][j], c[i + 1][(j + 1) % ns],
				c[i][(j + 1) % ns]));
			glTexCoord2dv(t[i][j]); glVertex3dv(c[i][j]);
			glTexCoord2dv(t[i + 1][j + 1]);
			glVertex3dv(c[i + 1][(j + 1) % ns]);
			glTexCoord2dv(t[i][j + 1]);
			glVertex3dv(c[i][(j + 1) % ns]);
		}
	glEnd();
}

void CALLBACK resize(int width, int height)
{
	GLuint wp = width<height ? width - 20 : height - 20;
//	glViewport(10, 10, wp, wp);

	glViewport(0, 0, width, height);

	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();

	glOrtho(-6.2, 6.2, -6.2, 6.2, 1., 12.);
//	glOrtho(0.0, 12.4, -6.2, 6.2, 2., 12.);
//	glOrtho(-6.2, 6.2, -6.2, 6.2, 4., 12.);
//	glFrustum(-5, 5, -5, 5, 2, 12);

	glMatrixMode(GL_MODELVIEW);
}

//cone0 c1(12, 24);
//cone0 c1(48, 64);


//cone0_norm c1(12, 24);
//cone0_norm c1(48, 120);

//cone0_norm_texture c1(4, 120);

//cyl0 c1(4, 24);
//cyl0 c1(48, 64);


//cyl0_norm c1(8, 24);
//cyl0_norm c1(48, 64);

cyl0_norm_texture c1(8, 24);

//arc0 c1(8, 36, 1080.0);
//arc0 c1(8, 36, 360.0, 0.05);
//arc0 c1(8, 36, 360.0);
//arc0 c1(48, 64);

double fi = 0.0;

void CALLBACK display(void)
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	// glClear( GL_COLOR_BUFFER_BIT );
	// glClear( GL_DEPTH_BUFFER_BIT );

	glRasterPos3d(-6.1999, -6.1999, -11.999);
	//	glRasterPos3d(0.0, 0.0, -11.999);
	//glPixelZoom(1.0f, 1.0f);
	GLint wp[4];
	glGetIntegerv(GL_VIEWPORT, wp);
	glPixelZoom((float)wp[2] / pimage->sizeX,
		(float)wp[3] / pimage->sizeY);

	glPixelStorei(GL_UNPACK_ALIGNMENT, 1);
	glDrawPixels(pimage->sizeX, pimage->sizeY,
		GL_RGB, GL_UNSIGNED_BYTE, pimage->data);

	glPolygonMode(GL_FRONT_AND_BACK, GL_FILL);

	glEnable(GL_COLOR_MATERIAL);

	glPushMatrix();
		glTranslated(0., 0., -6.0);
		glRotated(35. + fi, 1., 0., 0.);
		glRotated(35. + fi, 0., 1., 0.);

		fi += 1.5;
	
		glPointSize(10.0f);
		glEnable(GL_POINT_SMOOTH);
		glBegin(GL_POINTS);
			glColor3d(0, 0, 0);
			glVertex3f(0.f, 0.f, 0.f);
		glEnd();
		glDisable(GL_POINT_SMOOTH);
	
		glLineWidth(1.5f);
		glEnable(GL_LINE_SMOOTH);
		glBegin(GL_LINES);
			// Axa X
			glColor3d(0., 0., 0.);
			glVertex3d(-5.5, 0., 0.);
			glColor3d(1., 0., 0.);
			glVertex3d(5.5, 0., 0.);
			// Axa Y
			glColor3d(0., 0., 0.);
			glVertex3d(0., -5.5, 0.);
			glColor3d(0., 1., 0.);
			glVertex3d(0., 5.5, 0.);
			// Axa Z
			glColor3d(0., 0., 0.);
			glVertex3d(0., 0., -5.5);
			glColor3d(0., 0., 1.);
			glVertex3d(0., 0., 5.5);
		glEnd();
		
		// Con X
		glColor3d(1, 0, 0);
		glPushMatrix();
			glTranslated(5.3f, 0.0f, 0.0f);
			glRotated(90, 0.0f, 1.0f, 0.0f);
			auxSolidCone(0.1f, 0.2f);
		glPopMatrix();

		// Con Y
		glColor3d(0, 1, 0);
		glPushMatrix();
			glTranslated(0.0f, 5.3f, 0.0f);
			glRotated(-90, 1.0f, 0.0f, 0.0f);
			auxSolidCone(0.1f, 0.2f);
		glPopMatrix();
		
		// Con Z
		glColor3d(0, 0, 1);
		glPushMatrix();
			glTranslated(0.0f, 0.0f, 5.3f);
			auxSolidCone(0.1f, 0.2f);
		glPopMatrix();
		
		glColor3d(0.5, 0.5, 0.5);

		//VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV

//		glPolygonMode(GL_FRONT_AND_BACK, GL_LINE);
		//glPolygonMode(GL_FRONT_AND_BACK, GL_POINT);
		//glPointSize(2.0f);

		//glPolygonMode(GL_FRONT, GL_FILL);
		//glPolygonMode(GL_BACK, GL_LINE);


		glDisable(GL_COLOR_MATERIAL);

		glEnable(GL_TEXTURE_2D);

		glBindTexture(GL_TEXTURE_2D, tex_name1);

		glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
		glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
		glTexEnvi(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_REPLACE);


		//glBegin(GL_QUADS);
		//	glColor4d(1., 1., 0., 1.);
		//	glTexCoord2d(0., 0.), glVertex3d(0., -5., 5.);
		//	glTexCoord2d(0., 1.0), glVertex3d(0., 5., 5.);
		//	glTexCoord2d(1., 1.0), glVertex3d(0., 5., -5.);
		//	glTexCoord2d(1., 0.), glVertex3d(0., -5., -5.);
		//glEnd();


		

		glBindTexture(GL_TEXTURE_2D, tex_name2);
		glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
		glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
		glTexEnvi(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_DECAL);

		//glBegin(GL_POLYGON);
		//	glColor4d(1., 0., 1., 1.5);
		//	glTexCoord2d(0., 0.5), glVertex3d(-5., 0., 0.);
		//	glTexCoord2d(0.2, 1.), glVertex3d(-3., 4., 0.);
		//	glTexCoord2d(0.8, 1.), glVertex3d(3., 4., 0.);
		//	glTexCoord2d(1., 0.5), glVertex3d(5., 0., 0.);
		//	glTexCoord2d(0.8, 0.), glVertex3d(3., -4., 0.);
		//	glTexCoord2d(0.2, 0.), glVertex3d(-3., -4., 0.);
		//glEnd();



		GLfloat fd[4] = { 0.8f, 0.8f, 0.0f, 1.0f };
		glMaterialfv(GL_FRONT, GL_DIFFUSE, fd);
		GLfloat fa[4] = { 0.3f, 0.3f, 0.0f, 1.0f };
		glMaterialfv(GL_FRONT, GL_AMBIENT, fa);
		GLfloat fs[4] = { 0.1f, 0.1f, 0.0f, 1.0f };
//		GLfloat fs[4] = { 1.0f, 1.0f, 0.0f, 1.0f };
		glMaterialfv(GL_FRONT, GL_SPECULAR, fs);
		GLfloat bd[4] = { 0.7f, 0.0f, 0.0f, 1.0f };
		glMaterialfv(GL_BACK, GL_DIFFUSE, bd);
		GLfloat ba[4] = { 0.2f, 0.0f, 0.0f, 1.0f };
		glMaterialfv(GL_BACK, GL_AMBIENT, ba);
		GLfloat bs[4] = { 0.1f, 0.0f, 0.0f, 1.0f };
//		GLfloat bs[4] = { 1.0f, 0.0f, 0.0f, 1.0f };
		glMaterialfv(GL_BACK, GL_SPECULAR, bs);


		glEnable(GL_CULL_FACE);
		glCullFace(GL_BACK);

		glPushMatrix();
			glScaled(2., 2., 4.);
			glColor3d(1., 0., 1.);
			c1.draw();
		glPopMatrix();	

		glCullFace(GL_FRONT);
		glDisable(GL_TEXTURE_2D);

		glPushMatrix();
			glScaled(2., 2., 4.);
			glColor3d(1., 0., 1.);
			c1.draw();
		glPopMatrix();
		glDisable(GL_CULL_FACE);

		//GLfloat fd2[4] = { 0.0f, 0.8f, 0.0f, 1.0f };
		//glMaterialfv(GL_FRONT, GL_DIFFUSE, fd2);
		//glMaterialfv(GL_FRONT, GL_AMBIENT, fd2);


		glPushMatrix();
			glRotated(180.0, 1.0, 0.0, 0.0);
			glScaled(2., 2., 4.);
			glColor3d(0., 1., 1.);
			c1.draw();
		glPopMatrix();


		glEnable(GL_COLOR_MATERIAL);


		glPolygonMode(GL_FRONT_AND_BACK, GL_FILL);



		//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
	
	glPopMatrix();

	auxSwapBuffers();
}


const int  mx = 128;
const int  ny = 128;
unsigned char p[mx][ny][3];


void main()
{
	auxInitPosition(0, 0, 500, 500);
	auxInitDisplayMode(AUX_RGB | AUX_DEPTH | AUX_DOUBLE);
	auxInitWindow(L"OpenGL");
	auxIdleFunc(display);
	auxReshapeFunc(resize);
	glEnable(GL_ALPHA_TEST);
	glEnable(GL_DEPTH_TEST);
	glEnable(GL_NORMALIZE);
	glEnable(GL_BLEND);
	glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
//	glClearColor(0.f, 0.f, 0.f, 0.f);
	glClearColor(1.f, 1.f, 1.f, 0.f);

	glLightModeli(GL_LIGHT_MODEL_TWO_SIDE, GL_TRUE);

//	glShadeModel(GL_FLAT);
	glShadeModel(GL_SMOOTH);

	glEnable(GL_LIGHTING);
	glEnable(GL_LIGHT0);
	GLfloat pos[4] = { 0.f, 2.f, 5.f, 1.f };
	glLightfv(GL_LIGHT0, GL_POSITION, pos);
	GLfloat dir[3] = { 0.f, 0.f, -5.f };
	glLightfv(GL_LIGHT0, GL_SPOT_DIRECTION, dir);
	GLfloat col[4] = { 1.f, 1.f, 1.f, 1.f };
	glLightfv(GL_LIGHT0, GL_DIFFUSE, col);

	//float ambient[4] = { 1.0f, 1.0f, 1.0f, 1.f };
	//glLightModelfv(GL_LIGHT_MODEL_AMBIENT, ambient);


	pimage = auxDIBImageLoadA("Mybitmap.bmp");

	pimage1 = auxDIBImageLoadA("MyTexture.bmp");
//	pimage2 = auxDIBImageLoadA("Texture_512_256.bmp");

	for (int i = 0; i < mx; i++)
		for (int j = 0; j < ny; j++)
		{
//			if ((i+j) % 5)
			if (i % 2)
			{
				p[i][j][0] = 255;
				p[i][j][1] = 0;
				p[i][j][2] = 255;
			}
			else
			{
				p[i][j][0] = 0;
				p[i][j][1] = 255;
				p[i][j][2] = 255;
			}
		}


	glGenTextures(1, &tex_name1);
	glGenTextures(1, &tex_name2);

	glBindTexture(GL_TEXTURE_2D, tex_name1);
	glPixelStorei(GL_UNPACK_ALIGNMENT, 1);

	glTexImage2D(GL_TEXTURE_2D, 0, 3,
		pimage1->sizeX, pimage1->sizeY,
		0, GL_RGB, GL_UNSIGNED_BYTE, pimage1->data);

	glBindTexture(GL_TEXTURE_2D, tex_name2);
	glPixelStorei(GL_UNPACK_ALIGNMENT, 1);
	//glTexImage2D(GL_TEXTURE_2D, 0, 3, pimage2->sizeX, pimage2->sizeY,
	//	0, GL_RGB, GL_UNSIGNED_BYTE, pimage2->data);

	glTexImage2D(GL_TEXTURE_2D, 0, 3, mx, ny,
		0, GL_RGB, GL_UNSIGNED_BYTE, p);

	//gluBuild2DMipmaps(GL_TEXTURE_2D, 3, pimage2->sizeX, pimage2->sizeY,
	//	GL_RGB, GL_UNSIGNED_BYTE, pimage2->data);

	auxMainLoop(display);
}