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
    public partial class UCEditArtist : UserControl
    {
        public int loadedIndexOfArtist;
        public int loadedIndexRowOfDgv;
        public UCEditArtist()
        {
            try
            {
                InitializeComponent();
                btnEdit.Enabled = false;
                txtFirstName.Enabled = false;
                txtLastName.Enabled = false;
                txtStageName.Enabled = false;
                //txtId.Enabled = false;
                DgvLoad();
                
            }catch (ServerDisconnectedException ex)
            {
                MessageBox.Show("Server disconnected!");
                LoginController.Instance.frmLogin.Dispose();
                MainController.Instance.frmMain.Dispose();
                this.Dispose();
                return;
            }
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
        private void DgvLoad()
        {
            var ds = LoadAllArtistsController.Instance.LoadAllArtists();
            if (ds != null)
            {
                
                dgvArtist.DataSource = ds;                
                dgvCleanup();

            }
        }
        private void dgvCleanup()
        {
            if (dgvArtist.Rows.Count>0)
            {
                dgvArtist.Columns["Id"].Visible = false;
                dgvArtist.Columns["Values"].Visible = false;
                dgvArtist.Columns["TableName"].Visible = false;
            }           
        }
        private object SearchArtist(string parameter = "")
        {      
            SearchValue searchValue = new SearchValue()
                {
                    Type = typeof(Artist).AssemblyQualifiedName,
                    Value = parameter,
                    Parameter = "StageName"
                };
            return SearchArtistController.Instance.SearchArtist(searchValue);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchValue sv = new SearchValue()
                {
                Type = typeof(Artist).AssemblyQualifiedName,
                Value = txtSearch.Text,
                Parameter = "StageName"
                };
                dgvArtist.Columns.Clear();
                dgvArtist.DataSource = SearchArtistController.Instance.SearchArtist(sv);
                dgvCleanup();
                if (dgvArtist.Rows.Count!=0)
                    MessageBox.Show("System found artists of desired value.");
                else
                {
                    MessageBox.Show("System can't find artists of desired value.", "System can't find artists of desired value.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DgvLoad();
                }
                    
                
            
            }
            catch (ServerDisconnectedException ex)
            {
                MessageBox.Show("Server disconnected!");
                LoginController.Instance.frmLogin.Dispose();
                MainController.Instance.frmMain.Dispose();                
                return;
            }
        }
        //###################
        private Artist loadArtist(int idArtist)
        {
            SearchValue sv = new SearchValue
            {
                Parameter = "Id",
                Value = idArtist,
                Type = typeof(Artist).AssemblyQualifiedName
            };
            BindingList<Artist> a = (BindingList<Artist>)SearchArtistController.Instance.SearchArtist(sv);
            Artist artist = null;
            if(a!=null && a.Count == 1)
            {
               return a.ElementAt(0);
            }
            if (artist == null)
            {
                MessageBox.Show("Couldn't load artist.", "Couldn't load artist.",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
            return null;
            
        }
        private void loadData(Artist artist)
        {
            txtFirstName.Enabled = true;
            txtFirstName.Text = artist.FirstName;
            txtLastName.Enabled = true;
            txtLastName.Text = artist.LastName;
            txtStageName.Enabled = true;
            txtStageName.Text = artist.StageName;
            //txtId.Text = artist.Id.ToString();
            btnEdit.Enabled = true;
        }
        //###################
        private void btnLoadArtist_Click(object sender, EventArgs e)
        {
            if (dgvArtist.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvArtist.SelectedRows[0];
                if (selectedRow != null) 
                {
                    SearchValue sv = new SearchValue
                    {
                        Parameter = "Id",
                        Value = Int32.Parse(selectedRow.Cells["Id"].Value.ToString()),
                        Type = typeof(Artist).AssemblyQualifiedName
                    };
                    Artist a = (Artist)LoadArtistController.Instance.LoadArtist(sv);
                    if (a == null)
                    {
                        MessageBox.Show("System loaded the artist.", "System loaded the artist.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    loadData(a);
                    MessageBox.Show("System loaded the artist.", "System loaded the artist.",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    loadedIndexOfArtist = a.Id;
                    loadedIndexRowOfDgv = selectedRow.Index;
                    return;
                }
                MessageBox.Show("System couldn't load the artist.", "System couldn't load the artist.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("System couldn't load the artist.", "System couldn't load the artist.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validation())
                {
                    MessageBox.Show("Try again!");
                    return;
                }
                //kreiramo artista preko teksta iz textboxova
                
                //uzimamo artista koji je izabran iz dgv-a
                
                //Artist artistOriginal = loadArtist(Int32.Parse(selectedRow.Cells["Id"].Value.ToString()));
                SearchValue sv = new SearchValue
                {
                    Parameter = "Id",
                    Value = loadedIndexOfArtist,
                    Type = typeof(Artist).AssemblyQualifiedName
                };
                Artist artistOriginal = (Artist)LoadArtistController.Instance.LoadArtist(sv);
                Artist artistNew = new Artist()
                {
                    Id = Int32.Parse(artistOriginal.Id.ToString()),
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    StageName = txtStageName.Text,
                };
                //editujemo izabranog artista
                EditValue ev = new EditValue
                {
                    OriginalValue = artistOriginal,
                    Type = typeof(Artist).AssemblyQualifiedName,
                    EditedValue = artistNew
                };
                EditArtistController.Instance.EditArtist(ev);
                //ucitavamo dgv opet
                DgvLoad();                
                dgvArtist.Rows[loadedIndexRowOfDgv].Selected = true;
            }
            catch(ServerDisconnectedException ex)
            {
                MessageBox.Show("Server disconnected!");
                LoginController.Instance.frmLogin.Dispose();
                MainController.Instance.frmMain.Dispose();
                return;
            }
        }
            
    }
}

