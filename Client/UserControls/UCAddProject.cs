using Client.Controller;
using Common.Domain;
using Common.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.UserControls
{
    public partial class UCAddProject : UserControl
    {
        public UCAddProject()
        {
            try
            {
                InitializeComponent();
                loadMusicProducerCMB();
                loadArtistCMB();
                loadSongDgv();
                
            }
            catch(ServerDisconnectedException ex)
            {
                MessageBox.Show("Server disconnected!");
                LoginController.Instance.frmLogin.Dispose();
                MainController.Instance.frmMain.Dispose();
                this.Dispose();
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

            bool b1, b2, b3, b4;
            if (!String.IsNullOrEmpty(txtName.Text))
                b1 = true;
            else
            {
                b1 = false;
                MessageBox.Show("Name field is empty!");
            }
            if (!String.IsNullOrEmpty(rtxtDescription.Text))
                b2 = true;
            else
            {
                b2 = false;
                MessageBox.Show("Description field is empty!");
            }
            if (cmbArtist.SelectedIndex!=-1)
                b3 = true;
            else
            {
                b3 = false;
                MessageBox.Show("Artist not selected!!");
            }
            if (cmbMusicProducer.SelectedIndex != -1)
                b4 = true;
            else
            {
                b4 = false;
                MessageBox.Show("Music producer not selected!");
            }



            return b1 && b2 && b3 && b4;
        }
        private void loadArtistCMB()
        {
            cmbArtist.DataSource = LoadAllArtistsController.Instance.LoadAllArtists();
            cmbArtist.DisplayMember = "StageName";
        }
        private void loadMusicProducerCMB()
        {
            cmbMusicProducer.DataSource = LoadAllMusicProducersController.Instance.LoadAllMusicProducers();
            cmbMusicProducer.DisplayMember = "StageName";
        }
        private void loadSongDgv()
        {          
            dgvSong.DataSource = LoadAllSongsController.Instance.LoadAllSongs();
            dgvSongCleanup();
        }
        private void btnAddProject_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validation())
                {
                    MessageBox.Show("Project can't be added, data is not correct","Project can't be added!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //pravimo projekat na osnovu podataka
                Project pr = new Project();
                pr.Name = txtName.Text;
                pr.Description = rtxtDescription.Text;
                pr.Artist = (Artist)cmbArtist.SelectedItem;
                pr.MusicProducer = (MusicProducer)cmbMusicProducer.SelectedItem;
                pr.CreationDate = DateTime.Now;
                //dodajemo projekat u bazu
                object o = AddProjectController.Instance.AddProject(pr);
                if (o == null)
                {
                    Debug.WriteLine("error while adding project");
                    return;
                }
                //zovemo projekte da uzmemo poslednjeg clana                
                BindingList<Project> result = (BindingList<Project>)LoadAllProjectsController.Instance.LoadAllProjects();
                //ovo je redudantno, ali radi tako da necu da diram za sad
                BindingList<Project> projects = new BindingList<Project>();

                foreach (object obj in result)
                {
                    if (obj.GetType() == typeof(Project))
                        projects.Add((Project)obj);
                }
                //sada kada smo dobili bindinglist projekti, uzimamo poslednji projekat
                Project latestAdded;
                if (projects != null)
                    latestAdded = projects.Last();
                else
                {
                    MessageBox.Show("Greska pri ucitavanju projekata");
                    return;
                }
                //uzimamo izabrane pesme, u songsnew dodajemo indeks poslednjeg dodatog projekta
                List<Song> songsOriginal = new List<Song>();
                List<Song> songsNew = new List<Song>();
                
                    foreach (DataGridViewRow row in dgvSong.SelectedRows)
                    {
                        Song s = row.DataBoundItem as Song;
                        songsOriginal.Add(s);
                    }
                    foreach (Song s in songsOriginal)
                    {
                        Song sNew = new Song
                        {
                            Id = s.Id,
                            Name = s.Name,
                            BPM = s.BPM,
                            CreationDate = s.CreationDate,
                            Genre = s.Genre,
                            MusicProducer = s.MusicProducer,
                            Artist = s.Artist,
                            MusicVideo = s.MusicVideo,
                            Project = latestAdded
                        };
                        songsNew.Add(sNew);
                    }
                    //editujemo
                    EditValue ev = new EditValue();
                    ev.OriginalValue = songsOriginal;
                    ev.EditedValue = songsNew;
                    ev.Type = typeof(Song).AssemblyQualifiedName;
                    EditSongController.Instance.EditSong(ev);
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
    }
}
