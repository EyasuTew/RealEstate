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
using System.Text.RegularExpressions;

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
            Boolean vname = false;
            if (string.IsNullOrWhiteSpace(name.Text) | name.Text.Length < 4)
            {
                vname = false; name.Focus(); errorProvider1.SetError(name, "Name should contain at least four character.");
            }
            else
            {
                vname = true; errorProvider1.SetError(name, "");
            }

            Boolean vtype = false;
            if (string.IsNullOrWhiteSpace(type.Text) | type.Text.Length < 3)
            {
                vtype = false; type.Focus(); errorProvider1.SetError(type, "Type should be selected.");
            }
            else
            {
                vtype = true; errorProvider1.SetError(type, "");
            }

            Boolean vfor = false;
            if (string.IsNullOrWhiteSpace(for_.Text) | for_.Text.Length < 3)
            {
                vfor = false; type.Focus(); errorProvider1.SetError(for_, "Type should be selected.");
            }
            else
            {
                vfor = true; errorProvider1.SetError(for_, "");
            }
            Boolean vlocation = false;
            if (string.IsNullOrWhiteSpace(location.Text) | location.Text.Length < 4)
            {
                vlocation = false; location.Focus(); errorProvider1.SetError(location, "Loation should contain at least four character.");
            }
            else
            {
                vlocation = true; errorProvider1.SetError(location, "");
            }
            Boolean varea = false;
            if (string.IsNullOrWhiteSpace(area.Text) | !Regex.IsMatch(totalprice.Text, @"[0-9]{1,20}"))
            {
                varea = false; location.Focus(); errorProvider1.SetError(area,
                    "Area should be number.");
            }
            else
            {
                varea = true; errorProvider1.SetError(area, "");
            }
            Boolean vpriceperhectar = false;
            if (string.IsNullOrWhiteSpace(priceheactar.Text) | !Regex.IsMatch(totalprice.Text, @"[0-9]{1,20}"))
            {
                vpriceperhectar = false; location.Focus(); errorProvider1.SetError(priceheactar,
                    "Price per hectar should be number.");
            }
            else
            {
                vpriceperhectar = true; errorProvider1.SetError(priceheactar, "");
            }

            Boolean vtotalprice = false;
            if (string.IsNullOrWhiteSpace(totalprice.Text) | !Regex.IsMatch(totalprice.Text, @"[0-9]{1,20}"))
            {
                vtotalprice = false; totalprice.Focus(); errorProvider1.SetError(totalprice,
                    "Total price should be number.");
            }
            else
            {
                vtotalprice = true; errorProvider1.SetError(totalprice, "");
            }
            Boolean vfinishing = false;
            if (string.IsNullOrWhiteSpace(finishing.Text) | finishing.Text.Length < 2)
            {
                vfinishing = false; type.Focus(); errorProvider1.SetError(finishing, "Finishing should be selected.");
            }
            else
            {
                vfinishing = true; errorProvider1.SetError(finishing, "");
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

            Boolean vpictureBox1 = false;
            if (string.IsNullOrWhiteSpace(pictureBox1.ImageLocation))
            {
                vpictureBox1 = false; pictureBox1.Focus(); errorProvider1.SetError(pictureBox1,
                    "Photo one should not be empty");
            }
            else
            {
                vpictureBox1 = true; errorProvider1.SetError(pictureBox1, "");
            }
            Boolean vpictureBox2 = false;
            if (string.IsNullOrWhiteSpace(pictureBox2.ImageLocation))
            {
                vpictureBox2 = false; pictureBox2.Focus(); errorProvider1.SetError(pictureBox2,
                    "Photo two should not be empty");
            }
            else
            {
                vpictureBox2 = true; errorProvider1.SetError(pictureBox2, "");
            }
            Boolean vpictureBox3 = false;
            if (string.IsNullOrWhiteSpace(pictureBox3.ImageLocation))
            {
                vpictureBox3 = false; pictureBox3.Focus(); errorProvider1.SetError(pictureBox3,
                    "Photo three should not be empty");
            }
            else
            {
                vpictureBox3 = true; errorProvider1.SetError(pictureBox3, "");
            }

            if (vname == true & vtype == true & vfor == true & vlocation == true & varea == true & vpriceperhectar == true
                & vtotalprice == true & vfinishing == true & vcompany == true & vpictureBox3==true & vpictureBox2==true
                & vpictureBox1==true)
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

                Bitmap twoB = new Bitmap(pictureBox2.ImageLocation);
                ImageConverter converter2 = new ImageConverter();
                byte[] two = (byte[])converter2.ConvertTo(twoB, typeof(byte[]));
                house.phototwo = two;

                Bitmap threeB = new Bitmap(pictureBox3.ImageLocation);
                ImageConverter converter3 = new ImageConverter();
                byte[] three = (byte[])converter3.ConvertTo(threeB, typeof(byte[]));
                house.photothree = three;

                responseDto response = houseClient.createHouse(house, token);
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

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
            Dashboard dash = new Dashboard();
            dash.Show();
        }
    }
}
