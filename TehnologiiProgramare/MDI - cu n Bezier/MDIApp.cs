using System;
using System.Windows.Forms;
//Declar�m clasa principal� a aplica�iei
class MDIApp
{
//Func�ia Main define�te punctul de intrare al aplica�iei
[STAThread]
public static void Main()
    {
        //Cre�m fereastra principal� a aplica�iei
        MainMDIWnd MainWnd = new MainMDIWnd();
        //Metoda Run lanseaz� ciclul de prelucrare a mesajelor �i
        //vizualizeaz� fereastra pe ecran
        Application.Run(MainWnd);
    }
}
