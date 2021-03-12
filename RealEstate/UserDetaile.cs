using RealEstate.UserEndPoint;
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
    public partial class UserDetaile : Form
    {
        public static userDto currentUserNow=null;
        public UserDetaile()
        {
            InitializeComponent();
        }

        private void UserDetaile_Load(object sender, EventArgs e)
        {
            currentUserNow = Admin.currentUser;
            username.Text = currentUserNow.username;
            firstname.Text = currentUserNow.fname;
            lastname.Text = currentUserNow.lname;
            phone.Text = currentUserNow.phone;
            email.Text = currentUserNow.email;
            company.Text = currentUserNow.company;
            status.Text = currentUserNow.status.ToString();
        }

        private void changestatus_Click(object sender, EventArgs e)
        {
            string token = File.ReadAllText("token.txt");
            UserEndPointClient userend = new UserEndPointClient();
            responseDto response = userend.activateUser(currentUserNow.id,token);
            if (response.status == true)
            {
                DialogResult rese = MessageBox.Show(response.message, "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                this.Close();
                Admin admin = new Admin();
                admin.Show();
            }
            else
            {
                DialogResult rese = MessageBox.Show(response.message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            string token = File.ReadAllText("token.txt");
            UserEndPointClient userend = new UserEndPointClient();
            responseDto response = userend.deactivateUser(currentUserNow.id, token);
            if (response.status == true)
            {
                
                DialogResult rese = MessageBox.Show(response.message, "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                this.Close();
                Admin admin = new Admin();
                admin.Show();
            }
            else
            {
                DialogResult rese = MessageBox.Show(response.message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            Admin admin = new Admin();
            admin.Show();
        }
    }
}
