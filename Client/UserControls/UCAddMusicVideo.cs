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
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.UserControls
{
    public partial class UCAddMusicVideo : UserControl
    {
        public UCAddMusicVideo()
        {
            try
            {
                InitializeComponent();
                loadSongDgv();                
                loadDirectorCMB();
                cmbDirector.DisplayMember = "stageName";
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

            bool b1, b2, b3;
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
            if (cmbDirector.SelectedIndex != -1)
                b3 = true;
            else
            {
                b3 = false;
                MessageBox.Show("Director not selected!!");
            }

            return b1 && b2 && b3;
        }
        private void loadSongDgv()
        {
            SearchValue sv = new SearchValue()
            {
                Type = typeof(Song).AssemblyQualifiedName,
                Value = null,
                Parameter = "MusicVideo"
            };
            dgvSong.DataSource = SearchSongController.Instance.SearchSong(sv);
            dgvSongCleanup();
        }
        private void loadDirectorCMB()
        {          
            cmbDirector.DataSource = LoadAllDirectorsController.Instance.LoadAllDirectors();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validation())
                {
                    MessageBox.Show("Music video can't be added!", "Adding music video unsuccessful.. Try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //pravimo objekat klase musicvideo na osnovu unetih podataka
                MusicVideo mv = new MusicVideo();
                mv.Name = txtName.Text;
                mv.Description = rtxtDescription.Text;
                mv.Director = (Director)cmbDirector.SelectedItem;
                mv.CreationDate = DateTime.Now;
                //dodajemo muzicki video u bazu
                object o = AddMusicVideoController.Instance.AddMusicVideo(mv);
                if (o == null)
                {
                    Debug.Write("error while adding music video");
                    return;
                }
                //zovemo muzicke videe sve da bismo uzeli poslednjeg clana
                SearchValue sv = new SearchValue();
                sv.Parameter = "Name";
                sv.Value = "";
                sv.Type = typeof(MusicVideo).AssemblyQualifiedName;
                //BindingList<MusicVideo> result = (BindingList<MusicVideo>)SearchMusicVideoController.Instance.SearchMusicVideo(sv);
                BindingList<MusicVideo> result = (BindingList<MusicVideo>)LoadAllMusicVideosController.Instance.LoadAllMusicVideos();
                //ovo ispod je redudantno ali vrv radi tako da sam ostavio za sad
                BindingList<MusicVideo> musicVideos = new BindingList<MusicVideo>();
                foreach (object obj in result)
                {
                    if (obj.GetType() == typeof(MusicVideo))
                        musicVideos.Add((MusicVideo)obj);
                }
                //uzimamo poslednjeg clana
                MusicVideo latestAdded;
                if (musicVideos != null)
                    latestAdded = musicVideos.Last();
                else
                {
                    MessageBox.Show("Music video can't be added!", "Adding music video unsuccessful.. Try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //uzimamo izabrane pesme, u songsnew dodajemo indeks poslednjeg dodatog muzickog videa
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
                        Project = s.Project,
                        MusicVideo = latestAdded,
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
                this.Dispose();
                return;
            }
            
        }
    }
}
