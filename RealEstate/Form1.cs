using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealEstate
{
    public partial class Home : Form
    {
        public Home()
        {
            //InitializeComponent();
            if (File.Exists("token.txt"))
            {
                Console.WriteLine("File exists...");
            }
            else
            {
                this.Hide();
                Signin signIn = new Signin();
                signIn.Show();
                
                //Console.WriteLine("File does not exist in the current directory!");
            }
        }

        private void signIn_Click(object sender, EventArgs e)
        {

        }

        private void signIn_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Signin s = new Signin();
            s.Show();
        }
    }
}
