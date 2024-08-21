using Client.Controller;
using Common.Exceptions;
using System.Diagnostics;

namespace Client
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
   
            try
            {
                LoginController.Instance.ShowFrmLogin();
            }
            catch(ServerDisconnectedException ex)
            {
                Debug.Write(ex.Message);
                MessageBox.Show("Server je pao");
            }
            
        }
    }
}