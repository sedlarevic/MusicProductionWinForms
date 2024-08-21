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
    public partial class UCEditSong : UserControl
    {
        public UCEditSong()
        {
            try
            {
                InitializeComponent();

                txtBPM.Enabled = false;
                txtSongName.Enabled = false;
                txtSongId.Enabled = false;

                loadArtistCMB();
                cmbArtist.Enabled = false;
                cmbArtist.DisplayMember = "StageName";

                loadGenreCMB();
                cmbGenre.Enabled = false;

                loadMusicProducerCMB();
                cmbMusicProducer.Enabled = false;
                cmbMusicProducer.DisplayMember = "StageName";

                loadMusicVideoCMB();
                cmbMusicVideo.Enabled = false;
                cmbMusicVideo.DisplayMember = "Description";

                loadProjectCMB();
                cmbProject.Enabled = false;
                cmbProject.DisplayMember = "Name";

                loadSongDgv();
                
            }
            catch (ServerDisconnectedException ex)
            {
                MessageBox.Show("Server disconnected!");
                LoginController.Instance.frmLogin.Dispose();
                MainController.Instance.frmMain.Dispose();
                return;
            }
            

        }
        private void dgvSongCleanup()
        {
            if (dgvSong.Rows.Count > 0)
            {
                dgvSong.Columns["Id"].Visible = false;
                dgvSong.Columns["Values"].Visible = false;
                dgvSong.Columns["TableName"].Visible = false;
            }
        }
        private bool Validation()
        {
            bool b1, b2, b3, b4, b5;
            if (!String.IsNullOrEmpty(txtSongName.Text))
                b1 = true;
            else
            {
                b1 = false;
                MessageBox.Show("Name field empty!");
            }
            if (String.IsNullOrEmpty(txtBPM.Text) || !int.TryParse(txtBPM.Text, out int number))
            {
                b2 = false;
                MessageBox.Show("BPM field either empty or not a number!");
            }
            else
                b2 = true;
            if (cmbGenre.SelectedIndex != -1)
                b3 = true;
            else
            {
                b3 = false;
                MessageBox.Show("Genre not selected!");
            }
            if (cmbArtist.SelectedIndex != -1)
                b4 = true;
            else
            {
                b4 = false;
                MessageBox.Show("Artist not selected!");
            }
            if (cmbMusicProducer.SelectedIndex != -1)
                b5 = true;
            else
            {
                b5 = false;
                MessageBox.Show("Music Producer not selected!");
            }


            return b1 && b2 && b3 && b4 && b5;

        }
        private void loadMusicProducerCMB()
        {
            SearchValue sv = new SearchValue();
            sv.Parameter = "stageName";
            sv.Value = "";
            sv.Type = typeof(MusicProducer).AssemblyQualifiedName;
            cmbMusicProducer.DataSource = SearchMusicProducerController.Instance.SearchMusicProducer(sv);
        }
        private void loadMusicVideoCMB()
        {
            SearchValue sv = new SearchValue();
            sv.Parameter = "Name";
            sv.Value = "";
            sv.Type = typeof(MusicVideo).AssemblyQualifiedName;
            cmbMusicVideo.DataSource = SearchMusicVideoController.Instance.SearchMusicVideo(sv);
        }
        private void loadArtistCMB()
        {
            SearchValue sv = new SearchValue();
            sv.Parameter = "stageName";
            sv.Value = "";
            sv.Type = typeof(Artist).AssemblyQualifiedName;
            cmbArtist.DataSource = SearchArtistController.Instance.SearchArtist(sv);
        }
        private void loadProjectCMB()
        {
            SearchValue sv=new SearchValue();
            sv.Parameter = "Name";
            sv.Value = "";
            sv.Type = typeof(Project).AssemblyQualifiedName;
            cmbProject.DataSource=SearchProjectController.Instance.SearchProject(sv);
        }
        private void loadGenreCMB()
        {
            cmbGenre.DataSource = Enum.GetValues(typeof(SongGenre));
        }
        private void loadSongDgv()
        {
            SearchValue sv = new SearchValue();
            sv.Parameter = "Name";
            sv.Value = "";
            sv.Type = typeof(Song).AssemblyQualifiedName;
            dgvSong.DataSource = SearchSongController.Instance.SearchSong(sv);
            dgvSongCleanup();
        }
        private Song loadSong(int idSong)
        {
            SearchValue sv = new SearchValue
            {
                Parameter = "Id",
                Value = idSong,
                Type = typeof(Song).AssemblyQualifiedName
            };
            BindingList<Song> song = (BindingList<Song>)SearchSongController.Instance.SearchSong(sv);
            
            if (song != null && song.Count == 1)
            {
                return song.ElementAt(0);
            }
            if (song == null)
            {
                MessageBox.Show("Couldn't load song.", "Couldn't load song.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return null;
        }
        private void loadData(Song song)
        {
            DataGridViewRow selectedRow = dgvSong.SelectedRows[0];
            txtSongId.Text = song.Id.ToString();
            txtSongName.Text = song.Name;
            txtSongName.Enabled = true;

            txtBPM.Text = song.BPM.ToString();
            txtBPM.Enabled = true;

            cmbArtist.Enabled = true;
            cmbArtist.DisplayMember = "StageName";
            cmbArtist.SelectedItem = song.Artist;

            cmbMusicProducer.Enabled = true;
            cmbMusicProducer.DisplayMember = "StageName";
            cmbMusicProducer.SelectedItem = song.MusicProducer;

            cmbMusicVideo.Enabled = true;
            cmbMusicVideo.DisplayMember = "Name";
            cmbMusicVideo.SelectedItem = song.MusicVideo;

            cmbProject.Enabled = true;
            cmbProject.DisplayMember = "Name";
            cmbProject.SelectedItem = song.Project;

            cmbGenre.Enabled = true;
            cmbGenre.SelectedItem = song.Genre;

            btnEditSong.Enabled = true;
            MessageBox.Show("Successful load of a song", "Loading song successful..", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnEditSong_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validation())
                {
                    MessageBox.Show("Unsuccessful edit of a song", "Loading song unsuccessful..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //pravimo objekat klase song iz iz izabranog reda
                Song songOriginal = new Song();
                DataGridViewRow selectedRow = dgvSong.SelectedRows[0];
                songOriginal = loadSong(Int32.Parse(selectedRow.Cells["Id"].Value.ToString()));
                //pravimo objekat klase song iz podataka iz cmb-a, textboxova...
                Song songNew = new Song();
                songNew.Name = txtSongName.Text;
                songNew.Id = Int32.Parse(txtSongId.Text);
                songNew.BPM = Int32.Parse(txtBPM.Text);
                songNew.Artist = cmbArtist.SelectedItem as Artist;
                songNew.MusicProducer = cmbMusicProducer.SelectedItem as MusicProducer;
                songNew.MusicVideo = cmbMusicVideo.SelectedItem as MusicVideo;
                songNew.Project = cmbProject.SelectedItem as Project;
                songNew.Genre = (SongGenre)cmbGenre.SelectedItem;
                songNew.CreationDate = (DateTime)selectedRow.Cells["CreationDate"].Value;
                //edituijemo
                EditValue ev = new EditValue
                {
                    OriginalValue = songOriginal,
                    Type = typeof(Song).AssemblyQualifiedName,
                    EditedValue = songNew
                };
                EditSongController.Instance.EditSong(ev);
                //ucitavamo sve
                int indexOfSelectedRow = selectedRow.Index;
                loadSongDgv();
                 
                dgvSong.Rows[indexOfSelectedRow].Selected = true;
            }
            catch (ServerDisconnectedException ex)
            {
                MessageBox.Show("Server disconnected!");
                LoginController.Instance.frmLogin.Dispose();
                MainController.Instance.frmMain.Dispose();
                return;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchValue sv = new SearchValue()
                {
                    Parameter = "Name",
                    Value = txtSearch.Text,
                    Type = typeof(Song).AssemblyQualifiedName
                };
                dgvSong.DataSource = SearchSongController.Instance.SearchSong(sv);
                dgvSongCleanup();
                if(dgvSong.Rows.Count > 0)
                    MessageBox.Show("Successful search of songs", "Searching songs successful..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Unsuccessful search of songs", "Searching songs unsuccessful..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadSongDgv();
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
        private void btnLoad_Click(object sender, EventArgs e)
        { 
            if (dgvSong.SelectedRows.Count == 1 && dgvSong.SelectedRows[0]!=null)
            {
                //DataGridViewRow selectedRow = dgvSong.SelectedRows[0];
                //txtSongId.Text = selectedRow.Cells["Id"].Value.ToString();

                //txtSongName.Text = selectedRow.Cells["Name"].Value.ToString();
                //txtSongName.Enabled = true;

                //txtBPM.Text = selectedRow.Cells["BPM"].Value.ToString();
                //txtBPM.Enabled = true;

                //cmbArtist.Enabled = true;
                //Artist selectedArtist = selectedRow.Cells["Artist"].Value as Artist;
                //cmbArtist.DisplayMember = "StageName";
                //cmbArtist.SelectedItem = selectedArtist;

                //cmbMusicProducer.Enabled = true;
                //MusicProducer selectedProducer = selectedRow.Cells["MusicProducer"].Value as MusicProducer;
                //cmbMusicProducer.DisplayMember = "StageName";
                //cmbMusicProducer.SelectedItem = selectedProducer;

                //cmbMusicVideo.Enabled = true;
                //MusicVideo selectedVideo = selectedRow.Cells["MusicVideo"].Value as MusicVideo;
                //cmbMusicVideo.DisplayMember = "Name";
                //cmbMusicVideo.SelectedItem = selectedVideo;

                //cmbProject.Enabled = true;
                //Project selectedProject = selectedRow.Cells["Project"].Value as Project;
                //cmbProject.DisplayMember = "Name";
                //cmbProject.SelectedItem = selectedProject;

                //cmbGenre.Enabled = true;
                //SongGenre selectedGenre = (SongGenre)selectedRow.Cells["Genre"].Value;
                //cmbGenre.SelectedItem = selectedGenre;
                //btnEditSong.Enabled = true;
                //MessageBox.Show("Successful load of a song", "Loading song successful..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataGridViewRow selectedRow = dgvSong.SelectedRows[0];
                Song song = loadSong(Int32.Parse(selectedRow.Cells["Id"].Value.ToString()));
                if(song == null)
                {
                    MessageBox.Show("Unsuccessful load of a song", "Loading song unsuccessful..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                loadData(song);
                MessageBox.Show("Successful load of a song", "Loading song successful..", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Unsuccessful load of a song", "Loading song unsuccessful..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
