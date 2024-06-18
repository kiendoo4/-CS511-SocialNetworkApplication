namespace _CS511__SocialNetworkApplication.View
{
    partial class Comment
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
            this.lbName = new System.Windows.Forms.Label();
            this.tbContent = new System.Windows.Forms.RichTextBox();
            this.flowContent = new System.Windows.Forms.FlowLayoutPanel();
            this.lbTime = new System.Windows.Forms.Label();
            this.picAva = new System.Windows.Forms.PictureBox();
            this.flowContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAva)).BeginInit();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Quicksand", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(55, 3);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(61, 25);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "Name";
            // 
            // tbContent
            // 
            this.tbContent.BackColor = System.Drawing.Color.White;
            this.tbContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbContent.Location = new System.Drawing.Point(0, 3);
            this.tbContent.Margin = new System.Windows.Forms.Padding(0, 3, 6, 3);
            this.tbContent.Name = "tbContent";
            this.tbContent.Size = new System.Drawing.Size(695, 36);
            this.tbContent.TabIndex = 2;
            this.tbContent.Text = "";
            // 
            // flowContent
            // 
            this.flowContent.AutoSize = true;
            this.flowContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowContent.Controls.Add(this.tbContent);
            this.flowContent.Controls.Add(this.lbTime);
            this.flowContent.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowContent.Location = new System.Drawing.Point(59, 31);
            this.flowContent.Name = "flowContent";
            this.flowContent.Size = new System.Drawing.Size(701, 58);
            this.flowContent.TabIndex = 3;
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(3, 42);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(38, 16);
            this.lbTime.TabIndex = 3;
            this.lbTime.Text = "Time";
            // 
            // picAva
            // 
            this.picAva.Location = new System.Drawing.Point(3, 3);
            this.picAva.Name = "picAva";
            this.picAva.Size = new System.Drawing.Size(50, 50);
            this.picAva.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAva.TabIndex = 0;
            this.picAva.TabStop = false;
            // 
            // Comment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flowContent);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.picAva);
            this.Margin = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.MinimumSize = new System.Drawing.Size(760, 5);
            this.Name = "Comment";
            this.Size = new System.Drawing.Size(763, 92);
            this.flowContent.ResumeLayout(false);
            this.flowContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAva)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox tbContent;
        private System.Windows.Forms.FlowLayoutPanel flowContent;
        private System.Windows.Forms.Label lbTime;
        public System.Windows.Forms.PictureBox picAva;
        public System.Windows.Forms.Label lbName;
    }
}
