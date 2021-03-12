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
    public partial class Admin : Form
    {
        public static UserEndPoint.userDto currentUser = null;
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            string token = File.ReadAllText("token.txt");
            UserEndPointClient userClient= new UserEndPointClient();
            paginationDto pag = new paginationDto();
            pag.start = 8;
            pag.max = 30;
            pag.count = 0;

            userListResponseDto listUser = userClient.listUser(pag,token);
            if (listUser.responseDto.status == false)
            {

            }
            else
            {
                int x = 10;
                int y = 5;
                int delta = 10;
                int dx = 0 + delta;
                // Create name label
                var labelName1 = new Label();
                labelName1.AutoSize = true;
                labelName1.Location = new Point(x + dx, y);
                labelName1.Font = new Font(labelName1.Font, FontStyle.Bold);
                labelName1.Text = "Username";
                // Create mail label
                var labelMail1 = new Label();
                labelMail1.AutoSize = true;
                labelMail1.Location = new Point(x + dx + labelName1.Width, y);
                labelMail1.Font = new Font(labelMail1.Font, FontStyle.Bold);
                labelMail1.Text = "Type";
                // Create phone label
                var labelPhone1 = new Label();
                labelPhone1.AutoSize = true;
                labelPhone1.Location = new Point(x + dx + labelName1.Width + labelMail1.Width, y);
                labelPhone1.Font = new Font(labelPhone1.Font, FontStyle.Bold);
                labelPhone1.Text = "Status";

                panel1.Controls.Add(labelName1);
                panel1.Controls.Add(labelMail1);
                panel1.Controls.Add(labelPhone1);
                // Iterate
                int dy1 = x + labelName1.Height;// + labelMail.Height + labelPhone.Height;
                int dy2 = x + labelName1.Height;//picture.Height;
                y += Math.Max(dy1, dy2) + delta;












                for (int i = 0; i < listUser.paginationDto.count; i++)
                {
                    userDto user = listUser.userDtoList[i];
                    dx = 0 + delta;
                    // Create name label
                    var labelName = new Label();
                    labelName.AutoSize = true;
                    labelName.Location = new Point(x + dx, y);
                    //labelName.Font = new Font(labelName.Font, FontStyle.Bold);
                    labelName.Text = listUser.userDtoList[i].username;
                    // Create mail label
                    var labelMail = new Label();
                    labelMail.AutoSize = true;
                    labelMail.Location = new Point(x + dx + labelName.Width,y);
                    labelMail.Text = listUser.userDtoList[i].type;
                    // Create phone label
                    var labelPhone = new Label();
                    labelPhone.AutoSize = true;
                    labelPhone.Location = new Point(x + dx+ labelName.Width + labelMail.Width, y);
                    labelPhone.Text = listUser.userDtoList[i].status.ToString();
                    //
                    var btn = new Button();
                    btn.Text = "Detail";
                    btn.Name = "detail";
                    btn.Location = new Point(x + dx+ labelName.Width + labelMail.Width  + labelMail.Width,y);
                    btn.Click += (object s, EventArgs ee) =>
                    {
                        this.Hide();
                        currentUser = user;
                        UserDetaile userDetaile = new UserDetaile();
                        userDetaile.Show();
                    };
                    panel1.Controls.Add(labelName);
                    panel1.Controls.Add(labelMail);
                    panel1.Controls.Add(labelPhone);
                    panel1.Controls.Add(btn);
                    // Iterate
                    dy1 = x + labelName.Height;// + labelMail.Height + labelPhone.Height;
                    dy2 = x + labelName.Height;//picture.Height;
                    y += Math.Max(dy1, dy2) + delta;
                }

            }
        }

        private void signout_Click(object sender, EventArgs e)
        {
            File.Delete("token.txt");
            this.Hide();
            Signin sign = new Signin();
            sign.Show();
        }

        private void home_Click(object sender, EventArgs e)
        {
            this.Hide();
            First first = new First();
            first.Show();
        }

        private void profile_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profile pr = new Profile();
            pr.Show();
        }
    }
}
