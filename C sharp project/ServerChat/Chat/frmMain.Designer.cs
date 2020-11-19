namespace Chat
{
    partial class frmMain
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
            this.pnlLeftSide = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSound = new System.Windows.Forms.Button();
            this.btnCamera = new System.Windows.Forms.Button();
            this.btnAtachfile = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.userPic = new System.Windows.Forms.PictureBox();
            this.lblStat = new System.Windows.Forms.Label();
            this.pnlShowMessage = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPic)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeftSide
            // 
            this.pnlLeftSide.BackColor = System.Drawing.Color.SkyBlue;
            this.pnlLeftSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeftSide.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftSide.Name = "pnlLeftSide";
            this.pnlLeftSide.Size = new System.Drawing.Size(158, 483);
            this.pnlLeftSide.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.btnSound);
            this.panel2.Controls.Add(this.btnCamera);
            this.panel2.Controls.Add(this.btnAtachfile);
            this.panel2.Controls.Add(this.btnSend);
            this.panel2.Controls.Add(this.txtMessage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(158, 417);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(583, 66);
            this.panel2.TabIndex = 2;
            // 
            // btnSound
            // 
            this.btnSound.BackColor = System.Drawing.Color.Transparent;
            this.btnSound.BackgroundImage = global::Chat.Properties.Resources.sound_48px;
            this.btnSound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSound.FlatAppearance.BorderSize = 0;
            this.btnSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSound.Location = new System.Drawing.Point(26, 9);
            this.btnSound.Name = "btnSound";
            this.btnSound.Size = new System.Drawing.Size(40, 46);
            this.btnSound.TabIndex = 14;
            this.btnSound.UseVisualStyleBackColor = false;
            this.btnSound.Visible = false;
            // 
            // btnCamera
            // 
            this.btnCamera.BackColor = System.Drawing.Color.Transparent;
            this.btnCamera.BackgroundImage = global::Chat.Properties.Resources.Webcam;
            this.btnCamera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCamera.FlatAppearance.BorderSize = 0;
            this.btnCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCamera.Location = new System.Drawing.Point(72, 13);
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.Size = new System.Drawing.Size(40, 44);
            this.btnCamera.TabIndex = 13;
            this.btnCamera.UseVisualStyleBackColor = false;
            this.btnCamera.Visible = false;
            // 
            // btnAtachfile
            // 
            this.btnAtachfile.BackColor = System.Drawing.Color.Transparent;
            this.btnAtachfile.BackgroundImage = global::Chat.Properties.Resources.attach_48px;
            this.btnAtachfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAtachfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtachfile.FlatAppearance.BorderSize = 0;
            this.btnAtachfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtachfile.Location = new System.Drawing.Point(118, 9);
            this.btnAtachfile.Name = "btnAtachfile";
            this.btnAtachfile.Size = new System.Drawing.Size(40, 46);
            this.btnAtachfile.TabIndex = 12;
            this.btnAtachfile.UseVisualStyleBackColor = false;
            this.btnAtachfile.Click += new System.EventHandler(this.btnAtachfile_Click);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Transparent;
            this.btnSend.BackgroundImage = global::Chat.Properties.Resources.Telegram_for_Android;
            this.btnSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Location = new System.Drawing.Point(515, 6);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(42, 51);
            this.btnSend.TabIndex = 1;
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.BackColor = System.Drawing.SystemColors.Menu;
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.EnableAutoDragDrop = true;
            this.txtMessage.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtMessage.Location = new System.Drawing.Point(164, 6);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMessage.Size = new System.Drawing.Size(345, 51);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.Text = "";
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlTitle.Controls.Add(this.userPic);
            this.pnlTitle.Controls.Add(this.lblStat);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(158, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(583, 88);
            this.pnlTitle.TabIndex = 0;
            this.pnlTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTitle_Paint);
            // 
            // userPic
            // 
            this.userPic.BackgroundImage = global::Chat.Properties.Resources.iman;
            this.userPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.userPic.Location = new System.Drawing.Point(501, 12);
            this.userPic.Name = "userPic";
            this.userPic.Size = new System.Drawing.Size(56, 56);
            this.userPic.TabIndex = 3;
            this.userPic.TabStop = false;
            // 
            // lblStat
            // 
            this.lblStat.AutoSize = true;
            this.lblStat.Location = new System.Drawing.Point(15, 35);
            this.lblStat.Name = "lblStat";
            this.lblStat.Size = new System.Drawing.Size(35, 13);
            this.lblStat.TabIndex = 2;
            this.lblStat.Text = "label1";
            // 
            // pnlShowMessage
            // 
            this.pnlShowMessage.AutoScroll = true;
            this.pnlShowMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlShowMessage.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlShowMessage.Location = new System.Drawing.Point(159, 90);
            this.pnlShowMessage.Name = "pnlShowMessage";
            this.pnlShowMessage.Size = new System.Drawing.Size(580, 324);
            this.pnlShowMessage.TabIndex = 4;
            this.pnlShowMessage.WrapContents = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 483);
            this.Controls.Add(this.pnlShowMessage);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlLeftSide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "چت رنجر";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeftSide;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.RichTextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblStat;
        private System.Windows.Forms.Button btnAtachfile;
        private System.Windows.Forms.Button btnCamera;
        private System.Windows.Forms.Button btnSound;
        private System.Windows.Forms.PictureBox userPic;
        private System.Windows.Forms.FlowLayoutPanel pnlShowMessage;
    }
}

