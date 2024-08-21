namespace Client.UserControls
{
    partial class UCEditSong
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
            lblId = new Label();
            txtSongId = new TextBox();
            lblMusicProducer = new Label();
            cmbMusicProducer = new ComboBox();
            lblMusicVideo = new Label();
            cmbMusicVideo = new ComboBox();
            btnEditSong = new Button();
            lblArtist = new Label();
            cmbArtist = new ComboBox();
            lblSongGenre = new Label();
            cmbGenre = new ComboBox();
            lblBPM = new Label();
            txtBPM = new TextBox();
            lblName = new Label();
            txtSongName = new TextBox();
            btnLoad = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            dgvSong = new DataGridView();
            lblProject = new Label();
            cmbProject = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvSong).BeginInit();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(107, 28);
            lblId.Name = "lblId";
            lblId.Size = new Size(22, 20);
            lblId.TabIndex = 50;
            lblId.Text = "id";
            // 
            // txtSongId
            // 
            txtSongId.Location = new Point(39, 51);
            txtSongId.Name = "txtSongId";
            txtSongId.Size = new Size(151, 27);
            txtSongId.TabIndex = 49;
            // 
            // lblMusicProducer
            // 
            lblMusicProducer.AutoSize = true;
            lblMusicProducer.Location = new Point(59, 335);
            lblMusicProducer.Name = "lblMusicProducer";
            lblMusicProducer.Size = new Size(111, 20);
            lblMusicProducer.TabIndex = 48;
            lblMusicProducer.Text = "music producer";
            // 
            // cmbMusicProducer
            // 
            cmbMusicProducer.FormattingEnabled = true;
            cmbMusicProducer.Location = new Point(39, 358);
            cmbMusicProducer.Name = "cmbMusicProducer";
            cmbMusicProducer.Size = new Size(151, 28);
            cmbMusicProducer.TabIndex = 47;
            // 
            // lblMusicVideo
            // 
            lblMusicVideo.AutoSize = true;
            lblMusicVideo.Location = new Point(74, 407);
            lblMusicVideo.Name = "lblMusicVideo";
            lblMusicVideo.Size = new Size(88, 20);
            lblMusicVideo.TabIndex = 46;
            lblMusicVideo.Text = "music video";
            // 
            // cmbMusicVideo
            // 
            cmbMusicVideo.FormattingEnabled = true;
            cmbMusicVideo.Location = new Point(39, 430);
            cmbMusicVideo.Name = "cmbMusicVideo";
            cmbMusicVideo.Size = new Size(151, 28);
            cmbMusicVideo.TabIndex = 45;
            // 
            // btnEditSong
            // 
            btnEditSong.Location = new Point(39, 543);
            btnEditSong.Name = "btnEditSong";
            btnEditSong.Size = new Size(151, 29);
            btnEditSong.TabIndex = 44;
            btnEditSong.Text = "edit song";
            btnEditSong.UseVisualStyleBackColor = true;
            btnEditSong.Click += btnEditSong_Click;
            // 
            // lblArtist
            // 
            lblArtist.AutoSize = true;
            lblArtist.Location = new Point(90, 266);
            lblArtist.Name = "lblArtist";
            lblArtist.Size = new Size(42, 20);
            lblArtist.TabIndex = 43;
            lblArtist.Text = "artist";
            // 
            // cmbArtist
            // 
            cmbArtist.FormattingEnabled = true;
            cmbArtist.Location = new Point(39, 289);
            cmbArtist.Name = "cmbArtist";
            cmbArtist.Size = new Size(151, 28);
            cmbArtist.TabIndex = 42;
            // 
            // lblSongGenre
            // 
            lblSongGenre.AutoSize = true;
            lblSongGenre.Location = new Point(74, 201);
            lblSongGenre.Name = "lblSongGenre";
            lblSongGenre.Size = new Size(83, 20);
            lblSongGenre.TabIndex = 41;
            lblSongGenre.Text = "song genre";
            // 
            // cmbGenre
            // 
            cmbGenre.FormattingEnabled = true;
            cmbGenre.Location = new Point(39, 224);
            cmbGenre.Name = "cmbGenre";
            cmbGenre.Size = new Size(151, 28);
            cmbGenre.TabIndex = 40;
            // 
            // lblBPM
            // 
            lblBPM.AutoSize = true;
            lblBPM.Location = new Point(90, 141);
            lblBPM.Name = "lblBPM";
            lblBPM.Size = new Size(39, 20);
            lblBPM.TabIndex = 39;
            lblBPM.Text = "BPM";
            // 
            // txtBPM
            // 
            txtBPM.Location = new Point(39, 164);
            txtBPM.Name = "txtBPM";
            txtBPM.Size = new Size(151, 27);
            txtBPM.TabIndex = 38;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(75, 81);
            lblName.Name = "lblName";
            lblName.Size = new Size(82, 20);
            lblName.TabIndex = 37;
            lblName.Text = "song name";
            // 
            // txtSongName
            // 
            txtSongName.Location = new Point(39, 104);
            txtSongName.Name = "txtSongName";
            txtSongName.Size = new Size(151, 27);
            txtSongName.TabIndex = 36;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(248, 321);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 56);
            btnLoad.TabIndex = 35;
            btnLoad.Text = "load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(248, 265);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 34;
            btnSearch.Text = "search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(230, 232);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(125, 27);
            txtSearch.TabIndex = 33;
            // 
            // dgvSong
            // 
            dgvSong.AllowUserToAddRows = false;
            dgvSong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSong.Location = new Point(361, 84);
            dgvSong.MultiSelect = false;
            dgvSong.Name = "dgvSong";
            dgvSong.ReadOnly = true;
            dgvSong.RowHeadersWidth = 51;
            dgvSong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSong.Size = new Size(837, 435);
            dgvSong.TabIndex = 32;
            // 
            // lblProject
            // 
            lblProject.AutoSize = true;
            lblProject.Location = new Point(88, 474);
            lblProject.Name = "lblProject";
            lblProject.Size = new Size(56, 20);
            lblProject.TabIndex = 52;
            lblProject.Text = "project";
            // 
            // cmbProject
            // 
            cmbProject.FormattingEnabled = true;
            cmbProject.Location = new Point(39, 499);
            cmbProject.Name = "cmbProject";
            cmbProject.Size = new Size(151, 28);
            cmbProject.TabIndex = 51;
            // 
            // UCEditSong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblProject);
            Controls.Add(cmbProject);
            Controls.Add(lblId);
            Controls.Add(txtSongId);
            Controls.Add(lblMusicProducer);
            Controls.Add(cmbMusicProducer);
            Controls.Add(lblMusicVideo);
            Controls.Add(cmbMusicVideo);
            Controls.Add(btnEditSong);
            Controls.Add(lblArtist);
            Controls.Add(cmbArtist);
            Controls.Add(lblSongGenre);
            Controls.Add(cmbGenre);
            Controls.Add(lblBPM);
            Controls.Add(txtBPM);
            Controls.Add(lblName);
            Controls.Add(txtSongName);
            Controls.Add(btnLoad);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(dgvSong);
            Name = "UCEditSong";
            Size = new Size(1236, 601);
            ((System.ComponentModel.ISupportInitialize)dgvSong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblId;
        private TextBox txtSongId;
        private Label lblMusicProducer;
        private ComboBox cmbMusicProducer;
        private Label lblMusicVideo;
        private ComboBox cmbMusicVideo;
        private Button btnEditSong;
        private Label lblArtist;
        private ComboBox cmbArtist;
        private Label lblSongGenre;
        private ComboBox cmbGenre;
        private Label lblBPM;
        private TextBox txtBPM;
        private Label lblName;
        private TextBox txtSongName;
        private Button btnLoad;
        private Button btnSearch;
        private TextBox txtSearch;
        private DataGridView dgvSong;
        private Label lblProject;
        private ComboBox cmbProject;
    }
}
