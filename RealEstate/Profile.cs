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
            Boolean vusername = false;
            if (string.IsNullOrWhiteSpace(username.Text) | username.Text.Length < 4)
            {
                vusername = false; username.Focus(); errorProvider1.SetError(username, "User name should contain at least four character.");
            }
            else
            {
                vusername = true; errorProvider1.SetError(username, "");
            }
            
            Boolean vfirstname = false;
            if (string.IsNullOrWhiteSpace(firstname.Text) | firstname.Text.Length < 3)
            {
                vfirstname = false; firstname.Focus(); errorProvider1.SetError(firstname, "First name should contain at least three character.");
            }
            else
            {
                vfirstname = true; errorProvider1.SetError(firstname, "");
            }
            Boolean vlastname = false;
            if (string.IsNullOrWhiteSpace(lastname.Text) | lastname.Text.Length < 3)
            {
                vlastname = false; lastname.Focus(); errorProvider1.SetError(lastname, "Last name should contain at least three character.");
            }
            else
            {
                vlastname = true; errorProvider1.SetError(lastname, "");
            }
            Boolean vphone = false;
            if (string.IsNullOrWhiteSpace(lastname.Text) | lastname.Text.Length < 3)
            {
                vphone = false; phone.Focus(); errorProvider1.SetError(phone, "Phone should contain ten number.");
            }
            else
            {
                vphone = true; errorProvider1.SetError(phone, "");
            }
            Boolean vemail = false;
            if (string.IsNullOrWhiteSpace(email.Text) | email.Text.Length < 3)
            {
                vemail = false; email.Focus(); errorProvider1.SetError(email,
                    "Email should follow email format.");
            }
            else
            {
                vemail = true; errorProvider1.SetError(email, "");
            }
            Boolean vcompany = false;
            if (string.IsNullOrWhiteSpace(company.Text) | company.Text.Length < 3)
            {
                vcompany = false; company.Focus(); errorProvider1.SetError(company,
                    "Company name should contain atleast two character.");
            }
            else
            {
                vcompany = true; errorProvider1.SetError(company, "");
            }

            if (vusername == true & vfirstname == true & vlastname == true & vphone == true &
                vemail == true & vcompany == true)
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
                string token = File.ReadAllText("token.txt");
                responseDto res = userClient.updateUser(user, token);
                if (res.status == true)
                {
                    MessageBox.Show(res.message , "Success",
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
            Boolean vpassword = false;
            if (string.IsNullOrWhiteSpace(password.Text) | password.Text.Length < 4)
            {
                vpassword = false; password.Focus(); errorProvider1.SetError(password, "New Password should contain at least four character.");
            }
            else
            {
                vpassword = true; errorProvider1.SetError(password, "");
            }
            Boolean vconfirmpassword = false;
            if (string.IsNullOrWhiteSpace(confirmpassword.Text) 
                | confirmpassword.Text.Length < 4 | !(confirmpassword.Text == password.Text))
            {
                vconfirmpassword = false; confirmpassword.Focus(); errorProvider1.SetError(confirmpassword, "Confirm password should be same with password and not empty.");
            }
            else
            {
                vconfirmpassword = true; errorProvider1.SetError(confirmpassword, "");
            }
            Boolean voldpassword = false;
            if (string.IsNullOrWhiteSpace(oldpassword.Text) | oldpassword.Text.Length < 4 )
            {
                voldpassword = false; oldpassword.Focus();
                errorProvider1.SetError(oldpassword, "Old password should contain at least four character.");
            }
            else
            {
                voldpassword = true; errorProvider1.SetError(oldpassword, "");
            }
            if (vpassword == true & vconfirmpassword == true & voldpassword == true)
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
}
