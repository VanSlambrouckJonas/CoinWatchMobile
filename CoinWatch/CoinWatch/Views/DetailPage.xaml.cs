using CoinWatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoinWatch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public CustomAsset Asset { get; set; }
        public DetailPage(CustomAsset asset)
        {
            InitializeComponent();
            this.Asset = asset;
            lblChange_percentage.Text = asset.Change_percentage;
            lblChange_percentage.TextColor = Color.FromHex(asset.Color);
            lblKrakenName.Text = asset.KrakenName;
            lblOpening.Text = asset.Opening.ToString();
            lblStrPrice.Text = asset.StrPrice;
            lblStrVolume.Text = asset.StrVolume;
            lblTickerName.Text = asset.TickerName;
            lblMinOrder.Text = asset.MinOrder.ToString() + "ADA";
            if (asset.Leverage.Count > 0)
            {
                lblLeverage.Text = asset.Leverage.Last().ToString() + asset.TickerName;
            }
            else
            {
                lblLeverage.Text = "not available";
            }
        }
    }
}