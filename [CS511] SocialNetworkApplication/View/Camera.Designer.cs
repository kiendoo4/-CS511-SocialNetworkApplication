namespace _CS511__SocialNetworkApplication.View
{
    partial class Camera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Camera));
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.takepicIcon = new System.Windows.Forms.PictureBox();
            this.takepic = new System.Windows.Forms.PictureBox();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.takepicIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.takepic)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.takepicIcon);
            this.panel4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel4.Location = new System.Drawing.Point(12, 463);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(136, 39);
            this.panel4.TabIndex = 63;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Quicksand SemiBold", 10F);
            this.label3.Location = new System.Drawing.Point(36, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Chụp hình";
            // 
            // takepicIcon
            // 
            this.takepicIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.takepicIcon.Image = ((System.Drawing.Image)(resources.GetObject("takepicIcon.Image")));
            this.takepicIcon.Location = new System.Drawing.Point(4, 3);
            this.takepicIcon.Name = "takepicIcon";
            this.takepicIcon.Size = new System.Drawing.Size(30, 30);
            this.takepicIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.takepicIcon.TabIndex = 0;
            this.takepicIcon.TabStop = false;
            // 
            // takepic
            // 
            this.takepic.Location = new System.Drawing.Point(12, 17);
            this.takepic.Name = "takepic";
            this.takepic.Size = new System.Drawing.Size(652, 440);
            this.takepic.TabIndex = 1;
            this.takepic.TabStop = false;
            this.takepic.Click += new System.EventHandler(this.takepic_Click);
            // 
            // Camera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(678, 513);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.takepic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Camera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Camera";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.takepicIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.takepic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox takepic;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox takepicIcon;
    }
}