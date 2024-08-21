namespace Client.UserControls
{
    partial class UCAddMusicVideo
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
            btnAdd = new Button();
            lblDirector = new Label();
            cmbDirector = new ComboBox();
            lblDescription = new Label();
            rtxtDescription = new RichTextBox();
            dgvSong = new DataGridView();
            txtName = new TextBox();
            lblName = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSong).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(69, 439);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(220, 29);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "add music video";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblDirector
            // 
            lblDirector.AutoSize = true;
            lblDirector.Location = new Point(145, 355);
            lblDirector.Name = "lblDirector";
            lblDirector.Size = new Size(61, 20);
            lblDirector.TabIndex = 10;
            lblDirector.Text = "director";
            // 
            // cmbDirector
            // 
            cmbDirector.FormattingEnabled = true;
            cmbDirector.Location = new Point(69, 378);
            cmbDirector.Name = "cmbDirector";
            cmbDirector.Size = new Size(220, 28);
            cmbDirector.TabIndex = 9;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(136, 189);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(83, 20);
            lblDescription.TabIndex = 8;
            lblDescription.Text = "description";
            // 
            // rtxtDescription
            // 
            rtxtDescription.Location = new Point(69, 221);
            rtxtDescription.Name = "rtxtDescription";
            rtxtDescription.Size = new Size(220, 120);
            rtxtDescription.TabIndex = 7;
            rtxtDescription.Text = "";
            // 
            // dgvSong
            // 
            dgvSong.AllowUserToAddRows = false;
            dgvSong.AllowUserToDeleteRows = false;
            dgvSong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSong.Location = new Point(333, 89);
            dgvSong.Name = "dgvSong";
            dgvSong.ReadOnly = true;
            dgvSong.RowHeadersWidth = 51;
            dgvSong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSong.Size = new Size(567, 434);
            dgvSong.TabIndex = 6;
            // 
            // txtName
            // 
            txtName.Location = new Point(105, 152);
            txtName.Name = "txtName";
            txtName.Size = new Size(159, 27);
            txtName.TabIndex = 12;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(157, 121);
            lblName.Name = "lblName";
            lblName.Size = new Size(46, 20);
            lblName.TabIndex = 13;
            lblName.Text = "name";
            // 
            // UCAddMusicVideo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(btnAdd);
            Controls.Add(lblDirector);
            Controls.Add(cmbDirector);
            Controls.Add(lblDescription);
            Controls.Add(rtxtDescription);
            Controls.Add(dgvSong);
            Name = "UCAddMusicVideo";
            Size = new Size(989, 629);
            ((System.ComponentModel.ISupportInitialize)dgvSong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private Label lblDirector;
        private ComboBox cmbDirector;
        private Label lblDescription;
        private RichTextBox rtxtDescription;
        private DataGridView dgvSong;
        private TextBox txtName;
        private Label lblName;
    }
}
