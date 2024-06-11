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
            this.closeButton = new System.Windows.Forms.Button();
            this.HideButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CurrentUC
            // 
            this.CurrentUC.Location = new System.Drawing.Point(26, 35);
            this.CurrentUC.Name = "CurrentUC";
            this.CurrentUC.Size = new System.Drawing.Size(1740, 903);
            this.CurrentUC.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Red;
            this.closeButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.closeButton.Location = new System.Drawing.Point(1744, 11);
            this.closeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(19, 14);
            this.closeButton.TabIndex = 6;
            this.closeButton.UseVisualStyleBackColor = false;
            // 
            // HideButton
            // 
            this.HideButton.BackColor = System.Drawing.Color.Green;
            this.HideButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.HideButton.Location = new System.Drawing.Point(1708, 11);
            this.HideButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HideButton.Name = "HideButton";
            this.HideButton.Size = new System.Drawing.Size(19, 14);
            this.HideButton.TabIndex = 5;
            this.HideButton.UseVisualStyleBackColor = false;
            // 
            // MainW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1800, 950);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.HideButton);
            this.Controls.Add(this.CurrentUC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainW";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facebook";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CurrentUC;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button HideButton;
    }
}