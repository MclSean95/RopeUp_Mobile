using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AwesomeApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();
            
        }
        UserValidation validator = new UserValidation();
        private void SignUp_Clicked(object sender, EventArgs e)
        {
            if (IsValidUser())
            {
                WriteFile();
                Navigation.PushAsync(new UserPage());
            }
            else
                invalid.IsVisible = true;
        }

        private void WriteFile()
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "userData.txt");

            using (var writer = new StreamWriter(filename))
            {
                writer.WriteLine(user.Text);
                writer.WriteLine(pass.Text);
                writer.WriteLine(name.Text);
                writer.WriteLine(email.Text);
                writer.WriteLine(dob.Date.ToString());

            }

        }

        private bool IsValidUser()
        {
            if (validator.ValidateUsername(user.Text) &&
                validator.ValidatePassword(pass.Text, passValid.Text) &&
                validator.ValidateName(name.Text)&&
                validator.ValidateEmail(email.Text))
                return true;
            else
                return false;
        }
    }
}