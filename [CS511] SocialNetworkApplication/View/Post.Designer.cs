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
            this.lbUser = new System.Windows.Forms.Label();
            this.textPost = new System.Windows.Forms.RichTextBox();
            this.flowMedia = new System.Windows.Forms.FlowLayoutPanel();
            this.flowPost = new System.Windows.Forms.FlowLayoutPanel();
            this.tableMedia = new System.Windows.Forms.TableLayoutPanel();
            this.panelButton = new System.Windows.Forms.Panel();
            this.btShare = new System.Windows.Forms.Button();
            this.btLike = new System.Windows.Forms.Button();
            this.btComment = new System.Windows.Forms.Button();
            this.flowComment = new System.Windows.Forms.FlowLayoutPanel();
            this.panelComment = new System.Windows.Forms.Panel();
            this.cbEmo = new System.Windows.Forms.ComboBox();
            this.picAttach = new System.Windows.Forms.PictureBox();
            this.picSend = new System.Windows.Forms.PictureBox();
            this.tbComment = new System.Windows.Forms.RichTextBox();
            this.lbDate = new System.Windows.Forms.Label();
            this.picMode = new System.Windows.Forms.PictureBox();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.flowPost.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.panelComment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAttach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.BackColor = System.Drawing.Color.White;
            this.lbUser.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold);
            this.lbUser.Location = new System.Drawing.Point(74, 10);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(119, 30);
            this.lbUser.TabIndex = 3;
            this.lbUser.Text = "Trung Kien";
            // 
            // textPost
            // 
            this.textPost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.textPost.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textPost.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPost.Location = new System.Drawing.Point(3, 3);
            this.textPost.Name = "textPost";
            this.textPost.ReadOnly = true;
            this.textPost.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.textPost.Size = new System.Drawing.Size(772, 37);
            this.textPost.TabIndex = 5;
            this.textPost.Text = "";
            // 
            // flowMedia
            // 
            this.flowMedia.AutoSize = true;
            this.flowMedia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowMedia.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowMedia.Location = new System.Drawing.Point(3, 46);
            this.flowMedia.MinimumSize = new System.Drawing.Size(772, 5);
            this.flowMedia.Name = "flowMedia";
            this.flowMedia.Size = new System.Drawing.Size(772, 5);
            this.flowMedia.TabIndex = 9;
            // 
            // flowPost
            // 
            this.flowPost.AutoSize = true;
            this.flowPost.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowPost.Controls.Add(this.textPost);
            this.flowPost.Controls.Add(this.flowMedia);
            this.flowPost.Controls.Add(this.tableMedia);
            this.flowPost.Controls.Add(this.panelButton);
            this.flowPost.Controls.Add(this.flowComment);
            this.flowPost.Controls.Add(this.panelComment);
            this.flowPost.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPost.Location = new System.Drawing.Point(13, 79);
            this.flowPost.Name = "flowPost";
            this.flowPost.Size = new System.Drawing.Size(778, 165);
            this.flowPost.TabIndex = 10;
            // 
            // tableMedia
            // 
            this.tableMedia.AutoSize = true;
            this.tableMedia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableMedia.ColumnCount = 2;
            this.tableMedia.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableMedia.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableMedia.Location = new System.Drawing.Point(3, 57);
            this.tableMedia.MinimumSize = new System.Drawing.Size(772, 5);
            this.tableMedia.Name = "tableMedia";
            this.tableMedia.RowCount = 1;
            this.tableMedia.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableMedia.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableMedia.Size = new System.Drawing.Size(772, 5);
            this.tableMedia.TabIndex = 10;
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.btShare);
            this.panelButton.Controls.Add(this.btLike);
            this.panelButton.Controls.Add(this.btComment);
            this.panelButton.Location = new System.Drawing.Point(3, 68);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(772, 41);
            this.panelButton.TabIndex = 11;
            // 
            // btShare
            // 
            this.btShare.Font = new System.Drawing.Font("Quicksand", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btShare.Location = new System.Drawing.Point(518, 3);
            this.btShare.Name = "btShare";
            this.btShare.Size = new System.Drawing.Size(251, 35);
            this.btShare.TabIndex = 13;
            this.btShare.Text = "Chia sẽ";
            this.btShare.UseVisualStyleBackColor = true;
            // 
            // btLike
            // 
            this.btLike.Font = new System.Drawing.Font("Quicksand", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLike.Location = new System.Drawing.Point(3, 3);
            this.btLike.Name = "btLike";
            this.btLike.Size = new System.Drawing.Size(251, 35);
            this.btLike.TabIndex = 0;
            this.btLike.Text = "Thích";
            this.btLike.UseVisualStyleBackColor = true;
            // 
            // btComment
            // 
            this.btComment.Font = new System.Drawing.Font("Quicksand", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btComment.Location = new System.Drawing.Point(260, 3);
            this.btComment.Name = "btComment";
            this.btComment.Size = new System.Drawing.Size(252, 35);
            this.btComment.TabIndex = 12;
            this.btComment.Text = "Bình luận";
            this.btComment.UseVisualStyleBackColor = true;
            // 
            // flowComment
            // 
            this.flowComment.AutoSize = true;
            this.flowComment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowComment.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowComment.Location = new System.Drawing.Point(3, 115);
            this.flowComment.MinimumSize = new System.Drawing.Size(772, 5);
            this.flowComment.Name = "flowComment";
            this.flowComment.Size = new System.Drawing.Size(772, 5);
            this.flowComment.TabIndex = 13;
            // 
            // panelComment
            // 
            this.panelComment.AutoSize = true;
            this.panelComment.Controls.Add(this.cbEmo);
            this.panelComment.Controls.Add(this.picAttach);
            this.panelComment.Controls.Add(this.picSend);
            this.panelComment.Controls.Add(this.tbComment);
            this.panelComment.Location = new System.Drawing.Point(3, 126);
            this.panelComment.Name = "panelComment";
            this.panelComment.Size = new System.Drawing.Size(772, 36);
            this.panelComment.TabIndex = 14;
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
            this.cbEmo.Location = new System.Drawing.Point(39, 3);
            this.cbEmo.Name = "cbEmo";
            this.cbEmo.Size = new System.Drawing.Size(52, 30);
            this.cbEmo.TabIndex = 14;
            this.cbEmo.SelectedIndexChanged += new System.EventHandler(this.cbEmo_SelectedIndexChanged);
            // 
            // picAttach
            // 
            this.picAttach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAttach.Image = global::_CS511__SocialNetworkApplication.Properties.Resources._11;
            this.picAttach.Location = new System.Drawing.Point(3, 3);
            this.picAttach.Name = "picAttach";
            this.picAttach.Size = new System.Drawing.Size(30, 30);
            this.picAttach.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAttach.TabIndex = 13;
            this.picAttach.TabStop = false;
            this.picAttach.Click += new System.EventHandler(this.picAttach_Click);
            // 
            // picSend
            // 
            this.picSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSend.Image = global::_CS511__SocialNetworkApplication.Properties.Resources.send;
            this.picSend.Location = new System.Drawing.Point(739, 3);
            this.picSend.Name = "picSend";
            this.picSend.Size = new System.Drawing.Size(30, 30);
            this.picSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSend.TabIndex = 12;
            this.picSend.TabStop = false;
            this.picSend.Click += new System.EventHandler(this.picSend_Click);
            // 
            // tbComment
            // 
            this.tbComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tbComment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbComment.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbComment.Location = new System.Drawing.Point(97, 3);
            this.tbComment.Name = "tbComment";
            this.tbComment.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.tbComment.Size = new System.Drawing.Size(636, 30);
            this.tbComment.TabIndex = 12;
            this.tbComment.Text = "";
            this.tbComment.TextChanged += new System.EventHandler(this.tbComment_TextChanged);
            // 
            // lbDate
            // 
            this.lbDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDate.AutoSize = true;
            this.lbDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDate.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbDate.Location = new System.Drawing.Point(105, 47);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(81, 20);
            this.lbDate.TabIndex = 11;
            this.lbDate.Text = "labelTime";
            // 
            // picMode
            // 
            this.picMode.Location = new System.Drawing.Point(79, 47);
            this.picMode.Name = "picMode";
            this.picMode.Size = new System.Drawing.Size(20, 20);
            this.picMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMode.TabIndex = 8;
            this.picMode.TabStop = false;
            // 
            // picAvatar
            // 
            this.picAvatar.Image = ((System.Drawing.Image)(resources.GetObject("picAvatar.Image")));
            this.picAvatar.InitialImage = ((System.Drawing.Image)(resources.GetObject("picAvatar.InitialImage")));
            this.picAvatar.Location = new System.Drawing.Point(13, 12);
            this.picAvatar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(55, 55);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAvatar.TabIndex = 2;
            this.picAvatar.TabStop = false;
            // 
            // Post
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.flowPost);
            this.Controls.Add(this.picMode);
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.picAvatar);
            this.Name = "Post";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(804, 257);
            this.flowPost.ResumeLayout(false);
            this.flowPost.PerformLayout();
            this.panelButton.ResumeLayout(false);
            this.panelComment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAttach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbUser;
        public System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.RichTextBox textPost;
        private System.Windows.Forms.PictureBox picMode;
        private System.Windows.Forms.FlowLayoutPanel flowMedia;
        private System.Windows.Forms.FlowLayoutPanel flowPost;
        private System.Windows.Forms.TableLayoutPanel tableMedia;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Button btShare;
        private System.Windows.Forms.Button btLike;
        private System.Windows.Forms.Button btComment;
        private System.Windows.Forms.FlowLayoutPanel flowComment;
        private System.Windows.Forms.Panel panelComment;
        private System.Windows.Forms.RichTextBox tbComment;
        private System.Windows.Forms.PictureBox picSend;
        private System.Windows.Forms.PictureBox picAttach;
        private System.Windows.Forms.ComboBox cbEmo;
    }
}
