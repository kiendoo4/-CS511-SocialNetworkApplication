namespace _CS511__SocialNetworkApplication.View
{
    partial class FormFeed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFeed));
            this.picClose = new System.Windows.Forms.PictureBox();
            this.btPost = new System.Windows.Forms.Button();
            this.cbEmo = new System.Windows.Forms.ComboBox();
            this.picAttach = new System.Windows.Forms.PictureBox();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.tbContent = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAttach)).BeginInit();
            this.SuspendLayout();
            // 
            // picClose
            // 
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::_CS511__SocialNetworkApplication.Properties.Resources.close_button;
            this.picClose.Location = new System.Drawing.Point(682, 12);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(30, 30);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picClose.TabIndex = 16;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // btPost
            // 
            this.btPost.Font = new System.Drawing.Font("Quicksand", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPost.Location = new System.Drawing.Point(12, 240);
            this.btPost.Name = "btPost";
            this.btPost.Size = new System.Drawing.Size(700, 35);
            this.btPost.TabIndex = 23;
            this.btPost.Text = "Đăng bài";
            this.btPost.UseVisualStyleBackColor = true;
            this.btPost.Click += new System.EventHandler(this.btPost_Click);
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
            this.cbEmo.Location = new System.Drawing.Point(48, 204);
            this.cbEmo.Name = "cbEmo";
            this.cbEmo.Size = new System.Drawing.Size(52, 30);
            this.cbEmo.TabIndex = 22;
            this.cbEmo.SelectedIndexChanged += new System.EventHandler(this.cbEmo_SelectedIndexChanged);
            // 
            // picAttach
            // 
            this.picAttach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAttach.Image = global::_CS511__SocialNetworkApplication.Properties.Resources._11;
            this.picAttach.Location = new System.Drawing.Point(12, 204);
            this.picAttach.Name = "picAttach";
            this.picAttach.Size = new System.Drawing.Size(30, 30);
            this.picAttach.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAttach.TabIndex = 21;
            this.picAttach.TabStop = false;
            this.picAttach.Click += new System.EventHandler(this.picAttach_Click);
            // 
            // cbMode
            // 
            this.cbMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Items.AddRange(new object[] {
            "Công khai",
            "Bạn bè",
            "Chỉ mình tôi"});
            this.cbMode.Location = new System.Drawing.Point(12, 12);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(121, 30);
            this.cbMode.TabIndex = 20;
            // 
            // tbContent
            // 
            this.tbContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tbContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbContent.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbContent.Location = new System.Drawing.Point(12, 48);
            this.tbContent.MaximumSize = new System.Drawing.Size(700, 150);
            this.tbContent.Name = "tbContent";
            this.tbContent.Size = new System.Drawing.Size(700, 150);
            this.tbContent.TabIndex = 19;
            this.tbContent.Text = "";
            // 
            // FormFeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(724, 288);
            this.ControlBox = false;
            this.Controls.Add(this.btPost);
            this.Controls.Add(this.cbEmo);
            this.Controls.Add(this.picAttach);
            this.Controls.Add(this.cbMode);
            this.Controls.Add(this.tbContent);
            this.Controls.Add(this.picClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFeed";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAttach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.Button btPost;
        private System.Windows.Forms.ComboBox cbEmo;
        private System.Windows.Forms.PictureBox picAttach;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.RichTextBox tbContent;
    }
}