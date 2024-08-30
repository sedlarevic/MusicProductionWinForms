namespace Client.UserControls
{
    partial class UCEditProject
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblSongs = new Label();
            btnLoad = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            dgvSong = new DataGridView();
            lblArtist = new Label();
            cmbArtist = new ComboBox();
            lblName = new Label();
            txtName = new TextBox();
            btnEdit = new Button();
            lblMusicProducer = new Label();
            cmbMusicProducer = new ComboBox();
            lblDescription = new Label();
            rtxtDescription = new RichTextBox();
            dgvSongsOnProject = new DataGridView();
            dgvProject = new DataGridView();
            btnRemove = new Button();
            lblAllSongs = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSongsOnProject).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProject).BeginInit();
            SuspendLayout();
            // 
            // lblSongs
            // 
            lblSongs.AutoSize = true;
            lblSongs.Location = new Point(548, 339);
            lblSongs.Name = "lblSongs";
            lblSongs.Size = new Size(134, 20);
            lblSongs.TabIndex = 47;
            lblSongs.Text = "songs on an album";
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(1255, 550);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(159, 78);
            btnLoad.TabIndex = 46;
            btnLoad.Text = "load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(1047, 597);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(159, 29);
            btnSearch.TabIndex = 45;
            btnSearch.Text = "search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(1047, 550);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(159, 27);
            txtSearch.TabIndex = 44;
            // 
            // dgvSong
            // 
            dgvSong.AllowUserToAddRows = false;
            dgvSong.AllowUserToDeleteRows = false;
            dgvSong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSong.Location = new Point(305, 46);
            dgvSong.Name = "dgvSong";
            dgvSong.ReadOnly = true;
            dgvSong.RowHeadersWidth = 51;
            dgvSong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSong.Size = new Size(627, 274);
            dgvSong.TabIndex = 43;
            // 
            // lblArtist
            // 
            lblArtist.AutoSize = true;
            lblArtist.Location = new Point(128, 370);
            lblArtist.Name = "lblArtist";
            lblArtist.Size = new Size(42, 20);
            lblArtist.TabIndex = 40;
            lblArtist.Text = "artist";
            // 
            // cmbArtist
            // 
            cmbArtist.FormattingEnabled = true;
            cmbArtist.Location = new Point(36, 393);
            cmbArtist.Name = "cmbArtist";
            cmbArtist.Size = new Size(220, 28);
            cmbArtist.TabIndex = 39;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(124, 94);
            lblName.Name = "lblName";
            lblName.Size = new Size(46, 20);
            lblName.TabIndex = 38;
            lblName.Text = "name";
            // 
            // txtName
            // 
            txtName.Location = new Point(72, 117);
            txtName.Name = "txtName";
            txtName.Size = new Size(159, 27);
            txtName.TabIndex = 37;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(36, 441);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(220, 29);
            btnEdit.TabIndex = 36;
            btnEdit.Text = "edit project";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // lblMusicProducer
            // 
            lblMusicProducer.AutoSize = true;
            lblMusicProducer.Location = new Point(94, 303);
            lblMusicProducer.Name = "lblMusicProducer";
            lblMusicProducer.Size = new Size(111, 20);
            lblMusicProducer.TabIndex = 35;
            lblMusicProducer.Text = "music producer";
            // 
            // cmbMusicProducer
            // 
            cmbMusicProducer.FormattingEnabled = true;
            cmbMusicProducer.Location = new Point(36, 326);
            cmbMusicProducer.Name = "cmbMusicProducer";
            cmbMusicProducer.Size = new Size(220, 28);
            cmbMusicProducer.TabIndex = 34;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(103, 147);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(83, 20);
            lblDescription.TabIndex = 33;
            lblDescription.Text = "description";
            // 
            // rtxtDescription
            // 
            rtxtDescription.Location = new Point(36, 170);
            rtxtDescription.Name = "rtxtDescription";
            rtxtDescription.Size = new Size(220, 120);
            rtxtDescription.TabIndex = 32;
            rtxtDescription.Text = "";
            // 
            // dgvSongsOnProject
            // 
            dgvSongsOnProject.AllowUserToAddRows = false;
            dgvSongsOnProject.AllowUserToDeleteRows = false;
            dgvSongsOnProject.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSongsOnProject.Location = new Point(305, 362);
            dgvSongsOnProject.MultiSelect = false;
            dgvSongsOnProject.Name = "dgvSongsOnProject";
            dgvSongsOnProject.ReadOnly = true;
            dgvSongsOnProject.RowHeadersWidth = 51;
            dgvSongsOnProject.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSongsOnProject.Size = new Size(627, 179);
            dgvSongsOnProject.TabIndex = 31;
            // 
            // dgvProject
            // 
            dgvProject.AllowUserToAddRows = false;
            dgvProject.AllowUserToDeleteRows = false;
            dgvProject.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProject.Location = new Point(966, 46);
            dgvProject.MultiSelect = false;
            dgvProject.Name = "dgvProject";
            dgvProject.ReadOnly = true;
            dgvProject.RowHeadersWidth = 51;
            dgvProject.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProject.Size = new Size(601, 495);
            dgvProject.TabIndex = 48;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(493, 549);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(254, 29);
            btnRemove.TabIndex = 49;
            btnRemove.Text = "remove selected song from project";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // lblAllSongs
            // 
            lblAllSongs.AutoSize = true;
            lblAllSongs.Location = new Point(577, 23);
            lblAllSongs.Name = "lblAllSongs";
            lblAllSongs.Size = new Size(67, 20);
            lblAllSongs.TabIndex = 50;
            lblAllSongs.Text = "all songs";
            // 
            // UCEditProject
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblAllSongs);
            Controls.Add(btnRemove);
            Controls.Add(dgvProject);
            Controls.Add(lblSongs);
            Controls.Add(btnLoad);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(dgvSong);
            Controls.Add(lblArtist);
            Controls.Add(cmbArtist);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(btnEdit);
            Controls.Add(lblMusicProducer);
            Controls.Add(cmbMusicProducer);
            Controls.Add(lblDescription);
            Controls.Add(rtxtDescription);
            Controls.Add(dgvSongsOnProject);
            Name = "UCEditProject";
            Size = new Size(1610, 637);
            ((System.ComponentModel.ISupportInitialize)dgvSong).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSongsOnProject).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProject).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSongs;
        private Button btnLoad;
        private Button btnSearch;
        private TextBox txtSearch;
        private DataGridView dgvSong;
        private Label lblArtist;
        private ComboBox cmbArtist;
        private Label lblName;
        private TextBox txtName;
        private Button btnEdit;
        private Label lblMusicProducer;
        private ComboBox cmbMusicProducer;
        private Label lblDescription;
        private RichTextBox rtxtDescription;
        private DataGridView dgvSongsOnProject;
        private DataGridView dgvProject;
        private Button btnRemove;
        private Label lblAllSongs;
    }
}
