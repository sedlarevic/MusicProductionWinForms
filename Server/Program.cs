using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 namespace Server
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
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmServer());
        }
    }

}