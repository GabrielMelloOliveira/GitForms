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
	public partial class FollowersPage : ContentPage
	{
        List<User> ListFollowers = new List<User>();
        User user = new User();

        public FollowersPage (User user)
		{
			InitializeComponent ();
            this.user = user;
            lvFollowers.Refreshing += LvFollowers_Refreshing;
		}

        private async void LvFollowers_Refreshing(object sender, EventArgs e)
        {
            UserService service = new UserService();
            ListFollowers = await service.GetFollowers(user.login);
            lvFollowers.ItemsSource = null;
            lvFollowers.ItemsSource = ListFollowers;
            ((ListView)sender).IsRefreshing = false;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            UserService service = new UserService();
            lvFollowers.IsRefreshing = true;
            ListFollowers = await service.GetFollowers(user.login);
            lvFollowers.ItemsSource = ListFollowers;
            lvFollowers.IsRefreshing = false;
        }
    }
}