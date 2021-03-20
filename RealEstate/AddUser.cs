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
            Boolean vusername = false;
            if (string.IsNullOrWhiteSpace(username.Text) | username.Text.Length < 4)
            {
                vusername = false; username.Focus(); errorProvider1.SetError(username, "User name should contain at least four character.");
            }
            else
            {
                vusername = true; errorProvider1.SetError(username, "");
            }
            Boolean vpassword = false;
            if (string.IsNullOrWhiteSpace(username.Text) | username.Text.Length < 4)
            {
                vpassword = false; password.Focus(); errorProvider1.SetError(password, "Password should contain at least four character.");
            }
            else
            {
                vpassword = true; errorProvider1.SetError(password, "");
            }
            Boolean vconfirmpassword = false;
            if (string.IsNullOrWhiteSpace(confirmpassword.Text) | 
                confirmpassword.Text.Length < 4 | 
                !(confirmpassword.Text == password.Text))
            {
                vconfirmpassword = false; confirmpassword.Focus(); errorProvider1.SetError(confirmpassword, "Confirm password should be same with password and empty.");
            }
            else
            {
                vconfirmpassword = true; errorProvider1.SetError(confirmpassword, "");
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


            if (vusername == true & vpassword == true & vfirstname == true & vlastname == true & vphone == true &
                vemail == true & vcompany == true & vconfirmpassword==true)
            {
                UserEndPointClient userClient = new UserEndPointClient();
                userDto user = new userDto();
                user.id = 0;
                user.username = username.Text;
                user.password = password.Text;
                Console.WriteLine("Password <===> "+password.Text);
                user.fname = firstname.Text;
                user.lname = lastname.Text;
                user.phone = phone.Text;
                user.email = email.Text;
                user.company = company.Text;
                user.status = true;
                user.createdat = new DateTime();
                responseDto res = userClient.createUser(user);
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
        }
    }
}
