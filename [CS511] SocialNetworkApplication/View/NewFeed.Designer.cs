namespace _CS511__SocialNetworkApplication.View
{
    partial class NewFeed
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
            this.tbContent = new System.Windows.Forms.RichTextBox();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picAttach = new System.Windows.Forms.PictureBox();
            this.cbEmo = new System.Windows.Forms.ComboBox();
            this.btPost = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAttach)).BeginInit();
            this.SuspendLayout();
            // 
            // tbContent
            // 
            this.tbContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tbContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbContent.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbContent.Location = new System.Drawing.Point(224, 120);
            this.tbContent.MaximumSize = new System.Drawing.Size(550, 100);
            this.tbContent.Name = "tbContent";
            this.tbContent.Size = new System.Drawing.Size(550, 100);
            this.tbContent.TabIndex = 0;
            this.tbContent.Text = "";
            this.tbContent.TextChanged += new System.EventHandler(this.tbContent_TextChanged);
            // 
            // cbMode
            // 
            this.cbMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Items.AddRange(new object[] {
            "Công khai",
            "Bạn bè",
            "Chỉ mình tôi"});
            this.cbMode.Location = new System.Drawing.Point(224, 84);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(121, 30);
            this.cbMode.TabIndex = 1;
            // 
            // picClose
            // 
            this.picClose.Image = global::_CS511__SocialNetworkApplication.Properties.Resources.close_button;
            this.picClose.Location = new System.Drawing.Point(744, 84);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(30, 30);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picClose.TabIndex = 15;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // picAttach
            // 
            this.picAttach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAttach.Image = global::_CS511__SocialNetworkApplication.Properties.Resources._11;
            this.picAttach.Location = new System.Drawing.Point(224, 226);
            this.picAttach.Name = "picAttach";
            this.picAttach.Size = new System.Drawing.Size(30, 30);
            this.picAttach.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAttach.TabIndex = 14;
            this.picAttach.TabStop = false;
            this.picAttach.Click += new System.EventHandler(this.picAttach_Click);
            // 
            // cbEmo
            // 
            this.cbEmo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEmo.FormattingEnabled = true;
            this.cbEmo.Items.AddRange(new object[] {
            "😃",
            "😆",
            "😅",
            "😞",
            "😢",
            "👍",
            "👎",
            "👏"});
            this.cbEmo.Location = new System.Drawing.Point(260, 226);
            this.cbEmo.Name = "cbEmo";
            this.cbEmo.Size = new System.Drawing.Size(52, 30);
            this.cbEmo.TabIndex = 17;
            // 
            // btPost
            // 
            this.btPost.Font = new System.Drawing.Font("Quicksand", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPost.Location = new System.Drawing.Point(224, 262);
            this.btPost.Name = "btPost";
            this.btPost.Size = new System.Drawing.Size(550, 35);
            this.btPost.TabIndex = 18;
            this.btPost.Text = "Đăng bài";
            this.btPost.UseVisualStyleBackColor = true;
            this.btPost.Click += new System.EventHandler(this.btPost_Click);
            // 
            // NewFeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btPost);
            this.Controls.Add(this.cbEmo);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.picAttach);
            this.Controls.Add(this.cbMode);
            this.Controls.Add(this.tbContent);
            this.Name = "NewFeed";
            this.Size = new System.Drawing.Size(1057, 901);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAttach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox tbContent;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.PictureBox picAttach;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.ComboBox cbEmo;
        private System.Windows.Forms.Button btPost;
    }
}
