using SQLite;
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
	public partial class HistoryPage : ContentPage
	{
        HistoryVM viewModel;
		public HistoryPage ()
		{
			InitializeComponent ();

            viewModel = new HistoryVM();
            BindingContext = viewModel;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{
            //    conn.CreateTable<Post>();
            //    var posts = conn.Table<Post>().ToList();
            //    postListView.ItemsSource = posts;
            //}

            //var posts = await App.MobileService.GetTable<Post>().Where(p => p.UserId == App.user.id).ToListAsync();

            //var posts = await Post.Read();
            //postListView.ItemsSource = posts;

            //viewModel.Posts.Clear(); // to keep on adding elements
            //var posts = await Post.Read();
            //foreach (var post in posts)
            //    viewModel.Posts.Add(post);

            viewModel.UpdatePosts();
        }
    }
}