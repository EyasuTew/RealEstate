﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealEstate
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            


            if (File.Exists("token.txt"))
            {
                Console.WriteLine("File exists...");
                Application.Run(new Dashboard());
            }
            else
            {
                //this.Hide();
                //Signin signIn = new Signin();
                //signIn.Show();
                Application.Run(new Signin());

                //Console.WriteLine("File does not exist in the current directory!");
            }
        }
    }
}