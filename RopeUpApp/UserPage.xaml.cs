using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AwesomeApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "userData.txt");

            using (var reader = new StreamReader(filename))
            {
                user.Text = reader.ReadLine();
                pass.Text = reader.ReadLine();
                name.Text = reader.ReadLine();
                email.Text = reader.ReadLine();
                dob.Text = reader.ReadLine();
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "userData.txt");

            using(var reader = new StreamReader(filename))
            {
                text.Text = reader.ReadLine();
            }
        }
    }
}