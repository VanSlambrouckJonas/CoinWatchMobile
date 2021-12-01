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
    public partial class AddAssetPage : ContentPage
    {
        public Login User = new Login();
        public List<string> assets = new List<string>();
        public AddAssetPage(Login user)
        {
            InitializeComponent();
            btnList.Clicked += BtnList_Clicked;
            Login UserNew = new Login();
            assets = user.Assets;
            User = user;
            User.Assets = assets;
        }

        private void BtnList_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(entCoin.Text))
            {
                User.Assets.Add(entCoin.Text);
                Debug.WriteLine("coin: " + entCoin.Text);
                Navigation.PushAsync(new AssetListPage(User));
            }

        }
    }
}