namespace Client.UserControls
{
    partial class UCEditArtist
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
            btnLoadArtist = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnEdit = new Button();
            dgvArtist = new DataGridView();
            lblStageName = new Label();
            lblLastName = new Label();
            txtLastName = new TextBox();
            txtStageName = new TextBox();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvArtist).BeginInit();
            SuspendLayout();
            // 
            // btnLoadArtist
            // 
            btnLoadArtist.Location = new Point(210, 278);
            btnLoadArtist.Name = "btnLoadArtist";
            btnLoadArtist.Size = new Size(94, 66);
            btnLoadArtist.TabIndex = 27;
            btnLoadArtist.Text = "load artist";
            btnLoadArtist.UseVisualStyleBackColor = true;
            btnLoadArtist.Click += btnLoadArtist_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(196, 210);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(125, 27);
            txtSearch.TabIndex = 26;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(210, 243);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 25;
            btnSearch.Text = "search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(44, 342);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(125, 29);
            btnEdit.TabIndex = 24;
            btnEdit.Text = "edit an artist";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // dgvArtist
            // 
            dgvArtist.AllowUserToAddRows = false;
            dgvArtist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArtist.Location = new Point(336, 80);
            dgvArtist.MultiSelect = false;
            dgvArtist.Name = "dgvArtist";
            dgvArtist.ReadOnly = true;
            dgvArtist.RowHeadersWidth = 51;
            dgvArtist.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArtist.Size = new Size(519, 400);
            dgvArtist.TabIndex = 23;
            // 
            // lblStageName
            // 
            lblStageName.AutoSize = true;
            lblStageName.Location = new Point(60, 276);
            lblStageName.Name = "lblStageName";
            lblStageName.Size = new Size(86, 20);
            lblStageName.TabIndex = 22;
            lblStageName.Text = "stage name";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(71, 213);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(73, 20);
            lblLastName.TabIndex = 21;
            lblLastName.Text = "last name";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(44, 236);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(125, 27);
            txtLastName.TabIndex = 20;
            // 
            // txtStageName
            // 
            txtStageName.Location = new Point(44, 299);
            txtStageName.Name = "txtStageName";
            txtStageName.Size = new Size(125, 27);
            txtStageName.TabIndex = 19;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(71, 151);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(75, 20);
            lblFirstName.TabIndex = 18;
            lblFirstName.Text = "first name";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(44, 174);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(125, 27);
            txtFirstName.TabIndex = 15;
            // 
            // UCEditArtist
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnLoadArtist);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(btnEdit);
            Controls.Add(dgvArtist);
            Controls.Add(lblStageName);
            Controls.Add(lblLastName);
            Controls.Add(txtLastName);
            Controls.Add(txtStageName);
            Controls.Add(lblFirstName);
            Controls.Add(txtFirstName);
            Name = "UCEditArtist";
            Size = new Size(888, 533);
            ((System.ComponentModel.ISupportInitialize)dgvArtist).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoadArtist;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnEdit;
        private DataGridView dgvArtist;
        private Label lblStageName;
        private Label lblLastName;
        private TextBox txtLastName;
        private TextBox txtStageName;
        private Label lblFirstName;
        private TextBox txtFirstName;
    }
}
