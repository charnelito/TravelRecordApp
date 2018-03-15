using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
        RegisterVM viewModel;
		public RegisterPage ()
		{
			InitializeComponent ();

            viewModel = new RegisterVM();
            BindingContext = viewModel;

        }

        //private async void registerButton_Clicked(object sender, EventArgs e)
        //{
        //    if (passwordEntry.Text == confirmPasswordEntry.Text)
        //    {
        //        // We can register the user
           
        //        User.Register(user);
        //    }
        //    else
        //    {
        //        await DisplayAlert("Error", "Password don't match", "Ok");
        //    }
        //}
    }
}