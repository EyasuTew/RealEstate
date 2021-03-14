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

            try { 
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
            catch
            {
                MessageBox.Show("Unknown error", "Connection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Application.Run(new First());
            }
        }

        private void signIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Signin sign = new Signin();
            sign.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            HousesEndpointClient houseClient = new HousesEndpointClient();
            houseListResponseDto listHouse = houseClient.searchHousesByString(value.Text);
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







        public void getSearchByBetweenArea(searachBetweenAreaDto searchByArea)
        {
            panel1.Controls.Clear();
            HousesEndpointClient houseClient = new HousesEndpointClient();
            houseListResponseDto listHouse = houseClient.searchBetweenArea(searchByArea);
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

        private void button1_Click(object sender, EventArgs e)
        {
            searchBetweenPriceDto search = new searchBetweenPriceDto();
            search.from = "0";
            search.to = "1000000";
            this.getSearchByBetweenPrice(search);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            searachBetweenAreaDto search = new searachBetweenAreaDto();
            search.from = "0";
            search.to = "200";
            this.getSearchByBetweenArea(search);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            searachBetweenAreaDto search = new searachBetweenAreaDto();
            search.from = "200";
            search.to = "400";
            this.getSearchByBetweenArea(search);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            searachBetweenAreaDto search = new searachBetweenAreaDto();
            search.from = "400";
            search.to = "700";
            this.getSearchByBetweenArea(search);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            searachBetweenAreaDto search = new searachBetweenAreaDto();
            search.from = "700";
            search.to = "900";
            this.getSearchByBetweenArea(search);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            searachBetweenAreaDto search = new searachBetweenAreaDto();
            search.from = "900";
            search.to = "100000000000000";
            this.getSearchByBetweenArea(search);
        }


        public void getSearchByBetweenPrice(searchBetweenPriceDto searchByPrice)
        {
            panel1.Controls.Clear();
            HousesEndpointClient houseClient = new HousesEndpointClient();
            houseListResponseDto listHouse = houseClient.searchBetweenPrice(searchByPrice);
            //Console.WriteLine("COUNT "+listHouse.housesDtoList.Length.ToString());
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

        private void button2_Click(object sender, EventArgs e)
        {
            searchBetweenPriceDto search = new searchBetweenPriceDto();
            search.from = "1000000";
            search.to = "3000000";
            this.getSearchByBetweenPrice(search);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            searchBetweenPriceDto search = new searchBetweenPriceDto();
            search.from = "3000000";
            search.to = "6000000";
            this.getSearchByBetweenPrice(search);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            searchBetweenPriceDto search = new searchBetweenPriceDto();
            search.from = "6000000";
            search.to = "9000000";
            this.getSearchByBetweenPrice(search);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            searchBetweenPriceDto search = new searchBetweenPriceDto();
            search.from = "9000000";
            search.to = "1000000000000000";
            this.getSearchByBetweenPrice(search);
        }
    }
}
