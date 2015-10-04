using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ConductorManager
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

            Settings.Load();

            SplashForm splash = new SplashForm();
            splash.ShowDialog();

            Application.Run(new Form1());
        }
    }
}
