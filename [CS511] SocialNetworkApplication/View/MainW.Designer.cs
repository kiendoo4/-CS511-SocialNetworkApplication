namespace _CS511__SocialNetworkApplication.View
{
    partial class MainW
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainW));
            this.CurrentUC = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // CurrentUC
            // 
            this.CurrentUC.Location = new System.Drawing.Point(26, 35);
            this.CurrentUC.Name = "CurrentUC";
            this.CurrentUC.Size = new System.Drawing.Size(1740, 903);
            this.CurrentUC.TabIndex = 0;
            // 
            // MainW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1800, 938);
            this.Controls.Add(this.CurrentUC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainW";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facebook";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CurrentUC;
    }
}