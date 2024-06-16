using System.Drawing;
using System.Windows.Forms;

namespace _CS511__SocialNetworkApplication.View
{
    partial class UserIndividual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserIndividual));
            this.Avatar = new System.Windows.Forms.PictureBox();
            this.NameUser = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // Avatar
            // 
            this.Avatar.Image = ((System.Drawing.Image)(resources.GetObject("Avatar.Image")));
            this.Avatar.InitialImage = ((System.Drawing.Image)(resources.GetObject("Avatar.InitialImage")));
            this.Avatar.Location = new System.Drawing.Point(23, 8);
            this.Avatar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Avatar.Name = "Avatar";
            this.Avatar.Size = new System.Drawing.Size(55, 55);
            this.Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Avatar.TabIndex = 0;
            this.Avatar.TabStop = false;
            // 
            // NameUser
            // 
            this.NameUser.AutoSize = true;
            this.NameUser.BackColor = System.Drawing.Color.White;
            this.NameUser.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold);
            this.NameUser.Location = new System.Drawing.Point(86, 19);
            this.NameUser.Name = "NameUser";
            this.NameUser.Size = new System.Drawing.Size(164, 30);
            this.NameUser.TabIndex = 1;
            this.NameUser.Text = "Tên người dùng";
            // 
            // UserIndividual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.NameUser);
            this.Controls.Add(this.Avatar);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UserIndividual";
            this.Size = new System.Drawing.Size(416, 75);
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Label NameUser;
        public PictureBox Avatar;
    }
}
