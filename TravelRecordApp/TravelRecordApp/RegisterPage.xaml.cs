using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
        User user;
		public RegisterPage ()
		{
			InitializeComponent ();

            user = new User();
            containerStackLayout.BindingContext = user;

        }

        private async void registerButton_Clicked(object sender, EventArgs e)
        {
            if (passwordEntry.Text == confirmPasswordEntry.Text)
            {
                // We can register the user
           
                User.Register(user);
            }
            else
            {
                await DisplayAlert("Error", "Password don't match", "Ok");
            }
        }
    }
}