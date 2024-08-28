namespace Server
{
    public partial class FrmServer : Form
    {

        private Server server;
        public FrmServer()
        {
            InitializeComponent();
            lblServer.Text = "";
            btnStop.Enabled = false;      
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            server = new Server();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            server.Start();
            lblServer.Text = "Server pokrenut!";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            lblServer.Text = "Server zaustavljen!";
            server.Stop();
        }

        private void FrmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
            
        }
    }
}
