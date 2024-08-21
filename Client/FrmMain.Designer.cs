namespace Client
{
    partial class FrmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            ToolStripSong = new ToolStripMenuItem();
            AddSong = new ToolStripMenuItem();
            EditSong = new ToolStripMenuItem();
            ToolStripArtist = new ToolStripMenuItem();
            AddArtist = new ToolStripMenuItem();
            EditArtist = new ToolStripMenuItem();
            ToolStripProject = new ToolStripMenuItem();
            AddProject = new ToolStripMenuItem();
            EditProject = new ToolStripMenuItem();
            ToolStripMusicVideo = new ToolStripMenuItem();
            AddMusicVideo = new ToolStripMenuItem();
            lblWelcome = new Label();
            songToolStripMenuItem1 = new ToolStripMenuItem();
            mainPnl = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripSong, ToolStripArtist, ToolStripProject, ToolStripMusicVideo });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1603, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripSong
            // 
            ToolStripSong.DropDownItems.AddRange(new ToolStripItem[] { AddSong, EditSong });
            ToolStripSong.Name = "ToolStripSong";
            ToolStripSong.Size = new Size(57, 24);
            ToolStripSong.Text = "Song";
            // 
            // AddSong
            // 
            AddSong.Name = "AddSong";
            AddSong.Size = new Size(120, 26);
            AddSong.Text = "Add";
            // 
            // EditSong
            // 
            EditSong.Name = "EditSong";
            EditSong.Size = new Size(120, 26);
            EditSong.Text = "Edit";
            // 
            // ToolStripArtist
            // 
            ToolStripArtist.DropDownItems.AddRange(new ToolStripItem[] { AddArtist, EditArtist });
            ToolStripArtist.Name = "ToolStripArtist";
            ToolStripArtist.Size = new Size(58, 24);
            ToolStripArtist.Text = "Artist";
            // 
            // AddArtist
            // 
            AddArtist.Name = "AddArtist";
            AddArtist.Size = new Size(120, 26);
            AddArtist.Text = "Add";
            // 
            // EditArtist
            // 
            EditArtist.Name = "EditArtist";
            EditArtist.Size = new Size(120, 26);
            EditArtist.Text = "Edit";
            // 
            // ToolStripProject
            // 
            ToolStripProject.DropDownItems.AddRange(new ToolStripItem[] { AddProject, EditProject });
            ToolStripProject.Name = "ToolStripProject";
            ToolStripProject.Size = new Size(69, 24);
            ToolStripProject.Text = "Project";
            // 
            // AddProject
            // 
            AddProject.Name = "AddProject";
            AddProject.Size = new Size(120, 26);
            AddProject.Text = "Add";
            // 
            // EditProject
            // 
            EditProject.Name = "EditProject";
            EditProject.Size = new Size(120, 26);
            EditProject.Text = "Edit";
            // 
            // ToolStripMusicVideo
            // 
            ToolStripMusicVideo.DropDownItems.AddRange(new ToolStripItem[] { AddMusicVideo });
            ToolStripMusicVideo.Name = "ToolStripMusicVideo";
            ToolStripMusicVideo.Size = new Size(104, 24);
            ToolStripMusicVideo.Text = "Music Video";
            // 
            // AddMusicVideo
            // 
            AddMusicVideo.Name = "AddMusicVideo";
            AddMusicVideo.Size = new Size(120, 26);
            AddMusicVideo.Text = "Add";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(618, 41);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(0, 20);
            lblWelcome.TabIndex = 1;
            // 
            // songToolStripMenuItem1
            // 
            songToolStripMenuItem1.Name = "songToolStripMenuItem1";
            songToolStripMenuItem1.Size = new Size(224, 26);
            // 
            // mainPnl
            // 
            mainPnl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainPnl.Location = new Point(0, 28);
            mainPnl.Name = "mainPnl";
            mainPnl.Size = new Size(1603, 695);
            mainPnl.TabIndex = 2;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1603, 723);
            Controls.Add(mainPnl);
            Controls.Add(lblWelcome);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmMain";
            Text = "Form1";
            FormClosed += FrmMain_FormClosed;
            Load += FrmMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Panel MainPnl { get { return mainPnl; } set { mainPnl = value; } }

        private MenuStrip menuStrip1;
        private ToolStripMenuItem ToolStripSong;
        private ToolStripMenuItem ToolStripArtist;
        private ToolStripMenuItem ToolStripProject;
        private ToolStripMenuItem ToolStripMusicVideo;
        private Label lblWelcome;
        private ToolStripMenuItem AddSong;
        private ToolStripMenuItem EditSong;
        private ToolStripMenuItem AddArtist;
        private ToolStripMenuItem EditArtist;
        private ToolStripMenuItem AddProject;
        private ToolStripMenuItem EditProject;
        private ToolStripMenuItem AddMusicVideo;
        private ToolStripMenuItem songToolStripMenuItem1;
        private Panel mainPnl;
    }
}