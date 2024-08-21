namespace Server
{
    partial class FrmServer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnStart = new Button();
            btnStop = new Button();
            lblServer = new Label();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(12, 12);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(168, 94);
            btnStart.TabIndex = 0;
            btnStart.Text = "start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(243, 12);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(168, 94);
            btnStop.TabIndex = 1;
            btnStop.Text = "stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // lblServer
            // 
            lblServer.AutoSize = true;
            lblServer.Location = new Point(465, 239);
            lblServer.Name = "lblServer";
            lblServer.Size = new Size(0, 20);
            lblServer.TabIndex = 2;
            // 
            // FrmServer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 577);
            Controls.Add(lblServer);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Name = "FrmServer";
            Text = "Form1";
            FormClosed += FrmServer_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Button btnStop;
        private Label lblServer;
    }
}
