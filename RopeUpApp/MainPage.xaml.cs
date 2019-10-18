using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using System.Reflection;

namespace AwesomeApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent(); 
        }

        List<string> loginInfo = new List<string>();
        int count = 0;
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            count++;
            ((Button)sender).Text = $"You clicked {count} times.";
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            ReadFile();
            foreach (string s in loginInfo)
            {
                string temp = "Username: " + user.Text + " " + pass.Text;
                 if (s == temp)
                    Navigation.PushAsync(new UserPage());
                else
                {
                    invalid.IsVisible = true;
                    pass.Text = "";
                }
            }
        }

        private void SignUp_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUp());
        }

        private void ReadFile()
        {
            
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof (MainPage)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("AwesomeApp.TempDB.txt");
            
            using (var reader = new System.IO.StreamReader(stream))
            {
                loginInfo.Add(reader.ReadLine());
            }
        }
    }
}
