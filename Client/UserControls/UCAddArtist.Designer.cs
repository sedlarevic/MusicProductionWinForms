namespace Client.UserControls
{
    partial class UCAddArtist
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
            btnAddArtist = new Button();
            lblStageName = new Label();
            lblLastName = new Label();
            lblFirstName = new Label();
            txtStageName = new TextBox();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            SuspendLayout();
            // 
            // btnAddArtist
            // 
            btnAddArtist.Location = new Point(0, 217);
            btnAddArtist.Name = "btnAddArtist";
            btnAddArtist.Size = new Size(125, 29);
            btnAddArtist.TabIndex = 13;
            btnAddArtist.Text = "add an artist";
            btnAddArtist.UseVisualStyleBackColor = true;
            btnAddArtist.Click += btnAddArtist_Click;
            // 
            // lblStageName
            // 
            lblStageName.AutoSize = true;
            lblStageName.Location = new Point(17, 141);
            lblStageName.Name = "lblStageName";
            lblStageName.Size = new Size(86, 20);
            lblStageName.TabIndex = 12;
            lblStageName.Text = "stage name";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(20, 88);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(73, 20);
            lblLastName.TabIndex = 11;
            lblLastName.Text = "last name";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(20, 35);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(75, 20);
            lblFirstName.TabIndex = 10;
            lblFirstName.Text = "first name";
            // 
            // txtStageName
            // 
            txtStageName.Location = new Point(0, 164);
            txtStageName.Name = "txtStageName";
            txtStageName.Size = new Size(125, 27);
            txtStageName.TabIndex = 9;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(0, 111);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(125, 27);
            txtLastName.TabIndex = 8;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(0, 58);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(125, 27);
            txtFirstName.TabIndex = 7;
            // 
            // UCAddArtist
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(btnAddArtist);
            Controls.Add(lblStageName);
            Controls.Add(lblLastName);
            Controls.Add(lblFirstName);
            Controls.Add(txtStageName);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Name = "UCAddArtist";
            Size = new Size(128, 249);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddArtist;
        private Label lblStageName;
        private Label lblLastName;
        private Label lblFirstName;
        private TextBox txtStageName;
        private TextBox txtLastName;
        private TextBox txtFirstName;
    }
}
