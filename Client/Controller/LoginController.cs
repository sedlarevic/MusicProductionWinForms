using Common.Communication;
using Common.Domain;
using Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controller
{
    public class LoginController
    {

        private static LoginController instance;
        public FrmLogin frmLogin;
        public static LoginController Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoginController();
                return instance;
            }
        }      
        public void Login(LoginValue<MusicProducer> lvalue)
        {

            if (lvalue.Value == null || lvalue.Value.GetType() != typeof(MusicProducer))
            {
                MessageBox.Show("No such administrator class exists");
                return;
            }
            LogoutController.Instance.MusicProducer = lvalue.Value;
            Response res = Communication.Instance.Login(lvalue);
            if (res.Exception == null)
            {
                MessageBox.Show("Login Successful! ", $"Welcome {lvalue.Value.StageName}",MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmLogin.Visible = false;
                MainController.Instance.ShowFrmMain((MusicProducer)res.Result);   
            }
            else
            {
                if(res.Exception.Message=="Server closed")
                {
                    MessageBox.Show("Server closed! ", "Login unsuccessful, try again ",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    MainController.Instance.frmMain?.Dispose();
                    LoginController.Instance.frmLogin?.Dispose();
                }
                else
                {
                    MessageBox.Show(res.Exception.Message, "Login unsuccessful, try again ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void ShowFrmLogin()
        {
            try
            {
                Communication.Instance.Connect();
                frmLogin = new FrmLogin();
                LogoutController.Instance.frmLogin = frmLogin;
                Application.Run(frmLogin);
            }
            catch (SocketException ex)
            {
                Debug.Write(ex.ToString());
            }
            
        }


    }
}
