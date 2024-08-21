
using Client.Controller;
using Common.Domain;
using Common.Exceptions;

namespace Client
{
    public partial class FrmLogin : Form
    {

        private MusicProducer MusicProducer { get; set; }

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MusicProducer producer = new MusicProducer()
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text,
            };
            MusicProducer = producer;
            LoginValue<MusicProducer> lv = new LoginValue<MusicProducer>()
            {
                Value = producer
            };
            try
            {
                LoginController.Instance.Login(lv);
            }
            catch(ServerDisconnectedException ex) 
            {
                MessageBox.Show("Server started!");
                this.Dispose();
            }
            
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
