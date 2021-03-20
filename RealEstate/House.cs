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
            try { 
            string token = File.ReadAllText("token.txt");
            Bitmap twoB = new Bitmap(pictureBox2.ImageLocation);
            ImageConverter converter2 = new ImageConverter();
            byte[] two = (byte[])converter2.ConvertTo(twoB, typeof(byte[]));

            HousesEndpointClient hu = new HousesEndpointClient();
            responseDto re = hu.changeHousePhotoTwo(houseCurrentNow.id, two, token);
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
            catch
            {
                DialogResult result = MessageBox.Show(
                                        "Unknown error", "Exception", MessageBoxButtons.OKCancel,
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
        
                    pictureBox3.ImageLocation = imageLocation;

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
            try
            {
                string token = File.ReadAllText("token.txt");
                Bitmap oneB = new Bitmap(pictureBox1.ImageLocation);
                ImageConverter converter = new ImageConverter();
                byte[] one = (byte[])converter.ConvertTo(oneB, typeof(byte[]));
                //house.photoone = one;

                HousesEndpointClient hu = new HousesEndpointClient();
                responseDto re = hu.changeHousePhotoOne(houseCurrentNow.id, one, token);
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
            catch
            {
                DialogResult result = MessageBox.Show(
                                        "Unknown error", "Exception", MessageBoxButtons.OKCancel,
                                        MessageBoxIcon.Error);
            }
        }

        private void change3_Click(object sender, EventArgs e)
        {
            try { 
                string token = File.ReadAllText("token.txt");
                Bitmap threeB = new Bitmap(pictureBox3.ImageLocation);
                ImageConverter converter3 = new ImageConverter();
                byte[] three = (byte[])converter3.ConvertTo(threeB, typeof(byte[]));
            

                HousesEndpointClient hu = new HousesEndpointClient();
                responseDto re = hu.changeHousePhotoThree(houseCurrentNow.id, three, token);
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
            catch
            {
                DialogResult result = MessageBox.Show(
                                        "Unknown error", "Exception", MessageBoxButtons.OKCancel,
                                        MessageBoxIcon.Error);
            }

        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dash = new Dashboard();
            dash.Show();
        }

        private void update_Click(object sender, EventArgs e)
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
            
            if (vname == true & vtype == true & vfor == true & vlocation == true & varea == true & vpriceperhectar == true
                & vtotalprice == true & vfinishing == true & vcompany == true )
            {
                string token = File.ReadAllText("token.txt");
                HousesEndpointClient houseClient = new HousesEndpointClient();
                housesUpdateRequestDto house = new housesUpdateRequestDto();
                house.name = name.Text;
                house.type = type.Text;
                house.for_ = for_.Text;
                house.location = location.Text;
                house.area = area.Text;
                house.priceperhectar = priceheactar.Text;
                house.totalprice = totalprice.Text;
                house.finishing = finishing.Text;
                house.id = houseCurrentNow.id;
                house.company = company.Text;
                Console.WriteLine(" house id == " + houseCurrentNow.id+" "+ house.id);
                responseDto response = houseClient.updateHouse(house, houseCurrentNow.id, token);
                if (response.status == true)
                {
                    DialogResult result = MessageBox.Show(
                        response.message, "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    //if (result == DialogResult.OK)
                    //{
                        this.Hide();
                        Dashboard userDb = new Dashboard();
                        userDb.Show();
                    //}
                    //else
                    //{

                    //    DialogResult res = MessageBox.Show(response.message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                    //}
                }
                else
                {
                    DialogResult result = MessageBox.Show(
                        response.message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }
    }
}
