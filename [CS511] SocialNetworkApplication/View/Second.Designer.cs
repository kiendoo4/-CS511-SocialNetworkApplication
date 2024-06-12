namespace _CS511__SocialNetworkApplication.View
{
    partial class Second
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Second));
            this.userUC = new System.Windows.Forms.Panel();
            this.socialUC = new System.Windows.Forms.Panel();
            this.flowPost = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.messageUC = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.socialUC.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.messageUC.SuspendLayout();
            this.SuspendLayout();
            // 
            // userUC
            // 
            this.userUC.Location = new System.Drawing.Point(0, 0);
            this.userUC.Name = "userUC";
            this.userUC.Size = new System.Drawing.Size(416, 903);
            this.userUC.TabIndex = 0;
            // 
            // socialUC
            // 
            this.socialUC.Controls.Add(this.flowPost);
            this.socialUC.Location = new System.Drawing.Point(422, 0);
            this.socialUC.Name = "socialUC";
            this.socialUC.Size = new System.Drawing.Size(853, 903);
            this.socialUC.TabIndex = 1;
            // 
            // flowPost
            // 
            this.flowPost.AutoScroll = true;
            this.flowPost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPost.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPost.Location = new System.Drawing.Point(0, 0);
            this.flowPost.Name = "flowPost";
            this.flowPost.Size = new System.Drawing.Size(853, 903);
            this.flowPost.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Paytone One", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 48);
            this.label1.TabIndex = 12;
            this.label1.Text = "Người liên hệ";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(13, 77);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(443, 40);
            this.panel2.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Quicksand SemiBold", 10F);
            this.textBox1.Location = new System.Drawing.Point(54, 6);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(384, 28);
            this.textBox1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // messageUC
            // 
            this.messageUC.Controls.Add(this.flowLayoutPanel2);
            this.messageUC.Controls.Add(this.panel2);
            this.messageUC.Controls.Add(this.label1);
            this.messageUC.Location = new System.Drawing.Point(1281, 0);
            this.messageUC.Name = "messageUC";
            this.messageUC.Size = new System.Drawing.Size(459, 903);
            this.messageUC.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 138);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(456, 765);
            this.flowLayoutPanel2.TabIndex = 14;
            // 
            // Second
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.messageUC);
            this.Controls.Add(this.socialUC);
            this.Controls.Add(this.userUC);
            this.Name = "Second";
            this.Size = new System.Drawing.Size(1740, 903);
            this.socialUC.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.messageUC.ResumeLayout(false);
            this.messageUC.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel userUC;
        private System.Windows.Forms.Panel socialUC;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel messageUC;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowPost;
    }
}
