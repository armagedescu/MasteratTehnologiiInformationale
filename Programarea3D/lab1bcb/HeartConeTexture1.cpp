#include <windows.h>
#include <GL/gl.h>
#include <GL/glu.h>
#include <GL/glaux.h>
#include <math.h>
#include <iostream>
using namespace std;

#include "HeartConeTexture1.h"



HeartConeTexture1::HeartConeTexture1(int heightsegm, int sectors)
{
	sectors += sectors & 1;
	nh = nh      > MAXH ? MAXH : (heightsegm < 1 ? 10 : heightsegm);
	ns = sectors > MAXS ? MAXS : (sectors < 3 ? 10 : sectors);
	points.setdimensions(nh, ns, 3);
	//norms.setdimensions(ns * 6, 3);

	AUX_RGBImageRec *pPhobos = auxDIBImageLoadW(L"Phobos2.bmp");
	glGenTextures(1, &tex_phobos);
	glBindTexture(GL_TEXTURE_2D, tex_phobos);
	glPixelStorei(GL_UNPACK_ALIGNMENT, 1);
	glTexImage2D(GL_TEXTURE_2D, 0, 3,
		pPhobos->sizeX, pPhobos->sizeY, 
		0, GL_RGB, GL_UNSIGNED_BYTE, pPhobos->data);

	for (int i = 0; i < mx; i++)
		for (int j = 0; j < ny; j++)
		{
			if ((  (i & 255) >  127 && (j & 255) >  127  ) ||  ((i & 255) <  127 && (j & 255) <  127))
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

	glGenTextures(1, &tex_generated);
	glBindTexture(GL_TEXTURE_2D, tex_generated);
	glPixelStorei(GL_UNPACK_ALIGNMENT, 1);

	glTexImage2D(GL_TEXTURE_2D, 0, 3, mx, ny,
		0, GL_RGB, GL_UNSIGNED_BYTE, p);
	calculate();
}

void HeartConeTexture1::calculate()
{
	//Raza va creste de la 0 la 1.5 pentru ns/2 sectoare si apoi va scade de la 1.5 la 0 pana la ns
	const double rmax = 1.5;
	const double ratio = rmax / (ns / 2); // rata de modificare a unghiului pentru fiecare sector
	//Inaltimea va fi egala cu 1
	const double h = 1.0;
	const double hstep =       1.0 / nh; //Grosimea unui strat
	const double pistep = 2 * M_PI / ns; //Unghiul unui sector. Creste contra acelor ceasornicului


	// Calculam coordonatele
	int j;
	for(j = 0; j <= ns / 2; j++) //pana la 180 de grade inclusiv, calculat in numar de sectoare
	{
		double dbj = (double)j;
		double rcur = dbj * ratio; // Curba lui Arhimede. Raza curenta: unghiul inmultit cu un coeficient
		double picur = pistep * dbj; // Unghiul curent in radiani
		points[nh - 1][j][0] (rcur * cos(picur));// + 0.5);// mutam figura cu 0.5 unitati in directia axei X, se face in matrita de translare
		points[nh - 1][j][1] (rcur * sin(picur));
		points[nh - 1][j][2] (h); // h = 1

		//double dFdFi[3] = 
		//{
		//	rcur * (cos(picur) - picur * sin(picur)), rcur * (sin(picur) + picur * cos(picur)), 0
		//};
		//
		//double dFdZ[3] = 
		//{
		//	rcur * cos(picur),                        rcur * sin(picur),                        1
		//};
		//
		//double dFiZ[3] = 
		//{
		//	 (dFdFi[1] * dFdZ[2] - dFdFi[2] * dFdZ[1]),
		//	 (dFdFi[2] * dFdZ[0] - dFdFi[0] * dFdZ[2]) * (j < ns/2 ? 1 : -1),
		//	 (dFdFi[0] * dFdZ[1] - dFdFi[1] * dFdZ[0]),
		//};
		//norms[j].set (dFiZ);

	}
	// Transformam simetric coordonatele in ordine negativa fata de axa Y
	for(int z = ns / 2 - 1; j < ns ; j++, z--) //pana la 180 de grade exclusiv, calculat in numar de sectoare
	{
		points[nh - 1][j][0] ( points[nh - 1][z][0]);
		points[nh - 1][j][1] (-points[nh - 1][z][1]);
		points[nh - 1][j][2] ( points[nh - 1][z][2]); // h = 1

		
		//norms[j][0] ( norms[z][0]);
		//norms[j][1] (-norms[z][1]);
		//norms[j][2] ( norms[z][2]);
	}

	// Calculam fiecare strat, miscorand stratul precedent proportional cu numarul straturi
	for(int i = nh - 2; i >= 0; i--)
	{
		double hcur = hstep * (i + 1);
		for(int j = 0; j < ns ; j++)
		{
			points[i][j][0] (points[nh - 1][j][0] * hcur);
			points[i][j][1] (points[nh - 1][j][1] * hcur);
			points[i][j][2] (hcur);
		}
	}


}

void HeartConeTexture1::draw()
{
	glEnable(GL_CULL_FACE);
	glCullFace(GL_BACK);
	draw(tex_phobos);
	glCullFace(GL_FRONT);
	draw(tex_generated);
	glDisable(GL_CULL_FACE);
}
void HeartConeTexture1::drawInverse()
{
	glEnable(GL_CULL_FACE);
	glCullFace(GL_BACK);
	draw(tex_generated);
	glCullFace(GL_FRONT);
	draw(tex_phobos);
	glDisable(GL_CULL_FACE);
}
void HeartConeTexture1::draw(GLuint texture)
{
	static GLdouble v[3] = {0.0, 0.0, 0.0};
	glPushMatrix();

	const double s[16] = {
		     1,    0, 0, 0,
		     0, 0.95, 0, 0, //<-- 0.95, aplatizare dup� Y
		   0.5,    0, 1, 0, //<-- 0.5,   deplasare dup� X
		     0,    0, 0, 1
	};
	glMultMatrixd (s);
	glEnable(GL_TEXTURE_2D);

	glBindTexture(GL_TEXTURE_2D, texture);

	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
	glTexEnvi(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_DECAL);



    glBegin(GL_TRIANGLES);

	for (int j = 0; j < ns; j++)
    {
		//glNormal3dv(norms[j]);
		glTexCoord2d(0. , 0.5 );                    glVertex3d(0., 0., 0.);
		//glNormal3dv(norms[(j + 1) % ns]);
        glTexCoord2dv((double*)points[0][j]);       glVertex3dv(points[0][j]);
        glTexCoord2dv((double*)points[0][j + 1]);   glVertex3dv(points[0][(j + 1) % ns]);
	}
	for(int i = 0; i < nh - 1; i++)
    {
		for (int j = 0; j < ns; j++)
        {
			//glNormal3dv(norms[j]);
            glTexCoord2dv((double*)points[i][j]);                glVertex3dv((double*)points[i][j]);
            glTexCoord2dv((double*)points[i + 1][j]);            glVertex3dv((double*)points[i + 1][j]);
			//glNormal3dv(norms[(j + 1) % ns]);
            glTexCoord2dv((double*)points[i + 1][j + 1]);        glVertex3dv((double*)points[i + 1][(j + 1) % ns]);

			//glNormal3dv(norms[j]);
            glTexCoord2dv((double*)points[i][j]);                glVertex3dv((double*)points[i][j]);
			//glNormal3dv(norms[(j + 1) % ns]);
            glTexCoord2dv((double*)points[i + 1][j + 1 ]);       glVertex3dv((double*)points[i + 1][(j + 1) % ns]);
            glTexCoord2dv((double*)points[i][j + 1]);            glVertex3dv((double*)points[i][(j + 1) % ns]);
        }

    }

    glEnd();
	glDisable(GL_TEXTURE_2D);
	glPopMatrix();
}

