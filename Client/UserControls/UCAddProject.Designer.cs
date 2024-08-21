namespace Client.UserControls
{
    partial class UCAddProject
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
            lblName = new Label();
            txtName = new TextBox();
            btnAdd = new Button();
            lblMusicProducer = new Label();
            cmbMusicProducer = new ComboBox();
            lblDescription = new Label();
            rtxtDescription = new RichTextBox();
            lblArtist = new Label();
            cmbArtist = new ComboBox();
            dgvSong = new DataGridView();
            btnAddProject = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSong).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(145, 146);
            lblName.Name = "lblName";
            lblName.Size = new Size(46, 20);
            lblName.TabIndex = 21;
            lblName.Text = "name";
            // 
            // txtName
            // 
            txtName.Location = new Point(93, 169);
            txtName.Name = "txtName";
            txtName.Size = new Size(159, 27);
            txtName.TabIndex = 20;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(78, 484);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(220, 29);
            btnAdd.TabIndex = 19;
            btnAdd.Text = "adit project";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // lblMusicProducer
            // 
            lblMusicProducer.AutoSize = true;
            lblMusicProducer.Location = new Point(115, 345);
            lblMusicProducer.Name = "lblMusicProducer";
            lblMusicProducer.Size = new Size(111, 20);
            lblMusicProducer.TabIndex = 18;
            lblMusicProducer.Text = "music producer";
            // 
            // cmbMusicProducer
            // 
            cmbMusicProducer.FormattingEnabled = true;
            cmbMusicProducer.Location = new Point(57, 368);
            cmbMusicProducer.Name = "cmbMusicProducer";
            cmbMusicProducer.Size = new Size(220, 28);
            cmbMusicProducer.TabIndex = 17;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(124, 199);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(83, 20);
            lblDescription.TabIndex = 16;
            lblDescription.Text = "description";
            // 
            // rtxtDescription
            // 
            rtxtDescription.Location = new Point(57, 222);
            rtxtDescription.Name = "rtxtDescription";
            rtxtDescription.Size = new Size(220, 120);
            rtxtDescription.TabIndex = 15;
            rtxtDescription.Text = "";
            // 
            // lblArtist
            // 
            lblArtist.AutoSize = true;
            lblArtist.Location = new Point(149, 412);
            lblArtist.Name = "lblArtist";
            lblArtist.Size = new Size(42, 20);
            lblArtist.TabIndex = 23;
            lblArtist.Text = "artist";
            // 
            // cmbArtist
            // 
            cmbArtist.FormattingEnabled = true;
            cmbArtist.Location = new Point(57, 435);
            cmbArtist.Name = "cmbArtist";
            cmbArtist.Size = new Size(220, 28);
            cmbArtist.TabIndex = 31;
            // 
            // dgvSong
            // 
            dgvSong.AllowUserToAddRows = false;
            dgvSong.AllowUserToDeleteRows = false;
            dgvSong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSong.Location = new Point(328, 169);
            dgvSong.Name = "dgvSong";
            dgvSong.ReadOnly = true;
            dgvSong.RowHeadersWidth = 51;
            dgvSong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSong.Size = new Size(627, 294);
            dgvSong.TabIndex = 26;
            // 
            // btnAddProject
            // 
            btnAddProject.Location = new Point(124, 495);
            btnAddProject.Name = "btnAddProject";
            btnAddProject.Size = new Size(94, 29);
            btnAddProject.TabIndex = 32;
            btnAddProject.Text = "add project";
            btnAddProject.UseVisualStyleBackColor = true;
            btnAddProject.Click += btnAddProject_Click;
            // 
            // UCAddProject
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnAddProject);
            Controls.Add(dgvSong);
            Controls.Add(lblArtist);
            Controls.Add(cmbArtist);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblMusicProducer);
            Controls.Add(cmbMusicProducer);
            Controls.Add(lblDescription);
            Controls.Add(rtxtDescription);
            Name = "UCAddProject";
            Size = new Size(1020, 652);
            ((System.ComponentModel.ISupportInitialize)dgvSong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private TextBox txtName;
        private Button btnAdd;
        private Label lblMusicProducer;
        private ComboBox cmbMusicProducer;
        private Label lblDescription;
        private RichTextBox rtxtDescription;
        private Label lblArtist;
        private ComboBox cmbArtist;
        private DataGridView dgvSong;
        private Button btnAddProject;
    }
}
