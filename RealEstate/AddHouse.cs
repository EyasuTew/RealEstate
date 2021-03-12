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
    public partial class AddHouse : Form
    {
        public AddHouse()
        {
            InitializeComponent();
            
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

                    pictureBox3.ImageLocation = imageLocation;

                    //Console.Write(photo1.ImageLocation);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            string token = File.ReadAllText("token.txt");
            HousesEndpointClient houseClient = new HousesEndpointClient();
            housesRequestDto house = new housesRequestDto();
            house.name = name.Text;
            house.type = type.Text;
            house.for_ = for_.Text;
            house.location = location.Text;
            house.area = area.Text;
            house.priceperhectar = priceheactar.Text;
            house.totalprice = totalprice.Text;
            house.finishing = finishing.Text;
            house.status = true;
            house.id = 0;
            house.company = company.Text;

            Bitmap oneB = new Bitmap(pictureBox1.ImageLocation);
            ImageConverter converter = new ImageConverter();
            byte[] one = (byte[])converter.ConvertTo(oneB, typeof(byte[]));
            house.photoone = one;

            Bitmap twoB = new Bitmap(pictureBox3.ImageLocation);
            ImageConverter converter2 = new ImageConverter();
            byte[] two = (byte[])converter2.ConvertTo(twoB, typeof(byte[]));
            house.phototwo = two;

            Bitmap threeB = new Bitmap(pictureBox3.ImageLocation);
            ImageConverter converter3 = new ImageConverter();
            byte[] three = (byte[])converter3.ConvertTo(threeB, typeof(byte[]));
            house.photothree = three;

            responseDto response=houseClient.createHouse(house, token);
            if (response.status == true)
            {
                DialogResult result = MessageBox.Show(
                    response.message, "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    this.Hide();
                    Dashboard userDb = new Dashboard();
                    userDb.Show();
                }
                else
                {

                    DialogResult res = MessageBox.Show(response.message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                    //if (result == DialogResult.Cancel)
                    //{
                    //    this.Close();
                    //}
                }
            }

        }
    }
}
