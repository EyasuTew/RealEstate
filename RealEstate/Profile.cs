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
    public partial class Profile : Form
    {
        public static userDto currentUserNow=null;
        public Profile()
        {
            InitializeComponent();
        }

        private void update_Click(object sender, EventArgs e)
        {

            UserEndPointClient userClient = new UserEndPointClient();
            userDto user = new userDto();
            user.id = currentUserNow.id;
            //user.username = username.Text;
            //user.password = password.Text;
            user.fname = firstname.Text;
            user.lname = lastname.Text;
            user.phone = phone.Text;
            user.email = email.Text;
            user.company = company.Text;
            //user.status = null;
            user.createdat = currentUserNow.createdat;
            responseDto res = userClient.updateUser(user,"token");
            if (res.status == true)
            {
                MessageBox.Show(res.message + "\n" + "You can login now", "Success",
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

        private void Profile_Load(object sender, EventArgs e)
        {
            //
            string token = File.ReadAllText("token.txt");
            UserEndPointClient userClient = new UserEndPointClient();
            userDto user=userClient.me(token);
            //userDto user = new userDto();
            if (user == null)
            {

            }
            else
            {
                currentUserNow = user;
                username.Text = currentUserNow.username;
                firstname.Text = currentUserNow.fname;
                lastname.Text = currentUserNow.lname;
                phone.Text = currentUserNow.phone;
                email.Text = currentUserNow.email;
                company.Text = currentUserNow.company;
                status.Text = currentUserNow.status.ToString();
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            Signin sign = new Signin();
            sign.Show();
        }

        private void changepassword_Click(object sender, EventArgs e)
        {
            string token = File.ReadAllText("token.txt");
            UserEndPointClient userClient = new UserEndPointClient();
            responseDto res = userClient.changePasswordUser(password.Text, token);
            if (res.status == true)
            {
                MessageBox.Show(res.message + "\n" + "Password changed, Login again", "Success",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
        
                File.Delete("token.txt");
                this.Close();
                Signin s = new Signin();
                s.Show();
            }
            else
            {
                MessageBox.Show(res.message, "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
