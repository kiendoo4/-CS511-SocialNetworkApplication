namespace _CS511__SocialNetworkApplication.View
{
    partial class SavedPosts
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
            this.flowPost = new System.Windows.Forms.FlowLayoutPanel();
            this.picDelete = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // flowPost
            // 
            this.flowPost.AutoScroll = true;
            this.flowPost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowPost.Location = new System.Drawing.Point(0, 36);
            this.flowPost.Margin = new System.Windows.Forms.Padding(0);
            this.flowPost.Name = "flowPost";
            this.flowPost.Size = new System.Drawing.Size(857, 862);
            this.flowPost.TabIndex = 0;
            // 
            // picDelete
            // 
            this.picDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDelete.Image = global::_CS511__SocialNetworkApplication.Properties.Resources.close_button;
            this.picDelete.Location = new System.Drawing.Point(823, 3);
            this.picDelete.Name = "picDelete";
            this.picDelete.Size = new System.Drawing.Size(30, 30);
            this.picDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDelete.TabIndex = 18;
            this.picDelete.TabStop = false;
            this.picDelete.Click += new System.EventHandler(this.picDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 30);
            this.label1.TabIndex = 19;
            this.label1.Text = "Saved posts";
            // 
            // SavedPosts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picDelete);
            this.Controls.Add(this.flowPost);
            this.Name = "SavedPosts";
            this.Size = new System.Drawing.Size(856, 898);
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowPost;
        private System.Windows.Forms.PictureBox picDelete;
        private System.Windows.Forms.Label label1;
    }
}
