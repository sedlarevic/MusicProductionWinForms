using Client.Controller;
using Common.Domain;
using Common.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.UserControls
{
    public partial class UCAddArtist : UserControl
    {
        public UCAddArtist()
        {
            InitializeComponent();
            AddArtistController.Instance.AddArtistForm = this;

        }
            
        private bool Validation()
        {

            bool b1, b2, b3;
            if (!String.IsNullOrEmpty(txtFirstName.Text))
                b1 = true;
            else
            {
                b1 = false;
                MessageBox.Show("First name field is empty!");
            }
            if (!String.IsNullOrEmpty(txtLastName.Text))
                b2 = true;
            else
            {
                b2 = false;
                MessageBox.Show("Last name field is empty!");
            }
            if (!String.IsNullOrEmpty(txtStageName.Text))
                b3 = true;
            else
            {
                b3 = false;
                MessageBox.Show("Stage name field is empty!");
            }



            return b1 && b2 && b3;
        }

        private void btnAddArtist_Click(object sender, EventArgs e)
        {
            if (Validation())
                AddArtist();
            else
                MessageBox.Show("Try again");
        }
        private void AddArtist()
        {
            try
            {
                Artist a = new Artist();
                a.FirstName = txtFirstName.Text;
                a.LastName = txtLastName.Text;
                a.StageName = txtStageName.Text;
                AddArtistController.Instance.AddArtist(a);
            }
            catch (ServerDisconnectedException ex)
            {
                MessageBox.Show("Server disconnected!");
                LoginController.Instance.frmLogin.Dispose();
                MainController.Instance.frmMain.Dispose();
                this.Dispose();
                return;
            }
        }

       
    }
}
