namespace RealEstate
{
    partial class Admin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.home = new System.Windows.Forms.Button();
            this.signout = new System.Windows.Forms.Button();
            this.profile = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 483);
            this.panel1.TabIndex = 7;
            // 
            // home
            // 
            this.home.Location = new System.Drawing.Point(12, 12);
            this.home.Name = "home";
            this.home.Size = new System.Drawing.Size(75, 23);
            this.home.TabIndex = 8;
            this.home.Text = "Home";
            this.home.UseVisualStyleBackColor = true;
            this.home.Click += new System.EventHandler(this.home_Click);
            // 
            // signout
            // 
            this.signout.Location = new System.Drawing.Point(475, 12);
            this.signout.Name = "signout";
            this.signout.Size = new System.Drawing.Size(75, 23);
            this.signout.TabIndex = 9;
            this.signout.Text = "Sign out";
            this.signout.UseVisualStyleBackColor = true;
            this.signout.Click += new System.EventHandler(this.signout_Click);
            // 
            // profile
            // 
            this.profile.Location = new System.Drawing.Point(375, 12);
            this.profile.Name = "profile";
            this.profile.Size = new System.Drawing.Size(75, 23);
            this.profile.TabIndex = 10;
            this.profile.Text = "Profile";
            this.profile.UseVisualStyleBackColor = true;
            this.profile.Click += new System.EventHandler(this.profile_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label13.Location = new System.Drawing.Point(135, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(230, 31);
            this.label13.TabIndex = 28;
            this.label13.Text = "Admin Dashboard";
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 573);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.profile);
            this.Controls.Add(this.signout);
            this.Controls.Add(this.home);
            this.Controls.Add(this.panel1);
            this.Name = "Admin";
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.Admin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button home;
        private System.Windows.Forms.Button signout;
        private System.Windows.Forms.Button profile;
        private System.Windows.Forms.Label label13;
    }
}