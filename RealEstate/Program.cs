using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RealEstate.UserEndPoint;
namespace RealEstate
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            


            if (File.Exists("token.txt"))
            {
                string token = File.ReadAllText("token.txt");
                UserEndPointClient userClient = new UserEndPointClient();
                userDto user=userClient.me(token);
                if (user.type == "admin")
                {
                    Application.Run(new Admin());
                }
                else
                {
                    Application.Run(new Dashboard());
                }
                
            }
            else
            {
                //this.Hide();
                //Signin signIn = new Signin();
                //signIn.Show();
                Application.Run(new First());

                //Console.WriteLine("File does not exist in the current directory!");
            }
        }
    }
}
