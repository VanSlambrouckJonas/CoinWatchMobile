using CoinWatch.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoinWatch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            btnLogin.Clicked += BtnLogin_Clicked;
            entEmail.Text = "jonas@gmail.com";
            entUser.Text = "Jonas";
        }

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(entEmail.Text) && !string.IsNullOrEmpty(entUser.Text))
            {
                Login user = new Login();
                user.Name = entUser.Text;
                user.Email = entEmail.Text;
                Debug.WriteLine("user: " + user.Name + "     email: " + user.Email);
                Navigation.PushAsync(new AssetListPage(user));
            }

        }
    }
}