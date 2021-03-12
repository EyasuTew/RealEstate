﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RealEstate.UserEndPoint;
using System.IO;

namespace RealEstate
{
    public partial class Signin : Form
    {
        public Signin()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserEndPointClient userEpc = new UserEndPointClient();
            authDto authdto = new authDto();

            authdto.username = userNameTB.Text;
            authdto.password = passwordTB.Text;
            authResponseDto response = userEpc.auth(authdto);
        
            Console.WriteLine(response.token);
            if (response.status == false)
            {
                MessageBox.Show(response.message, "Signin error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (response.type == "admin")
                {
                    File.WriteAllText("token.txt", response.token);
                    this.Hide();
                    Admin ad = new Admin();
                    ad.Show();
                }
                else
                {
                    File.WriteAllText("token.txt", response.token);
                    Console.WriteLine("TOKEN  " + File.ReadAllText("token.txt"));
                    this.Hide();
                    Dashboard userDb = new Dashboard();
                    userDb.Show();
                }
            }
        }

        private void Signin_Load(object sender, EventArgs e)
        {
            if (File.Exists("token.txt"))
            {
                this.Close();
                Dashboard dash = new Dashboard();
                dash.Show();
                //this.Hide();
                //Console.WriteLine("File exists...");
                //Application.Run(new Dashboard());
            }
            else
            {
                //this.Hide();
                //Signin signIn = new Signin();
                //signIn.Show();
                //Application.Run(new First());

                //Console.WriteLine("File does not exist in the current directory!");
            }
        }

        private void signUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            AddUser adduser = new AddUser();
            adduser.Show();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            First first = new First();
            first.Show();
        }
    }
}
