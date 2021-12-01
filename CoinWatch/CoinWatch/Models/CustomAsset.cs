using System;
using System.Collections.Generic;
using System.Text;

namespace CoinWatch.Models
{
    public class CustomAsset
    {
        public string TickerName { get; set; }
        public string AssetName { get; set; }
        public string KrakenName { get; set; }
        public decimal Price { get; set; }
        public string StrPrice
        {
            get
            {
                return PriceFormat(Price);
            }
        }
        public decimal Volume { get; set; }
        public string StrVolume
        {
            get
            {
                return VolFormat(Volume);
            }
        }
        public decimal Opening { get; set; }
        public decimal Change
        {
            get
            {
                return Price - Opening;
            }
        }
        public string Change_percentage
        {
            get
            {
                return CalculateChange(Opening, Price);
            }
        }
        public List<int> Leverage { get; set; }
        public decimal MinOrder { get; set; }
        public string Color
        {
            get
            {
                if (Change > 0)
                {
                    return "#4CAF50";
                }
                else if (Change < 0)
                {
                    return "#FF5252";
                }
                else
                {
                    return "#B2B5BE";
                }

            }
        }

        string CalculateChange(decimal previous, decimal current)
        {
            if (previous == 0)
                throw new InvalidOperationException();

            var change = current - previous;
            return Math.Round((decimal)(change / previous) * 100, 2).ToString() + "%";
        }

        public static string VolFormat(decimal number)
        {
            if (number > 1000000)
                return Math.Round(number / 1000000, 4).ToString() + "M";
            else if (number > 1000)
                return Math.Round(number / 1000, 4).ToString() + "K";
            else
                return number.ToString();
        }

        public static string PriceFormat(decimal number)
        {
            if (number > 1000000)
                return "$" + Math.Round(number / 1000000, 4).ToString() + "M";
            else if (number > 1000)
                return "$" + Math.Round(number / 1000, 4).ToString() + "K";
            else
                return "$" + Math.Round(number, 5).ToString();
        }
    }
}
