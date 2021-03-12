using RealEstate.HousesEndpoint;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealEstate
{
    public partial class First : Form
    {
        public static housesDto houseCurrent = null;
        public First()
        {
            InitializeComponent();
        }

        private void First_Load(object sender, EventArgs e)
        {
            //string token = File.ReadAllText("token.txt");
            HousesEndpointClient houseClient = new HousesEndpointClient();
            paginationDto pag = new paginationDto();
            pag.start = 8;
            pag.max = 30;
            pag.count = 0;

            houseListResponseDto listHouse = houseClient.listAll(pag);
            if (listHouse.responseDto.status == false)
            {

            }
            else
            {
                int x = 10;
                int y = 0;
                int delta = 10;
                for (int i = 0; i < listHouse.paginationDto.count; i++)
                {
                    housesDto house = listHouse.housesDtoList[i];
                    ImageConverter ic = new ImageConverter();
                    Image img;
                    Bitmap bitmap1;
                    PictureBox picture = new PictureBox(); ;
                    if (listHouse.housesDtoList[i].photoone == null || listHouse.housesDtoList[i].photoone.Length < 100)
                    {
                        Console.WriteLine("hhhhhh");
                    }
                    else
                    {
                        img = (Image)ic.ConvertFrom(listHouse.housesDtoList[i].photoone);
                        bitmap1 = new Bitmap(img);

                        picture.Image = img;
                        picture.Location = new Point(x, y);
                        //picture.Size = new Size(picture.Image.Width, picture.Image.Height);
                        picture.Size = new Size(200, 100);
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                    }

                    int dx = 300 + delta;
                    // Create name label
                    var labelName = new Label();
                    labelName.AutoSize = true;
                    labelName.Location = new Point(x + dx, y);
                    labelName.Font = new Font(labelName.Font, FontStyle.Bold);
                    labelName.Text = listHouse.housesDtoList[i].name + " " + listHouse.housesDtoList[i].type;
                    // Create mail label
                    var labelMail = new Label();
                    labelMail.AutoSize = true;
                    labelMail.Location = new Point(x + dx, y + labelName.Height);
                    labelMail.Text = listHouse.housesDtoList[i].for_;
                    // Create phone label
                    var labelPhone = new Label();
                    labelPhone.AutoSize = true;
                    labelPhone.Location = new Point(x + dx, y + labelName.Height + labelMail.Height);
                    labelPhone.Text = listHouse.housesDtoList[i].location;
                    //
                    var btn = new Button();
                    btn.Text = "Detail";
                    btn.Name = "detail";
                    btn.Location = new Point(x + dx, y + labelName.Height + labelMail.Height);
                    btn.Click += (object s, EventArgs ee) =>
                    {
                        //
                        this.Hide();
                        houseCurrent = house;
                        HouseDetaile houseDetaile = new HouseDetaile();
                        houseDetaile.Show();
                        //MessageBox.Show(house.finishing, "Test",
                        //MessageBoxButtons.OK, MessageBoxIcon.Error);
                    };

                    // Add controls
                    panel1.Controls.Add(picture);
                    panel1.Controls.Add(labelName);
                    panel1.Controls.Add(labelMail);
                    //panel1.Controls.Add(labelPhone);
                    panel1.Controls.Add(btn);
                    // Iterate
                    int dy1 = labelName.Height + labelMail.Height + labelPhone.Height;
                    int dy2 = picture.Height;
                    y += Math.Max(dy1, dy2) + delta;
                }

            }
        }

        private void signIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Signin sign = new Signin();
            sign.Show();
        }
    }
}
