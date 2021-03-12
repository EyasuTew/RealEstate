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
namespace RealEstate
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            UserEndPointClient userClient = new UserEndPointClient();
            userDto user = new userDto();
            user.id = 0;
            user.username = username.Text;
            user.password = password.Text;
            user.fname = firstname.Text;
            user.lname = lastname.Text;
            user.phone = phone.Text;
            user.email = email.Text;
            user.company = company.Text;
            user.status = true;
            user.createdat = new DateTime();
            responseDto res=userClient.createUser(user);
            if (res.status==true)
            {
                MessageBox.Show(res.message+"\n"+"You can login now", "Success",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                Signin signin = new Signin();
                signin.Show();
            }
            else
            {
                MessageBox.Show(res.message, "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
