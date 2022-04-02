using System;
using System.Windows.Forms;
//Declarãm clasa principalã a aplicaþiei
class MDIApp
{
//Funcþia Main defineºte punctul de intrare al aplicaþiei
[STAThread]
public static void Main()
    {
        //Creãm fereastra principalã a aplicaþiei
        MainMDIWnd MainWnd = new MainMDIWnd();
        //Metoda Run lanseazã ciclul de prelucrare a mesajelor ºi
        //vizualizeazã fereastra pe ecran
        Application.Run(MainWnd);
    }
}
