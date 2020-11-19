namespace ClientChat
{
    partial class MessageBoxe
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelMSG = new System.Windows.Forms.Panel();
            this.btnMaddage = new System.Windows.Forms.Button();
            this.pnlMsg = new System.Windows.Forms.Panel();
            this.btnMessage = new System.Windows.Forms.Button();
            this.pnlImage = new System.Windows.Forms.Panel();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panelMSG.SuspendLayout();
            this.pnlMsg.SuspendLayout();
            this.pnlImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.panelMSG);
            this.panel1.Controls.Add(this.pnlMsg);
            this.panel1.Controls.Add(this.pnlImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MinimumSize = new System.Drawing.Size(0, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 84);
            this.panel1.TabIndex = 5;
            // 
            // panelMSG
            // 
            this.panelMSG.AutoSize = true;
            this.panelMSG.Controls.Add(this.btnMaddage);
            this.panelMSG.Location = new System.Drawing.Point(83, 9);
            this.panelMSG.MaximumSize = new System.Drawing.Size(202, 0);
            this.panelMSG.MinimumSize = new System.Drawing.Size(200, 64);
            this.panelMSG.Name = "panelMSG";
            this.panelMSG.Size = new System.Drawing.Size(200, 66);
            this.panelMSG.TabIndex = 4;
            // 
            // btnMaddage
            // 
            this.btnMaddage.AutoSize = true;
            this.btnMaddage.Enabled = false;
            this.btnMaddage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaddage.Location = new System.Drawing.Point(8, 11);
            this.btnMaddage.Name = "btnMaddage";
            this.btnMaddage.Size = new System.Drawing.Size(183, 52);
            this.btnMaddage.TabIndex = 0;
            this.btnMaddage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMaddage.UseVisualStyleBackColor = true;
            // 
            // pnlMsg
            // 
            this.pnlMsg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlMsg.AutoSize = true;
            this.pnlMsg.Controls.Add(this.btnMessage);
            this.pnlMsg.Location = new System.Drawing.Point(226, -192);
            this.pnlMsg.MaximumSize = new System.Drawing.Size(202, 0);
            this.pnlMsg.MinimumSize = new System.Drawing.Size(0, 64);
            this.pnlMsg.Name = "pnlMsg";
            this.pnlMsg.Size = new System.Drawing.Size(202, 64);
            this.pnlMsg.TabIndex = 3;
            // 
            // btnMessage
            // 
            this.btnMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMessage.AutoSize = true;
            this.btnMessage.BackColor = System.Drawing.Color.Transparent;
            this.btnMessage.FlatAppearance.BorderSize = 0;
            this.btnMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMessage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnMessage.Location = new System.Drawing.Point(24, 8);
            this.btnMessage.MaximumSize = new System.Drawing.Size(159, 0);
            this.btnMessage.MinimumSize = new System.Drawing.Size(0, 64);
            this.btnMessage.Name = "btnMessage";
            this.btnMessage.Size = new System.Drawing.Size(159, 64);
            this.btnMessage.TabIndex = 1;
            this.btnMessage.UseVisualStyleBackColor = false;
            // 
            // pnlImage
            // 
            this.pnlImage.Controls.Add(this.picAvatar);
            this.pnlImage.Location = new System.Drawing.Point(6, 9);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(71, 72);
            this.pnlImage.TabIndex = 2;
            // 
            // picAvatar
            // 
            this.picAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picAvatar.Location = new System.Drawing.Point(4, 4);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(63, 66);
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            // 
            // MessageBoxe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "MessageBoxe";
            this.Size = new System.Drawing.Size(580, 90);
            this.panelMSG.ResumeLayout(false);
            this.panelMSG.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlMsg.ResumeLayout(false);
            this.pnlMsg.PerformLayout();
            this.pnlImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelMSG;
        private System.Windows.Forms.Button btnMaddage;
        private System.Windows.Forms.Panel pnlMsg;
        private System.Windows.Forms.Button btnMessage;
        private System.Windows.Forms.Panel pnlImage;
        private System.Windows.Forms.PictureBox picAvatar;
    }
}
