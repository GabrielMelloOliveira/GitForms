using GitForms.Service;
using GitHubLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GitForms.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReposPage : ContentPage
	{
        List<Repos> ListRepos = new List<Repos>();
        User user = new User();

		public ReposPage (User user)
		{
			InitializeComponent();
            this.user = user;
            lvRepos.Refreshing += LvRepos_Refreshing;
        }

        private async void LvRepos_Refreshing(object sender, EventArgs e)
        {
            ReposService service = new ReposService();
            ListRepos = await service.GetRepos(user.login);
            lvRepos.ItemsSource = null;
            lvRepos.ItemsSource = ListRepos;
            ((ListView)sender).IsRefreshing = false;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            ReposService service = new ReposService();
            lvRepos.IsRefreshing = true;
            ListRepos = await service.GetRepos(user.login);
            lvRepos.ItemsSource = ListRepos;
            lvRepos.IsRefreshing = false;
        }
    }
}