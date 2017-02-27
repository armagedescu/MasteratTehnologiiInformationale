using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PrelucrareaSemnalelorDigitale
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Console.WriteLine("salut");
            Application.Run(new Form1());
        }
    }
}
