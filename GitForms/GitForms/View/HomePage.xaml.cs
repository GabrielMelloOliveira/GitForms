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
	public partial class HomePage : MasterDetailPage
	{
        public User UserLogged { get; set; }

        public HomePage (User user)
		{
			InitializeComponent ();

            UserLogged = user;
            this.BindingContext = user;

            btnRepos.Clicked += BtnRepos_Clicked;
            btnFollowers.Clicked += BtnFollowers_Clicked;
            btnFollowing.Clicked += BtnFollowing_Clicked;

            InfoMenu();

            Detail = new NavigationPage(new ReposPage(UserLogged) { Title = "Meus Repositórios" }) { Title = "Meus Repositórios", BarBackgroundColor = Color.Black, BarTextColor = Color.White };
        }

        private void InfoMenu()
        {
            lbLogin.Text = UserLogged.login;
        }

        private void BtnFollowing_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new FollowingPage(UserLogged) { Title = "Seguindo" }) { Title = "Seguindo", BarBackgroundColor = Color.Black, BarTextColor = Color.White };
            IsPresented = false;
        }

        private void BtnFollowers_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new FollowersPage(UserLogged) { Title = "Seguidores" }) { Title = "Seguidores", BarBackgroundColor = Color.Black, BarTextColor = Color.White };
            IsPresented = false;
        }

        private void BtnRepos_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ReposPage(UserLogged) { Title = "Meus Repositórios" }) { Title = "Meus Repositórios", BarBackgroundColor = Color.Black, BarTextColor = Color.White };
            IsPresented = false;
        }
    }
}