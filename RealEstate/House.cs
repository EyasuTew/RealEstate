using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RealEstate.HousesEndpoint;
using System.IO;

namespace RealEstate
{
    public partial class House : Form
    {
        public static housesDto houseCurrentNow = null;
        public House()
        {
            InitializeComponent();
        }

        private void House_Load(object sender, EventArgs e)
        {
            housesDto houseCurrent = Dashboard.houseCurrent;
            houseCurrentNow = houseCurrent;
            if (houseCurrent == null)
            {

            }
            else
            {

                name.Text = houseCurrent.name;
                type.Text = houseCurrent.type;
                location.Text = houseCurrent.location;
                area.Text = houseCurrent.area.ToString();
                priceheactar.Text = houseCurrent.priceperhectar.ToString();
                totalprice.Text = houseCurrent.totalprice.ToString();
                for_.Text = houseCurrent.for_;
                finishing.Text = houseCurrent.finishing;
                company.Text = houseCurrent.company;

                finishing.Text = houseCurrent.finishing;
                finishing.Text = houseCurrent.finishing;
                if(houseCurrent.status==null || houseCurrent.status == false)
                {
                    status.Text = "Not Available";
                }
                else
                {
                    status.Text = "Available";
                }
                ImageConverter ic1 = new ImageConverter();
                Image img1;
                Bitmap bitmap1;
                //PictureBox picture = new PictureBox(); ;
                if (houseCurrent.photoone == null || houseCurrent.photoone.Length < 100)
                {
                    Console.WriteLine("hhhhhh");
                }
                else
                {
                    img1 = (Image)ic1.ConvertFrom(houseCurrent.photoone);
                    bitmap1 = new Bitmap(img1);
                    pictureBox1.Image = img1;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }


                ImageConverter ic2 = new ImageConverter();
                Image img2;
                Bitmap bitmap2;
                //PictureBox picture = new PictureBox(); ;
                if (houseCurrent.phototwo == null || houseCurrent.photoone.Length < 100)
                {
                    Console.WriteLine("hhhhhh");
                }
                else
                {
                    img2 = (Image)ic2.ConvertFrom(houseCurrent.phototwo);
                    bitmap2 = new Bitmap(img2);
                    pictureBox2.Image = img2;
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                }


                ImageConverter ic3 = new ImageConverter();
                Image img3;
                Bitmap bitmap3;
                //PictureBox picture = new PictureBox(); ;
                if (houseCurrent.photothree == null || houseCurrent.photoone.Length < 100)
                {
                    Console.WriteLine("hhhhhh");
                }
                else
                {
                    img3 = (Image)ic2.ConvertFrom(houseCurrent.photothree);
                    bitmap3 = new Bitmap(img3);
                    pictureBox3.Image = img3;
                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            //houseCurrentNow.id;
            string token = File.ReadAllText("token.txt");
            HousesEndpointClient h = new HousesEndpointClient();
            responseDto re=h.deleteHouse(houseCurrentNow.id, token);
            if (re.status == true)
            {
                DialogResult result = MessageBox.Show(
                                    re.message, "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                this.Hide();
                Dashboard dh = new Dashboard();
                dh.Show();
            }
            else
            {
                DialogResult result = MessageBox.Show(
                                    re.message, "Success", MessageBoxButtons.OKCancel, 
                                    MessageBoxIcon.Error);
            }
        }

        private void changestatus_Click(object sender, EventArgs e)
        {
            string token = File.ReadAllText("token.txt");
            HousesEndpointClient h = new HousesEndpointClient();
            responseDto re = h.changeHouseStatus(houseCurrentNow.id, token);
            if (re.status == true)
            {
                DialogResult result = MessageBox.Show(
                                    re.message, "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                this.Hide();
                Dashboard dh = new Dashboard();
                dh.Show();
            }
            else
            {
                DialogResult result = MessageBox.Show(
                                    re.message, "Success", MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string token = File.ReadAllText("token.txt");
            Bitmap twoB = new Bitmap(pictureBox2.ImageLocation);
            ImageConverter converter2 = new ImageConverter();
            byte[] two = (byte[])converter2.ConvertTo(twoB, typeof(byte[]));

            HousesEndpointClient hu = new HousesEndpointClient();
            responseDto re = hu.changeHousePhotoOne(houseCurrentNow.id, two, token);
            if (re.status == true)
            {
                DialogResult result = MessageBox.Show(
                                    re.message, "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                this.Hide();
                Dashboard dh = new Dashboard();
                dh.Show();
            }
            else
            {
                DialogResult result = MessageBox.Show(
                                    re.message, "Success", MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            String imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg|PNG files(*.png)|*.png| All Files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;

                    pictureBox1.ImageLocation = imageLocation;

                    //Console.Write(photo1.ImageLocation);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            String imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg|PNG files(*.png)|*.png| All Files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;

                    pictureBox2.ImageLocation = imageLocation;

                    //Console.Write(photo1.ImageLocation);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            String imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg|PNG files(*.png)|*.png| All Files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;

                    pictureBox2.ImageLocation = imageLocation;

                    //Console.Write(photo1.ImageLocation);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void change1_Click(object sender, EventArgs e)
        {
            string token = File.ReadAllText("token.txt");
            Bitmap oneB = new Bitmap(pictureBox1.ImageLocation);
            ImageConverter converter = new ImageConverter();
            byte[] one = (byte[])converter.ConvertTo(oneB, typeof(byte[]));
            //house.photoone = one;

            HousesEndpointClient hu = new HousesEndpointClient();
            responseDto re= hu.changeHousePhotoOne(houseCurrentNow.id,one,token);
            if (re.status == true)
            {
                DialogResult result = MessageBox.Show(
                                    re.message, "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                this.Hide();
                Dashboard dh = new Dashboard();
                dh.Show();
            }
            else
            {
                DialogResult result = MessageBox.Show(
                                    re.message, "Success", MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Error);
            }
        }

        private void change3_Click(object sender, EventArgs e)
        {
            string token = File.ReadAllText("token.txt");
            Bitmap threeB = new Bitmap(pictureBox3.ImageLocation);
            ImageConverter converter3 = new ImageConverter();
            byte[] three = (byte[])converter3.ConvertTo(threeB, typeof(byte[]));
            

            HousesEndpointClient hu = new HousesEndpointClient();
            responseDto re = hu.changeHousePhotoOne(houseCurrentNow.id, three, token);
            if (re.status == true)
            {
                DialogResult result = MessageBox.Show(
                                    re.message, "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                this.Hide();
                Dashboard dh = new Dashboard();
                dh.Show();
            }
            else
            {
                DialogResult result = MessageBox.Show(
                                    re.message, "Success", MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Error);
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dash = new Dashboard();
            dash.Show();
        }
    }
}
