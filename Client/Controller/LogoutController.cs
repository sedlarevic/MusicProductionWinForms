using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controller
{
    public class LogoutController
    {

        private static LogoutController instance;
        public MusicProducer MusicProducer { get; set; }
        public FrmLogin frmLogin;
        public static LogoutController Instance
        {

            get 
            {
            if(instance == null)
               instance = new LogoutController();
            return instance;
            } 
        
        }
        public void Logout()
        {
            Console.WriteLine("Logoutovanje korisnika: " + MusicProducer.Username);

            Response res = Communication.Instance.Logout(MusicProducer);
            if (res.Exception == null)
            {
                frmLogin.Visible = true;
            }
            else
            {
                MessageBox.Show(res.Exception.Message);
                if (res.Exception.Message == "Server closed")
                {
                    MessageBox.Show("Server closed");
                    MainController.Instance.frmMain.Dispose();
                    LoginController.Instance.frmLogin.Dispose();
                }
            }

        }



    }

    }

