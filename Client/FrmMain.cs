using Client.Controller;
using Client.UserControls;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmMain : Form
    {
        private MusicProducer loggedMusicProducer;
        public FrmMain()
        {
            InitializeComponent();
        }

        public FrmMain(MusicProducer producer)
        {
            InitializeComponent();
            loggedMusicProducer = producer;
            lblWelcome.Text = "Welcome, " + producer.Username + "!";
            AttachEventHandlers();
        }
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainController.Instance.Logout();
        }
        private void AttachEventHandlers()
        {
            foreach (ToolStripItem item in menuStrip1.Items)
            {

                if (item is ToolStripMenuItem mainMenuItem)
                    foreach (ToolStripItem subItem in mainMenuItem.DropDownItems)
                    {
                        if (subItem is ToolStripMenuItem subMenuItem)
                        {
                            if (!subMenuItem.Name.Contains("ToolStrip"))
                                subMenuItem.Click += new EventHandler(MainController.Instance.ShowMenu);
                        }

                    }

            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

       
    }
}
