using GitForms.Service;
using GitHubLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GitForms.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FollowingPage : ContentPage
	{
        List<User> ListFollowing = new List<User>();
        User user = new User();

        public FollowingPage (User user)
		{
			InitializeComponent ();
            this.user = user;
            lvFollowing.Refreshing += LvFollowing_Refreshing;
		}

        private async void LvFollowing_Refreshing(object sender, EventArgs e)
        {
            UserService service = new UserService();
            ListFollowing = await service.GetFollowing(user.login);
            lvFollowing.ItemsSource = null;
            lvFollowing.ItemsSource = ListFollowing;
            ((ListView)sender).IsRefreshing = false;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            UserService service = new UserService();
            lvFollowing.IsRefreshing = true;
            ListFollowing = await service.GetFollowing(user.login);
            lvFollowing.ItemsSource = ListFollowing;
            lvFollowing.IsRefreshing = false;
        }
    }
}