namespace _CS511__SocialNetworkApplication.View
{
    partial class Friends
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.friendInviteList = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uMightKnowList = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.yourInvitation = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Paytone One", 15F);
            this.label1.Location = new System.Drawing.Point(13, 449);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lời mời kết bạn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Paytone One", 15F);
            this.label2.Location = new System.Drawing.Point(13, 886);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(375, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "Những người bạn có thể biết";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.friendInviteList);
            this.panel1.Location = new System.Drawing.Point(20, 504);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 354);
            this.panel1.TabIndex = 2;
            // 
            // friendInviteList
            // 
            this.friendInviteList.Location = new System.Drawing.Point(0, 0);
            this.friendInviteList.Name = "friendInviteList";
            this.friendInviteList.Size = new System.Drawing.Size(783, 354);
            this.friendInviteList.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.uMightKnowList);
            this.panel2.Location = new System.Drawing.Point(20, 940);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 354);
            this.panel2.TabIndex = 3;
            // 
            // uMightKnowList
            // 
            this.uMightKnowList.Location = new System.Drawing.Point(0, 0);
            this.uMightKnowList.Name = "uMightKnowList";
            this.uMightKnowList.Size = new System.Drawing.Size(783, 354);
            this.uMightKnowList.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.yourInvitation);
            this.panel3.Location = new System.Drawing.Point(21, 79);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(784, 354);
            this.panel3.TabIndex = 5;
            // 
            // yourInvitation
            // 
            this.yourInvitation.Location = new System.Drawing.Point(0, 0);
            this.yourInvitation.Name = "yourInvitation";
            this.yourInvitation.Size = new System.Drawing.Size(783, 354);
            this.yourInvitation.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Paytone One", 15F);
            this.label3.Location = new System.Drawing.Point(14, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 40);
            this.label3.TabIndex = 4;
            this.label3.Text = "Lời mời đã gửi";
            // 
            // Friends
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Friends";
            this.Size = new System.Drawing.Size(824, 1320);
            this.Load += new System.EventHandler(this.Friends_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel friendInviteList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel uMightKnowList;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel yourInvitation;
        private System.Windows.Forms.Label label3;
    }
}
