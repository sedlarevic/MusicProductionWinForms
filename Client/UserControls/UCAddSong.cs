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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Client.UserControls
{
    public partial class UCAddSong : UserControl
    {
        public UCAddSong()
        {
            try
            {
                InitializeComponent();
                loadArtistCMB();
                cmbArtist.DisplayMember = "StageName";
                loadGenresCMB();
                loadMusicVideoCMB();
                cmbMusicVideo.DisplayMember = "Name";
                cmbMusicVideo.SelectedIndex = cmbMusicVideo.Items.Count - 1;
               
                loadMusicProducerCMB();
                cmbMusicProducer.DisplayMember = "StageName";
                loadProjectCMB();
                cmbProject.DisplayMember = "Name";              
                cmbProject.SelectedIndex = cmbProject.Items.Count - 1;
                

            }
            catch (ServerDisconnectedException ex)
            {
                MessageBox.Show("Server disconnected!");
                LoginController.Instance.frmLogin.Dispose();
                MainController.Instance.frmMain.Dispose();
                return;
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
        private void loadArtistCMB()
        {
            cmbArtist.DataSource = LoadAllArtistsController.Instance.LoadAllArtists();
        }
        private void loadMusicVideoCMB()
        {   
            BindingList<MusicVideo> musicVideos = (BindingList<MusicVideo>)LoadAllMusicVideosController.Instance.LoadAllMusicVideos();
            musicVideos.Add(new MusicVideo() { Name = "(Empty)"});
            cmbMusicVideo.DataSource = musicVideos; 
        }
        private void loadGenresCMB()
        {
            cmbGenre.DataSource = Enum.GetValues(typeof(SongGenre));
        }
        private void loadMusicProducerCMB()
        {          
            cmbMusicProducer.DataSource = LoadAllMusicProducersController.Instance.LoadAllMusicProducers();
        }
        private void loadProjectCMB()
        {
            BindingList<Project> projects = (BindingList<Project>)LoadAllProjectsController.Instance.LoadAllProjects();
            projects.Add(new Project() { Name = "(Empty)"});
            cmbProject.DataSource = projects;
        }
        private void btnAddSong_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validation())
                {
                    MessageBox.Show("Song can't be added!", "Song can't be added, data is not correct", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    return;
                }
                //pravimo song iz unetih podataka
                Song s = new Song();
                s.Name = txtSongName.Text;
                s.BPM = Int32.Parse(txtBPM.Text);
                s.CreationDate = DateTime.Now;
                s.MusicProducer = (MusicProducer)cmbMusicProducer.SelectedItem;
                s.Artist = (Artist)cmbArtist.SelectedItem;
                s.Genre = (SongGenre)cmbGenre.SelectedItem;
                MusicVideo m = (MusicVideo)cmbMusicVideo.SelectedItem;
                if (m != null && !m.Name.Equals("(Empty)"))
                    s.MusicVideo = (MusicVideo)cmbMusicVideo.SelectedItem;
                
                Project p = (Project)cmbProject.SelectedItem;
                if (p != null && !p.Name.Equals("(Empty)"))
                    s.Project = (Project)cmbProject.SelectedItem;
                //kontroler za add song
                AddSongController.Instance.AddSong(s);
            }
            catch (ServerDisconnectedException ex)
            {
                MessageBox.Show("Server disconnected!");
                LoginController.Instance.frmLogin.Dispose();
                MainController.Instance.frmMain.Dispose();
                return;
            }
            
        }
    }
}
