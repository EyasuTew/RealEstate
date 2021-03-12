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
namespace RealEstate
{
    public partial class House : Form
    {
        public House()
        {
            InitializeComponent();
        }

        private void House_Load(object sender, EventArgs e)
        {
            housesDto houseCurrent = Dashboard.houseCurrent;
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
    }
}
