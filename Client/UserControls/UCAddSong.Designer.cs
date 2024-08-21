namespace Client.UserControls
{
    partial class UCAddSong
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
            lblMusicProducer = new Label();
            cmbMusicProducer = new ComboBox();
            lblMusicVideo = new Label();
            cmbMusicVideo = new ComboBox();
            btnAddSong = new Button();
            lblArtist = new Label();
            cmbArtist = new ComboBox();
            lblSongGenre = new Label();
            cmbGenre = new ComboBox();
            lblBPM = new Label();
            txtBPM = new TextBox();
            lblName = new Label();
            txtSongName = new TextBox();
            lblProject = new Label();
            cmbProject = new ComboBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // lblMusicProducer
            // 
            lblMusicProducer.AutoSize = true;
            lblMusicProducer.Location = new Point(116, 270);
            lblMusicProducer.Name = "lblMusicProducer";
            lblMusicProducer.Size = new Size(111, 20);
            lblMusicProducer.TabIndex = 29;
            lblMusicProducer.Text = "music producer";
            // 
            // cmbMusicProducer
            // 
            cmbMusicProducer.FormattingEnabled = true;
            cmbMusicProducer.Location = new Point(96, 293);
            cmbMusicProducer.Name = "cmbMusicProducer";
            cmbMusicProducer.Size = new Size(151, 28);
            cmbMusicProducer.TabIndex = 28;
            // 
            // lblMusicVideo
            // 
            lblMusicVideo.AutoSize = true;
            lblMusicVideo.Location = new Point(131, 342);
            lblMusicVideo.Name = "lblMusicVideo";
            lblMusicVideo.Size = new Size(88, 20);
            lblMusicVideo.TabIndex = 27;
            lblMusicVideo.Text = "music video";
            // 
            // cmbMusicVideo
            // 
            cmbMusicVideo.FormattingEnabled = true;
            cmbMusicVideo.Location = new Point(96, 365);
            cmbMusicVideo.Name = "cmbMusicVideo";
            cmbMusicVideo.Size = new Size(151, 28);
            cmbMusicVideo.TabIndex = 26;
            // 
            // btnAddSong
            // 
            btnAddSong.Location = new Point(96, 492);
            btnAddSong.Name = "btnAddSong";
            btnAddSong.Size = new Size(151, 29);
            btnAddSong.TabIndex = 25;
            btnAddSong.Text = "add song";
            btnAddSong.UseVisualStyleBackColor = true;
            btnAddSong.Click += btnAddSong_Click;
            // 
            // lblArtist
            // 
            lblArtist.AutoSize = true;
            lblArtist.Location = new Point(147, 201);
            lblArtist.Name = "lblArtist";
            lblArtist.Size = new Size(42, 20);
            lblArtist.TabIndex = 24;
            lblArtist.Text = "artist";
            // 
            // cmbArtist
            // 
            cmbArtist.FormattingEnabled = true;
            cmbArtist.Location = new Point(96, 224);
            cmbArtist.Name = "cmbArtist";
            cmbArtist.Size = new Size(151, 28);
            cmbArtist.TabIndex = 23;
            // 
            // lblSongGenre
            // 
            lblSongGenre.AutoSize = true;
            lblSongGenre.Location = new Point(131, 136);
            lblSongGenre.Name = "lblSongGenre";
            lblSongGenre.Size = new Size(83, 20);
            lblSongGenre.TabIndex = 22;
            lblSongGenre.Text = "song genre";
            // 
            // cmbGenre
            // 
            cmbGenre.FormattingEnabled = true;
            cmbGenre.Location = new Point(96, 159);
            cmbGenre.Name = "cmbGenre";
            cmbGenre.Size = new Size(151, 28);
            cmbGenre.TabIndex = 21;
            // 
            // lblBPM
            // 
            lblBPM.AutoSize = true;
            lblBPM.Location = new Point(147, 76);
            lblBPM.Name = "lblBPM";
            lblBPM.Size = new Size(39, 20);
            lblBPM.TabIndex = 20;
            lblBPM.Text = "BPM";
            // 
            // txtBPM
            // 
            txtBPM.Location = new Point(96, 99);
            txtBPM.Name = "txtBPM";
            txtBPM.Size = new Size(151, 27);
            txtBPM.TabIndex = 19;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(132, 16);
            lblName.Name = "lblName";
            lblName.Size = new Size(82, 20);
            lblName.TabIndex = 18;
            lblName.Text = "song name";
            // 
            // txtSongName
            // 
            txtSongName.Location = new Point(96, 39);
            txtSongName.Name = "txtSongName";
            txtSongName.Size = new Size(151, 27);
            txtSongName.TabIndex = 17;
            // 
            // lblProject
            // 
            lblProject.AutoSize = true;
            lblProject.Location = new Point(144, 414);
            lblProject.Name = "lblProject";
            lblProject.Size = new Size(56, 20);
            lblProject.TabIndex = 31;
            lblProject.Text = "project";
            // 
            // cmbProject
            // 
            cmbProject.FormattingEnabled = true;
            cmbProject.Location = new Point(96, 438);
            cmbProject.Name = "cmbProject";
            cmbProject.Size = new Size(151, 28);
            cmbProject.TabIndex = 30;
            // 
            // button1
            // 
            button1.Location = new Point(96, 489);
            button1.Name = "button1";
            button1.Size = new Size(151, 29);
            button1.TabIndex = 25;
            button1.Text = "add song";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnAddSong_Click;
            // 
            // UCAddSong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblProject);
            Controls.Add(cmbProject);
            Controls.Add(lblMusicProducer);
            Controls.Add(cmbMusicProducer);
            Controls.Add(lblMusicVideo);
            Controls.Add(cmbMusicVideo);
            Controls.Add(button1);
            Controls.Add(btnAddSong);
            Controls.Add(lblArtist);
            Controls.Add(cmbArtist);
            Controls.Add(lblSongGenre);
            Controls.Add(cmbGenre);
            Controls.Add(lblBPM);
            Controls.Add(txtBPM);
            Controls.Add(lblName);
            Controls.Add(txtSongName);
            Name = "UCAddSong";
            Size = new Size(340, 557);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMusicProducer;
        private ComboBox cmbMusicProducer;
        private Label lblMusicVideo;
        private ComboBox cmbMusicVideo;
        private Button btnAddSong;
        private Label lblArtist;
        private ComboBox cmbArtist;
        private Label lblSongGenre;
        private ComboBox cmbGenre;
        private Label lblBPM;
        private TextBox txtBPM;
        private Label lblName;
        private TextBox txtSongName;
        private Label lblProject;
        private ComboBox cmbProject;
        private Button button1;
    }
}
