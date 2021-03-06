﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;

namespace TravelRecordApp
{
	public partial class MainPage : ContentPage
	{
        MainVM viewModel;
		public MainPage()
		{
			InitializeComponent();

            var assembly = typeof(MainPage);

            viewModel = new MainVM();
            BindingContext = viewModel;

            iconImage.Source = ImageSource.FromResource("TravelRecordApp.Assets.Images.plane.png", assembly);
		}

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            //bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            //bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

            //if (isEmailEmpty || isPasswordEmpty)
            //{
            //}
            //else
            //{
            //    var user = (await App.MobileService.GetTable<User>().Where(u => u.Email == emailEntry.Text).ToListAsync()).FirstOrDefault();

            //    if (user != null)
            //    {
            //        App.user = user;
            //        if (user.Password == passwordEntry.Text)
            //            await Navigation.PushAsync(new HomePage());
            //        else
            //            await DisplayAlert("Error", "Email or password are incorrect", "Ok");
            //    }
            //    else
            //    {
            //        await DisplayAlert("Error", "Email or password are incorrect", "Ok");
            //    }

            //}

            bool canLogin = await User.Login(emailEntry.Text, passwordEntry.Text);

            if (canLogin)
                await Navigation.PushAsync(new HomePage());
            else
                await DisplayAlert("Error", "Try again", "Ok");
        }

        //private void registerUserButton_Clicked(object sender, EventArgs e)
        //{
        //     Navigation.PushAsync(new RegisterPage());
            
        //}



    }
}
