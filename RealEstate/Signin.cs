using System;
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
                File.WriteAllText("token.txt", response.token);
                Console.WriteLine("TOKEN  " + File.ReadAllText("token.txt"));
                //this.Hide();
                //UserDashBoard userDb = new UserDashBoard();
                //userDb.Show();
            }
        }
    }
}
