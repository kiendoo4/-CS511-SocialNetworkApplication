namespace _CS511__SocialNetworkApplication.View
{
    partial class EachFriend
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EachFriend));
            this.Avatar = new System.Windows.Forms.PictureBox();
            this.NameUser = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.friendIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.friendIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // Avatar
            // 
            this.Avatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Avatar.Image = ((System.Drawing.Image)(resources.GetObject("Avatar.Image")));
            this.Avatar.Location = new System.Drawing.Point(61, 17);
            this.Avatar.Name = "Avatar";
            this.Avatar.Size = new System.Drawing.Size(200, 200);
            this.Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Avatar.TabIndex = 0;
            this.Avatar.TabStop = false;
            // 
            // NameUser
            // 
            this.NameUser.AutoSize = true;
            this.NameUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NameUser.Font = new System.Drawing.Font("Quicksand SemiBold", 13F);
            this.NameUser.Location = new System.Drawing.Point(98, 220);
            this.NameUser.Name = "NameUser";
            this.NameUser.Size = new System.Drawing.Size(129, 33);
            this.NameUser.TabIndex = 1;
            this.NameUser.Text = "Trung Kien";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.friendIcon);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(61, 262);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 39);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Quicksand SemiBold", 10F);
            this.label1.Location = new System.Drawing.Point(36, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chấp nhận lời mời";
            // 
            // friendIcon
            // 
            this.friendIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.friendIcon.Image = ((System.Drawing.Image)(resources.GetObject("friendIcon.Image")));
            this.friendIcon.Location = new System.Drawing.Point(4, 3);
            this.friendIcon.Name = "friendIcon";
            this.friendIcon.Size = new System.Drawing.Size(30, 30);
            this.friendIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.friendIcon.TabIndex = 0;
            this.friendIcon.TabStop = false;
            // 
            // EachFriend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.NameUser);
            this.Controls.Add(this.Avatar);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "EachFriend";
            this.Size = new System.Drawing.Size(318, 318);
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.friendIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Avatar;
        private System.Windows.Forms.Label NameUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox friendIcon;
    }
}
