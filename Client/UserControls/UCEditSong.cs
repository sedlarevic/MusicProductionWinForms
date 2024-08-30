using Client.Controller;
using Common.Domain;
using Common.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.UserControls
{
    public partial class UCEditSong : UserControl
    {
        public int loadedIndexOfSong;
        public int loadedIndexRowOfDgv;
        public UCEditSong()
        {

            try
            {
                InitializeComponent();
                loadedIndexOfSong = -1;
                txtBPM.Enabled = false;
                txtSongName.Enabled = false;
                //txtSongId.Enabled = false;

                loadArtistCMB();
                cmbArtist.Enabled = false;
                cmbArtist.DisplayMember = "StageName";
                cmbArtist.ValueMember = "Id";

                loadGenreCMB();
                cmbGenre.Enabled = false;

                loadMusicProducerCMB();
                cmbMusicProducer.Enabled = false;
                cmbMusicProducer.DisplayMember = "StageName";
                cmbMusicProducer.ValueMember = "Id";

                loadMusicVideoCMB();
                cmbMusicVideo.Enabled = false;
                cmbMusicVideo.DisplayMember = "Name";
                
                cmbMusicVideo.ValueMember = "Id";
                
                loadProjectCMB();
                cmbProject.Enabled = false;
                cmbProject.DisplayMember = "Name";
                
                cmbProject.ValueMember = "Id";               

                loadSongDgv();
                dgvSongCleanup();
                
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
            cmbMusicProducer.DataSource = LoadAllMusicProducersController.Instance.LoadAllMusicProducers();
        }
        private void loadMusicVideoCMB()
        {
            BindingList<MusicVideo> musicVideos = (BindingList<MusicVideo>)LoadAllMusicVideosController.Instance.LoadAllMusicVideos();
            musicVideos.Add(new MusicVideo() { Name = "(Empty)" });
            cmbMusicVideo.DataSource = musicVideos;
        }
        private void loadArtistCMB()
        {           
            cmbArtist.DataSource = LoadAllArtistsController.Instance.LoadAllArtists();
        }
        private void loadProjectCMB()
        {
            BindingList<Project> projects = (BindingList<Project>)LoadAllProjectsController.Instance.LoadAllProjects();
            projects.Add(new Project() { Name = "(Empty)" });
            cmbProject.DataSource = projects;
        }
        private void loadGenreCMB()
        {
            cmbGenre.DataSource = Enum.GetValues(typeof(SongGenre));
        }
        private void loadSongDgv()
        {
            dgvSong.DataSource = LoadAllSongsController.Instance.LoadAllSongs();
            //dgvSong.DataSource = upitSaJoinom();
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
            //txtSongId.Text = song.Id.ToString();
            txtSongName.Text = song.Name;
            txtSongName.Enabled = true;

            txtBPM.Text = song.BPM.ToString();
            txtBPM.Enabled = true;

            cmbArtist.DisplayMember = "StageName";
            cmbArtist.Enabled = true;
            //cmbArtist.SelectedItem = song.Artist;
            cmbArtist.SelectedValue = song.Artist.Id;

            cmbMusicProducer.DisplayMember = "StageName";
            cmbMusicProducer.Enabled = true;
            //cmbMusicProducer.SelectedItem = song.MusicProducer;
            cmbMusicProducer.SelectedValue = song.MusicProducer.Id;

            cmbMusicVideo.DisplayMember = "Name";
            cmbMusicVideo.Enabled = true;
            //cmbMusicVideo.SelectedItem = song.MusicVideo;
            if (song.MusicVideo != null && !song.MusicVideo.Name.Equals("(Empty)"))
                cmbMusicVideo.SelectedValue = song.MusicVideo.Id;
            else
                cmbMusicVideo.SelectedIndex = cmbMusicVideo.Items.Count-1;

            cmbProject.DisplayMember = "Name";
            cmbProject.Enabled = true;
            //cmbProject.SelectedItem = song.Project;
            if (song.Project != null && !song.Project.Name.Equals("Empty"))
                cmbProject.SelectedValue = song.Project.Id;
            else
                cmbProject.SelectedIndex = cmbProject.Items.Count-1;
            

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

                //pokusavam sa loadedint
                //DataGridViewRow selectedRow = dgvSong.SelectedRows[0];
                //songOriginal = loadSong(Int32.Parse(selectedRow.Cells["Id"].Value.ToString()));
                SearchValue sv = new SearchValue
                {
                    Parameter = "Id",
                    //Value = Int32.Parse(selectedRow.Cells["Id"].Value.ToString()),
                    Value = loadedIndexOfSong.ToString(),
                    Type = typeof(Song).AssemblyQualifiedName
                };
                songOriginal = (Song)LoadSongController.Instance.LoadSong(sv);
                //pravimo objekat klase song iz podataka iz cmb-a, textboxova...
                Song songNew = new Song();
                songNew.Name = txtSongName.Text;
                songNew.Id = Int32.Parse(songOriginal.Id.ToString());
                songNew.BPM = Int32.Parse(txtBPM.Text);
                songNew.Artist = cmbArtist.SelectedItem as Artist;
                songNew.MusicProducer = cmbMusicProducer.SelectedItem as MusicProducer;
                MusicVideo m = (MusicVideo)cmbMusicVideo.SelectedItem;
                if (m != null && !m.Name.Equals("(Empty)"))
                    songNew.MusicVideo = cmbMusicVideo.SelectedItem as MusicVideo;
                Project p = (Project)cmbProject.SelectedItem;
                if (p != null && !p.Name.Equals("(Empty)"))
                    songNew.Project = cmbProject.SelectedItem as Project;
                songNew.Genre = (SongGenre)cmbGenre.SelectedItem;
                songNew.CreationDate = songOriginal.CreationDate;
                //edituijemo
                EditValue ev = new EditValue
                {
                    OriginalValue = songOriginal,
                    Type = typeof(Song).AssemblyQualifiedName,
                    EditedValue = songNew
                };
                EditSongController.Instance.EditSong(ev);
                //ucitavamo sve
                
                loadSongDgv();
                 
                dgvSong.Rows[loadedIndexRowOfDgv].Selected = true;
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
                DataGridViewRow selectedRow = dgvSong.SelectedRows[0];
                SearchValue sv = new SearchValue
                {
                    Parameter = "Id",
                    Value = Int32.Parse(selectedRow.Cells["Id"].Value.ToString()),
                    Type = typeof(Song).AssemblyQualifiedName
                };
                Song song = (Song)LoadSongController.Instance.LoadSong(sv);
                
                if(song == null)
                {
                    MessageBox.Show("Unsuccessful load of a song", "Loading song unsuccessful..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                loadData(song);
                loadedIndexOfSong = song.Id;
                loadedIndexRowOfDgv = selectedRow.Index;
            }
            else
            {
                MessageBox.Show("Unsuccessful load of a song", "Loading song unsuccessful..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}
