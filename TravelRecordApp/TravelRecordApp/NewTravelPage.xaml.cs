﻿using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Logic;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewTravelPage : ContentPage
	{
        NewTravelVM viewModel;
		public NewTravelPage ()
		{
			InitializeComponent ();

            viewModel = new NewTravelVM();
            BindingContext = viewModel;

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await DisplayAlert("Need Permission","We will have to access your location","Ok");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    if (results.ContainsKey(Permission.Location))
                        status = results[Permission.Location];
                }

                if (status == PermissionStatus.Granted)
                {
                    var locator = CrossGeolocator.Current;
                    var position = await locator.GetPositionAsync();

                    var venues = await Venue.GetVenues(position.Latitude, position.Longitude);
                    venueListView.ItemsSource = venues;
                }
                else
                {
                    await DisplayAlert("Need Permission", "We will have to access your location", "Ok");
                }
   
            }
            catch (Exception ex)
            {
            }
        }

        //private async void ToolbarItem_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {
                //var selectedVenue = venueListView.SelectedItem as Venue;
           
                /*using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<Post>();
                    int rows = conn.Insert(post);

                    if (rows > 0)
                        DisplayAlert("Success", "Experience successfully inserted", "OK");
                    else
                        DisplayAlert("Failure", "Experience failed to be inserted", "OK");
                }*/

                //await App.MobileService.GetTable<Post>().InsertAsync(post);
                //Post.Insert(post);
            //    await DisplayAlert("Success", "Experience successfully inserted", "OK");
            //}
            //catch (NullReferenceException nre)
            //{
            //    await DisplayAlert("Failure", "Experience failed to be inserted", "OK");
            //}
            //catch (Exception ex)
            //{
            //    await DisplayAlert("Failure", "Experience failed to be inserted", "OK");
            //}

        //}
    }
}