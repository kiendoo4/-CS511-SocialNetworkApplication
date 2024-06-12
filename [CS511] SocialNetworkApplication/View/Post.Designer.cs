namespace _CS511__SocialNetworkApplication.View
{
    partial class Post
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Post));
            this.NameUser = new System.Windows.Forms.Label();
            this.Avatar = new System.Windows.Forms.PictureBox();
            this.mode = new System.Windows.Forms.ComboBox();
            this.textPost = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // NameUser
            // 
            this.NameUser.AutoSize = true;
            this.NameUser.BackColor = System.Drawing.Color.White;
            this.NameUser.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold);
            this.NameUser.Location = new System.Drawing.Point(90, 9);
            this.NameUser.Name = "NameUser";
            this.NameUser.Size = new System.Drawing.Size(119, 30);
            this.NameUser.TabIndex = 3;
            this.NameUser.Text = "Trung Kien";
            // 
            // Avatar
            // 
            this.Avatar.Image = ((System.Drawing.Image)(resources.GetObject("Avatar.Image")));
            this.Avatar.InitialImage = ((System.Drawing.Image)(resources.GetObject("Avatar.InitialImage")));
            this.Avatar.Location = new System.Drawing.Point(27, 16);
            this.Avatar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Avatar.Name = "Avatar";
            this.Avatar.Size = new System.Drawing.Size(55, 55);
            this.Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Avatar.TabIndex = 2;
            this.Avatar.TabStop = false;
            // 
            // mode
            // 
            this.mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mode.Font = new System.Drawing.Font("Quicksand SemiBold", 9F);
            this.mode.FormattingEnabled = true;
            this.mode.Location = new System.Drawing.Point(95, 41);
            this.mode.Name = "mode";
            this.mode.Size = new System.Drawing.Size(121, 31);
            this.mode.TabIndex = 4;
            // 
            // textPost
            // 
            this.textPost.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textPost.Font = new System.Drawing.Font("Quicksand SemiBold", 12F);
            this.textPost.Location = new System.Drawing.Point(23, 101);
            this.textPost.Name = "textPost";
            this.textPost.Size = new System.Drawing.Size(766, 50);
            this.textPost.TabIndex = 5;
            this.textPost.Text = "";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(23, 192);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 600);
            this.panel1.TabIndex = 6;
            // 
            // Post
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.textPost);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mode);
            this.Controls.Add(this.NameUser);
            this.Controls.Add(this.Avatar);
            this.Name = "Post";
            this.Size = new System.Drawing.Size(810, 855);
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label NameUser;
        public System.Windows.Forms.PictureBox Avatar;
        private System.Windows.Forms.ComboBox mode;
        private System.Windows.Forms.RichTextBox textPost;
        private System.Windows.Forms.Panel panel1;
    }
}
