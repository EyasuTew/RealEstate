namespace RealEstate
{
    partial class Signin
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
            this.signUp = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.userNameTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // signUp
            // 
            this.signUp.AutoSize = true;
            this.signUp.Location = new System.Drawing.Point(391, 201);
            this.signUp.Name = "signUp";
            this.signUp.Size = new System.Drawing.Size(45, 13);
            this.signUp.TabIndex = 7;
            this.signUp.TabStop = true;
            this.signUp.Text = "Sign Up";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(360, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Sign in";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(220, 116);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.PasswordChar = '.';
            this.passwordTB.Size = new System.Drawing.Size(216, 20);
            this.passwordTB.TabIndex = 5;
            // 
            // userNameTB
            // 
            this.userNameTB.Location = new System.Drawing.Point(220, 75);
            this.userNameTB.Name = "userNameTB";
            this.userNameTB.Size = new System.Drawing.Size(216, 20);
            this.userNameTB.TabIndex = 4;
            // 
            // Signin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 261);
            this.Controls.Add(this.signUp);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.userNameTB);
            this.Name = "Signin";
            this.Text = "Signin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel signUp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.TextBox userNameTB;
    }
}