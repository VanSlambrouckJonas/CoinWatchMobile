using CoinWatch.Models;
using CoinWatch.Repositories;
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
    public partial class AssetListPage : ContentPage
    {
        private Login User = new Login();
        public AssetListPage(Login user)
        {
            InitializeComponent();
            LoadData(user);
            User = user;
        }

        private async void LoadData(Login user)
        {
            Login log = new Login();
            log.Email = user.Email;
            log.Name = user.Name;
            List<CustomAsset> info = await AssetRepository.GetAssets(user.Assets);

            lvwRegistrations.ItemsSource = info;
        }

        private void lvwRegistrations_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Debug.WriteLine("in selected");
            CustomAsset selected = lvwRegistrations.SelectedItem as CustomAsset;
            if (selected != null)
            {
                Debug.WriteLine("selected: " + selected.AssetName);
                Navigation.PushAsync(new DetailPage(selected));
                lvwRegistrations.SelectedItem = null;
            }
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            ToolbarItem item = (ToolbarItem)sender;
            Debug.WriteLine($"You clicked the \"{item.Text}\" toolbar item.");
            Navigation.PushAsync(new AddAssetPage(User));
        }
    }
}