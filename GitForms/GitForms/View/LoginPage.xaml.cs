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
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            btnLogin.Clicked += BtnLogin_Clicked;
            lbLoading.IsVisible = false;
        }

        async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            UserService service = new UserService();
            lbLoading.IsVisible = true;
            User user = await service.GetUser(eUsername.Text);
            App.Current.MainPage = new HomePage(user);
        }
    }
}