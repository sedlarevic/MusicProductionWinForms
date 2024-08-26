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
    public partial class UCEditProject : UserControl
    {
        public UCEditProject()
        {
            try
            {
                InitializeComponent();

                loadArtistCMB();
                loadMusicProducerCMB();
                
                loadProjectDgv();

                txtId.Enabled = false;
                txtName.Enabled = false;
                rtxtDescription.Enabled = false;
                cmbArtist.Enabled = false;
                cmbMusicProducer.Enabled = false;
                btnRemove.Enabled = false;
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
        private void dgvProjectCleanup()
        {
            if (dgvProject.Rows.Count > 0)
            {
                dgvProject.Columns["Id"].Visible = false;
                dgvProject.Columns["Values"].Visible = false;
                dgvProject.Columns["TableName"].Visible = false;
            }
        }
        private void dgvSongsOnProjectCleanup()
        {
            if (dgvSongsOnProject.Rows.Count > 0)
            {
                dgvSongsOnProject.Columns["Id"].Visible = false;
                dgvSongsOnProject.Columns["Values"].Visible = false;
                dgvSongsOnProject.Columns["TableName"].Visible = false;
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
            if (cmbArtist.SelectedIndex != -1)
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
        private void loadSongDgv()
        {
            SearchValue sv = new SearchValue();
            sv.Parameter = "Name";
            sv.Value = "";
            sv.Type = typeof(Song).AssemblyQualifiedName;
            dgvSong.DataSource = SearchSongController.Instance.SearchSong(sv);
            dgvSongCleanup();
        }
        private void loadProjectDgv()
        {
            SearchValue sv = new SearchValue();
            sv.Parameter = "Name";
            sv.Value = "";
            sv.Type = typeof(Project).AssemblyQualifiedName;
            dgvProject.DataSource = SearchProjectController.Instance.SearchProject(sv);
            dgvProjectCleanup();     
        }
        private void loadArtistCMB()
        {
            SearchValue sv = new SearchValue();
            sv.Parameter = "stageName";
            sv.Value = "";
            sv.Type = typeof(Artist).AssemblyQualifiedName;
            cmbArtist.DataSource = SearchArtistController.Instance.SearchArtist(sv);
            cmbArtist.DisplayMember = "StageName";
        }
        private void loadMusicProducerCMB()
        {
            SearchValue sv = new SearchValue();
            sv.Parameter = "stageName";
            sv.Value = "";
            sv.Type = typeof(MusicProducer).AssemblyQualifiedName;
            cmbMusicProducer.DataSource = SearchMusicProducerController.Instance.SearchMusicProducer(sv);
            cmbMusicProducer.DisplayMember = "StageName";
        }
        // ############################
        private Project loadProject(int idProject)
        {
            SearchValue sv = new SearchValue
            {
                Parameter = "Id",
                Value = idProject,
                Type = typeof(Project).AssemblyQualifiedName
            };
            BindingList<Project> project = (BindingList<Project>)SearchProjectController.Instance.SearchProject(sv);

            if (project != null && project.Count == 1)
            {
                return project.ElementAt(0);
            }
            if (project == null)
            {
                MessageBox.Show("Couldn't load project.", "Couldn't load project.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return null;
        }
        private void loadProjectDetails(Project project)
        {

            txtId.Text = project.Id.ToString();
            txtName.Text = project.Name;
            txtName.Enabled = true;
            rtxtDescription.Text = project.Description;
            rtxtDescription.Enabled = true;

            cmbArtist.Enabled = true;
            cmbArtist.SelectedItem = project.Artist;
            cmbArtist.DisplayMember = "StageName";

            cmbMusicProducer.Enabled = true;
            cmbMusicProducer.SelectedItem = project.MusicProducer;
            cmbMusicProducer.DisplayMember = "StageName";
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
        // ############################
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validation())
                {
                    MessageBox.Show("Unsuccessful edit of a project!","System was unsuccessful in editing a project",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }

                //editujemo prvo projekat
                if (dgvProject.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("Unsuccessful edit of a project!", "System was unsuccessful in editing a project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //pravimo novi projekat sa podacima novim
                DataGridViewRow dgvProjectRow = dgvProject.SelectedRows[0];
                int selectedProjectIndex = dgvProjectRow.Index;
                Project newProject = new Project();
                newProject.Id = Int32.Parse(txtId.Text);
                newProject.Name = txtName.Text;
                newProject.Description = rtxtDescription.Text;
                newProject.Artist = cmbArtist.SelectedItem as Artist;
                newProject.MusicProducer = cmbMusicProducer.SelectedItem as MusicProducer;
                newProject.CreationDate = (DateTime)dgvProjectRow.Cells["CreationDate"].Value;
                //uzimamo originalan projekat
                //Project originalProject = loadProject(Int32.Parse(dgvProjectRow.Cells["Id"].Value.ToString()));
                SearchValue sv = new SearchValue
                {
                    Parameter = "Id",
                    Value = Int32.Parse(dgvProjectRow.Cells["Id"].Value.ToString()),
                    Type = typeof(Project).AssemblyQualifiedName
                };
                Project originalProject = (Project)LoadProjectController.Instance.LoadProject(sv);
                //editujemo
                EditValue evProject = new EditValue();
                evProject.EditedValue = newProject;
                evProject.OriginalValue = originalProject;
                evProject.Type = typeof(Project).AssemblyQualifiedName;
                //ispitujemo da li je dobro prosao edit
                object resultEdit = EditProjectController.Instance.EditProject(evProject);
                if (resultEdit == null)
                {
                    MessageBox.Show("Unsuccessful edit of a project!", "System was unsuccessful in editing a project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //pravimo za editsong editvalue
                List<Song> songsOriginal = new List<Song>();
                List<Song> songsNew = new List<Song>();
                //uzimamo sve pesme koje su prvobitno na projektu
                foreach (DataGridViewRow row in dgvSong.SelectedRows)
                {
                    SearchValue sValue = new SearchValue()
                    {
                        Value = Int32.Parse(row.Cells["Id"].Value.ToString()),
                        Parameter = "Id",
                        Type = typeof(Song).AssemblyQualifiedName
                    };
                    
                    Song s = (Song)LoadSongController.Instance.LoadSong(sValue);
                    //Song s = row.DataBoundItem as Song;
                    songsOriginal.Add(s);
                }
                //uzimamo sve pesme koje su sad na projektu, nakon edita
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
                        Project = newProject
                    };
                    songsNew.Add(sNew);
                }
                //editujemo pesme
                EditValue evSong = new EditValue();
                evSong.OriginalValue = songsOriginal;
                evSong.EditedValue = songsNew;
                evSong.Type = typeof(Song).AssemblyQualifiedName;

                EditSongController.Instance.EditSong(evSong);
                loadSongDgv();
                
                //sada kada smo editovali i pesme i project, postavljamo sve pesme projekta u dgv
                SearchValue sValueForSongsOnProject = new SearchValue()
                {
                    Parameter = "Project",
                    Type = typeof(Song).AssemblyQualifiedName,
                    Value = newProject.Id
                };               
                dgvSongsOnProjectCleanup();
                loadSongDgv();
                loadProjectDgv();
                dgvSongsOnProject.DataSource = SearchSongController.Instance.SearchSong(sValueForSongsOnProject);
                dgvSongsOnProjectCleanup();
                dgvProject.Rows[selectedProjectIndex].Selected = true;
                List<int> selectedIndexes = new List<int>();
                foreach (DataGridViewRow row in dgvSongsOnProject.Rows)
                {
                    selectedIndexes.Add(Int32.Parse(row.Cells["Id"].Value.ToString()));
                }
                foreach (DataGridViewRow row in dgvSong.Rows)
                {
                    if (selectedIndexes.Contains(Int32.Parse(row.Cells["Id"].Value.ToString())))
                        row.Selected = true;
                    else
                        row.Selected = false;
                }
                MessageBox.Show("Successful edit of a project!", "System was successful in editing a project", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchValue sv = new SearchValue();
                sv.Parameter = "Name";
                sv.Value = txtSearch.Text;
                sv.Type = typeof(Project).AssemblyQualifiedName;
                dgvProject.DataSource = SearchProjectController.Instance.SearchProject(sv);
                dgvProjectCleanup();
                if (dgvProject.Rows.Count != 0)
                    MessageBox.Show("System found projects of desired value.");
                else
                {
                    MessageBox.Show("System can't find projects of desired value.", "System can't find projects of desired value.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadProjectDgv();
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
            try
            {
                if (dgvProject.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("Unsuccessful load of a project", "System unsuccessfully loaded the project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }     
                //ucitavamo song dgv
                SearchValue svSong = new SearchValue()
                {
                    Value = "",
                    Parameter = "Name",
                    Type = typeof(Song).AssemblyQualifiedName
                };
                dgvSong.DataSource = SearchSongController.Instance.SearchSong(svSong);
                dgvSongCleanup();
                //
                //uzimamo izabran projekat i loadujemo u textboxove i comboboxove
                DataGridViewRow selectedRow = dgvProject.SelectedRows[0];
                //Project project = loadProject(Int32.Parse(selectedRow.Cells["Id"].Value.ToString()));
                SearchValue svProject = new SearchValue
                {
                    Parameter = "Id",
                    Value = Int32.Parse(selectedRow.Cells["Id"].Value.ToString()),
                    Type = typeof(Project).AssemblyQualifiedName
                };
                Project project = (Project)LoadProjectController.Instance.LoadProject(svProject);
                if(project == null)
                {
                    MessageBox.Show("Unsuccessful load of a project", "System unsuccessfully loaded the project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                loadProjectDetails(project);
                //
                //ucitavamo pesme projekta
                SearchValue projectSongs = new SearchValue()
                {
                    Value = txtId.Text,
                    Parameter = "Project",
                    Type = typeof(Song).AssemblyQualifiedName
                };
                dgvSongsOnProject.DataSource = SearchSongController.Instance.SearchSong(projectSongs);
                dgvSongsOnProjectCleanup();
                //
                //postavljamo u listi pesama sve pesme projekta
                List<int> selectedIndexes = new List<int>();
                foreach (DataGridViewRow row in dgvSongsOnProject.Rows)
                {
                    selectedIndexes.Add(Int32.Parse(row.Cells["Id"].Value.ToString()));
                }
                foreach (DataGridViewRow row in dgvSong.Rows)
                {
                    if (selectedIndexes.Contains(Int32.Parse(row.Cells["Id"].Value.ToString())))
                        row.Selected = true;
                    else
                        row.Selected = false;
                }

                btnRemove.Enabled = true;
                MessageBox.Show("Successful load of a project", "System successfully loaded the project", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (ServerDisconnectedException ex)
            {
                MessageBox.Show("Server disconnected!");
                LoginController.Instance.frmLogin.Dispose();
                MainController.Instance.frmMain.Dispose();
                return;
            }
            

        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSongsOnProject.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("no rows selected");
                    return;
                }
                if(dgvSongsOnProject.Rows.Count <= 0)
                {
                    MessageBox.Show("no rows");
                    return;
                }
                //editovanje
                DataGridViewRow selected = dgvSongsOnProject.SelectedRows[0];
                //Song sOriginal = loadSong(Int32.Parse(selected.Cells["Id"].Value.ToString()));
                SearchValue sv = new SearchValue
                {
                    Parameter = "Id",
                    Value = Int32.Parse(selected.Cells["Id"].Value.ToString()),
                    Type = typeof(Song).AssemblyQualifiedName
                };
                Song sOriginal = (Song)LoadSongController.Instance.LoadSong(sv);
                Song sNew = new Song()
                {
                    Id = sOriginal.Id,
                    Name = sOriginal.Name,
                    BPM = sOriginal.BPM,
                    CreationDate = sOriginal.CreationDate,
                    Genre = sOriginal.Genre,
                    MusicProducer = sOriginal.MusicProducer,
                    Artist = sOriginal.Artist,
                    MusicVideo = sOriginal.MusicVideo,
                    Project = null
                };
                EditValue ev = new EditValue()
                {
                    EditedValue = sNew,
                    OriginalValue = sOriginal,
                    Type = typeof(Song).AssemblyQualifiedName
                };
                EditSongController.Instance.EditSong(ev);
                //ucitavanje pesama na projektu
                SearchValue evSongsOnProject = new SearchValue()
                {
                    Value = txtId.Text,
                    Parameter = "Project",
                    Type = typeof(Song).AssemblyQualifiedName
                };
                dgvSongsOnProject.DataSource = SearchSongController.Instance.SearchSong(evSongsOnProject);
                dgvSongsOnProjectCleanup();
                //postavljanje u listi svih pesama pesme koje pripadaju projektu
                loadSongDgv();
                List<int> selectedIndexes = new List<int>();
                foreach (DataGridViewRow row in dgvSongsOnProject.Rows)
                {
                    selectedIndexes.Add(Int32.Parse(row.Cells["Id"].Value.ToString()));
                }
                foreach (DataGridViewRow row in dgvSong.Rows)
                {
                    if (selectedIndexes.Contains(Int32.Parse(row.Cells["Id"].Value.ToString())))
                        row.Selected = true;
                    else
                        row.Selected = false;
                }

                return;
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
